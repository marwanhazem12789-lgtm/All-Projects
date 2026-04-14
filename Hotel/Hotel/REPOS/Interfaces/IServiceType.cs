using Hotel.Models;

namespace Hotel.REPOS.Interfaces
{
    public interface IServiceType
    {
        List<ServiceType> GetServices();
        void add(ServiceTypeVM r);
        void Update(ServiceTypeVM r);
        void delete(int r);
        ServiceType Get(int id);
    }
}
