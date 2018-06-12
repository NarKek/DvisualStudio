using DvisualStudio.Core;
using DvisualStudio.Core.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    class Program
    {
        static void Main(string[] args)
        {
            IEnumerable<Concert> cons = Factory.Instance.GetRepository().Concerts;
        }
    }
}
