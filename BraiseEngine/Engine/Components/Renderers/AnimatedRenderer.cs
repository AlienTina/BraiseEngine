using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Newtonsoft.Json;
using System.Collections.Generic;

namespace BraiseEngine.Components
{
	public class AnimatedRenderer : Renderer
	{
		[JsonIgnore]
		List<Texture2D> animation {  get; set; }

		[EditableInEditor]
		List<string> animationPaths { get; set; }
		[EditableInEditor]
		public float framerate = 20;
		float timeUntilNextFrame = 0;
		int frame = 0;
		public AnimatedRenderer(GameObject parent, List<Texture2D> animation, List<string> animationPaths) : base(parent) 
		{
			this.parent = parent;
			this.animation = animation;
			timeUntilNextFrame = 1 / framerate;
		}

		[JsonConstructor]
		public AnimatedRenderer(List<string> animationPaths)
		{
			this.animationPaths = animationPaths;
			foreach(string path in animationPaths)
			{
				animation.Add(Core.Instance.Content.Load<Texture2D>(path));
			}
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

		public override void Draw(SpriteBatch _spriteBatch)
		{
			if (Active)
			{
				Core.Instance._spriteBatch.Draw(animation[frame], parent.transform.position, null, color, (float)parent.transform.rotation, origin, parent.transform.scale, SpriteEffects.None, 0);
			}
		}
	}
}
