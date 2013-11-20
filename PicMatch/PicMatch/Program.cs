using System;
using System.Drawing;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AForge;
using AForge.Imaging;


namespace PicMatch
{

    class Program
    {
        static void Main(string[] args)
        {
            var image1 = new Bitmap(@"C:\Users\Julian Sandiford\Documents\GitHub\PicMatch\PicMatch\PicMatch\images\Bitmap2.bmp", false);
            var image2 = new Bitmap(@"C:\Users\Julian Sandiford\Documents\GitHub\PicMatch\PicMatch\PicMatch\images\Bitmap1.bmp", false);
            ExhaustiveTemplateMatching tm = new ExhaustiveTemplateMatching( 0 );
            TemplateMatch[] matchings = tm.ProcessImage(image1, image2);
            var MatchScore = matchings[0].Similarity;
            MatchScore = MatchScore * 100;
            Console.WriteLine("The images match " + MatchScore + "%");
            Console.ReadLine();
        }

        
    }
}
