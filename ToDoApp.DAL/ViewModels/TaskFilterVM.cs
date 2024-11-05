using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ToDoApp.DAL.ViewModels
{
    public class TaskFilterVM
    {
        public string Category { get; set; }
        public bool? Status { get; set; }
    }

}
