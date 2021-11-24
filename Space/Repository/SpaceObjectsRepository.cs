using Microsoft.EntityFrameworkCore;
using Space.DataBase;
using Space.Interface;
using System.Collections.Generic;
using System.Linq;
using Space.SpaceObjects;

namespace Space.Repository
{
    public class SpaceObjectRepository : ISpaceObjectRepository<SpaceObject>
    {
        private SpaceObjectContext _context;

        public SpaceObjectRepository(SpaceObjectContext context)
        {
            _context = context;
        }

        public IEnumerable<SpaceObject> GetSpaceObjects()
        {
            return _context.SpaceObjects.ToList();
        }

        public void InsertObject(SpaceObject spaceObject)
        {
            _context.SpaceObjects.Add(spaceObject);
        }

        public void DeleteObject(int objectId)
        {
            SpaceObject spaceObject = _context.SpaceObjects.Find(objectId);
            _context.SpaceObjects.Remove(spaceObject);
        }

        public void UpdateObject(SpaceObject spaceObject)
        {
            _context.Entry(spaceObject).State = EntityState.Modified;
        }

        public void Save()
        {
            _context.SaveChanges();
        }
    }
}
