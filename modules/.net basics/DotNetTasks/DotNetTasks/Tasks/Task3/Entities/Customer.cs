using System;
using System.Collections.Generic;
using System.Text;
using System.Xml.Serialization;
using Newtonsoft.Json;

namespace DotNetTasks.Tasks.Task3.Entities
{
    [Serializable]
    public class Customer
    {
        public Customer()
        {
            this.Orders ??= new List<Order>();
        }

        [XmlElement("id")]
        public int Id { get; set; }

        [XmlElement("name")]
        public string Name { get; set; }
        
        [XmlElement("dateTimeRegistration")]
        public DateTime DateTimeRegistration { get; set; }

        [XmlElement("orders")]
        public List<Order> Orders { get; set; }

        public override string ToString()
        {
            var stringBuilder = new StringBuilder();
            stringBuilder.AppendLine($"Name: {this.Name}")
                .AppendLine($"Id: {this.Id}")
                .AppendLine($"DateTime of Registration: {this.DateTimeRegistration}")
                .AppendLine($"Orders count: {this.Orders.Count}");

            return stringBuilder.ToString();
        }
    }

    public class Customer2
    {
        public Customer2()
        {
            this.Orders ??= new List<Order>();
        }

        public int Id { get; set; }

        public string Name { get; set; }
        
        [JsonIgnore]
        public DateTime DateTimeRegistration { get; set; }

        public List<Order> Orders { get; set; }

        public override string ToString()
        {
            var stringBuilder = new StringBuilder();
            stringBuilder.AppendLine($"Name: {this.Name}")
                .AppendLine($"Id: {this.Id}")
                .AppendLine($"Orders count: {this.Orders.Count}");

            return stringBuilder.ToString();
        }
    }
}
