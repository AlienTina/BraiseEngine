using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System.Diagnostics;
using System.Text.Json.Serialization;

namespace BraiseEngine.Components
{
	/*
	 * 
	 * A simplified version of the regular Renderer
	 * 
	 * 
	 */
	public class BasicRenderer : Renderer
	{

		public BasicRenderer(GameObject parent, string spritePath) : base(parent, spritePath)
		{
			this.spritePath = spritePath;
			this.sprite = Core.Instance.Content.Load<Texture2D>(spritePath);
			this.parent = parent;
		}
		[JsonConstructor]
		public BasicRenderer(string spritePath)
		{
			this.spritePath = spritePath;
			this.sprite = Core.Instance.Content.Load<Texture2D>(spritePath);
		}

		public override void Draw(SpriteBatch _spriteBatch)
		{
			if (Active)
			{
				_spriteBatch.Draw(sprite, parent.transform.position, color);
			}
		}
	}
}
