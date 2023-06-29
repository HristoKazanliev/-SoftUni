using System;

namespace _02.VehiclesExtension
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] carInfo = Console.ReadLine().Split(" ",StringSplitOptions.RemoveEmptyEntries);
            Vehicle car = new Car(double.Parse(carInfo[1]), double.Parse(carInfo[2]), double.Parse(carInfo[3]));

            string[] truckInfo = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries);
            Vehicle truck = new Truck(double.Parse(truckInfo[1]), double.Parse(truckInfo[2]), double.Parse(truckInfo[3]));

            string[] busInfo = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries);
            Vehicle bus = new Bus(double.Parse(busInfo[1]), double.Parse(busInfo[2]), double.Parse(busInfo[3]));

            int numberOperations = int.Parse(Console.ReadLine());
            for (int i = 0; i < numberOperations; i++)
            {
                try
                {
                    string[] commands = Console.ReadLine().Split();
                    string action = commands[0];
                    string typeOfVehicle = commands[1];
                    double value = double.Parse(commands[2]);

                    if (typeOfVehicle == "Car")
                    {
                        Command(car, action, value);
                    }
                    else if (typeOfVehicle == "Truck")
                    {
                        Command(truck, action, value);
                    }
                    else if (typeOfVehicle == "Bus")
                    {
                        Command(bus, action, value);
                    }
                }
                catch (Exception e )
                {
                    Console.WriteLine(e.Message);
                }
            }

            Console.WriteLine(car);
            Console.WriteLine(truck);
            Console.WriteLine(bus);
        }

        private static void Command(Vehicle vehicle, string action, double value)
        {
            if (action == "Drive")
            {
                vehicle.IsEmpty = false;
                Console.WriteLine(vehicle.Drive(value));
            }
            else if (action == "DriveEmpty")
            {
                vehicle.IsEmpty = true;
                Console.WriteLine(vehicle.Drive(value));
            }
            else if (action == "Refuel")
            {
                vehicle.Refuel(value);
            }
        }
    }
}
