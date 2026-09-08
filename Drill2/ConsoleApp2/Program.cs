using System;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace ConsoleApp2
{
    public abstract class Delivery
    {
        public required int Number { get; set; }
        public required string DestAddress { get; set; }
        public abstract decimal ShipmentCost(decimal distance);

        public void Ship(decimal distance)
        {
            Console.WriteLine($"Shipping to {DestAddress} with distance {distance} km. Cost: {ShipmentCost(distance)}");
        }
    }

    public class StandardDelivery : Delivery
    {
        public override decimal ShipmentCost(decimal distance)
        {
            return 5.00m * distance;
        }
    }

    public class ExpressDelivery : Delivery
    {
        public override decimal ShipmentCost(decimal distance)
        {
            return 15.00m * distance;
        }
    }

    public class InternacionalDelivery : Delivery
    {
        public override decimal ShipmentCost(decimal distance)
        {
            return 25.00m * distance;
        }
    }

    public interface INotifier
    {
        void Notify(string message);
    }

    public class EmailNotifier : INotifier  
    {
        public void Notify(string message)
        {
            Console.WriteLine($"Email sent: {message}");
        }
    }

    public class SMSNotifier : INotifier
    {
        public void Notify(string message)
        {
            Console.WriteLine($"SMS sent: {message}");
        }
    }

    public class AppNotifier : INotifier
    {
        public void Notify(string message)
        {
            Console.WriteLine($"App notification sent: {message}");
        }
    }


    public abstract class Vehicle
    {
        public required string Model { get; set; }
        public required string Code { get; set; }
        public abstract void Drive();
    }

    public class Van : Vehicle
    {
        public override void Drive()
        {
            Console.WriteLine("Driving the van.");
        }
    }

    public class Truck : Vehicle
    {
        public override void Drive()
        {
            Console.WriteLine("Driving the truck.");
        }
    }

    public class Plane : Vehicle
    {
        public override void Drive()
        {
            Console.WriteLine("Flying the plane.");
        }
    }

    public class DeliveryProcessor
    {
        private readonly Delivery _delivery;
        private readonly INotifier _notifier;
        private readonly Vehicle _vehicle;
        public DeliveryProcessor(Delivery delivery, INotifier notifier, Vehicle vehicle)
        {
            _delivery = delivery;
            _notifier = notifier;
            _vehicle = vehicle;
        }
        public void Process(decimal distance)
        {
            _delivery.Ship(distance);
            _notifier.Notify($"Delivery processed to {_delivery.DestAddress} sent");
            _vehicle.Drive();
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            Delivery delivery = new StandardDelivery { Number = 123, DestAddress = "123 Main St" };
            INotifier emailnotifier = new EmailNotifier();
            Vehicle Vanvehicle = new Van { Model = "Cargo Van", Code = "CV-001" };
            DeliveryProcessor processor = new DeliveryProcessor(delivery, emailnotifier, Vanvehicle);
            processor.Process(10); // Process a delivery with a distance of 10 km

            Delivery internacionaldelivery = new InternacionalDelivery { Number = 456, DestAddress = "456 International Ave" };
            INotifier smsnotifier = new SMSNotifier();
            Vehicle Planevehicle = new Plane { Model = "Commercial Plane", Code = "CP-001" };
            DeliveryProcessor processor1 = new DeliveryProcessor(internacionaldelivery, smsnotifier, Planevehicle);
            processor1.Process(230);

            Delivery delivery1 = new ExpressDelivery { Number = 789, DestAddress = "789 Express Blvd" };
            INotifier appnotifier = new AppNotifier();
            Vehicle truckVehicle = new Truck { Model = "Delivery Truck", Code = "DT-001" };
            DeliveryProcessor processor2 = new DeliveryProcessor(delivery1, appnotifier, truckVehicle);
            processor2.Process(50);
        }
    }
}

