using System.Collections;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.AspNetCore.Mvc.Rendering;
using Store.Data;

namespace Store.Models
{
    public class OrderAppViewModel
    {
        public int Id { get; set; }
        
        public CustomerViewModel Customer { get; set; }
        public string CustomerId { get; set; }
        
        public DetailKalaViewModel Kala { get; set; }
        public int KalaId { get; set; }

        public IEnumerable<SelectListItem> CustomerSelectListItmes { get; set; }
        public IEnumerable<SelectListItem> KalaSelectListItmes { get; set; }
        
        public int Tedad { get; set; }
        public int KalaPrice { get; set; }
        public int KalaAll { get; set; }
        public int DateSabt { get; set; }
        public int TimeSabt { get; set; }
    }
}