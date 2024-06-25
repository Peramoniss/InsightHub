
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace InsightHub.Models
{
    public class SubareaConhecimento
    {
        public int Id { get; set; }

        [Required]
        public string? Nome { get; set; }

        [Required]
        public string? Numero { get; set; }

        [Required]
        [ForeignKey("AreaKey")]
        public int AreaKey { get; set; }

        public virtual AreaConhecimento AreaConhecimento { get; set; }
    }
}
