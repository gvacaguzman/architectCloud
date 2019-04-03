using System.Text;

namespace DeliveryPizzaRequest.Models
{
    public class DeliveryMan : Person
    {
        public string Code { get; set; }
        public string MotorcicleCode { get; set; }

        public string GetJsonValue()
        {
            StringBuilder jsonBuilder = new StringBuilder();
            jsonBuilder.Append(base.GetJsonValue());
            jsonBuilder.Append(string.Format("\"code\": \"{0}\",", Code));
            jsonBuilder.Append(string.Format("\"motorcicle code\": \"{0}\"", MotorcicleCode));
            return jsonBuilder.ToString();
        }
    }
}