namespace Module1
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.OutputEncoding = System.Text.Encoding.UTF8;

            DeliveryService service = new DeliveryService();

            Bicycle bicycle = new Bicycle();
            Car car = new Car();
            Truck truck = new Truck();

            service.AddTransport(bicycle);
            service.AddTransport(car);
            service.AddTransport(truck);

            Order order1 = new Order(1, "Фольга", 2, 5);
            Order order2 = new Order(2, "Побутова техніка", 100, 20);
            Order order3 = new Order(3, "Меблі", 300, 32);


            Console.WriteLine("Замовлення 1:");
            order1.Info();
            service.ShowPrices(order1);

            service.AssignOrder(order1, bicycle);

            Console.WriteLine("\nПеревірка зайнятого транспорту");
            service.AssignOrder(order2, bicycle);

            service.ShowActiveOrders();

            service.DeliverOrder(order1, car, new CardPayment());
            service.DeliverOrder(order1, bicycle, new CardPayment());

            Console.WriteLine("\nЗамовлення 2");
            order2.Info();
            service.ShowPrices(order2);

            service.AssignOrder(order2, car);

            service.DeliverOrder(order2, car, new CardPayment());

                      
            Console.WriteLine("\nЗамовлення 3");
            order3.Info();
            service.ShowPrices(order3);

            
            service.AssignOrder(order3, truck);

            service.DeliverOrder(order3, truck, new CardPayment());

            Console.WriteLine("\nЗамовлення 4");
            Order order4 = new Order(4, "Іжа", 3, 4);

            order4.Info();
            service.ShowPrices(order4);


            service.AssignOrder(order4, bicycle);

            service.DeliverOrder(order4, bicycle, new CardPayment());

            service.ShowActiveOrders();
            service.ShowHistory();

            Console.WriteLine("\nРоботу завершено");
        }
    }
}
