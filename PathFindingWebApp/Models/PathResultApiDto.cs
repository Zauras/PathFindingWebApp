using System.Collections.Generic;
using System.Linq;

namespace PathFindingWebApp.Models
{
    public class PathResultDto
    {
        public int Id { get; }
        public int PlaceIndex { get; set; }
        public int ScoreCount { get; set; }
        public float SuccessRate { get; set; }
    }
    
    public class PathResultListDto
    {
        public PathResultListDto()
        {
            IsWinnable = false;
        }
        
        public PathResultListDto(IEnumerable<PathResultDto> calculatedPathResult)
        {
            IsWinnable = calculatedPathResult.Any();
            CalculatedPathResult = calculatedPathResult;
        }

        public bool IsWinnable { get; }
        public IEnumerable<PathResultDto> CalculatedPathResult { get; set; }
    }
}