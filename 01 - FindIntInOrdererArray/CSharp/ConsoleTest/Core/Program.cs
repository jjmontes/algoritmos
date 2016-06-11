using System;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Reflection;

namespace ConsoleTest.Core
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Iniciando ConsoleTest: Ejercicio 01 - FindIntInOrdererArray");
            var types = Assembly.GetExecutingAssembly().GetTypes().Where(t => t.GetInterfaces().Contains(typeof(IExercise)));
            if (types.Any())
            {
                var lines = File.ReadAllLines(@"Data\data.txt");
                foreach (var line in lines)
                {
                    var chunk = line.Split('|');
                    var vector = chunk[0].Split(',').Select(n => Convert.ToInt32(n)).ToArray();
                    var number = Convert.ToInt32(chunk[1]);
                    var expected = Convert.ToInt32(chunk[2]);

                    foreach (var type in types)
                    {
                        var watch = new Stopwatch();
                        var o = Activator.CreateInstance(type, new object[] { });
                        var method = type.GetMethod("FindIntInOrdererArray", new Type[] { typeof(int[]), typeof(int) });
                        watch.Start();
                        var result = method.Invoke(o, new object[] { vector, number });
                        watch.Stop();

                        Console.WriteLine("{0}: Ticks de proceso: {1}.", type.Name, watch.ElapsedTicks);
                        Console.WriteLine("Esperaba: {0}. Resultado: {1}. {2}\n", expected, result, expected == Convert.ToInt32(result) ? "OK" : "er");
                    }
                }
            }
            else
            {
                Console.WriteLine(" No hay código que implemente la clase IExercise.");
            }

            Console.WriteLine("Pruebas terminadas.");
            Console.ReadKey();
        }
    }
}
