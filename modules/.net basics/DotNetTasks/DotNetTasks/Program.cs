using DotNetTasks.Tasks.Task3;
using DotNetTasks.Tasks.Task3.Entities;
using System;
using System.Collections.Generic;

namespace DotNetTasks
{
    public static class Program
    {
        private static void Main(string[] args)
        {
            var customer = new Customer
            {
                Name = "CustomerName",
                DateTimeRegistration = DateTime.Now,
                Id = 1
            };

            IEnumerable<Order> orders = new List<Order>
            {
                new Order
                {
                    Id = 1,
                    Customer = customer,
                    Name = "Order1",
                    DateTimeOrdered = DateTime.Now
                },
                new Order
                {
                    Id = 2,
                    Customer = customer,
                    Name = "Order2",
                    DateTimeOrdered = DateTime.Now
                },
                new Order
                {
                    Id = 3,
                    Customer = customer,
                    Name = "Order3",
                    DateTimeOrdered = DateTime.Now
                }
            };

            customer.Orders.AddRange(orders);

            var serialization = new Serialization();

            var json = serialization.SerializeJson(customer);
            var customerJson = serialization.DeserializeJson(json);

            serialization.SerializeXml(customer);
            var customerXml = serialization.DeserializeXml(customer);

            serialization.SerializeBinary(customer);
            var customerBinary = serialization.DeserializeBinary(customer);

            Console.Read();
        }
    }
}
