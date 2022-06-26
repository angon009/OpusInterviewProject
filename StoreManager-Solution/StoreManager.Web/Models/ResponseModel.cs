namespace StoreManager.Web.Models
{
    public enum ResponseTypes
    {
        Success,
        Danger
    }
    public class ResponseModel
    {
        public string? Message { get; set; }
        public ResponseTypes ResponseType { get; set; }
    }
}
