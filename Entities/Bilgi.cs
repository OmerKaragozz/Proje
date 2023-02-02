using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace Entities
{
    public class Bilgi
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int ID { get; set; }      
        public string? dc_Zaman { get; set; }        
        public string? dc_Kategori { get; set; }      
        public string? dc_Olay { get; set; }
    }
}