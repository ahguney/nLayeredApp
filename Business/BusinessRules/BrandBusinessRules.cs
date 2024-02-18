using DataAccess.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.BusinessRules
{
    public class BrandBusinessRules
    {
        private readonly IBrandDal _brandDal;

        public BrandBusinessRules(IBrandDal brandDal)
        {
            _brandDal = brandDal;
        }

        public void CheckIfBrandNameNotExists(string name)
        {
            bool isExists = _brandDal.Get(p => p.Name == name) is not null;
            if (isExists) 
            {
                throw new Exception("Brand Already exists.");
            }
        }
    }
}
