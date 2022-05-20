namespace MessagesWebApi.Models
{
    public class Json_Message
    {
        public int Id { get; set; }
        //[JsonProperty("id")]
        public string Content { get; set; }
        public DateTime Created { get; set; }
        public bool Sent { get; set; }
    }
}
