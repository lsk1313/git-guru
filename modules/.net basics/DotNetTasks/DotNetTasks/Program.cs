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

            var customer2 = new Customer2
            {
                Name = "CustomerName2",
                DateTimeRegistration = DateTime.Now,
                Id = 2
            };

            IEnumerable<Order> orders = new List<Order>
            {
                new Order
                {
                    Id = 1,
                    Name = "Order1",
                    DateTimeOrdered = DateTime.Now
                },
                new Order
                {
                    Id = 2,
                    Name = "Order2",
                    DateTimeOrdered = DateTime.Now
                },
                new Order
                {
                    Id = 3,
                    Name = "Order3",
                    DateTimeOrdered = DateTime.Now
                }
            };

            customer.Orders.AddRange(orders);
            customer2.Orders.AddRange(orders);

            var serialization = new Serialization();

            var json = serialization.SerializeJson(customer);
            var customerJson = serialization.DeserializeJson(json);
            
            var json2 = serialization.SerializeJsonAndWriteToFile(customer2);
            var customerJson2 = serialization.DeserializeJson(json2);

            serialization.SerializeXml(customer);
            var customerXml = serialization.DeserializeXml(customer);

            serialization.SerializeBinary(customer);
            var customerBinary = serialization.DeserializeBinary();

            Console.Read();
        }
    }
}
