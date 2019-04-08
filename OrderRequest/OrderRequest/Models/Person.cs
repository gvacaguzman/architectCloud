using System;
using System.Text;

namespace OrderRequest.Models
{
    public class Person
    {
        public string Name { get; set; }
        public string LastName { get; set; }
        public string Direction { get; set; }
        public string CI { get; set; }
        public string Cellphone { get; set; }

        public string GetJsonValue()
        {
            StringBuilder jsonBuilder = new StringBuilder();
            jsonBuilder.Append(string.Format("\"name\": \"{0}\",", Name));
            jsonBuilder.Append(string.Format("\"last name\": \"{0}\",", LastName));
            jsonBuilder.Append(string.Format("\"direction\": \"{0}\",", Direction));
            jsonBuilder.Append(string.Format("\"ci\": \"{0}\",", CI));
            jsonBuilder.Append(string.Format("\"cellphone\": \"{0}\",", Cellphone));
            return jsonBuilder.ToString();
        }
    }
}