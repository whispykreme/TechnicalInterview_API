namespace TechnicalInterview_API.DataLayer.Models
{
    public class Signature
    {
        public Guid SignatureId { get; set; }
        public byte[] SignatureImage { get; set; }
        public int VoterId { get; set; }
        public DateTime TimeStamp { get; set; }
    }
}
