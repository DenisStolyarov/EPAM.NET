using System;
using NLog;

namespace Address
{
    	private static readonly Logger logger = LogManager.GetCurrentClassLogger();

        static void Main(string[] args)
        {
            var path = "Addresses.txt";
            AddressReader addressReader = new AddressReader(path);
            addressReader.logger = logger;
            var addresses = addressReader.ReadAddresses();
            AddressWriter addressWriter = new AddressWriter(addresses);
            addressWriter.WriteToXml();
            Console.ReadLine();
        }
    }
}