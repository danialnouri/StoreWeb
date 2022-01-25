using System.ComponentModel.DataAnnotations;

namespace Store.Data
{
    public class Kala
    {
        [Key]
        public int KalaId { get; set; }
        [Required]
        public string KalaName { get; set; }
        public int KalaPrice { get; set; }
        
    }
}