using System;
using System.ComponentModel.DataAnnotations;

namespace MES.Model
{
    public class Operation
    {
        [Key, MaxLength(50)]
        public string WorkOrderId { get; set; }
        [Key]
        public int OperationId { get; set; }
        [Required, MaxLength(50)]
        public string EquipmentId { get; set; }
        [Required]
        public TimeSpan Duration { get; set; }
        public DateTimeOffset StartDate { get; set; }
        public DateTimeOffset EndDate { get; set; }
        public WorkOrder WorkOrder { get; set; }
        public Equipment Equipment { get; set; }
    }
}
