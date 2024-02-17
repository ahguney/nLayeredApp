﻿using AutoMapper;
using Business.Abstract;
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

        public BrandManager(IBrandDal brandDal,IMapper mapper)
        {
            _brandDal = brandDal;
            _mapper = mapper;
        }
        public AddBrandResponse Add(AddBrandRequest request)
        {
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
            return _brandDal.Get(id);
        }

        public GetBrandListResponse GetList(GetBrandListRequest request)
        {
            GetBrandListResponse response = _mapper.Map<GetBrandListResponse>(_brandDal.GetList());
            return response;
        }

        public void Update(Brand brand)
        {
            _brandDal.Update(brand);
        }
    }
}