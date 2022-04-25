using System.ComponentModel.DataAnnotations;

namespace LMSystemUI.Models
{
	public class CreateProjectModel
	{
		[Required]
		[MaxLength(150)]
		public string ProjectTitle { get; set; }
		[MaxLength(1000)]
		public string ProjectDescription { get; set; }
		[MaxLength(1000)]
		public string ProjectNotes { get; set; }
		[Required]
		[MaxLength(150)]
		public string ProjectStatus { get; set; }
	}
}

