using Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Concrete
{
    public class Brand : Entity<int>
    {
        public string Name { get; set; }

        public Brand()
        {
            
        }

        public Brand(int id,string name) : this()
        {
            Id = id;
            Name = name;
        }
    }
}
