using Microsoft.Xna.Framework;

namespace BraiseEngineTemplate.Components
{
	public abstract class Collider : Component
	{
		[EditableInEditor]
		public bool isTrigger = false;

		//These two variables are used in case of needing to get the colliders as rectangles
		[EditableInEditor]
		public Rectangle correctionRect;
		public Collider(GameObject parent) : base(parent)
		{ 
			this.parent = parent;
		}
		public Collider()
		{

		}

		//Call this method for collision checking
		public abstract bool CheckForCollision(Collider other);

	}
}
