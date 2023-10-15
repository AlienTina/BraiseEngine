using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BraiseEngineTemplate.Tilemaps
{
    public class Tilemap
    {
        public int width { get; set; }
        public int height { get; set; }
        public int offsetX { get; set; }
        public int offsetY { get; set; }
        public List<Layer> layers { get; set; }

        public Tilemap() { }

    }
}
