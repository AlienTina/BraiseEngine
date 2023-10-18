using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;
using Newtonsoft.Json;

namespace BraiseEngine.Components
{
	public class Renderer : Component
	{
		[JsonIgnore]
		public Texture2D sprite { get; set; }

		[EditableInEditor]
		public string spritePath = "";
		[EditableInEditor]
		public Color color = Color.White;
		[EditableInEditor]
		public Vector2 origin = Vector2.Zero;

		[JsonConstructor]
		public Renderer(string spritePath)
		{
			this.spritePath = spritePath;
			this.sprite = Core.Instance.Content.Load<Texture2D>(spritePath);
		}
		public Renderer()
		{

		}
		public Renderer(GameObject parent) : base(parent)
		{
			this.sprite = Core.Instance.LibContent.Load<Texture2D>("undefined");
			this.parent = parent;
		}

		public Renderer(GameObject parent, Texture2D sprite, string spritePath) : base(parent)
		{
			this.spritePath = spritePath;
			this.sprite = sprite;
			this.parent = parent;
		}
		public Renderer(GameObject parent, string spritePath) : base(parent)
		{
			this.spritePath = spritePath;
			this.sprite = Core.Instance.Content.Load<Texture2D>(spritePath);
			this.parent = parent;
		}

		public void CalculateOrigin(Vector2 point)
		{
			origin = new Vector2(sprite.Width * point.X, sprite.Height * point.Y);
		}

		public override void Update(GameTime gameTime)
		{
			base.Update(gameTime);
			Rectangle viewPort = new Rectangle(Core.Instance.cameraWorldPosition.ToPoint() - Core.Instance.screenCentre.ToPoint(), new Point(Core.Instance.ResolutionWidth, Core.Instance.ResolutionHeight));
			Rectangle spriteRect = new Rectangle(parent.transform.position.ToPoint(), sprite.Bounds.Size);
			Active = spriteRect.Intersects(viewPort);
		}

		public override void Draw(SpriteBatch _spriteBatch)
		{
			if (Active)
			{
				_spriteBatch.Draw(sprite, parent.transform.position, null, color, (float)parent.transform.rotation, origin, parent.transform.scale, SpriteEffects.None, 0);
			}
		}
	}
}
