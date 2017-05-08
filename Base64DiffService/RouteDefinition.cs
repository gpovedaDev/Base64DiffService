using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Base64DiffService
{
    public static class RouteDefinition
    {
        public const string SET_LEFT_SIDE = "v1/diff/{id}/left";
        public const string SET_RIGHT_SIDE = "v1/diff/{id}/right";
        public const string VIEW_DIFFED_RESULTS = "v1/diff/{id}";
    }
}
