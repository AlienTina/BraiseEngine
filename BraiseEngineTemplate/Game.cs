using BraiseEngineTemplate.Components;
using BraiseEngineTemplate.Components.Colliders;
using BraiseEngineTemplate.Engine.GameObjects;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System.Diagnostics;

namespace BraiseEngineTemplate
{
	internal class GameCode : Core
	{
		InputField field;
		protected override void Initialize()
		{
			base.Initialize();

			field = new InputField("Input Field");
			field.AddComponent(new Renderer(field, "Engine/Shapes/Box"));
			field.transform.position = screenCentre;
			
			UIButton button = new UIButton("Button");
			button.onClick += Button_onClick;
			button.AddComponent(new Renderer(button));
			button.transform.position += screenCentre + (Vector2.UnitY * 32);

			UI.gameObjects.Add(button);
			UI.gameObjects.Add(field);
		}

		private void Button_onClick(object sender, MouseClickEventArgs e)
		{
			Debug.WriteLine(field.text);
		}

		protected override void LoadContent()
		{
			base.LoadContent();
		}


		protected override void Update(GameTime gameTime)
		{
			base.Update(gameTime);
		}

		protected override void Draw(GameTime gameTime)
		{
			base.Draw(gameTime);
		}

	}
}
