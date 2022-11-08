using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Diagnostics;

namespace MES.Model
{
    [DebuggerDisplay($"{{MaterialId}}")]
    public class Material
    {
        [Key, MaxLength(50)]
        public string MaterialId { get; set; }
        [Required, MaxLength(100)]
        public string Description { get; set; }
        [Required, MaxLength(50)]
        public string Color { get; set; }
        public IEnumerable<WorkOrder> WorkOrders { get; set; }

        private string GetDebuggerDisplay()
        {
            return ToString();
        }
    }
}
