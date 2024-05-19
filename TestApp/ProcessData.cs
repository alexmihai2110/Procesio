using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestApp
{
    public class ProcessData : IProcess
    {
        public void Execute()
        {
            Console.WriteLine("This can be checked");
            //check is true and send message to WebAPI that the check was done
        }
    }
}
