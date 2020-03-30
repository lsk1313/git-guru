using System;
using System.Collections.Generic;

namespace DotNetTasks.Tasks.Task3.Entities
{
    [Serializable]
    public class Customer
    {
        public Customer()
        {
            this.Orders ??= new List<Order>();
        }

        public int Id { get; set; }

        public string Name { get; set; }

        public DateTime DateTimeRegistration { get; set; }

        public List<Order> Orders { get; set; }
    }
}
