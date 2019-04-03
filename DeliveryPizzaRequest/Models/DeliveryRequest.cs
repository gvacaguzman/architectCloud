using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;

namespace DeliveryPizzaRequest.Models
{
    public class DeliveryRequest
    {
        public int Id { get; set; }
        public string RequestStatus { get; set; }
        public string RequestDate { get; set; }
        public RequestClient RequestClient { get; set; }
        public RequestDetail RequestDetail { get; set; }
        public DeliveryMan DeliveryMan { get; set; }

        public string GetJsonValue()
        {
            StringBuilder jsonBuilder = new StringBuilder();
            jsonBuilder.Append(string.Format("\"request status\": \"{0}\",", RequestStatus));
            jsonBuilder.Append(string.Format("\"request date\": \"{0}\",", RequestDate));
            jsonBuilder.Append(string.Format("\"request client code\": \"{0}\",", RequestClient.Code));
            jsonBuilder.Append(string.Format("\"request details code\": \"{0}\",", RequestDetail.Code));
            jsonBuilder.Append(string.Format("\"delivery person code\": \"{0}\"", DeliveryMan.Code));
            return jsonBuilder.ToString();
        }
    }
}