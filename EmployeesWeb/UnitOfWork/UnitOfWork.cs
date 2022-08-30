using EmployeesWeb.Data;
using EmployeesWeb.Models;
using EmployeesWeb.Repository;

namespace EmployeesWeb.UOW
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly ApplicationDbContext _db;
        public UnitOfWork(ApplicationDbContext db)
        {
            _db = db;
        }
       

        public int CommitChanges()
        {
            return _db.SaveChanges();
        }

        public void Dispose()
        {
            _db.Dispose();
        }
    }
}
