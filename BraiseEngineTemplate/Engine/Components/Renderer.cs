using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;

namespace BraiseEngineTemplate.Components
{
	public class Renderer : Component
	{
		public Texture2D sprite { get; set; }
		public Color color = Color.White;
		public Vector2 origin = Vector2.Zero;
		public Renderer(GameObject parent) : base(parent)
		{
			this.sprite = Core.Instance.Content.Load<Texture2D>("Engine/undefined");
			this.parent = parent;
		}
		public Renderer(GameObject parent, Texture2D sprite) : base(parent)
		{
			this.sprite = sprite;
			this.parent = parent;
		}
		public Renderer(GameObject parent, string spritePath) : base(parent)
		{
			this.sprite = Core.Instance.Content.Load<Texture2D>(spritePath);
			this.parent = parent;
		}

		public void CalculateOrigin(Vector2 point)
		{
			origin = new Vector2(sprite.Width * point.X, sprite.Height * point.Y);
		}

		public override void Draw()
		{
			if (Active)
			{
				Core.Instance._spriteBatch.Draw(sprite, parent.transform.position, null, color, (float)parent.transform.rotation, origin, parent.transform.scale, SpriteEffects.None, 0);
			}
		}
	}
}
