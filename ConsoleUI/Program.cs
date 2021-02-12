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


            //CarTest();

            //ColorTest();

            //BrandTest();

            //CustomerTest();

            RentalTest();

        }

        private static void RentalTest()
        {
            RentalManager rentalManager = new RentalManager(new EfRentalDal());


            var AddedRentalCar = rentalManager.Add(new Rental { CarId = 1, CustomerId = 1, RentDate = new DateTime(2021, 04, 02) });
            Console.WriteLine(AddedRentalCar.Message);

            

        }   

        private static void CustomerTest()
        {
            CustomerManager customerManager = new CustomerManager(new EfCustomerDal());
            //********Added * *******
            var addedCustomer = customerManager.Add(new Customer { UserId = 3, CompanyName = "Serkan A.Ş"});
            if (addedCustomer.Success == true)
            {

                foreach (var customer in customerManager.GetAll().Data)
                {
                    Console.WriteLine($"Müşteri İsmi :{customer.CompanyName}");
                }
            }
            else
            {
                Console.WriteLine(addedCustomer.Message);
            }
        }

        private static void CarTest()
        {
            CarManager carManager = new CarManager(new EfCarDal());
            Console.WriteLine(" <<< **************************** <<< ARAÇ LİSTESİ >>> **************************** >>> \n");

            // ******** GetById ********
            //Console.WriteLine(carManager.Get(1).CarName);

            //********Added ********
            var addedCar = carManager.Add(new Car { CarName = "E200", BrandId = 2, ColorId = 2, ModelYear = 2018, DailyPrice = 3500, Description = "Mercedes E200 4Matic" });
            if (addedCar.Success == true)
            {

                foreach (var car in carManager.GetAll().Data)
                {
                    Console.WriteLine($"Araba ID :{car.CarId} Araba Adı :{car.CarName} Model ID :{ car.BrandId} Renk ID :{car.ColorId} Model Yılı: {car.ModelYear} Günlük Fiyat :{car.DailyPrice} Açıklama :{ car.Description}");
                }
            }
            else
            {
                Console.WriteLine(addedCar.Message);
            }


            //********Deleted * *******
            var deletedCar = carManager.GetById(10).Data;
            carManager.Delete(deletedCar);


            // ******** Updated ********
            var updatedCar = carManager.GetById(3).Data;
            updatedCar.Description = "Alfa Romeo 2020";
            carManager.Update(updatedCar);



            // Tüm Arabaların Listesi
            foreach (var car in carManager.GetAll().Data)
            {
                Console.WriteLine($"Araba ID :{car.CarId} Araba Adı :{car.CarName} Model ID :{ car.BrandId} Renk ID :{car.ColorId} Model Yılı: {car.ModelYear} Günlük Fiyat :{car.DailyPrice} Açıklama :{ car.Description}");
            }

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

            foreach (var color in colorManager.GetAll().Data)
            {
                Console.WriteLine("Renk ID :{0} Renk Adı :{1} ", color.ColorId, color.ColorName);
            }
        }

        private static void BrandTest()
        {
            BrandManager brandManager = new BrandManager(new EfBrandDal());
            Console.WriteLine(" <<< **************************** <<< MARKA LİSTESİ >>> **************************** >>> \n");

            // ******** All Brand List ********
            foreach (var brand in brandManager.GetAll().Data)
            {
                Console.WriteLine("Marka ID :{0} Marka Adı :{1} ", brand.BrandId, brand.BrandName);
            }

        }

    }
}
