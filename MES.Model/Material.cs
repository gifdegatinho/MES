using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;


namespace MES.Model
{
    public class Material
    {
        [Key, MaxLength(50)]
        public string MaterialId { get; set; }
        [Required, MaxLength(100)]
        public string Description { get; set; }
        [Required, MaxLength(50)]
        public string Color { get; set; }
        public IEnumerable<WorkOrder> WorkOrders { get; set; }
    }
}
