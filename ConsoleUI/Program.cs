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


            CarTest();

            //ColorTest();

            //BrandTest();



        }

        private static void CarTest()
        {
            CarManager carManager = new CarManager(new EfCarDal());
            Console.WriteLine(" <<< **************************** <<< ARAÇ LİSTESİ >>> **************************** >>> \n");

            // ******** GetById ********
            //Console.WriteLine(carManager.Get(1).CarName);

            // ******** Added ********
            //carManager.Add(new Car { CarName = "E200", BrandId = 2, ColorId = 2, ModelYear = 2018, DailyPrice = 3500, Description = "Mercedes E200 4Matic" });

            // ******** Deleted ********
            //var deletedCar = carManager.Get(7);
            // carManager.Delete(deletedCar);

            // ******** Updated ********
            //var updatedCar = carManager.Get(3);
            //updatedCar.Description = "Alfa Romeo 2020";
            //carManager.Update(updatedCar);

            // Tüm Arabaların Listesi
            //foreach (var car in carManager.GetAll())
            //{
            //    Console.WriteLine($"Araba ID :{car.CarId} Araba Adı :{car.CarName} Model ID :{ car.BrandId} Renk ID :{car.ColorId} Model Yılı: {car.ModelYear} Günlük Fiyat :{car.DailyPrice} Açıklama :{ car.Description}");
            //}

            foreach (var car in carManager.GetCarDetails())
            {
                Console.WriteLine($"Araba Adı: {car.CarName}Marka: {car.BrandName} Renk: {car.ColorName}Günlük Fiyatı: {car.DailyPrice}");
            }


        }

        private static void ColorTest()
        {
            ColorManager colorManager = new ColorManager(new EfColorDal());
            Console.WriteLine(" <<< **************************** <<< RENK LİSTESİ >>> **************************** >>> \n");

            // ******** GetById ********
            //Console.WriteLine(colorManager.Get(1).BrandName);

            // ******** Added ********
            //colorManager.Add(new Brand {ColorName="------"});

            // ******** Deleted ********
            //var deletedColor = colorManager.Get(7);
            // colorManager.Delete(deletedColor);

            // ******** Updated ********
            //var updatedColor = colorManager.Get(3);
            //updatedColor.ColorName = "------";
            //colorManager.Update(updatedColor);

            foreach (var color in colorManager.GetAll())
            {
                Console.WriteLine("Renk ID :{0} Renk Adı :{1} ", color.ColorId, color.ColorName);
            }
        }

        private static void BrandTest()
        {
            BrandManager brandManager = new BrandManager(new EfBrandDal());
            Console.WriteLine(" <<< **************************** <<< MARKA LİSTESİ >>> **************************** >>> \n");

            // ******** GetById ********
            //Console.WriteLine(brandManager.Get(1).BrandName);

            // ******** Added ********
            //brandManager.Add(new Brand {BrandName="------"});

            // ******** Deleted ********
            //var deletedBrand = brandManager.Get(7);
            // brandManager.Delete(deletedBrand);

            // ******** Updated ********
            //var updatedBrand = brandManager.Get(3);
            //updatedBrand.BrandName = "-----";
            //brandManager.Update(updatedBrand);

            foreach (var brand in brandManager.GetAll())
            {
                Console.WriteLine("Marka ID :{0} Marka Adı :{1} ", brand.BrandId, brand.BrandName);
            }

        }

    }
}
