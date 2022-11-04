using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace MES.Model
{
    public class MaterialDefinition
    {
        [Key, MaxLength(50)]
        public string MaterialDefinitionId { get; set; }
        [Required, MaxLength(100)]
        public string Description { get; set; }        
        public IEnumerable<WorkOrder> WorkOrders { get; set; }        
    }
}
