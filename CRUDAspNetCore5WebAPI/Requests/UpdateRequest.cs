using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TODO.API.Requests
{
    public class UpdateRequest
    {
        public int Id { get; set; }
        public string TaskName  { get; set; }
        public bool? IsDeleted { get; set; }
        public bool? IsComplete { get; set; }
    }
}
