using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Newtonsoft.Json;
using RestSharp;

namespace RestSharpDemo
{
    [TestClass]
    public class RestSharpDemoClass
    {
        string BaseUri = Properties.Settings.Default.Uri;
        int id;

        [TestMethod]
        public void TestGet()
        {
            
            RestClient client = new RestClient(BaseUri);
            RestRequest request = new RestRequest(Method.GET);

            IRestResponse restResponse = client.Execute(request);

            string response = restResponse.Content;
            Assert.AreEqual(200, (int)restResponse.StatusCode);
        }

        [TestMethod]
        public void TestPost()
        {
            string body = Properties.Settings.Default.body;

            RestClient client = new RestClient(BaseUri);
            RestRequest request = new RestRequest(Method.POST);
            request.AddHeader("Accept", "application/json");
            request.Parameters.Clear();
            request.AddParameter("application/json", body, ParameterType.RequestBody);

            IRestResponse response = client.Execute(request);
            string content = response.Content;

            User UserResponse = JsonConvert.DeserializeObject<User>(content);

            string name = UserResponse.name;
            string job = UserResponse.job;
            id = UserResponse.id;

            Assert.AreEqual("Shruthi", name);
            Assert.AreEqual("Engineer", job);
        }

        [TestMethod]
        public void TestPatch()
        {
            string patchbody = Properties.Settings.Default.PatchBody;

            RestClient client = new RestClient(BaseUri);
            RestRequest request = new RestRequest(Method.PATCH);
            request.AddHeader("Accept", "application/json");
            request.Parameters.Clear();
            request.AddParameter("application/json", patchbody, ParameterType.RequestBody);

            IRestResponse response = client.Execute(request);
            string content = response.Content;

            User UserResponse = JsonConvert.DeserializeObject<User>(content);

            string name = UserResponse.name;
            string job = UserResponse.job;
            id = UserResponse.id;

            Assert.AreEqual("Rose", name);
            Assert.AreEqual("Engineer", job);
        }


        [TestMethod]
        public void TestPut()
        {
            string Putbody = Properties.Settings.Default.PutBody;

            RestClient client = new RestClient(BaseUri);
            RestRequest request = new RestRequest(Method.PUT);
            request.AddHeader("Accept", "application/json");
            request.Parameters.Clear();
            request.AddParameter("application/json",Putbody, ParameterType.RequestBody);

            IRestResponse response = client.Execute(request);
            string content = response.Content;

            User UserResponse = JsonConvert.DeserializeObject<User>(content);

            string name = UserResponse.name;
            string job = UserResponse.job;
            id = UserResponse.id;

            Assert.AreEqual("Lily", name);
            Assert.AreEqual("Doctor", job);
        }

        [TestMethod]
        public void TestDelete()
        {
            string body = Properties.Settings.Default.body;

            string ReqBaseUri = BaseUri +"/"+ id;

            RestClient client = new RestClient(ReqBaseUri);
            RestRequest request = new RestRequest(Method.DELETE);

            IRestResponse restResponse = client.Execute(request);

            string response = restResponse.Content;
            Assert.AreEqual(204, (int)restResponse.StatusCode);

             request = new RestRequest(Method.GET);

             restResponse = client.Execute(request);

             response = restResponse.Content;
            Assert.AreEqual(404, (int)restResponse.StatusCode);



        }

        public class User
        {
            public string name { get; set; }
            public string job { get; set; }
            public int id { get; set; }
            public DateTime createdAt { get; set; }
        }
    }
}
