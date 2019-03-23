using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using VEGA.Controllers.Resources;
using VEGA.Models;
using VEGA.Persistance;

namespace VEGA.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class VehiclesController : ControllerBase
    {
        private readonly IVehicleRepository _vehicleRepository;
        private readonly IUnitOfWork _uow;
        private readonly IMapper _mapper;

        public VehiclesController(IVehicleRepository vehicleRepository ,IUnitOfWork uow, IMapper mapper)
        {
            _vehicleRepository = vehicleRepository;
            _uow = uow;
            _mapper = mapper;
        }

        // GET: api/Vehicle
        [HttpGet]
        public async Task<IEnumerable<VehicleResource>> GetVehicles()
        {
            var result = await _vehicleRepository.GetVehicles(includeRelated:true);

            return _mapper.Map<List<Vehicle>, List<VehicleResource>>(result);
        }

        // GET: api/Vehicle/5
        [HttpGet("{id}")]
        public async Task<IActionResult> GetVehicle([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var vehicle = await _vehicleRepository.GetVehicle(id);

            if (vehicle == null)
            {
                return NotFound();
            }

            var result = _mapper.Map<Vehicle, VehicleResource>(vehicle);
            return Ok(result);
        }

        // PUT: api/Vehicle/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutVehicle([FromRoute] int id, [FromBody] SaveVehicleResource saveVehicleResource)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != saveVehicleResource.Id)
            {
                return BadRequest();
            }

            var vehicle = await _vehicleRepository.GetVehicle(id);

            if (vehicle == null)
            {
                return NotFound();
            }

            _mapper.Map<SaveVehicleResource, Vehicle>(saveVehicleResource, vehicle);
            vehicle.LastUpdate = DateTime.Now;

            //_context.Entry(vehicle).State = EntityState.Modified;

            try
            {
                await _uow.CompleteAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                //if (!VehicleExists(id))
                //{
                    return NotFound();
                //}
                //else
                //{
                //    throw;
                //}
            }

            vehicle = await _vehicleRepository.GetVehicle(vehicle.Id);

            var result = _mapper.Map<Vehicle, VehicleResource>(vehicle);
            return Ok(result);
        }

        // POST: api/Vehicle
        [HttpPost]
        public async Task<IActionResult> PostVehicle([FromBody] SaveVehicleResource saveVehicleResource)
        {
            throw new Exception();

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var vehicle = _mapper.Map<SaveVehicleResource, Vehicle>(saveVehicleResource);
            vehicle.LastUpdate = DateTime.Now;

            _vehicleRepository.Add(vehicle);
            await _uow.CompleteAsync();

            vehicle = await _vehicleRepository.GetVehicle(vehicle.Id);

            var result = _mapper.Map<Vehicle, VehicleResource>(vehicle);

            return Ok(result);
        }

        // DELETE: api/Vehicle/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteVehicle([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var vehicle = await _vehicleRepository.GetVehicle(id, includeRelated: false);
            if (vehicle == null)
            {
                return NotFound();
            }

            _vehicleRepository.Remove(vehicle);
            await _uow.CompleteAsync();

            return Ok(vehicle);
        }
    }
}