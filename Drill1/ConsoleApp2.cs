using System;

namespace ConsoleApp2
{
    public abstract class Delivery
    {
        public required Number {  get; private set; }
        public required DestAdres {  get; private set; }
        public abstract decimal ShipmentCost(decimal distance);

        public void Ship(decimal distance)
        {
            Console.WriteLine($"Shipping to {DestAdres} with distance {distance} km. Cost: {ShipmentCost(distance)}");
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

    public class INotifier
    {
        public void Notify(string message);
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
        public abstract string Model { get; private set}
        public abstract string Code { get; private set}
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
            _notifier.Notify($"Delivery processed to {DestAdres} sended");
            _vehicle.Drive();
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            Delivery delivery = new StandardDelivery { Number = 123, DestAdres = "123 Main St" };
            INotifier notifier = new EmailNotifier();
            Vehicle vehicle = new Van();
            DeliveryProcessor processor = new DeliveryProcessor(delivery, notifier, vehicle);
            processor.Process(10); // Process a delivery with a distance of 10 km

            Delivery delivery = new InternacionalDelivery { Number = 456, DestAdres = "456 International Ave" };
            INotifier notifier = new SMSNotifier();
            Vehicle vehicle = new Plane();
            DeliveryProcessor processor1 = new DeliveryProcessor(delivery, notifier, vehicle);
            processor1.Process(230);

            Delivery delivery1 = new ExpressDelivery { Number = 789, DestAdres = "789 Express Blvd" };
            INotifier notifier1 = new AppNotifier();
            DeliveryProcessor processor2 = new DeliveryProcessor(delivery1, notifier1, vehicle);
            processor2.Process(50);
        }
    }
}
