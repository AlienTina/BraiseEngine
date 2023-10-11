using Microsoft.Xna.Framework;


namespace BraiseEngineTemplate
{
	/*
	 * 
	 * The Base class for making Components.
	 * 
	 * 
	 * 
	 * 
	 */
	public abstract class Component
	{
		public GameObject parent { get; set; }

		public bool Active = true;
		public Component(GameObject parent) 
		{
			this.parent = parent;
		}

		public virtual void Start()
		{

		}

		public virtual void Update(GameTime gameTime)
		{

		}

		public virtual void Draw()
		{

		}
	}
}
