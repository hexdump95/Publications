using System.ComponentModel.DataAnnotations.Schema;

namespace Publications.Entities
{
    [Table("author")]
    public class Author
    {
        [Column("id")]
        public long Id { get; set; }
        [Column("name")]
        public string? Name { get; set; }
    }
}
