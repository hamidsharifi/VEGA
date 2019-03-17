using System.Collections.Generic;
using System.Threading.Tasks;
using VEGA.Models;

namespace VEGA.Persistance
{
    public interface IVehicleRepository
    {
        Task<Vehicle> GetVehicle(int id, bool includeRelated = true);

        void Add(Vehicle vehicle);

        void Remove(Vehicle vehicle);
        Task<List<Vehicle>> GetVehicles(bool includeRelated = false);
    }
}