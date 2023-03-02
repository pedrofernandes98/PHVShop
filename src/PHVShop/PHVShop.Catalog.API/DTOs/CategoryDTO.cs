using PHVShop.Catalog.API.Models;
using System.ComponentModel.DataAnnotations;

namespace PHVShop.Catalog.API.DTOs
{
    public class CategoryDTO
    {
        public int CategoryId { get; set; }

        [Required(ErrorMessage = "O Name é obrigatório")]
        [MinLength(3)]
        [MaxLength(100)]
        public string? Name { get; set; }
        public ICollection<Product>? Products { get; set; }
    }
}
