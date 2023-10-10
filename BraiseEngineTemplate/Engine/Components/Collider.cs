using Microsoft.Xna.Framework;

namespace BraiseEngineTemplate.Components
{
	public abstract class Collider : Component
	{
		public bool isTrigger = false;

		//These two variables are used in case of needing to get the colliders as rectangles
		public Vector2 Position;
		public Vector2 Size { get; set; }
		public Collider(GameObject parent) : base(parent)
		{ 
			this.parent = parent;
		}

		//Call this method for collision checking
		public abstract bool CheckForCollision(Collider other);

	}
}
