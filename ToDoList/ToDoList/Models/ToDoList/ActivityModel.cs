using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ToDoList.Models.ToDoList
{
    public class ActivityModel
    {
        public Guid Id { get; set; }
        [Required, MinLength(10)]
        public string Name { get; set; }
        [Required, MaxLength(500)]
        public string Desription { get; set; }
    }
}
