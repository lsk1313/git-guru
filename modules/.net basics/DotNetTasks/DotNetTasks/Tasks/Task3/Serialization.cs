using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;
using System.Xml.Serialization;
using DotNetTasks.Tasks.Task3.Entities;
using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;

namespace DotNetTasks.Tasks.Task3
{
    public class Serialization
    {
        public string SerializeJson(object type)
        {
            var serializerSettings = new JsonSerializerSettings
            {
                ContractResolver = new CamelCasePropertyNamesContractResolver(),
                Formatting = Formatting.Indented
            };

            var json = JsonConvert.SerializeObject(type, serializerSettings);

            return json;
        }

        public string SerializeJsonAndWriteToFile(object type)
        {
            var json = this.SerializeJson(type);

            using var fileStream = new FileStream("customer.txt", FileMode.OpenOrCreate);

            var buffer = Encoding.UTF8.GetBytes(json);

            fileStream.Write(buffer, 0, buffer.Length);

            return json;
        }

        public Customer DeserializeJson(string json)
        {
            var value = JsonConvert.DeserializeObject<Customer>(json);

            return value;
        }

        public void SerializeXml(object type)
        {
            var xmlSerializer = new XmlSerializer(type.GetType());

            using var fileStream = new FileStream("customer.xml", FileMode.OpenOrCreate);

            xmlSerializer.Serialize(fileStream, type);
        }

        public Customer DeserializeXml(object type)
        {
            var xmlSerializer = new XmlSerializer(type.GetType());

            using var fileStream = new FileStream("customer.xml", FileMode.OpenOrCreate);

            var customer = (Customer)xmlSerializer.Deserialize(fileStream);

            return customer;
        }

        public void SerializeBinary(object type)
        {
            var binaryFormatter = new BinaryFormatter();

            using var fileStream = new FileStream("customer.dat", FileMode.OpenOrCreate);

            binaryFormatter.Serialize(fileStream, type);
        }

        public Customer DeserializeBinary()
        {
            var binaryFormatter = new BinaryFormatter();

            using var fileStream = new FileStream("customer.dat", FileMode.OpenOrCreate);

            var customer = (Customer)binaryFormatter.Deserialize(fileStream);

            return customer;
        }
    }
}
