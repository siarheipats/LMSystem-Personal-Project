using System.ComponentModel.DataAnnotations;

namespace LMSystemUI.Models
{
	public class CreateItemModel
	{
		[Required]
		[MaxLength(100)]
		public string ItemName { get; set; }
		[Required]
		[MaxLength(300)]
		public string ItemDescription { get; set; }
		[Required]
		public string Price { get; set; }
		[Required]
		public int QuantityInStock { get; set; }
	}
}

