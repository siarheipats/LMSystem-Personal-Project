namespace LmSystemLibrary.Models
{
	public class ItemModel
	{
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string Id { get; set; }
        public string ItemName { get; set; }
        public string ItemDescription { get; set; }
        public string Price { get; set; }
        public int QuantityInStock { get; set; }
    }
}

