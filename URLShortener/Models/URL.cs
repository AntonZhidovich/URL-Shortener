using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace URLShortenerApp.Models
{
    public class URL
    {
        [Key]
        public int Id {  get; set; }
        [Required]
        [DisplayName("Full URL")]
        public string FullURL { get; set; }
        [Required]
		[DisplayName("Short URL")]
		public string ShortURL { get; set; }
        [Required]
        public int Clicks { get; set; }
        [Required]
        public DateTime Created { get; set; }
    }
}
