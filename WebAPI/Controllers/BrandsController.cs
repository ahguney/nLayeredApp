using Business.Abstract;
using Business.Request.Brand;
using Business.Response.Brand;
using DataAccess.Concrete.EntityFramework.Context;
using Entities.Concrete;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Identity.Client;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BrandsController : ControllerBase
    {
        private readonly IBrandService _brandService;

        public BrandsController(IBrandService brandService)
        {
            _brandService = brandService;
        }


        [HttpPost("addbrand")]
        public ActionResult<AddBrandResponse> AddBrand(AddBrandRequest request)
        {
            return Created("" ,_brandService.Add(request));
        }


        [HttpGet("getList")]
        public ActionResult<GetBrandListResponse> GetList([FromQuery]GetBrandListRequest request = null)
        {
            return Ok(_brandService.GetList(request));
        }
    }
}
