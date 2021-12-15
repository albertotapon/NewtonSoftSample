using System;
using System.Collections.Generic;
using System.IO;
using System.Text.Json;
using System.Threading.Tasks;

namespace TextJSonSample
{
    internal class Program
    {
        public static async Task Serialize<T>(T obj, string path)
        {
            string jsonString = JsonSerializer.Serialize(obj);

            using FileStream createStream = File.Create(path);
            await JsonSerializer.SerializeAsync<T>(createStream, obj);
            await createStream.DisposeAsync();


            //File.WriteAllText(filePath, jsonString);
        }

        public static async Task<T> Deserialize<T>(string path)
        {
            using FileStream createStream = File.OpenRead(path);

            var obj = await JsonSerializer.DeserializeAsync<T>(createStream);

            return obj;
        }

        static async Task Main(string[] args)
        {
            var data = new Persona
            {
                idCliente = Guid.NewGuid(),
                Name = "Henry",
                apellidos = "Diculo"
            };
            data.Coches = new List<Coches>(
                new Coches()
                {

                }

                ) ;

            var data2 = new Persona
            {
                idCliente = Guid.NewGuid(),
                Name = "Alberto",
                apellidos = "Cuesta Muñoz"
            };

            var data3 = new Persona
            {
                idCliente = Guid.NewGuid(),
                Name = "César",
                apellidos = "Árevalo Salazar"
                
            };

            var data4 = new Persona
            {
                idCliente = Guid.NewGuid(),
                Name = "David",
                apellidos = "Cano Gutierrez"
            };

            Console.WriteLine("Object before serialization:");
            Console.WriteLine("----------------------------");
            Console.WriteLine();
            Console.WriteLine(data);
            Console.WriteLine(data2);
            Console.WriteLine(data3);
            Console.WriteLine(data4);

            await Serialize(data, "./fichero.json");
            await Serialize(data2, "./fichero2.json");
            await Serialize(data3, "./fichero3.json");
            await Serialize(data4, "./fichero4.json");

            var deserialized = await Deserialize<Persona>("./fichero.json");
            var deserialized2 = await Deserialize<Persona>("./fichero2.json");
            var deserialized3 = await Deserialize<Persona>("./fichero3.json");
            var deserialized4 = await Deserialize<Persona>("./fichero4.json");

            Console.WriteLine("Deserialized (json) string:");
            Console.WriteLine("---------------------------");
            Console.WriteLine();
            Console.WriteLine(deserialized);
            Console.WriteLine(deserialized2);
            Console.WriteLine(deserialized3);
            Console.WriteLine(deserialized4);
        }
    }
}