using BraiseEngine.Components;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BraiseEngine.Components
{
	public class SheetRenderer : Renderer
	{
		[EditableInEditor]
		List<Rectangle> animation { get; set; }
		[EditableInEditor]
		public float framerate = 20;
		float timeUntilNextFrame = 0;
		int frame = 0;
		public SheetRenderer(GameObject parent, List<Rectangle> sheetdata, Texture2D sprite) : base(parent)
		{
			this.parent = parent;
			this.animation = sheetdata;
			this.sprite = sprite;
			timeUntilNextFrame = 1 / framerate;
		}
		public SheetRenderer()
		{
			timeUntilNextFrame = 1 / framerate;
		}

		public SheetRenderer(GameObject parent, List<Rectangle> sheetdata, string spritePath) : base(parent)
		{
			this.parent = parent;
			this.animation = sheetdata;
			this.sprite = Core.Instance.Content.Load<Texture2D>(spritePath);
			timeUntilNextFrame = 1 / framerate;
		}

		public override void Update(GameTime gameTime)
		{
			if (Active)
			{
				timeUntilNextFrame -= (float)gameTime.ElapsedGameTime.TotalSeconds;
				if (timeUntilNextFrame < 0)
				{
					frame++;
					if (frame >= animation.Count) frame = 0;
					timeUntilNextFrame = 1 / framerate;
				}
			}
		}

		public override void Draw(SpriteBatch _spriteBatch)
		{
			if (Active)
			{
				_spriteBatch.Draw(sprite, parent.transform.position, animation[frame], color, (float)parent.transform.rotation, origin, parent.transform.scale, SpriteEffects.None, 0);
			}
		}
	}
}
