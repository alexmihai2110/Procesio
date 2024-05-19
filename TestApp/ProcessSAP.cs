using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestApp
{
    public class ProcessSAP : IProcess
    {
        public void Execute()
        {
            Console.WriteLine("This can not be checked");
            //check remains false and send message to WebAPI that the check can not be done
        }
    }
}
