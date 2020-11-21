using System.ComponentModel.DataAnnotations;

namespace MyAPI.Models
{
    public class Category
    {
        [Key]
        public int Id { get; set; }

        [Required(ErrorMessage = "Preenchimento obrigatório")]
        [MaxLength(30, ErrorMessage = "Preenchimento de no máximo 30 caracteres")]
        [MinLength(3, ErrorMessage = "Preenchimento de no mínimo 3 caracteres")]
        public string Title { get; set; }

    }
}