using DataAccess.Abstract;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DataAccess.Concrete.InMemory
{
    public class InMemoryCarDal //: ICarDal
    {
        List<Car> _cars;
        public InMemoryCarDal()
        {
            _cars = new List<Car> {
            new Car{Id=1,BrandId=1,ColorId=1,ModelYear="2021",DailyPrice=400,Description="En az 1 aylık kiralanabilir."},
            new Car{Id=2,BrandId=1,ColorId=2,ModelYear="2020",DailyPrice=300,Description="En az 2 aylık kiralanabilir."},
            new Car{Id=3,BrandId=2,ColorId=3,ModelYear="2019",DailyPrice=200,Description="En az 3 aylık kiralanabilir."},
            new Car{Id=4,BrandId=2,ColorId=4,ModelYear="2018",DailyPrice=100,Description="En az 4 aylık kiralanabilir."},
            new Car{Id=5,BrandId=3,ColorId=5,ModelYear="2017",DailyPrice=100,Description="En az 5 aylık kiralanabilir."}};
            

        }
        public void Add(Car car)
        {
            _cars.Add(car);
        }

        public void Delete(Car car)
        {
            Car carToDelete = _cars.SingleOrDefault(c=>c.Id==car.Id);
            _cars.Remove(carToDelete);
        }

        public List<Car> GetAll()
        {
            return _cars;
        }

        public List<Car> GetAllByBrandId(int BrandId)
        {
            return _cars.Where(c => c.BrandId == BrandId).ToList();
        }

        public void Update(Car car)
        {
            Car carToUpdate = _cars.SingleOrDefault(c => c.Id == car.Id);
            carToUpdate.ModelYear = car.ModelYear;
            carToUpdate.DailyPrice = car.DailyPrice;
            carToUpdate.BrandId = car.BrandId;
            carToUpdate.ColorId = car.ColorId;
            carToUpdate.Description = car.Description;

        }
    }
}
