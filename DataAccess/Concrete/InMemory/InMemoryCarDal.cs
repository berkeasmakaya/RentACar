using DataAccess.Abstract;
using Entities.Concrete;
using Entities.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Concrete.InMemory
{
    public class InMemoryCarDal : ICarDal
    {
        List<Car> _cars;

        public InMemoryCarDal()
        {
            _cars = new List<Car> {
                new Car { Id = 1, BrandId = 1, ColorId = 1, DailyPrice=300, ModelYear=2019, Description="Siyah Opel Astra" },
                new Car { Id = 2, BrandId = 1, ColorId = 2, DailyPrice=400, ModelYear=2020, Description="Kırmızı Opel Astra" },
                new Car { Id = 3, BrandId = 2, ColorId = 2, DailyPrice=550, ModelYear=2021, Description="Kırmızı Hyundai Kona" }
            };
        }

        public void Add(Car entity)
        {
            throw new NotImplementedException();
        }

        public void Delete(Car entity)
        {
            throw new NotImplementedException();
        }

        public Car Get(Expression<Func<Car, bool>> filter)
        {
            throw new NotImplementedException();
        }

        public List<Car> GetAll(Expression<Func<Car, bool>> filter = null)
        {
            throw new NotImplementedException();
        }

        public List<CarDetailDto> GetCarDetails()
        {
            throw new NotImplementedException();
        }

        public void Update(Car entity)
        {
            throw new NotImplementedException();
        }
    }
}
