using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace ConsoleApp
{
    internal class ProductDeserializer
    {        
        public void SerializeProducts(Stream stream, IProduct product)
        {
            JsonSerializer.Serialize(stream, product);
        }
        public IProduct DeserializeProducts(Stream stream)
        {
            return JsonSerializer.Deserialize<IProduct>(stream)
             ?? throw new InvalidOperationException("Не удалось десериализовать объект");
        }
    }
}
