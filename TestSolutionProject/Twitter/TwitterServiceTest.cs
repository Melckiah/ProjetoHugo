using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using TweetSharp;
using System.Net;
using System.Configuration;
using System.Diagnostics;
using System.IO;
using System.Collections.Generic;
using System.Linq;

namespace TestSolutionProject.Twitter
{
    [TestClass]
    public class TwitterServiceTest
    {
        private readonly string _consumerKey;
        private readonly string _consumerSecret;
        private readonly string _accessToken;
        private readonly string _accessTokenSecret;

        public TwitterServiceTest()
        {
            _consumerKey = ConfigurationManager.AppSettings["ConsumerKey"];
            _consumerSecret = ConfigurationManager.AppSettings["ConsumerSecret"];
            _accessToken = ConfigurationManager.AppSettings["AccessToken"];
            _accessTokenSecret = ConfigurationManager.AppSettings["AccessTokenSecret"];
        }

        [TestMethod]        
        public void Can_get_request_token()
        {
            var service = new TwitterService(_consumerKey, _consumerSecret);
            var requestToken = service.GetRequestToken();

            Assert.AreEqual(service.Response.StatusCode, HttpStatusCode.OK);
            Assert.IsNotNull(requestToken);
        }

        [TestMethod]
        public void Can_verify_credentials()
        {
            var service = GetAuthenticatedService();
            var user = service.VerifyCredentials(new VerifyCredentialsOptions());
            Assert.IsNotNull(user);
        }

        [TestMethod]        
        public void Can_tweet()
        {
            var service = GetAuthenticatedService();
           
            var status = "Testando com Bodão";
            var tweet = service.SendTweet(new SendTweetOptions { Status = status });

            Assert.AreEqual(service.Response.StatusCode, HttpStatusCode.OK);
            Assert.IsNotNull(tweet);
            Assert.AreNotEqual(0, tweet.Id);
        }

        [TestMethod]        
        public void Can_tweet_with_geo()
        {            
            var service = GetAuthenticatedService();
            var status = "Teste" + DateTime.UtcNow.Ticks;
            var tweet = service.SendTweet(new SendTweetOptions { Status = status, Lat = -27.80, Long = -50.30 });

            Assert.AreEqual(service.Response.StatusCode, HttpStatusCode.OK);
            Assert.IsNotNull(tweet);
            Assert.AreNotEqual(0, tweet.Id);
        }

        [TestMethod]        
        public void Can_tweet_with_image()
        {
            var service = GetAuthenticatedService();
            using (var stream = new FileStream("siuniplac.jpg", FileMode.Open))
            {
                var tweet = service.SendTweetWithMedia(new SendTweetWithMediaOptions
                {
                    Status = "Teste" + DateTime.UtcNow.Ticks,
                    Images = new Dictionary<string, Stream> { { "test", stream } }
                });
                Assert.IsNotNull(tweet);
                Assert.AreNotEqual(0, tweet.Id);
            }

        }

        [TestMethod]
        public void Can_get_entities_on_timeline()
        {
            var service = GetAuthenticatedService();
            var tweets = service.ListTweetsOnHomeTimeline(new ListTweetsOnHomeTimelineOptions());
            

            foreach (var tweet in tweets)
            {
                Assert.IsNotNull(tweet.Entities);
                if (tweet.Entities.HashTags.Any())
                {
                    foreach (var hashtag in tweet.Entities.HashTags)
                    {
                        Assert.IsFalse(string.IsNullOrEmpty(hashtag.Text));

                    }
                }
                if (tweet.Entities.Urls.Count() > 0)
                {
                    foreach (var url in tweet.Entities.Urls)
                    {
                        Assert.IsFalse(string.IsNullOrEmpty(url.Value));
                    }
                }
                if (tweet.Entities.Mentions.Count() > 0)
                {
                    foreach (var mention in tweet.Entities.Mentions)
                    {
                        Assert.IsFalse(string.IsNullOrEmpty(mention.ScreenName));
                    }
                }
            }
        }

        [TestMethod]
        public void Can_get_tweet_mentions()
        {
            var service = GetAuthenticatedService();
            var tweets = service.ListTweetsMentioningMe(new ListTweetsMentioningMeOptions());
            Assert.IsNotNull(tweets);
        }

        /// <summary>
        /// Esse metodo de teste deve ser rodado somente um unica vez
        /// o objetivo dele é autorizar o aplicativo na conta do twitter 
        /// </summary>

        [TestMethod]
        [Ignore]
        public void Can_exchange_for_access_token()
        {
            var service = new TwitterService(_consumerKey, _consumerSecret);
            var requestToken = service.GetRequestToken();

            var uri = service.GetAuthorizationUri(requestToken);
            Process.Start(uri.ToString());

            Console.WriteLine("Press the any key when you have confirmation of your code transmission.");
            var verifier = "3828390"; // <-- Debugger breakpoint and edit with the actual verifier

            OAuthAccessToken accessToken = service.GetAccessToken(requestToken, verifier);
            Assert.AreEqual(service.Response.StatusCode, HttpStatusCode.OK);
            Assert.IsNotNull(accessToken);
        }

        private TwitterService GetAuthenticatedService()
        {
            var service = new TwitterService(_consumerKey, _consumerSecret);
            service.TraceEnabled = true;
            service.AuthenticateWith(_accessToken, _accessTokenSecret);
            return service;
        }
    }
}
