using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Dtos
{
    public class BrandListDto
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public BrandListDto(int id,string name)
        {
            Name = name;
            Id = id;
        }
    }
}
