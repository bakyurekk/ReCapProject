using Business.Contract;
using DataAccess.Contract.InMemory;
using System;

namespace ConsoleUI
{
    class Program
    {
        static void Main(string[] args)
        {
            CarManager carManager = new CarManager(new InMemoryCarDal());

            foreach (var car in carManager.GetAll()) 
            {
                Console.WriteLine(car.Description);
            }
        }
    }
}
