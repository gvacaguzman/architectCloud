using System.Text;

namespace DeliveryPizzaRequest.Models
{
    public class RequestClient : Person
    {
        public string Code { get; set; }

        public string GetJsonValue()
        {
            StringBuilder jsonBuilder = new StringBuilder();
            jsonBuilder.Append(base.GetJsonValue());
            jsonBuilder.Append(string.Format("\"code\": \"{0}\",", Code));
            return jsonBuilder.ToString();
        }
    }
}