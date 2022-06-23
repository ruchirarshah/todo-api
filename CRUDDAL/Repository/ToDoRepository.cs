using CRUD_DAL.Data;
using CRUD_DAL.Interface;
using CRUD_DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CRUD_DAL.Repository
{
    public class ToDoRepository : IRepository<ToDoTask>
    {
        ApplicationDbContext _dbContext;
        public ToDoRepository(ApplicationDbContext applicationDbContext)
        {
            _dbContext = applicationDbContext;
        }
        public async Task<ToDoTask> Create(ToDoTask _object)
        {
            var obj = await _dbContext.ToDoTasks.AddAsync(_object);
            _dbContext.SaveChanges();
            return obj.Entity;
        }

        public void Delete(ToDoTask _object)
        {
            _dbContext.Remove(_object);
            _dbContext.SaveChanges();
        }

       
        public IEnumerable<ToDoTask> GetAll()
        {
            try
            {
                return _dbContext.ToDoTasks.Where(x => x.IsDeleted == false).ToList();
            }
            catch (Exception ee)
            {
                throw;
            }
        }

        public ToDoTask GetById(int Id)
        {
            return _dbContext.ToDoTasks.Where(x => x.IsDeleted == false && x.Id == Id).FirstOrDefault();
        }

        public void Update(ToDoTask _object)
        {
            _dbContext.ToDoTasks.Update(_object);
            _dbContext.SaveChanges();
        }
    }
}
