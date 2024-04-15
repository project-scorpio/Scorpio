namespace Scorpio.ObjectMapping.TestClasses
{
    public class MapFromDest : IMapFrom<MapFromSource>
    {
        public MapFromDest(MapFromSource source) => Source = source;

        public MapFromSource Source { get; }

        public void MapFrom(MapFromSource source)
        {
        }
    }
}