using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UKParliament.CodeTest.Data;

namespace UKParliament.CodeTest.Services
{
    public class DepartmentService : IDepartmentService
    {

        private readonly DbContext _context;

        public DepartmentService(DbContext context)
        {
            _context = context;
        }

        protected DbSet<Department> Departments => (_context as DepartmentManagerContext)?.Departments
                                         ?? _context.Set<Department>();

        public List<Department> GetAll()
        {
            var departments = Departments
            .Select(dept => new Department
            {
                 Id = dept.Id,
                 Name = dept.Name
            })
            .ToList();
            return departments;
        }
    }
}
