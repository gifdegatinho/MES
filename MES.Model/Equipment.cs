using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace MES.Model
{
    public class Equipment
    {
        [Key, MaxLength(50)]
        public string EquipmentId { get; set; }
        [Required, MaxLength(100)]
        public string Description { get; set; }
        [MaxLength(50)]
        public string ParentEquipmentId { get; set; }
        public Equipment ParentEquipment { get; set; }
        public IEnumerable<Equipment> ChildrenEquipment { get; set; }
    }
}
