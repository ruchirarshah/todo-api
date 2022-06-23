using CRUD_DAL.Interface;
using CRUD_DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CRUD_BAL.Service
{
    public class ToDoService
    {

        private readonly IRepository<ToDoTask> _todotask;

        public ToDoService(IRepository<ToDoTask> todotask)
        {
            _todotask = todotask;
        }
      
        public IEnumerable<ToDoTask> GetAllToDoTasks()
        {
            try
            {
                return _todotask.GetAll().ToList();
            }
            catch (Exception)
            {
                throw;
            }
        }
      
        public async Task<ToDoTask> AddTask(ToDoTask todotask)
        {
            return await _todotask.Create(todotask);
        }
        
        public bool DeleteTask(int Id)
        {

            try
            {
                var DataList = _todotask.GetAll().Where(x => x.Id == Id).ToList();
                foreach (var item in DataList)
                {
                    _todotask.Delete(item);
                }
                return true;
            }
            catch (Exception)
            {
                return false;
            }

        }
        public bool CompleteTask(int Id)
        {

            try
            {
                var DataList = _todotask.GetAll().Where(x => x.Id == Id).FirstOrDefault();
                DataList.IsComplete = true;
                DataList.UpdatedOn = DateTime.Now;
                _todotask.Update(DataList);
                return true;
            }
            catch (Exception)
            {
                return true;
            }

        }

        public bool UpdateTask(ToDoTask todoTask)
        {
            try
            {
                var DataList = _todotask.GetAll().Where(x => x.Id == todoTask.Id).FirstOrDefault() ;
                DataList.IsDeleted = todoTask.IsDeleted;
                DataList.TaskName = todoTask.TaskName;
                DataList.UpdatedOn = DateTime.Now;
                _todotask.Update(DataList);

                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }
    }
}
