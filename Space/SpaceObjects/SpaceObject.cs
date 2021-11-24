using System.ComponentModel.DataAnnotations.Schema;

namespace Space.SpaceObjects
{
    [Table("space_objects")]
    public class SpaceObject
    {
        [Column("id")]
        public int Id { get; set; }

        [Column("name")]
        public string Name { get; set; }

        [Column("description")]
        public string Description { get; set; }
    }
}
