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
            //var addedCar = carManager.Add(new Car { CarName = "E200", BrandId = 2, ColorId = 2, ModelYear = 2018, DailyPrice = 3500, Description = "Mercedes E200 4Matic" });
            //if (addedCar.Success == true)
            //{

            //    foreach (var car in carManager.GetAll())
            //    {
            //        Console.WriteLine($"Araba ID :{car.CarId} Araba Adı :{car.CarName} Model ID :{ car.BrandId} Renk ID :{car.ColorId} Model Yılı: {car.ModelYear} Günlük Fiyat :{car.DailyPrice} Açıklama :{ car.Description}");
            //    }
            //}
            //else
            //{
            //    Console.WriteLine(addedCar.Message);
            //}


            //********Deleted * *******
            //var deletedCar = carManager.GetById(10);
            //carManager.Delete(deletedCar);


            // ******** Updated ********
            //var updatedCar = carManager.Get(3);
            //updatedCar.Description = "Alfa Romeo 2020";
            //carManager.Update(updatedCar);



            // Tüm Arabaların Listesi
            //foreach (var car in carManager.GetAll())
            //{
            //    Console.WriteLine($"Araba ID :{car.CarId} Araba Adı :{car.CarName} Model ID :{ car.BrandId} Renk ID :{car.ColorId} Model Yılı: {car.ModelYear} Günlük Fiyat :{car.DailyPrice} Açıklama :{ car.Description}");
            //}

            var result = carManager.GetCarDetails();
            if (result.Success == true)
            {

                foreach (var car in result.Data)
                {
                    Console.WriteLine($"Araba adı: {car.CarName}Marka: {car.BrandName} Renk: {car.ColorName}Günlük fiyatı: {car.DailyPrice}");
                }
            }
            else
            {
                Console.WriteLine(result.Message);
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

            // ******** All Color List ********

            //foreach (var color in colorManager.GetAll())
            //{
            //    Console.WriteLine("Renk ID :{0} Renk Adı :{1} ", color.ColorId, color.ColorName);
            //}
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



            // ******** All Brand List ********
            //foreach (var brand in brandManager.GetAll())
            //{
            //    Console.WriteLine("Marka ID :{0} Marka Adı :{1} ", brand.BrandId, brand.BrandName);
            //}

        }

    }
}
