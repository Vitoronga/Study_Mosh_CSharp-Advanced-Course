using Study_Mosh_CSharp_Advanced.Events;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Study_Mosh_CSharp_Advanced.ExceptionHandling
{
    public class YoutubeAPI
    {
        public List<Video2> GetVideos(string user)
        {
            try
            {
                // Access Youtube web service
                // Read the data
                // Create a list of Video objects

                throw new Exception("Oops, some low level youtube exception.");
            }
            catch (Exception ex)
            {
                throw new YoutubeException("Could not fetch the videos from Youtube.", ex);
            }

            return new List<Video2>();
        }
    }
}
