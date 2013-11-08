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
            var image1 = new Bitmap(@"D:\Bitmap1.bmp", false);
            var image2 = new Bitmap(@"D:\Bitmap2.bmp", false);
            var image3 = new Bitmap(@"D:\Bitmap3.bmp", false);
            var image4 = new Bitmap(@"D:\Bitmap4.bmp", false);
           
            // create template matching algorithm's instance
            // use zero similarity to make sure algorithm will provide anything
            var aa = new ExhaustiveTemplateMatching(0);
            var ab = new ExhaustiveTemplateMatching(0);
            var ac = new ExhaustiveTemplateMatching(0);

            // compare two images
            var matchings12 = aa.ProcessImage(image1, image2);
            var matchings13 = ab.ProcessImage(image1, image3);
            var matchings14 = ac.ProcessImage(image1, image4);
            
            // check similarity level
            Console.WriteLine("{0}\n{1}\n{2}", matchings12[0].Similarity, matchings13[0].Similarity, matchings14[0].Similarity);


            // compare similarity levels and return result
            if (matchings12[0].Similarity > matchings13[0].Similarity && matchings12[0].Similarity > matchings14[0].Similarity)
            {
                
                    Console.WriteLine("Image 2 is best match");
            }

            if (matchings13[0].Similarity > matchings12[0].Similarity && matchings13[0].Similarity > matchings14[0].Similarity)
            {

                Console.WriteLine("Image 3 is best match");
            }
            else
            {
                Console.WriteLine("Image 4 is best match");
            }
        }
}