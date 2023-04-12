namespace Study_Mosh_CSharp_Advanced.Events
{
    public class MailService
    {
        public void OnVideoEncoded(object source, VideoEventArgs args)
        {
            Console.WriteLine("MailService: Sending an email... " + args.Video.Title);
        }
    }
}
