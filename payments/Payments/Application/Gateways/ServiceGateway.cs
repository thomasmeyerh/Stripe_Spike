using System;
using System.Net;
using RestSharp;

namespace Application.Gateways
{
    public class ServiceGateway
    {
        string baseAddress = "https://localhost:6001/api/Subscriptions/add-subscription";
        
        RestClient c = new RestClient();
        
        public ServiceGateway()
        {
            ServicePointManager.ServerCertificateValidationCallback += (sender, cert, chain, sslPolicyErrors) => true;
            c.BaseUrl = new Uri(baseAddress);
        }
        
        public bool CreateItem(string itemName)
        {
            var request = new RestRequest( Method.POST);
            var sub = new SubscriptionDTO() {Name = itemName};
            request.AddJsonBody(sub);
            var response = c.Execute(request);
            return response.IsSuccessful;
        }
    }
}

public class SubscriptionDTO {
    public string Name { get; set; }
}