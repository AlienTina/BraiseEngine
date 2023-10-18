using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;

namespace BraiseEngine
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

		[EditableInEditor]
		public bool Active = true;
		public Component(GameObject parent) 
		{
			this.parent = parent;
		}

		public Component()
		{
			
		}

		public virtual void Start()
		{

		}

		public virtual void Update(GameTime gameTime)
		{

		}

		public virtual void Draw(SpriteBatch _spriteBatch)
		{

		}
	}

	public class EditableInEditor : Attribute
	{
		public EditableInEditor()
		{

		}
	}
}
