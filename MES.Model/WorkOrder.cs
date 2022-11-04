using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MES.Model
{
    public class WorkOrder
    {
        [Key,MaxLength(50)]
        public string WorkOrderId { get; set; }
        [MaxLength(50),Required]
        public string MaterialDefinitionId { get; set; }
        [Required]
        public double Quantity { get; set; }
        public MaterialDefinition MaterialDefinition { get; set; }
        public IEnumerable<Operation> Operations { get; set; }        
    }
}
