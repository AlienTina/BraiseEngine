using Microsoft.Xna.Framework;
using System;

namespace BraiseEngineTemplate.Components.Colliders
{
	public class RectangleCollider : Collider
	{
		public Rectangle boundingRect;
		public RectangleCollider(GameObject parent, Rectangle boundingRectangle) : base(parent)
		{
			this.parent = parent;
			this.boundingRect = boundingRectangle;
			this.Size = new Vector2(boundingRect.Width, boundingRect.Height);
		}
		
		public override void Update(GameTime gameTime)
		{
			//Update the collider's position, and set the position variable to it
			boundingRect.Location = parent.transform.position.ToPoint();
			Position = boundingRect.Location.ToVector2();
		}

		public override bool CheckForCollision(Collider other)
		{
			if (other is RectangleCollider)
			{
				RectangleCollider otherRect = (RectangleCollider)other;
				return boundingRect.Intersects(otherRect.boundingRect);
			}
			else if (other is CircleCollider)
			{
				CircleCollider otherCircle = (CircleCollider)other;

				// Calculate the closest point on the rectangle to the circle's center
				float closestX = MathHelper.Clamp(otherCircle.boundingCircle.Center.X, boundingRect.Left, boundingRect.Right);
				float closestY = MathHelper.Clamp(otherCircle.boundingCircle.Center.Y, boundingRect.Top, boundingRect.Bottom);

				// Calculate the distance between the circle's center and the closest point
				float distanceX = otherCircle.boundingCircle.Center.X - closestX;
				float distanceY = otherCircle.boundingCircle.Center.Y - closestY;

				// Calculate the squared distance
				float squaredDistance = (distanceX * distanceX) + (distanceY * distanceY);

				// Check if the squared distance is less than the circle's radius squared
				if (squaredDistance <= (otherCircle.boundingCircle.Radius * otherCircle.boundingCircle.Radius))
				{
					return true; // Collision
				}

				return false; // No collision
			}
			return false;
		}
	}
}
