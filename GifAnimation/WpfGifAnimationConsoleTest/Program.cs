using GifAnimationCore.Decoding;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace GifAnimationConsoleTest
{
    class Program
    {
        static void Main(string[] args)
        {
            string path = @"d:\200.gif";

            var stream = File.OpenRead(path);
            GifHeader.ReadAsync(stream).ContinueWith(p =>
            {
                var gifFileHeader = p.Result;

                Console.WriteLine(gifFileHeader.Signature);
                Console.WriteLine(gifFileHeader.Version);
                Console.WriteLine(gifFileHeader.LogicalScreenDescriptor.Width);
                Console.WriteLine(gifFileHeader.LogicalScreenDescriptor.Height);
                Console.WriteLine(gifFileHeader.LogicalScreenDescriptor.IsGlobalColorTableSorted);
                Console.WriteLine(gifFileHeader.LogicalScreenDescriptor.GlobalColorTableSize);
                stream.Close();
            });


            Console.ReadLine();
        }
    }
}
