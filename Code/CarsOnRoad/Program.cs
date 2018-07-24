using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lesson3
{
    class Program
    {
        static void Main(string[] args)
        {
            Road road = new Road();
            road.Add(new Car());
            road.Add(new Truck());
            road.Add(new ElectroCar());
            road.Add(new Matis());

            while (true)
            {
                road.Update();
            }
        }
    }

    class Road
    {
        private List<CarOnRoad> _cars = new List<CarOnRoad>();

        public void Update()
        {
            foreach (var car in _cars)
            {
                car.Car.Accelerate();
                car.Distance += car.Car.Speed * 0.03f;
            }
        }

        public void Add(Car car)
        {
            _cars.Add(new CarOnRoad(car, 0));
        }
    }

    class CarOnRoad
    {
        public Car Car;
        public float Distance;

        public CarOnRoad(Car car, float distance)
        {
            Car = car;
            Distance = distance;
        }
    }

    class Car
    {
        public float FuelCount { get; protected set; }
        //M\s
        public float Speed { get; protected set; }

        public virtual void Accelerate()
        {
            FuelCount -= 1;
            Speed += 1 * 0.2f;
        }
    }

    class Truck : Car
    {
        public float Weidth;

        public override void Accelerate()
        {
            FuelCount -= 1 + (Weidth / 1000);
            Speed += 1 * 0.05f;
        }
    }

    class ElectroCar : Car
    {
        public override void Accelerate()
        {
            FuelCount -= 1;
            Speed += 1 * (0.5f * (FuelCount / 1000));
        }
    }

    class Matis : Car
    {
        public override void Accelerate()
        {
            FuelCount -= 0.1f;
            Speed += 1 * 0.1f;
        }
    }
}
