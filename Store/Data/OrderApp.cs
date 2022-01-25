using System.ComponentModel.DataAnnotations.Schema;

namespace Store.Data
{
    public class OrderApp
    {
        public int Id { get; set; }
        [ForeignKey("CustomerId")]
        public Customer Customer { get; set; }
        public string CustomerId { get; set; }
        [ForeignKey("KalaId")]
        public Kala Kala { get; set; }
        public int KalaId { get; set; }
        public int Tedad { get; set; }
        public int KalaPrice { get; set; }
        public int KalaAll { get; set; }
        public int DateSabt { get; set; }
        public int TimeSabt { get; set; }
    }
}