using Business.Concrete;
using DataAccess.Concrete.EntityFramework;
using System;

namespace ConsoleUI
{
    class Program
    {
        static void Main(string[] args)
        {
            CarTest();
        }
        private static void CarTest()
        {
            CarManager carManager = new CarManager(new EfCarDal());
            var result = carManager.GetCarDetails();

            if (result.Success == true)
            {
                foreach (var car in result.Data)
                {
                    Console.WriteLine("----------------------------------------------------------------------------------");
                    Console.WriteLine(car.Description + "\n" + car.BrandName + "\n" + car.ColorName + "\n" + car.DailyPrice);
                    Console.WriteLine("----------------------------------------------------------------------------------");
                }
            }
        }
    }
}
