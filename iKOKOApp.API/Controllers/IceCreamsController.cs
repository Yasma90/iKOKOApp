using iKOKO.Domain.Models;
using iKOKO.Persistence.UnitOfWork;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace iKOKO.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class IceCreamsController : ControllerBase
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly ILogger<IceCreamsController> _logger;

        public IceCreamsController(IUnitOfWork unitOfWork, ILogger<IceCreamsController> logger)
        {
            _unitOfWork = unitOfWork;
            _logger = logger;
        }

        // GET: api/IceCreams
        [HttpGet]
        public async Task<ActionResult<IEnumerable<IceCream>>> GetIceCreams()=> 
            await _unitOfWork.IceCreamRepository.GetAllAsync();
        
        // GET: api/IceCreams/5
        [HttpGet("{id}")]
        public async Task<ActionResult<IceCream>> GetIceCream(Guid id)
        {
            //var iceCream = await _context.IceCreams.FindAsync(id);
            var iceCream = await _unitOfWork.IceCreamRepository.GetAsync(id);

            if (iceCream == null)
            {
                _logger.LogDebug("IceCream don't found.");
                return NotFound();
            }

            return iceCream;
        }

        // PUT: api/IceCreams/5
        [HttpPut("{id}")]
        public async Task<IActionResult> Put(Guid id, IceCream iceCream)
        {
            if (id != iceCream.Id && !ModelState.IsValid)
            {
                return BadRequest();
            }

            _unitOfWork.IceCreamRepository.Update(iceCream);
            try
            {
                await _unitOfWork.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException ex)
            {
                if (!Exists(id))
                {
                    _logger.LogError($"Update function error: IceCream don't exist.");
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

        // POST: api/IceCreams
        [HttpPost]
        public async Task<ActionResult<IceCream>> Post(IceCream iceCream)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }
            await _unitOfWork.IceCreamRepository.AddAsync(iceCream);
            await _unitOfWork.SaveChangesAsync();

            return CreatedAtAction("GetIceCream", new { id = iceCream.Id }, iceCream);
        }

        // DELETE: api/IceCreams/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(Guid id)
        {
            var iceCream = await _unitOfWork.IceCreamRepository.DeleteAsync(id);
            if (iceCream == null)
            {
                _logger.LogDebug(" IceCream don't found.");
                return NotFound();
            }

            await _unitOfWork.SaveChangesAsync();

            return NoContent();
        }

        private bool Exists(Guid id) =>
            _unitOfWork.IceCreamRepository.GetAsync(id).Result != null;
        
    }
}
