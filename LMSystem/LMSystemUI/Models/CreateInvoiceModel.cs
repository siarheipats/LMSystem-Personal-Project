using System.ComponentModel.DataAnnotations;

namespace LMSystemUI.Models
{
	public class CreateInvoiceModel
	{
		[Required]
		[MaxLength(100)]
		public string InvoiceTitle { get; set; }
		[Required]
		[MaxLength(20)]
		public string InvoiceNumber { get; set; }
		[Required]
		[MaxLength(20)]
		public string InvoiceStatus { get; set; }
		public UserModel CreatedBy { get; set; }
	}
}

