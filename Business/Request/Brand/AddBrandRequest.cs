using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Request.Brand
{
    public class AddBrandRequest
    {
        public string Name { get; set; }

        public AddBrandRequest()
        {
            
        }
        public AddBrandRequest(string name)
        {
            Name = name;
        }
    }
}
