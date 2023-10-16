using AutomobileLibrary.BiussinessObject;
using AutomobileLibrary.DataAccess;

namespace AutomobileLibrary.Repository
{
    public  class CarRepository : ICarRepository
    {

        public Car GetCarByID(int carId) => CarDBContext.Instance.GetCarById(carId);
        public IEnumerable<Car> GetCars() => (IEnumerable<Car>)CarDBContext.Instance.GetCarList;
        public void InsertCar(Car car) => CarDBContext.Instance.AddNew(car);
        public void DeleteCar(int carId) => CarDBContext.Instance.Remove(carId);
        public void UpdateCar(Car car) => CarDBContext.Instance.Update(car);

     
    }
}
