namespace MemuTechAPI;

    public class Customer
    {
        public int Id { get; set; }
        public string? CodClient { get; set; }
        public string? NomeClient { get; set; }
        public string? LocClient { get; set; }
        public string? TelClient { get; set; }
        public bool DisactiveClient { get; set; }
    }