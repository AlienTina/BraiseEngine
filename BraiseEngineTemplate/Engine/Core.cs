using BraiseEngineTemplate.Components;
using BraiseEngineTemplate.Engine.Classes;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System;
using System.Collections.Generic;
using System.Diagnostics;

namespace BraiseEngineTemplate
{
	public class Core : Game
	{
		private static Core instance = null;
		private static readonly object padlock = new object();

		public static Core Instance
		{
			set { instance = value; }
			get
			{
				lock (padlock)
				{
					if (instance == null)
					{
						instance = new Core();
					}
					return instance;
				}
			}
		}

		protected GraphicsDeviceManager _graphics;
		public SpriteBatch _spriteBatch;

		public Scene currentScene = new Scene();

		private Matrix camera = Matrix.Identity;

		private Viewport viewport;
		public Vector2 cameraWorldPosition = Vector2.Zero;
		public Vector2 screenCentre;

		public Random rng = new Random();

		protected Color backgroundColor = Color.SkyBlue;

		public Core()
		{
			_graphics = new GraphicsDeviceManager(this);
			Content.RootDirectory = "Content";
			IsMouseVisible = true;

		}

		protected override void Initialize()
		{
			base.Initialize();

			viewport = _graphics.GraphicsDevice.Viewport;
			screenCentre = new Vector2(viewport.Width / 2, viewport.Height / 2);
		}

		protected override void LoadContent()
		{
			_spriteBatch = new SpriteBatch(GraphicsDevice);

		}

		protected override void Update(GameTime gameTime)
		{
			currentScene.Update(gameTime);

			Vector2 translation = -cameraWorldPosition + screenCentre;

			camera = Matrix.CreateTranslation(translation.X, translation.Y, 0);

			base.Update(gameTime);
		}

		protected override void Draw(GameTime gameTime)
		{
			GraphicsDevice.Clear(backgroundColor);

			_spriteBatch.Begin(SpriteSortMode.BackToFront, null, null, null, null, null, camera);
			currentScene.Draw();
			_spriteBatch.End();

			base.Draw(gameTime);
		}

		public Vector2 ScreenPointToWorldPoint(Vector2 Point)
		{
			return cameraWorldPosition + Point - screenCentre;
			
		}
	}
}