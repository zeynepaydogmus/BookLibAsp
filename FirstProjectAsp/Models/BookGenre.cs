using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace FirstProjectAsp.Models
{
    public class BookGenre
    {
        [Key]
        public int Id { get; set; }
        [Required(ErrorMessage ="Kitap türü adı boş bırakılamaz")]
        [DisplayName("Kitap Türü Adı")]
        [MaxLength(25)]
        public string Name { get; set; }
    }
}
