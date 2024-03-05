using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NetworkSourceSimulator;
namespace OOD
{
    public static class CLI
    {
        private static IDataSource dataSource;
        private static List<object> objects;
        private static Thread ReadingThread;
        public static void Init(string filename)
        {
            objects=new List<object>();
            dataSource=new  NetworkSourceSimulator.NetworkSourceSimulator(
               Path.Combine(Directory.GetCurrentDirectory(), filename), 1000, 2000);
        }
        public static void Run()
        {
            if(dataSource==null||objects==null)
            {
                throw new UnauthorizedAccessException("cant run before init");
            }

            while(true)
            {
                string command =Console.ReadLine();
                if(command == "exit")
                {
                    break;
                }
                else if(command=="print")
                {

                }
            }
        }

    }
}
