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
    public class WarehousesController : ControllerBase
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly ILogger<WarehousesController> _logger;

        public WarehousesController(IUnitOfWork unitOfWork, ILogger<WarehousesController> logger)
        {
            _unitOfWork = unitOfWork;
            _logger = logger;
        }

        // GET: api/Warehouses
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Warehouse>>> GetWarehouses() =>
            await _unitOfWork.WarehouseRepository.GetAllAsync();

        // GET: api/Warehouses/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Warehouse>> GetWarehouse(Guid id)
        {
            var warehouse = await _unitOfWork.WarehouseRepository.GetAsync(id);

            if (warehouse == null)
            {
                _logger.LogDebug("Warehouse don't found.");
                return NotFound();
            }

            return warehouse;
        }

        // PUT: api/Warehouses/5
        [HttpPut("{id}")]
        public async Task<IActionResult> Put(Guid id, Warehouse warehouse)
        {
            if (id != warehouse.Id && !ModelState.IsValid)
            {
                return BadRequest();
            }

            _unitOfWork.WarehouseRepository.Update(warehouse);
            try
            {
                await _unitOfWork.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException ex)
            {
                if (!Exists(id))
                {
                    _logger.LogError($"Update function error: Warehouse don't exist.");
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

        // POST: api/Warehouses
        [HttpPost]
        public async Task<ActionResult<Warehouse>> Post(Warehouse warehouse)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }
            await _unitOfWork.WarehouseRepository.AddAsync(warehouse);
            await _unitOfWork.SaveChangesAsync();

            return CreatedAtAction("GetWarehouse", new { id = warehouse.Id }, warehouse);
        }

        // DELETE: api/Warehouses/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(Guid id)
        {
            var warehouse = await _unitOfWork.WarehouseRepository.DeleteAsync(id);
            if (warehouse == null)
            {
                _logger.LogDebug(" Warehouse don't found.");
                return NotFound();
            }

            await _unitOfWork.SaveChangesAsync();

            return NoContent();
        }

        private bool Exists(Guid id) =>
            _unitOfWork.WarehouseRepository.GetAsync(id).Result != null;

    }
}
