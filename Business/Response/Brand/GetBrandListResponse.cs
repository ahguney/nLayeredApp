using Business.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Response.Brand
{
    public class GetBrandListResponse
    {
        public IList<BrandListDto> BrandListDtos { get; set; }

        public GetBrandListResponse()
        {
            
        }
        public GetBrandListResponse(IList<BrandListDto> brandListDtos)
        {
            BrandListDtos = brandListDtos;
        }
    }
}
