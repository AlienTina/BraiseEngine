using Microsoft.Xna.Framework;
using System;

namespace BraiseEngine.Components.Colliders
{
	public class Circle
	{
		public Vector2 Center {  get; set; }
		public float Radius { get; set; }
		public Circle(Vector2 center, float radius) 
		{
			this.Center = center;
			this.Radius = radius;
		}
		public Circle()
		{

		}
	}
	public class CircleCollider : Collider
	{
		[EditableInEditor]
		public Circle boundingCircle;
		[EditableInEditor]
		private Vector2 offset;
		public CircleCollider(GameObject parent, float radius, Vector2 offset) : base(parent)
		{
			this.parent = parent;
			this.boundingCircle = new Circle(parent.transform.position + offset, radius);
			this.offset = offset;
			this.correctionRect = new Rectangle();
			this.correctionRect.Size = new Vector2(radius * 2, radius * 2).ToPoint();
		}

		public CircleCollider()
		{

		}

		public override void Update(GameTime gameTime)
		{
			//Update the collider's position, and set the position variable to it
			boundingCircle.Center = parent.transform.position + offset;
			correctionRect.Location = (parent.transform.position - (Vector2.One * boundingCircle.Radius / 2)).ToPoint();
		}

		public override bool CheckForCollision(Collider other)
		{
			if(other is CircleCollider)
			{
				CircleCollider otherCircle = (CircleCollider)other;
				return ((otherCircle.boundingCircle.Center - boundingCircle.Center).Length() < (otherCircle.boundingCircle.Radius + boundingCircle.Radius));
			}
			else if(other is RectangleCollider)
			{
				RectangleCollider otherRect = (RectangleCollider)other;

				// Get the rectangle half width and height
				float rW = (otherRect.boundingRect.Width) / 2;
				float rH = (otherRect.boundingRect.Height) / 2;

				// Get the positive distance. This exploits the symmetry so that we now are
				// just solving for one corner of the rectangle (memory tell me it fabs for 
				// floats but I could be wrong and its abs)
				float distX = Math.Abs(boundingCircle.Center.X - (otherRect.boundingRect.Location.X + rW));
				float distY = Math.Abs(boundingCircle.Center.Y - (otherRect.boundingRect.Location.Y + rH));
				if (distX >= boundingCircle.Radius + rW || distY >= boundingCircle.Radius + rH)
				{
					// Outside see diagram circle E
					return false;
				}
				if (distX < rW || distY < rH)
				{
					// Inside see diagram circles A and B
					return true; // touching
				}

				// Now only circles C and D left to test
				// get the distance to the corner
				distX -= rW;
				distY -= rH;

				// Find distance to corner and compare to circle radius 
				// (squared and the sqrt root is not needed
				if (distX * distX + distY * distY < boundingCircle.Radius * boundingCircle.Radius)
				{
					// Touching see diagram circle C
					return true;
				}
				return false;
			}
			return false;
		}
	}
}
