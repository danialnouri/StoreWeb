using System.Collections;
using System.Collections.Generic;
using Store.Data;

namespace Store.Service
{
    public interface IOrderAppRepository : IRepositoryBase<OrderApp>
    {
        ICollection<OrderApp> GetOrderAppsByCustomer(string CustomerId);
    }
}