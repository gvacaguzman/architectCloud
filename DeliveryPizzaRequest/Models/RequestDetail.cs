using System.Text;

namespace DeliveryPizzaRequest.Models
{
    public class RequestDetail 
    {
        public string Code { get; set; }
        public string Flavor1 { get; set; }
        public string Flavor2 { get; set; }
        public string Flavor3 { get; set; }
        public string Flavor4 { get; set; }
        public string Size { get; set; }
        public string OtherInfo { get; set; }
        public string Price { get; set; }

        public string GetJsonValue()
        {
            StringBuilder jsonBuilder = new StringBuilder();
            jsonBuilder.Append(string.Format("\"code\": \"{0}\",", Code));
            jsonBuilder.Append(string.Format("\"flavor1\": \"{0}\",", Flavor1));
            jsonBuilder.Append(string.Format("\"flavor2\": \"{0}\",", Flavor2));
            jsonBuilder.Append(string.Format("\"flavor3\": \"{0}\",", Flavor3));
            jsonBuilder.Append(string.Format("\"flavor4\": \"{0}\",", Flavor4));
            jsonBuilder.Append(string.Format("\"size\": \"{0}\",", Size));
            jsonBuilder.Append(string.Format("\"more information\": \"{0}\",", OtherInfo));
            jsonBuilder.Append(string.Format("\"price\": \"{0}\"", Price));
            return jsonBuilder.ToString();
        }
    }
}