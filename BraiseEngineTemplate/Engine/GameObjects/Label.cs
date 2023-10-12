using Microsoft.Xna.Framework;
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

		public override void Draw()
		{
			base.Draw();
			Core.Instance._spriteBatch.DrawString(Core.Instance.DefaultFont, text, transform.position, color);
		}
	}
}
