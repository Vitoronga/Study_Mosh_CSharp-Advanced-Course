﻿namespace Study_Mosh_CSharp_Advanced.Delegates
{
    public class PhotoFilters
    {
        public void ApplyBrightness(Photo photo)
        {
            Console.WriteLine("Apply Brightness");

        }

        public void ApplyContrast(Photo photo)
        {
            Console.WriteLine("Apply Contrast");
        }

        public void Resize(Photo photo)
        {
            Console.WriteLine("Resize");
        }
    }
}
