using System;
using System.Collections.Generic;
using System.IO;
using System.Net;
using TweetSharp;

namespace TwitterBot
{
    class Program
    {
        private static string _consumer_key = "rHq"; //Use your own consumer key
        private static string _consumer_key_secret = "T7G0xTncS"; //Use your own consumer key
        private static string _access_token = "I00H4"; //Use your own access token
        private static string _access_token_secret = "3Sa6US"; //Use your own access token secret
        private static TwitterService twitterService = new TwitterService(_consumer_key, _consumer_key_secret, _access_token, _access_token_secret);

        private static int _currentImageId = 0;
        private static List<string> _imageList = new List<string>
        {
            $@"C:\Users\Nikos\Desktop\mario.png" //Path to your own image
        };


        static void Main(string[] args)
        {
            Console.WriteLine($"<{DateTime.Now}> - Open Bot");

            var tweet = "Hello World"; //comment this line if you want to upload text+image
            SendTweet(tweet); //comment this line if you want to upload text+image


            var imageText = "Tweet with image"; //Comment this if you want to upload only text
            SendMediaTweet(imageText, _currentImageId); //Comment this if you want to upload only text


            Console.ReadLine();
        }


        private static void SendTweet(string _status)
        {
            twitterService.SendTweet(new SendTweetOptions { Status = _status }, (tweet, response) => { });
        }


        private static void SendMediaTweet(string _status, int imageId)
        {
            using (var stream = new FileStream(_imageList[imageId], FileMode.Open))
            {
                twitterService.SendTweetWithMedia(new SendTweetWithMediaOptions
                {
                    Status = _status,
                    Images = new Dictionary<string, Stream> { { _imageList[imageId], stream } }
                });
            }
        }

    }
}
