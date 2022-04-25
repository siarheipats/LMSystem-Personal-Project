namespace LmSystemLibrary.Models
{
	public class ClientModel
	{
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string ClientAddress { get; set; }
        public string ClientPhoneNumber { get; set; }
        public string ClientEMail { get; set; }
    }
}

