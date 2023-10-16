using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutomobileLibrary.BiussinessObject;
namespace AutomobileLibrary.DataAccess
{
    public class CarDBContext
    {

        private static List<Car> CarList = new List<Car>()
        {
            new Car{CarId=1,CarName="CRV",Manufacturer="honda",Price=300000,ReleaseYear=2020 },
            new Car{CarId=2,CarName="Ford raptor",Manufacturer="Ford",Price=400000, ReleaseYear=2020 }
        };

        private static CarDBContext instance = null;
        private static readonly object instanceLock = new object();
        private CarDBContext() { }
        public static CarDBContext Instance
        {
            get {
                lock (instanceLock)
                {
                    if (instance == null)
                    {
                        instance = new CarDBContext();
                    }
                }
                
                
              return  instance; }
        }
        public List<Car> GetCarList => CarList;

        public Car GetCarById(int carID)
        {
            Car car = CarList.SingleOrDefault(pro => pro.CarId == carID);
            return car;

        }

        public void AddNew(Car car)
        {
            Car pro = GetCarById(car.CarId);
            if(pro == null)
            {
                CarList.Add(car);
            }
            else
            {
                throw new Exception("Car is already exists");
            }
        }

        public void Update(Car car)
        {
            Car c =GetCarById(car.CarId);
            if (c !=null)
            {
                var index = CarList.IndexOf(c);
                CarList[index] = car;
            }
            else
            {
                throw new Exception("car does not already exists");
            }
        }

        public void Remove(int CarId)
        {
            Car p = GetCarById(CarId);
            if(p != null)
            {
                CarList.Remove(p);
            }
            else
            {
                throw new Exception("Car does not already exists");
            }

        }



    }
}
