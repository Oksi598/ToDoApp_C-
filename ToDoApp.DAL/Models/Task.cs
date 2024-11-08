using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ToDoApp.DAL.Models.Identity;

namespace ToDoApp.DAL.Models
{
    public class Task
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public string Category { get; set; }
        public int Priority { get; set; }
        public DateTime DueDate { get; set; }
        public bool Status { get; set; }
        public bool IsArchived { get; set; }
        public string UserId { get; set; }
        public User User { get; set; }
    }

}
