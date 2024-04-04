using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;
using NetworkSourceSimulator;
using OOD.Factories;
using OOD.Iterators;
using OOD.Objects;
using OOD.Serializers;
using OOD.Visitors;
namespace OOD
{
    public static class CLI
    {
        private static IDataSource dataSource;
        private static List<IMyObject> objects;
        private static Dictionary<string, IBinaryFactory> factories;
        private static Thread ReadingThread;
        private static Mutex mut;
        private static List<byte[]> test;
        public static void Init(string filename)
        {
            objects=new List<IMyObject>();
            factories = new Dictionary<string, IBinaryFactory>()
            {
                { "NCR", new CrewBinaryFactory() },
            { "NPA", new PassengerBinaryFactory() },
            { "NCA", new CargoBinaryFactory() },
            { "NCP", new CargoPlaneBinaryFactory() },
            { "NPP", new PassengerPlaneBinaryFactory() },
            { "NAI", new AirportBinaryFactory() },
            { "NFL", new FlightBinaryFactory() }
            };
            mut = new Mutex();
            dataSource=new  NetworkSourceSimulator.NetworkSourceSimulator(
               Path.Combine(Directory.GetCurrentDirectory(), filename), 100, 200);
        }
        public static void Run()
        {
            if(dataSource==null||objects==null)
            {
                throw new UnauthorizedAccessException("cant run before init");
            }
            ReadingThread = new Thread(new ThreadStart(MessageReceiver))
            {
                IsBackground = true
            };
            ReadingThread.Start();
            while (true)
            {
                string command =Console.ReadLine();
                if(command == "exit")
                {
                    break;
                }
                else if(command=="print")
                {
                    SaveSnapshot();
                }
                else if (command=="report")
                {
                    generateReport();
                }
            }
            try
            {
                ReadingThread.Abort();
            }
            catch (Exception tae)
            {
                Console.WriteLine("Aborting working Thread");
            }
            Environment.Exit(0);
        }
        public static void MessageReader(object sender, NewDataReadyArgs args)
        {
            
            byte[] message = dataSource.GetMessageAt(args.MessageIndex).MessageBytes;
            IMyObject o = factories[Encoding.ASCII.GetString(message, 0, 3)].produce(message);
            mut.WaitOne();
            objects.Add(o);
            mut.ReleaseMutex();
        }
        
        public static void MessageReceiver()
        {

            dataSource.OnNewDataReady += MessageReader;
            dataSource.Run();

        }
        private static void SaveSnapshot()
        {
            ISerializer ser = new JsonSerializer();
            string filename=$"snapshot_{DateTime.Now.ToString("HH_mm_ss")}.json";
            mut.WaitOne();
            ser.serialize(filename, objects);
            Console.WriteLine("Saving Snapshot");
            mut.ReleaseMutex();
        }

       // new command stuff
        public static List<IReportable> GetReportables()
        {
            List<IReportable> rep = new List<IReportable>();
            foreach (var ent in objects)
            {
                if (typeof(IReportable).IsAssignableFrom(ent.GetType()))
                {
                    rep.Add((IReportable)ent);
                }
            }
            return rep;
        }
        public static void generateReport()
        {
            List<IReportable> reportables = GetReportables();
            List<IMediaVisitor> visitors = new List<IMediaVisitor>() { new NewsPaper("MiniGazeta"),
            new Television(),new Radio("Radio niemamsilywymyslacsmiesznychnazwwiecbedziedlyga:)")};
            NewsGenerator ng=new NewsGenerator(reportables, visitors);
            string? news=ng.GenerateNextNews();
            while(news!=null)
            {
                Console.WriteLine(news);
                news = ng.GenerateNextNews();
            }

        }
    }
}
