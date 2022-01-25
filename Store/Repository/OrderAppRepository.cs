using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using Store.Data;
using Store.Service;

namespace Store.Repository
{
    public class OrderAppRepository:IOrderAppRepository
    {
        private readonly ApplicationDbContext _db;

        public OrderAppRepository(ApplicationDbContext db)
        {
            _db = db;
        }
        public ICollection<OrderApp> FindAll()
        {
           var orderApps = _db.OrderApps
                .Include(c => c.Customer)
                .Include(k => k.Kala)
                .ToList();
           return orderApps;
        }

        public OrderApp FindById(int id)
        {
            var orderApp = _db.OrderApps
                .Include(c => c.Customer)
                .Include(k => k.Kala)
                .FirstOrDefault(o => o.Id == id);
            return orderApp;
        }

        public bool isExists(int id)
        {
            var exists = _db.OrderApps.Any(k => k.KalaId == id);
            return exists;
        }

        public bool Create(OrderApp entity)
        {
            _db.OrderApps.Add(entity);
            return Save();
        }

        public bool Update(OrderApp entity)
        {
            _db.OrderApps.Update(entity);
            return Save();
        }

        public bool Delete(OrderApp entity)
        {
            _db.OrderApps.Remove(entity);
            return Save();
        }

        public bool Save()
        {
            var change = _db.SaveChanges();
            return change > 0;
        }

        public ICollection<OrderApp> GetOrderAppsByCustomer(string CustomerId)
        {
           var orderApps = FindAll()
                .Where(c => c.CustomerId == CustomerId)
                .ToList();
           return orderApps;
        }
    }
}