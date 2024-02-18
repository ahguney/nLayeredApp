using AutoMapper;
using Business.Abstract;
using Business.BusinessRules;
using Business.Request.Brand;
using Business.Response.Brand;
using DataAccess.Abstract;
using Entities.Concrete;
using Microsoft.EntityFrameworkCore.Metadata;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Concrete
{
    public class BrandManager : IBrandService
    {
        private readonly IBrandDal _brandDal;
        private readonly IMapper _mapper;
        private readonly BrandBusinessRules _brandBusinessRules;
        

        public BrandManager(IBrandDal brandDal,IMapper mapper, BrandBusinessRules brandBusinessRules)
        {
            _brandDal = brandDal;
            _mapper = mapper;
            _brandBusinessRules = brandBusinessRules;
        }
        public AddBrandResponse Add(AddBrandRequest request)
        {
            _brandBusinessRules.CheckIfBrandNameNotExists(request.Name);

            Brand brand = _mapper.Map<Brand>(request);
            Brand responseBrand = _brandDal.Add(brand);
            AddBrandResponse response = _mapper.Map<AddBrandResponse>(responseBrand);
            return response;
        }

        public void Delete(Brand brand)
        {
            _brandDal.Delete(brand);
        }

        public Brand GetByID(int id)
        {
            return _brandDal.Get(p=>p.Id.Equals(id) && p.DeletedAt.HasValue == false);
        }

        public GetBrandListResponse GetList(GetBrandListRequest request)
        {
            GetBrandListResponse response = _mapper.Map<GetBrandListResponse>(_brandDal.GetList(p=>p.DeletedAt.HasValue == false));
            return response;
        }

        public void Update(Brand brand)
        {
            _brandDal.Update(brand);
        }
    }
}
