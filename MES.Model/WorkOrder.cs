using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;


namespace MES.Model
{
    public class WorkOrder
    {
        [Key, MaxLength(50)]
        public string WorkOrderId { get; set; }
        [Required, MaxLength(50)]
        public string MaterialId { get; set; }
        [Required]
        public double Quantity { get; set; }
        public Material Material { get; set; }
        public IEnumerable<Operation> Operations { get; set; }
    }
}
