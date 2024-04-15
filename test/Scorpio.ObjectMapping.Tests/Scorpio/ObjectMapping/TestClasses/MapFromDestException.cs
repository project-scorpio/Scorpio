namespace Scorpio.ObjectMapping.TestClasses
{
    public class MapFromDestException : IMapFrom<MapFromSource>
    {

        public MapFromDestException()
        {
        }
        public void MapFrom(MapFromSource source)
        {
            throw new System.NotImplementedException();
            // Method intentionally left empty.
        }
    }
}