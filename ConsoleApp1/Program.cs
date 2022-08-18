using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //string text = "Room 1501, 15/F.,SPA Centre 53-55 Lockhart Road, Wanchai, HONGKONG ";
            //Console.WriteLine("Total Length: " + text.Length);
            //int count = 0;
            //foreach (var c in text)
            //{
            //    if (char.IsControl(c))
            //    {
            //        Console.WriteLine("Found control character: {0}", (int)c);
            //    }
            //    Console.WriteLine(count++);
            //}

            string text = @"I ordered a Taurus in August and it hasn't been scheduled, I was just wondering if there is something wrong with the order? Or if the queue is just long? Order Number:8028Vehicle Rep:74JTag#: 200L049Description: 2011 TAURUS FWD SELOrdered: 08-AUG- 2010VIN Assigned:VIN#:Scheduled:In Production:Produced:Invoiced:Released:Shipped:Ready:Tax Location: STATE OF MICHIGAN (20 )State Insured:USOB Status:050 - CLEAN UNSCHEDULED ORDER";
            
            Console.WriteLine(text.Length);
            int counter = 0;
            for (int i = 0; i < text.Length; i++)
            {
                if (Char.ConvertToUtf32(text, i) < 32)
                {
                    Console.WriteLine("position " + i + " " + text[i] + " => " + Char.ConvertToUtf32(text, i));
                }
            }
            Console.ReadLine();

            Console.Read();
        }
    }
}
