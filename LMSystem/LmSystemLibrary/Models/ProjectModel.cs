namespace LmSystemLibrary.Models
{
	public class ProjectModel
	{
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string Id { get; set; }
        public string ProjectTitle { get; set; }
        public string ProjectDescription { get; set; }
        public ClientModel ProjectClient { get; set; }
        public DateTime DateCreated { get; set; } = DateTime.UtcNow;
        public string ProjectNotes { get; set; }
        public string CreatedBy { get; set; }
        public string ProjectStatus { get; set; }
        public List<InvoiceModel> Invoices { get; set; }
    }
}

