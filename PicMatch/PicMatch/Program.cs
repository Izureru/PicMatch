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

            var image1 = new Bitmap(@"D:\GitHub\PicMatch\PicMatch\PicMatch\images\Bitmap2.bmp", false);
            var image2 = new Bitmap(@"D:\GitHub\PicMatch\PicMatch\PicMatch\images\Bitmap1.bmp", false);

//The class also can be used to get similarity level between two image of the same size, which can be useful to get information about how different/similar are images: 
// create template matching algorithm's instance
// use zero similarity to make sure algorithm will provide anything
ExhaustiveTemplateMatching tm = new ExhaustiveTemplateMatching( 0 );
// compare two images
TemplateMatch[] matchings = tm.ProcessImage(image1, image2);
// check similarity level

            
  Console.WriteLine(matchings[0].Similarity);
            Console.ReadLine();

            //if ( matchings[0].Similarity > 0.95 )
//{

//    // do something with quite similar images
//}
        }

        
    }
}
