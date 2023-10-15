using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BraiseEngineTemplate.Tilemaps
{
	public class Entity
	{
		public string name { get; set; }
		public int id { get; set; }
		public long _eid { get; set; }
		public int x { get; set; }
		public int y { get; set; }
		public int originX { get; set; }
		public int originY { get; set; }
	}
	public class Layer
	{
		public string name { get; set; }
		protected long _eid { get; set; }
		public int offsetX { get; set; }
		public int offsetY { get; set; }
		public int gridCellWidth { get; set; }
		public int gridCellHeight { get; set; }
		public int gridCellsX { get; set; }
		public int gridCellsY { get; set;}

		//tile
		public string tileset { get; set; }
		public int[,] data2D { get; set; }

		//entity
		public List<Entity> entities = new List<Entity>();

		//grid
		public int[,] grid2D { get; set; }

		public Layer()
		{

		}

	}
}
