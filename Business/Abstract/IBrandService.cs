using Business.Request.Brand;
using Business.Response.Brand;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace Business.Abstract
{
    public interface IBrandService
    {
        GetBrandListResponse GetList(GetBrandListRequest request);
        Brand GetByID(int id);
        AddBrandResponse Add(AddBrandRequest brand);
        void Update(Brand brand);
        void Delete(Brand brand);
    }
}
