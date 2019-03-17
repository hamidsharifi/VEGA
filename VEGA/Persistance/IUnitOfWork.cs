using System.Threading.Tasks;

namespace VEGA.Persistance
{
    public interface IUnitOfWork
    {
        Task CompleteAsync();
    }
}