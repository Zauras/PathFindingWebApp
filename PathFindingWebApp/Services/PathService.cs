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

        private List<List<PathsNode>> layerList;

        private void FindPath(int[] path)
        {
            layerList = new List<List<PathsNode>>();
            Next(path, 0, 0);
        }


        private void Next(int[] path, int layerIndex, int nodeIndex, bool isRolledBack=false)
        {
            // if layer not exist, create and add
            if (layerIndex >= layerList.Count)
            {
                var layer = GetLayer(path, layerIndex);
                layerList.Add(layer);
            }

            // NEXT NODE IN LAYER:
            // IF LAYER HAS MORE NODES, ONLY IF FAILS CURRENT NODE BRANCH
            bool isLayerHasMoreNodes = layerList[layerIndex].Count - 1 > nodeIndex;
            
            if (isRolledBack  && isLayerHasMoreNodes)
            {
                return Next(path, layerIndex, ++nodeIndex);
            }

            // TRY PREVIOUS LAYER: => ROLLBACK
            if (!isLayerHasMoreNodes)
            {
                int prevLayerIndex = layerIndex - 1;
                // IF PREV LAYER EMPTY - FAILED
                if (prevLayerIndex < 0 || layerList[prevLayerIndex].Count == 0)
                {
                    return null;
                }
                return Next(path, prevLayerIndex, 0, true);
            }
            
            // NEXT LAYER
            return Next(path, ++layerIndex, 0), ;
        }


        private List<PathsNode> GetLayer(int[] path, int layerIndex)
        {
            int layerRoot = path[layerIndex];

            int nearestLayerMember = layerIndex;
            int farthestLayerMember = layerIndex + layerRoot;

            int[] layerValues = path[nearestLayerMember..farthestLayerMember];

            var layer = layerValues
                .Select((value, indexInLayer) => new PathsNode(layerIndex, indexInLayer, value))
                .OrderBy(member => member.Weight)
                .ToList();

            return layer;
        }
    }

    class PathsNode
    {
        public PathsNode(int layerIndex, int indexInLayer, int value)
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