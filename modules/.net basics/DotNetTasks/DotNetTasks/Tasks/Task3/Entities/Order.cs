using System;
using System.Xml.Serialization;
using Newtonsoft.Json;

namespace DotNetTasks.Tasks.Task3.Entities
{
    [Serializable]
    public class Order
    {
        public Order() { }

        public int Id { get; set; }

        public string Name { get; set; }

        public DateTime DateTimeOrdered { get; set; }

        [JsonIgnore]
        [XmlIgnore]
        [field: NonSerialized]
        public Customer Customer { get; set; }
    }
}
