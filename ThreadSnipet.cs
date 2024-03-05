using NetworkSourceSimulator;

namespace OOD
{

    public static partial class OODEntry
    {
        public static class ThreadSnipet
        {
            public static void MessageReceiver()
            {
                NetworkSourceSimulator.NetworkSourceSimulator nss = new NetworkSourceSimulator.NetworkSourceSimulator(
                   Path.Combine(Directory.GetCurrentDirectory(), "example_data.ftr"), 100, 500);
                nss.OnNewDataReady += MessageReader;
                

            }
            public static void test()
            {
                Thread nT = new Thread(new ThreadStart(MessageReceiver));
                nT.Start();
                while(true)
                {
                    string commnad=Console.ReadLine();
                    Console.WriteLine(commnad);
                    if(commnad=="exit")
                        break;
                }
                Console.WriteLine("exited");
                
            }
            public static void MessageReader(object sender, NewDataReadyArgs args)
            {
                Console.WriteLine(args.MessageIndex);
            }
        }
    }

}
