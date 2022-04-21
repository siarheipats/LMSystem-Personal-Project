namespace LmSystemLibrary.Models
{
	public class UserModel
	{
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        // TODO: Implement encrption for email and password
        public string Id { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Role { get; set; }
        // 1 - Full 2 - Partial 3 - View Only
        public string DataAccessLvl { get; set; } = "2";
    }
}

