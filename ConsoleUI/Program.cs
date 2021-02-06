using Business.Abstract;
using Business.Contract;
using DataAccess.Contract.EntityFramework;
using DataAccess.Contract.InMemory;
using Entities.Contract;
using System;

namespace ConsoleUI
{
    public class Program
    {
        static void Main(string[] args)
        {
            ICarService carManager = new CarManager(new EfCarDal());
            IBrandService brandManager = new BrandManager(new EfBrandDal());
            IColorService colorManager = new ColorManager(new EfColorDal());

            //Ekleme
            //carManager.Add(new Car {CarName = "E200",BrandId=2,ColorId=2,ModelYear=2018, DailyPrice = 3500,Description="Mercedes E200 4Matic"});
            //Silme
            //carManager.Delete(new Car { CarId = 6 });
            Console.WriteLine(carManager.Get(1).CarName);
            Console.WriteLine(" <<< **************************** <<< ARAÇ LİSTESİ >>> **************************** >>> \n");
            foreach (var car in carManager.GetAll())
            {
                Console.WriteLine("Araba ID :{0} Araba Adı :{1} Model ID :{2} Renk ID :{3} Model Yılı: {4} Günlük Fiyat :{5} Açıklama :{6}", car.CarId ,car.CarName,car.BrandId,car.ColorId,car.ModelYear,car.DailyPrice,car.Description);
            }

            Console.WriteLine(" <<< **************************** <<< MARKA LİSTESİ >>> **************************** >>> \n");
            foreach (var brand in brandManager.GetAll())
            {
                Console.WriteLine("Marka ID :{0} Marka Adı :{1} ",brand.BrandId,brand.BrandName);
            }

            Console.WriteLine(" <<< **************************** <<< RENK LİSTESİ >>> **************************** >>> \n");
            foreach (var color in colorManager.GetAll())
            {
                Console.WriteLine("Renk ID :{0} Renk Adı :{1} ", color.ColorId, color.ColorName);
            }




        }
    }
}
