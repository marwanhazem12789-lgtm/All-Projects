using Demo2Web.Models;

namespace Demo2Web.Repos.Faces
{
    public interface IOrder
    {
        List<Order> GetAll();
        void add(OrderVM order);
        void Update(OrderVM order);
        void delete(int Id);
        Order GetById (int Id);
    }
}
