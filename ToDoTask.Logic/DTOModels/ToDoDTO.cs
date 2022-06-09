using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ToDoTask.Logic.DTOModels
{
    public class ToDoDTO
    {
        public int ToDoID { get; set; }

        public string ToDoName { get; set; }

        public bool IsDone { get; set; }
    }
}
