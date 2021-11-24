using System.Collections.Generic;
using Space.SpaceObjects;

namespace Space.Interface
{
    public interface ISpaceObjectRepository<T>
        where T : SpaceObject
    {
        IEnumerable<T> GetSpaceObjects();
        void InsertObject(T spaceObject);
        void DeleteObject(int objectId);
        void UpdateObject(T spaceObject);
        void Save();
    }
}
