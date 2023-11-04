using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace FirstProjectAsp.Models
{
    public class Book
    {
        [Key]
        public int Id { get; set; }
        
        [Required(ErrorMessage = "Kitap adı boş bırakılamaz")]
        [DisplayName("Kitap Adı")]
        public string BookName { get; set; }
        public string Title { get; set; }
        [Required]
        public string Author  { get; set; }
        [Required]
        [Range(10,5000)]
        public double Price { get; set; }
        [ValidateNever]
        public int BookGenreId { get; set; }
        [ForeignKey("BookGenreId")]
        [ValidateNever]
        public BookGenre BookGenre { get; set; }
        [ValidateNever]
        public string ImageUrl { get; set; }
    }
}
