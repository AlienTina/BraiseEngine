using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System.Diagnostics;

namespace BraiseEngineTemplate.Components
{
	/*
	 * 
	 * A simplified version of the regular Renderer
	 * 
	 * 
	 */
	public class BasicRenderer : Renderer
	{
		public Texture2D sprite {  get; set; }
		public BasicRenderer(GameObject parent, Texture2D sprite) : base(parent, sprite)
		{
			this.sprite = sprite;
			this.parent = parent;
		}
		public BasicRenderer(GameObject parent, string spritePath) : base(parent, spritePath)
		{
			this.sprite = Core.Instance.Content.Load<Texture2D>(spritePath);
			this.parent = parent;
		}

		public override void Draw()
		{
			if (Active)
			{
				Core.Instance._spriteBatch.Draw(sprite, parent.transform.position, Color.White);
			}
		}
	}
}
