using BraiseEngineTemplate.Components.Colliders;
using Microsoft.Xna.Framework;
using System;
using System.ComponentModel.Design;

namespace BraiseEngineTemplate.Components
{
    public class KineticBody : Component
    {
        //A Variable that returns the Collider of the parent GameObject
        Collider collider
        {
            get { return parent.GetComponent(typeof(Collider)) as Collider; }
        }

        public Vector2 velocity { get; set; }
        public KineticBody(GameObject parent) : base(parent)
        {
            this.parent = parent;
        }

		public override void Update(GameTime gameTime)
		{
            if (Active)
            {
                //Cycle through each GameObject in the current loaded scene, check if the object has a collider, check if the collider is touching this object's collider, and check if the collider isn't a trigger
                foreach (GameObject gameObject in Core.Instance.currentScene.gameObjects)
                {
                    if (gameObject == parent) continue;
                    Collider objectCollider = gameObject.GetComponent(typeof(Collider)) as Collider;
                    if (objectCollider != null)
                    {
                        if (collider.CheckForCollision(objectCollider) && !objectCollider.isTrigger)
                        {
                            //If the two colliders are touching, try correcting the penetration
                            parent.transform.position += GetPenetration(objectCollider);
                        }
                    }
                }
                //Move the object based on velocity
                Vector2 newPosition = parent.transform.position + velocity * (float)gameTime.ElapsedGameTime.TotalSeconds;
                parent.transform.position = newPosition;
            }
		}

        private Vector2 GetPenetration(Collider other)
        {
            //Turn both colliders into rectangles for calculation (were doing this mostly so we don't have to do multiple calculations for each combination of collider types)
            Rectangle P = new Rectangle(collider.Position.ToPoint(), collider.Size.ToPoint());
            Rectangle Q = new Rectangle(other.Position.ToPoint(), other.Size.ToPoint());
            
            //Calculate the penetration size on the X and Y axies
			int W = (P.Left < Q.Left)
	           ? P.Right - Q.Left
	           : P.Left - Q.Right;
			int H = (P.Top < Q.Top)
				   ? P.Bottom - Q.Top
				   : P.Top - Q.Bottom;

            Vector2 penetration = Vector2.Zero;

            //set the final penetration value based on which axis has the bigger penetration
            if (Math.Abs(W) <= Math.Abs(H))
            {
                penetration.X = -W;
            }
            else
			 {
				penetration.Y = -H;
			}

            return penetration;
		}
	}
}
