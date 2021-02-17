using Business.Concrete;
using DataAccess.Concrete.EntityFramework;
using DataAccess.Concrete.InMemory;
using Entities.Concrete;
using System;

namespace ConsoleUI
{
    class Program
    {
        static void Main(string[] args)
        {
            // CarTest();
            //BrandTest();
            //ColorTest();
            RentalTest();
            //CustomerTest();
            //UserTest();

            Console.ReadLine();
        }

        private static void UserTest()
        {
            UserManager userManager = new UserManager(new EfUserDal());
            Console.WriteLine(userManager.GetAll().Message);
            foreach (var user in userManager.GetAll().Data)
            {
                Console.WriteLine("Kullanıcı Id=  " + user.Id + "  Kullanıcı ismi= " + user.FirstName + "  Kullanıcı soyismi= " + user.LastName + "  Kullanıcı emaili= " + user.Email);
            }
            Console.WriteLine(userManager.GetAll().Message);
            foreach (var user in userManager.GetUserDetails().Data)
            {
                Console.WriteLine("Kullanıcı Id=  " + user.Id +" Şirket Adı= " +user.CompanyName +"  Kullanıcı ismi= " + user.FirstName + "  Kullanıcı soyismi= " + user.LastName + "  Kullanıcı emaili= " + user.Email);
            }
        }

        private static void CustomerTest()
        {
            CustomerManager customerManager = new CustomerManager(new EfCustomerDal());
            Console.WriteLine(customerManager.GetAll().Message);
            foreach (var customer in customerManager.GetAll().Data)
            {
                Console.WriteLine("Id= " + customer.UserId + " Şirket adı= " + customer.CompanyName);

            }
            //customerManager.Add(new Customer {UserId=6,CompanyName="super"});
        }

        private static void RentalTest()
        {
            RentalManager rentalManager = new RentalManager(new EfRentalDal());
            Console.WriteLine(rentalManager.GetAll().Message);
            foreach (var rental in rentalManager.GetAll().Data)
            {
                Console.WriteLine("Id= " + rental.Id + " Araba Id= " + rental.CarId + " Müşteri Id= " + rental.CustomerId + " Kiralama tarihi= " + rental.RentDate + " Teslim tarihi= " + rental.ReturnDate);

            }
            
            
            
        }

        private static void BrandTest()
        {
            BrandManager brandManager = new BrandManager(new EfBrandDal());
            //Console.WriteLine(brandManager.GetById(1).Data.BrandName);
            Console.WriteLine(brandManager.GetById(1).Message);
            foreach (var brand in brandManager.GetAll().Data)
            {
                Console.WriteLine(brand.BrandId + "/ " + brand.BrandName);

            }

        }
        private static void ColorTest()
        {
            ColorManager colorManager = new ColorManager(new EfColorDal());
            Console.WriteLine(colorManager.GetById(1).Message);

            //Console.WriteLine(colorManager.GetById(3).Data.ColorName);
            foreach (var color in colorManager.GetAll().Data)
            {
                Console.WriteLine(color.ColorId + "/ " + color.ColorName);
            }
        }

    
        private static void CarTest()
        {
            CarManager carManager = new CarManager(new EfCarDal());
            var result = carManager.GetCarDetails();
            Console.WriteLine(result.Message);
            if (result.Success == true)
            {
                foreach (var car in result.Data)
                {
                    Console.WriteLine(car.Id + "/Adı: " + car.CarName + "/ Modeli: " + car.BrandName + " /Rengi: " + car.ColorName + " /Fiyatı  " + car.DailyPrice);
                    
                }

            }
            else
            {
                Console.WriteLine(result.Message);
            }


           
        }
    }
}
