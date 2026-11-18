using System;
using System.Collections.Generic;
using System.Text;

namespace Module1
{
    interface IPayment
    {
        void Pay(double amount);
    }

    class CardPayment : IPayment
    {
        public void Pay(double amount)
        {
            Console.WriteLine($"Оплата карткою: {amount} грн.");
        }
    }

    class CashPayment : IPayment
    {
        public void Pay(double amount)
        {
            Console.WriteLine($"Оплата готівкою: {amount} грн.");
        }
    }
}
