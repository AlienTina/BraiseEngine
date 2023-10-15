using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System.Collections.Generic;

namespace BraiseEngineTemplate.Engine.GameObjects
{
	public class Label : GameObject
	{
		public string text = "";
		public Color color = Color.Black;
		public Label() : base()
		{
			this.Name = "GameObject";
			Initialize();
		}

		public Label(string name) : base(name)
		{
			this.Name = name;
			Initialize();
		}

		public Label(string name, List<Component> components) : base(name, components)
		{
			this.Name = name;
			this.components = components;
			Initialize();
		}

		public override void Draw(SpriteBatch _spriteBatch)
		{
			base.Draw(_spriteBatch);
			Core.Instance._spriteBatch.DrawString(Core.Instance.DefaultFont, text, transform.position, color);
		}
	}
}
