using System;
using System.Collections.Generic;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;
using System.Xml.Serialization;
using DotNetTasks.Abstractions.Interfaces;
using DotNetTasks.Tasks.Task3.Entities;
using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;

namespace DotNetTasks.Tasks.Task3
{
    public class Serialization : ICommand
    {
        public void Execute()
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

            var json = SerializeJson(customer);
            var customerJson = DeserializeJson(json);
            Console.WriteLine($"Customer from json: {customerJson}");

            var json2 = SerializeJsonAndWriteToFile(customer2);
            var customerJson2 = DeserializeJson(json2);
            Console.WriteLine($"Customer from json2: {customerJson2}");

            SerializeXml(customer);
            var customerXml = DeserializeXml(customer);
            Console.WriteLine($"Customer from xml: {customerXml}");

            SerializeBinary(customer);
            var customerBinary = DeserializeBinary();
            Console.WriteLine($"Customer from binary: {customerBinary}");
        }

        public int Number => 3;

        public string DisplayName => "Task 3: Serialization";

        private static string SerializeJson(object type)
        {
            var serializerSettings = new JsonSerializerSettings
            {
                ContractResolver = new CamelCasePropertyNamesContractResolver(),
                Formatting = Formatting.Indented
            };

            var json = JsonConvert.SerializeObject(type, serializerSettings);

            return json;
        }

        private static string SerializeJsonAndWriteToFile(object type)
        {
            var json = SerializeJson(type);

            using var fileStream = new FileStream("customer.txt", FileMode.OpenOrCreate);

            var buffer = Encoding.UTF8.GetBytes(json);

            fileStream.Write(buffer, 0, buffer.Length);

            return json;
        }

        private static Customer DeserializeJson(string json)
        {
            var value = JsonConvert.DeserializeObject<Customer>(json);

            return value;
        }

        private static void SerializeXml(object type)
        {
            var xmlSerializer = new XmlSerializer(type.GetType());

            using var fileStream = new FileStream("customer.xml", FileMode.OpenOrCreate);

            xmlSerializer.Serialize(fileStream, type);
        }

        private static Customer DeserializeXml(object type)
        {
            var xmlSerializer = new XmlSerializer(type.GetType());

            using var fileStream = new FileStream("customer.xml", FileMode.OpenOrCreate);

            var customer = (Customer)xmlSerializer.Deserialize(fileStream);

            return customer;
        }

        private static void SerializeBinary(object type)
        {
            var binaryFormatter = new BinaryFormatter();

            using var fileStream = new FileStream("customer.dat", FileMode.OpenOrCreate);

            binaryFormatter.Serialize(fileStream, type);
        }

        private static Customer DeserializeBinary()
        {
            var binaryFormatter = new BinaryFormatter();

            using var fileStream = new FileStream("customer.dat", FileMode.OpenOrCreate);

            var customer = (Customer)binaryFormatter.Deserialize(fileStream);

            return customer;
        }
    }
}
