using System.Collections.Generic;
using System.Linq;
using PathFindingWebApp.Models;
using PathFindingWebApp.Services.Facades;

namespace PathFindingWebApp.Services
{
    public class PathService : IPathService
    {
        public PathResultListDto CalculatePath(PathInputDto pathInput)
        {
            int[] path = pathInput.PathInput;
            if (path.Length > path.Sum() - 1) return new PathResultListDto();
            
            return new PathResultListDto();
        }


        private IEnumerable<PathsLayerMember> GetLayer(int[] path, int layerIndex)
        {
            int layerRoot = path[layerIndex];
            
            int nearestLayerMember = layerIndex;
            int farthestLayerMember = layerIndex + layerRoot;
            
            int[] layerValues = path[nearestLayerMember..farthestLayerMember];

            var layer = layerValues.Select((value, indexInLayer) =>
            new PathsLayerMember(layerIndex, indexInLayer, value)).OrderBy(member => member.Weight);

            return layer;
        }
    }

    class PathsLayerMember
    {
        public PathsLayerMember(int layerIndex, int indexInLayer, int value)
        {
            int indexInPath = layerIndex + indexInLayer;
            Value = value;
            IndexInPath = indexInPath;
            Weight = indexInPath + value;
        }
        
        public int Value { get; }
        public int IndexInPath { get; }
        public int Weight { get; }
    }
}
