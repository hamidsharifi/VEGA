﻿using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using VEGA.Models;

namespace VEGA.Persistance
{
    public class VehicleRepository : IVehicleRepository
    {
        private readonly VegaDbContext _context;

        public VehicleRepository(VegaDbContext context)
        {
            _context = context;
        }

        public async Task<Vehicle> GetVehicle(int id, bool includeRelated = true)
        {
            if (!includeRelated)
            {
                return await _context.Vehicles.FindAsync(id);
            }
            return await _context.Vehicles
                .Include(v => v.Model)
                .ThenInclude(m => m.Make)
                .Include(v => v.Features)
                .ThenInclude(vf => vf.Feature)
                .FirstOrDefaultAsync(v => v.Id == id);
        }

        public void Add(Vehicle vehicle)
        {
            _context.Vehicles.Add(vehicle);
        }

        public void Remove(Vehicle vehicle)
        {
            _context.Vehicles.Remove(vehicle);
        }

        public async Task<List<Vehicle>> GetVehicles(bool includeRelated = false)
        {
            if (includeRelated)
            {
                return await _context.Vehicles
                    .Include(v => v.Model)
                    .ThenInclude(m => m.Make)
                    .Include(v => v.Features)
                    .ThenInclude(vf => vf.Feature).ToListAsync();
            }
            return await _context.Vehicles.ToListAsync();
        }
    }
}
