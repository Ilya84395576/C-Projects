using System;
using System.Collections.Generic;
using System.Text;

namespace Module1
{
    class DeliveryService
    {
        private List<Transport> transports = new List<Transport>();
        private List<Order> activeOrders = new List<Order>();
        private List<Order> history = new List<Order>();

        public void AddTransport(Transport transport)
        {
            transports.Add(transport);
        }

        public void ShowPrices(Order order)
        {
            Console.WriteLine("Вартість доставки:");

            foreach (Transport transport in transports)
            {
                if (transport.CanTake(order))
                {
                    Console.WriteLine($"{transport.name}: " + $"{transport.CalculateCost(order)} грн.");
                }
                else
                {
                    Console.WriteLine($"{transport.name}: недоступний.");
                }
            }
        }
        public void AssignOrder(Order order, Transport transport)
        {
                     
            if (!transports.Contains(transport))
            {
                Console.WriteLine("Такого транспорту немає");
                return;
            }

            
            if (order.AssignedTransport != null)
            {
                Console.WriteLine("Замовлення вже має призначений транспорт.");
                return;
            }
                     
            if (!transport.CanTake(order))
            {
                Console.WriteLine($"{transport.name} не може взяти замовлення.");
                return;
            }

           
            transport.isBusy = true;
            order.AssignTransport(transport);

            activeOrders.Add(order);

            Console.WriteLine($"Замовлення #{order.number} призначено: {transport.name}.");

            return;
        }
        

        public void DeliverOrder(Order order, Transport transport, IPayment payment)
        {
            if (!activeOrders.Contains(order))
            {
                Console.WriteLine("Замовлення не є активним.");
                return;
            }

            if (order.AssignedTransport != transport)
            {
                Console.WriteLine("Це замовлення призначене іншому транспорту.");
                return;
            }

            double cost = transport.CalculateCost(order);

            Console.WriteLine($"\nДоставка замовлення #{order.number}:");

            payment.Pay(cost);

            transport.isBusy = false;
            activeOrders.Remove(order);
            order.ClearTransport();
            history.Add(order);

            Console.WriteLine("Доставку завершено.");
            Console.WriteLine($"{transport.name} тепер вільний.");
        }
        public void ShowActiveOrders()
        {
            Console.WriteLine("Активні замовлення: ");

            if (activeOrders.Count == 0)
            {
                Console.WriteLine("Активних замовлень немає.");
                return;
            }

            foreach (Order order in activeOrders)
            {
                order.Info();
            }
        }
        public void ShowHistory()
        {
            Console.WriteLine("\nІсторія доставок:");

            if (history.Count == 0)
            {
                Console.WriteLine("Історія доставок порожня.");
                return;
            }

            foreach (Order order in history)
            {
                order.Info();
            }
        }
    }
}
