using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Response.Brand
{
    public class AddBrandResponse
    {
        public int Id { get; set; }

        public string Name { get; set; }


        public AddBrandResponse()
        {
            
        }
        public AddBrandResponse(int id ,string name)
        {
            Id = id;
            Name = name;
        }
    }
}
