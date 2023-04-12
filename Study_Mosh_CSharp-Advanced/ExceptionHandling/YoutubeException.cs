namespace Study_Mosh_CSharp_Advanced.ExceptionHandling
{
    public class YoutubeException : Exception
    {
        public YoutubeException(string message, Exception innerException) : base (message, innerException) 
        {

        }
    }
}
