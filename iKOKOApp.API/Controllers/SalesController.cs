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
    public class SalesController : ControllerBase
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly ILogger<SalesController> _logger;

        public SalesController(IUnitOfWork unitOfWork, ILogger<SalesController> logger)
        {
            _unitOfWork = unitOfWork;
            _logger = logger;
        }

        // GET: api/Sales
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Sale>>> GetSales() => 
            await _unitOfWork.SaleRepository.GetAllAsync();

        // GET: api/Sales/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Sale>> GetSale(Guid id)
        {
            //var sale = await _context.Sales.FindAsync(id);
            var sale = await _unitOfWork.SaleRepository.GetAsync(id);

            if (sale == null)
            {
                _logger.LogDebug("Sale don't found.");
                return NotFound();
            }

            return sale;
        }

        // PUT: api/Sales/5
        [HttpPut("{id}")]
        public async Task<IActionResult> Put(Guid id, Sale sale)
        {
            if (id != sale.Id && !ModelState.IsValid)
            {
                return BadRequest();
            }

            _unitOfWork.SaleRepository.Update(sale);
            try
            {
                await _unitOfWork.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException ex)
            {
                if (!Exists(id))
                {
                    _logger.LogError($"Update function error: Sale don't exist.");
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

        // POST: api/Sales
        [HttpPost]
        public async Task<ActionResult<Sale>> Post(Sale sale)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }
            await _unitOfWork.SaleRepository.AddAsync(sale);
            await _unitOfWork.SaveChangesAsync();

            return CreatedAtAction("GetSale", new { id = sale.Id }, sale);
        }

        // DELETE: api/Sales/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(Guid id)
        {
            var Sale = await _unitOfWork.SaleRepository.DeleteAsync(id);
            if (Sale == null)
            {
                _logger.LogDebug(" Sale don't found.");
                return NotFound();
            }

            await _unitOfWork.SaveChangesAsync();

            return NoContent();
        }

        private bool Exists(Guid id) => 
            _unitOfWork.SaleRepository.GetAsync(id).Result != null;
        
        // POST api/<Sale>
        //[HttpPost]
        //public IActionResult Post()
        //{
        //    var sale = new Sale
        //    {
        //    };

        //    _unitOfWork.SaleRepository.AddAsync(sale);
        //    _unitOfWork.SaveChangesAsync();
        //    _logger.LogDebug("Sale added successful!");
        //    return Ok();
        //}
    }
}
