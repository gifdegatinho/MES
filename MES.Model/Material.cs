using System.ComponentModel.DataAnnotations;


namespace MES.Model
{
    internal class Material
    {
        [Key, MaxLength(50)]
        public string MaterialId { get; set; }
        [Required, MaxLength(100)]
        public string Description { get; set; }
    }
}
