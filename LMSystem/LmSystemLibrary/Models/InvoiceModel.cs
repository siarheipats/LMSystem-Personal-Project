namespace LmSystemLibrary.Models
{
	public class InvoiceModel
	{
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string Id { get; set; }
        public string InvoiceTitle { get; set; }
        public string InvoiceNumber { get; set; }
        public string InvoiceStatus { get; set; }
        public DateTime DateCreated { get; set; } = DateTime.UtcNow;
        public List<ItemModel> Items { get; set; }
        public string Total { get; set; }
        public UserModel CreatedBy { get; set; }
    }
}

