using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ToDoTask.DataAccess.Models
{
    public class ToDoModel
    {
        public int ToDoID { get; set; }

        public string ToDoName { get; set; }
        public bool IsDone{ get; set; }

    }
}
