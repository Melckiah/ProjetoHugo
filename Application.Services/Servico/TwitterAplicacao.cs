using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TweetSharp;

namespace Applications.Services.Servico
{
    public class TwitterAplicacao
    {
        string _consumerKey;
        string _consumerSecret;
        string _accessToken;
        string _accessTokenSecret;

        public TwitterAplicacao()
        {
            _consumerKey = "SA26P2HdmslCsaFJhncY0rRtW";
            _consumerSecret = "4cX7n3n0sY0Hjiaq8vtXYNr2Eqvjqa4ZnSpHy29FwFiGjGEnjq";
            _accessToken = "749005178095927297-pcnjkwltr5jq3vxw7junsHQoIXZzt31";
            _accessTokenSecret = "FRIDiddL7ZP3WVUtTg5k8tXYrrAQervz1lmpn5y8c5AAt";
        }
        public TwitterService GetAuthenticatedService()
        {
            var service = new TwitterService(_consumerKey, _consumerSecret);
            service.TraceEnabled = true;
            service.AuthenticateWith(_accessToken, _accessTokenSecret);
            return service;
        }


        public void Criar()
        {
            var service = GetAuthenticatedService();


            var status = "VINHO CRIADO";
            var tweet = service.SendTweet(new SendTweetOptions { Status = status });


        }




    }
}
