using BraiseEngineTemplate.Components;
using BraiseEngineTemplate.Components.Colliders;
using BraiseEngineTemplate.Engine.GameObjects;
using BraiseEngineTemplate.Engine;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System.Diagnostics;

namespace BraiseEngineTemplate
{
	internal class GameCode : Core
	{
		protected override void Initialize()
		{
			base.Initialize();
		}

		protected override void LoadContent()
		{
			base.LoadContent();
		}


		protected override void Update(GameTime gameTime)
		{
			base.Update(gameTime);

			//Debug.WriteLine(currentScene.gameObjects);
		}

		protected override void Draw(GameTime gameTime)
		{
			base.Draw(gameTime);
		}

	}
}
