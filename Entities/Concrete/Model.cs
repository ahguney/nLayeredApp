using Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Concrete
{
    public class Model : Entity<int>
    {
        public int BrandId { get; set; }
        public int FuelId { get; set; }
        public int TransmissionId { get; set; }
        public decimal DailyPrice { get; set; }
        public string Name { get; set; }
        public short Year { get; set; }

        public Model()
        {
            
        }

        public Model(int brandId, int fuelId, int transmissionId, decimal dailyPrice, string name, short year) : this()
        {
            BrandId = brandId;
            FuelId = fuelId;
            TransmissionId = transmissionId;
            DailyPrice = dailyPrice;
            Name = name;
            Year = year;
        }




        // lazy loading = nesnenin ihtiyaç durumunda kullanılması
        public Brand? Brand { get; set; } = null;
        public Fuel? Fuel { get; set; } = null;
        public Transmission? Transmission { get; set; } = null;

        // public ICollection<Car>? Cars { get; set; } = null;
    }
}
