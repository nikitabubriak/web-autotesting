using System.Collections.Generic;
using RestSharp;
using RestSharp.Authenticators;
using Newtonsoft.Json;
using NUnit.Framework;
using ProductAutomation.Apis.Models;
using static ProductAutomation.Utils.Settings.Settings;

namespace ProductAutomation.Apis
{
    public class BaseApiTests
    {
        public static RestClient Client;
        public static IRestRequest Request;
        public static IRestResponse Response;

        public static void SetBaseUriAndAuth()
        {
            Client = new RestClient(baseUrl);
            Client.Authenticator = AuthTwitter();
        }

        private static OAuth1Authenticator AuthTwitter()
        {
            OAuth1Authenticator oAuth1Authenticator =
                OAuth1Authenticator.ForProtectedResource(consumerKey, consumerSecret, accessToken, accessTokenSecret);
            return oAuth1Authenticator;
        }

        public static void PostTweet(string message)
        {
            Request = new RestRequest("update.json", Method.POST);
            Request.AddParameter("status", message, ParameterType.GetOrPost);
            GetResponse();
        }

        public static void GetResponseOfResource(string apiResource)
        {
            Request = new RestRequest();
            Request.Resource = apiResource;
            GetResponse();
        }

        private static void GetResponse()
        {
            Response = Client.Execute(Request);
            //Console.Write("response content: " + Response.Content);
        }

        private static T DeserialiseResponse<T>()
        {
            return JsonConvert.DeserializeObject<T>(Response.Content);
        }

        public static void AssertTweetWasPosted(string tweet)
        {
            var result = DeserialiseResponse<List<HomeTimeline>>();
            //Console.Write("deserialised last tweet: " + result[0].text);
            Assert.True(result[0].text.Contains(tweet));
        }

    }
}
