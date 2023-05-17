using System.ComponentModel.DataAnnotations;

namespace UniversityApiBackend.Models.DataModels
{
    public class Curso: BaseEntity
    {
        [Required, StringLength(50)]
        public string Nombre { get; set; } = string.Empty;
        
        [Required, StringLength(280)]
        public string DescripcionCorta { get; set; } = string.Empty;
        
        [Required, StringLength(350)]
        public string DescripcionLarga { get; set; } = string.Empty;
        
        [Required, StringLength(50)]
        public string PublicoObjetivo { get; set; } = string.Empty;

        [Required, StringLength(100)]
        public string Objetivos { get; set; } = string.Empty;

        [Required, StringLength(50)]
        public string Requisitos { get; set; } = string.Empty;

        [EnumDataType(typeof(NivelCurso))]
        public NivelCurso Nivel { get; set; }
    }

    public enum NivelCurso
    {
        [Display(Name = "Básico")]
        Basico,

        [Display(Name = "Intermedio")]
        Intermedio,

        [Display(Name = "Avanzado")]
        Avanzado
    }
}
