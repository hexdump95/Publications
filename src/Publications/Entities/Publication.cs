using System.ComponentModel.DataAnnotations.Schema;

namespace Publications.Entities
{
    [Table("publication")]
    public class Publication
    {
        [Column("id")]
        public long Id { get; set; }
        public Author? Author { get; set; }
        [ForeignKey("Author")]
        [Column("author_id")]
        public long AuthorId { get; set; }
    }
}
