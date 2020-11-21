using System.ComponentModel.DataAnnotations;

namespace MyAPI.Models
{
    public class Product
    {
        [Key]
        public int Id { get; set; }

        [Required(ErrorMessage = "Preenchimento obrigatório")]
        [MaxLength(30, ErrorMessage = "Preenchimento de no máximo 30 caracteres")]
        [MinLength(3, ErrorMessage = "Preenchimento de no mínimo 3 caracteres")]
        public string Title { get; set; }

        [MaxLength(500, ErrorMessage= "Preenchimento de no máximo 500 caracteres")]
        public string Description { get; set; }

        [Required(ErrorMessage = "Preenchimento obrigatório")]
        [Range(1, int.MaxValue, ErrorMessage = "O preço deve ser maior que zero")]
        public double Price { get; set; }

        public Category Category { get; set; }

    }
}