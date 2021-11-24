using System.ComponentModel.DataAnnotations.Schema;

namespace Space.SpaceObjects
{
    [Table("black_holes")]
    public class BlackHole : SpaceObject
    {
        [Column("diameter")]
        public string Diameter { get; set; }
    }
}
