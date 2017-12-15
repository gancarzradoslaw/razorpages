using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ToDoList.Domain
{
    public class Activity
    {
        public virtual Guid Id { get; set; }
        public virtual string Name { get; set; }
        public virtual string Desription { get; set; }
        public virtual bool IsDeleted { get; set; }
    }
}
