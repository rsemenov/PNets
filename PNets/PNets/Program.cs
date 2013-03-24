using System;
using System.Linq;
using System.Text;
using System.IO;

namespace PNets
{
    class Program
    {
        static void Main(string[] args)
        {
            if (args.Length < 1)
            {
                Console.WriteLine("Petri Net file does not set. Please enter file with Petri Net as first command line parameter.");
                return;
            }

            if (!File.Exists(args[0]))
            {
                Console.WriteLine(
                    String.Format("File {0} does not exists. Please enter file with Petri Net as first command line parameter.", args[0]));
                return;
            }

            var net = PNets.Core.PetriNet.Parse(args[0]);
            var isBounded = net.IsStructuralBounded();
            Console.WriteLine(String.Format("Given PetriNet is {0}", isBounded? "structural bounded" : "structural unbounded"));
        }
    }
}
