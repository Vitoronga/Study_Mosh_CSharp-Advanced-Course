using System;
using System.Buffers.Text;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Study_Mosh_CSharp_Advanced.Events
{
    public class VideoEventArgs : EventArgs
    {
        public Video Video { get; set; }

    }

    public class VideoEncoder
    {
        // There are 3 steps to create an event:
        // 1- Define a delegate
        //public delegate void VideoEncodedEventHandler (object source, VideoEventArgs args);
        // 2- Define an event based on that delegate
        //public event VideoEncodedEventHandler VideoEncoded;
        // 3- Raise the event

        // The common way of doing steps 1 and 2 is by using the built-in delegate EventHandler and declare the event referencing it:
        public event EventHandler<VideoEventArgs> VideoEncoded;

        public void Encode(Video video)
        {
            Console.WriteLine("Encoding video...");
            Thread.Sleep(3000);

            OnVideoEncoded(video);
        }

        protected virtual void OnVideoEncoded(Video video)
        {
            if (VideoEncoded != null) VideoEncoded(this, new VideoEventArgs() { Video = video });
        }
    }
}
