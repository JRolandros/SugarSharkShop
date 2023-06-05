namespace SugarShark.Api.Models
{
    public class OrderResponse
    {
        public OrderResponse()
        {
            Errors = new List<string>();
        }
        public bool IsOrderValid { get; set; }

        public List<string> Errors { get; }

        public void addErrorMessage(string message) { Errors.Add(message);}
    }
}
