using System.Collections.Generic;
using System.Linq;
using Store.Data;
using Store.Service;

namespace Store.Repository
{
    public class KalaRepository:IKalaRepository
    {
        private readonly ApplicationDbContext _db;

        public KalaRepository(ApplicationDbContext db)
        {
            _db = db;
        }
        public ICollection<Kala> FindAll()
        {
            var kalas = _db.Kalas.ToList();
            return kalas;
        }

        public Kala FindById(int id)
        {
            var kala = _db.Kalas.Find(id);
            return kala;
        }

        public bool isExists(int id)
        {
            var exists = _db.Kalas.Any(k => k.KalaId == id);
            return exists;
        }

        public bool Create(Kala entity)
        {
            _db.Kalas.Add(entity);
            return Save();
        }

        public bool Update(Kala entity)
        {
            _db.Kalas.Update(entity);
            return Save();
        }

        public bool Delete(Kala entity)
        {
            _db.Kalas.Remove(entity);
            return Save();
        }

        public bool Save()
        {
            var change = _db.SaveChanges();
            return change > 0;
        }
    }
}