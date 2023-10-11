using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System.Collections.Generic;

namespace BraiseEngineTemplate.Components
{
	public class AnimatedRenderer : Renderer
	{
		List<Texture2D> animation {  get; set; }
		public float framerate = 20;
		float timeUntilNextFrame = 0;
		int frame = 0;
		public AnimatedRenderer(GameObject parent, List<Texture2D> animation) : base(parent) 
		{
			this.parent = parent;
			this.animation = animation;
			timeUntilNextFrame = 1 / framerate;
		}

		public AnimatedRenderer(GameObject parent, List<string> animationPaths) : base(parent)
		{
			this.parent = parent;
			foreach (string path in animationPaths)
			{
				animation.Add(Core.Instance.Content.Load<Texture2D>(path));
			}
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

		public override void Draw()
		{
			if (Active)
			{
				Core.Instance._spriteBatch.Draw(animation[frame], parent.transform.position, null, color, (float)parent.transform.rotation, origin, parent.transform.scale, SpriteEffects.None, 0);
			}
		}
	}
}
