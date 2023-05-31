using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Members.Models
{
	public class Members
	{
		[Key]
		public int ID { get; set; }
		[Required]
		[DisplayName("NAME")]
		public string Name { get; set; }
		[Required]
		[DisplayName("PHONE")]
		public string Phone { get; set; }
		[DisplayName("AADHAAR OR PAN")]
		public string PAN_AADHAR { get; set; }
		[Required]
		[DisplayName("ID PROOF TYPE")]
		public string IdentificationType { get; set; }
		[DisplayName("MEMBER ID")]
		public string Members_ID { get; set; }
		[Required]
		[DisplayName("DATE OF JOIN")]
		public string DOJ { get; set; }
		[Required]
		public string Photo { get; set; }
		[Required]
		[EmailAddress]
		public string Email { get; set; }
	}
}