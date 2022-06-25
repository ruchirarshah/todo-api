using CRUD_BAL.Service;
using CRUD_DAL.Interface;
using CRUD_DAL.Models;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TODO.API.Requests;

namespace CRUDAspNetCore5WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ToDoTaskController : ControllerBase
    {
        private readonly ToDoService _toDoService;

        private readonly IRepository<ToDoTask> _ToDoTask;

        public ToDoTaskController(IRepository<ToDoTask> ToDoTask, ToDoService ToDo)
        {
            _toDoService = ToDo;
            _ToDoTask = ToDoTask;

        }
        
        [HttpPost("Add")]
        
        public async Task<Object> Add([FromBody] ToDoTask Task)
        {
            try
            {
                await _toDoService.AddTask(Task);
                return true;
            }
            catch (Exception ex)
            {

                return false;
            }
        }
       
      
        [HttpPut("Update")]
       
        public bool Update(UpdateRequest request)
        {
            try
            {
                _toDoService.UpdateTask(request.Id,request.TaskName,request.IsDeleted,request.IsComplete);
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        [HttpGet("GetAll")]
        
        public Object GetAll()
        {
            var data = _toDoService.GetAllToDoTasks();
            var json = JsonConvert.SerializeObject(data, Formatting.Indented,
                new JsonSerializerSettings()
                {
                    ReferenceLoopHandling = Newtonsoft.Json.ReferenceLoopHandling.Ignore
                }
            );
            return json;
        }
    }
}