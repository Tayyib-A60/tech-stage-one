using System;
using SocksLaundryLib;

namespace SocksLaundry
{
    class Program
    {
        static void Main(string[] args)
        {
            var classLib = new ClassLib();
            int[] cleanPile = new int[] { 1, 2, 3, 1, 2, 3 };
            int[] dirtyPile = new int[] { 3, 3, 4, 1, 2, 7, 9 };
            classLib.GetMaximumPairOfSocks(2, cleanPile, dirtyPile);
            Console.WriteLine("SocksLaundry");
        }
    }
}
