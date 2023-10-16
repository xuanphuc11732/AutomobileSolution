﻿using AutomobileLibrary.BiussinessObject;
using System.Collections;

namespace AutomobileLibrary.Repository
{
    public interface ICarRepository
    {

        IEnumerable<Car> GetCars();
        Car GetCarByID(int carId);
        void InsertCar(Car car);
        void UpdateCar(Car car);
        void DeleteCar(int carId);
    }

   
}
