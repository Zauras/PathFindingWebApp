using System.Collections.Generic;
using PathFindingWebApp.Models;

namespace PathFindingWebApp.Services.Facades
{
    public interface IPathService
    {
        public PathResultListDto CalculatePath(PathInputDto pathInput);
    }
}
