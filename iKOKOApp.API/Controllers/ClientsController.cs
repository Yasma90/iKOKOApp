using System;
using System.Linq;
using System.Threading.Tasks;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using iKOKO.Domain.Models;
using iKOKO.Persistence.UnitOfWork;

namespace iKOKO.API.Controllers
{
     [Route("api/[controller]")]
    [ApiController]
    public class ClientsController : ControllerBase
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly ILogger<ClientsController> _logger;

        public ClientsController(IUnitOfWork unitOfWork, ILogger<ClientsController> logger)
        {
            _unitOfWork = unitOfWork;
            _logger = logger;
        }

        // GET: api/Clients
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Client>>> GetClients() => await _unitOfWork.ClientRepository.GetAllAsync();

        // GET: api/Clients/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Client>> GetClient(Guid id)
        {
            //var client = await _context.Clients.FindAsync(id);
            var client = await _unitOfWork.ClientRepository.GetAsync(id);

            if (client == null)
            {
                _logger.LogDebug("Client don't found.");
                return NotFound();
            }

            return client;
        }

        // PUT: api/Clients/5
        [HttpPut("{id}")]
        public async Task<IActionResult> Put(Guid id, Client client)
        {
            if (id != client.Id && !ModelState.IsValid)
            {
                return BadRequest();
            }

            _unitOfWork.ClientRepository.Update(client);
            try
            {
                await _unitOfWork.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException ex)
            {
                if (!Exists(id))
                {
                    _logger.LogError($"Update function error: Client don't exist.");
                    return NotFound();
                }
                else
                {
                    _logger.LogError($"Update function error: {ex.Message}");
                    throw;
                }
            }

            return NoContent();
        }

        // POST: api/Clients
        [HttpPost]
        public async Task<ActionResult<Client>> Post(Client Client)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }
            await _unitOfWork.ClientRepository.AddAsync(Client);
            await _unitOfWork.SaveChangesAsync();

            return CreatedAtAction("GetClient", new { id = Client.Id }, Client);
        }

        // DELETE: api/Clients/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(Guid id)
        {
            var client = await _unitOfWork.ClientRepository.DeleteAsync(id);
            if (client == null)
            {
                _logger.LogDebug(" Client don't found.");
                return NotFound();
            }

            await _unitOfWork.SaveChangesAsync();

            return NoContent();
        }

        private bool Exists(Guid id)
        {
            return _unitOfWork.ClientRepository.GetAsync(id).Result != null;
        } 

    }
}
