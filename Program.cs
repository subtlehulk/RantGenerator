using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading;

namespace RantGenerator
{
    class Program
    {
        static void Main(string[] args)
        {
            /*I came up with the idea when I was trying to get to sleep. I wanted to build a oprogram that helped me come up with rant ideas without
            having to sit and think especially when I have other things that I could be working on.

            So this will come with predetermined prompts that will be chosen at **random** so that when we run it, we will have a talking point for us
            we just have to then record and make it entertaining.

            Pseudo code:
            Create Array
            Fill array => this will eventually be either a file that I will add to, or it can be a database that randomly pulls a couple of suggestions
            Get length of array
            Create random number generator based on length
            for loop
                Select random elements
                check to see if cell is filled with a "0" string
                    if yes
                        Pull another
                    If no
                        Print
                        Set element to = "0" so it doesn't pull that again
            (may have to do a modulus check so that it will pull a cell even if there's an odd number of them filled not with "0")
            */


            //Create a new array of type string
            // string[] rants = new string[6];

            // //Fill up the array with some random prompts which I will add to later on.
            // rants[0] = "Coffee shops";
            // rants[1] = "Covid-19";
            // rants[2] = "Gyms";
            // rants[3] = "Gaming";
            // rants[4] = "Nostalgia";
            // rants[5] = "Day trips to seaside towns in the summer";

            string filepath = @"C:\Users\corey\OneDrive\RantGenerator\rants.txt";
            List<string> rants = new List<string>();
            rants = File.ReadAllLines(filepath).ToList();

            //create random number generator for length of array
            Random rantGen = new Random();
            
            Console.WriteLine("Your chosen prompts are:");
            for (int i = 0; i <= 4; i++)
             {
                
                Thread.Sleep(2000);
                 int cell = rantGen.Next(0, rants.Count);
                 while (rants[cell] == "0" || rants[cell] == null)
                 {
                     Console.WriteLine("That element in the list has been used before.");
                     Console.WriteLine("I will pick another one for you.");
                     cell = rantGen.Next(0, rants.Count);

                 }
                     Console.WriteLine(rants[cell]);
                     rants[cell] = "0";
                     File.WriteAllLines(filepath, rants);
                     i++;

                
             }
            // for (int i = 0; i <= rants.Length; i++)
            // {
            //     Console.WriteLine(rants[i]);
            // }
            Console.Read();
        
        }
    }
}
