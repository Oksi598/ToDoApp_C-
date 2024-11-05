using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ToDoApp.DAL.ViewModels
{
    public class UpdateTaskVM
    {
        public string Title { get; set; }
        public string Description { get; set; }
        public string Category { get; set; }
        public int Priority { get; set; }
        public DateTime DueDate { get; set; }
        public bool Status { get; set; }
        public bool IsArchived { get; set; }
    }
}
