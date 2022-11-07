using System;
using System.ComponentModel.DataAnnotations;

namespace MES.Model
{
    public class Operation
    {
        [Key, MaxLength(50)]
        public string WorkOrderId { get; set; }
        [Key, MaxLength(50)]
        public string OperationId { get; set; }
        [Required, MaxLength(50)]
        public string EquipmentId { get; set; }
        public DateTimeOffset? ScheduledStartDate { get; set; }
        public DateTimeOffset? ScheduledEndDate { get; set; }
        public DateTimeOffset? ActualStartDate { get; set; }
        public DateTimeOffset? ActualEndDate { get; set; }
        public TimeSpan? Duration { get; set; }
        public double? ProducedQuantity { get; set; }
        public double? ScrapQuantity { get; set; }
        public Equipment Equipment { get; set; }
        public WorkOrder WorkOrder { get; set; }
    }
}
