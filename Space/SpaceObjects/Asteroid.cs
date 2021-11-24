using System.ComponentModel.DataAnnotations.Schema;

namespace Space.SpaceObjects
{
    [Table("asteroids")]
    public class Asteroid : SpaceObject
    {
        [Column("weight")]
        public string Weight { get; set; }
    }
}
