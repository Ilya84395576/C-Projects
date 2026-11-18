using System;
using System.Collections.Generic;
using System.Text;

namespace Module1
{
    class Order
    {
        public int number { get; }
        public string description { get; }
        public double weight { get; }
        public double distance { get; }

        public Transport? AssignedTransport { get; private set; }

        public Order(int number, string description, double weight, double distance)
        {
            this.number = number;
            this.description = description;
            this.weight = weight;
            this.distance = distance;
            AssignedTransport = null;
        }

        public void Info()
        {
            Console.WriteLine($"Замовлення #{number}: {description}, " + $"вага: {weight} кг, відстань: {distance} км.");
        }

        public void AssignTransport(Transport transport)
        {
            AssignedTransport = transport;
        }

        
        public void ClearTransport()
        {
            AssignedTransport = null;
        }
    }

    abstract class Transport
    {
        public string name;
        public bool isBusy;

        public Transport(string name)
        {
            this.name = name;
            isBusy = false;
        }
        public abstract double CalculateCost(Order order);

        public virtual bool CanTake(Order order)
        {
            return !isBusy;
        }
    }

    class Bicycle : Transport
    {
        public Bicycle() : base("Велосипед") { }
        public override double CalculateCost(Order order)
        {
            return 20 + 5 * order.distance;
        }

        public override bool CanTake(Order order)
        {
            return !isBusy && order.weight <= 5 && order.distance <= 10;
        }
    }

    class Car : Transport
    {
        public Car() : base("Машина") { }
        public override double CalculateCost(Order order)
        {
            return 50 + 8 * order.distance + 1 * order.weight;
        }

        public override bool CanTake(Order order)
        {
            return !isBusy && order.weight <= 100;
        }
    }

    class Truck : Transport
    {
        public Truck() : base("Вантажівка") { }

        public override double CalculateCost(Order order)
        {
            return 200 + 15 * order.distance + 0.5 * order.weight;
        }

        public override bool CanTake(Order order)
        {
            return !isBusy && order.weight <= 500;
        }
    }
}
