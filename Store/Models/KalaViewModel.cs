

using System.ComponentModel.DataAnnotations;

namespace Store.Models
{
    public class DetailKalaViewModel
    {
        [Key]
        public int KalaId { get; set; }
        public string KalaName { get; set; }
        public int KalaPrice { get; set; }
    }
    public class CreateKalaViewModel
    { 
        [Required]
        public string KalaName { get; set; }
        public int KalaPrice { get; set; }
    }
}