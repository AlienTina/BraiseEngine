using BraiseEngine;
using BraiseEngine.Components;
using BraiseEngine.Engine;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Resources;

namespace BraiseEngine
{
	public class Core : Game
	{
		private static Core instance = null;
		private static readonly object padlock = new object();

		public SpriteFont DefaultFont;

		public KeyboardState currentKeyState;
		public KeyboardState lastKeyState;

		public MouseState currentMouseState;
		public MouseState lastMouseState;

		public Dictionary<string, Type> entityList = new Dictionary<string, Type>();

		public ContentManager LibContent;

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

		public Random rng = new Random(DateTime.Now.Second);

		public Color backgroundColor = Color.SkyBlue;

		public int ResolutionWidth = 1280;
		public int ResolutionHeight = 720;

		public Core()
		{
			_graphics = new GraphicsDeviceManager(this);
			Content.RootDirectory = "Content";
			IsMouseVisible = true;

			ResourceContentManager resxContent;
			resxContent = new ResourceContentManager(Services, ResourceFile.ResourceManager);
			LibContent = resxContent;
		}

		protected override void Initialize()
		{
			base.Initialize();

			viewport = _graphics.GraphicsDevice.Viewport;
			screenCentre = new Vector2(viewport.Width / 2, viewport.Height / 2);
			DefaultFont = LibContent.Load<SpriteFont>("DefaultFont");
		}

		protected override void LoadContent()
		{
			_spriteBatch = new SpriteBatch(GraphicsDevice);

		}

		protected override void Update(GameTime gameTime)
		{
			lastKeyState = currentKeyState;
			currentKeyState = Keyboard.GetState();

			lastMouseState = currentMouseState;
			currentMouseState = Mouse.GetState();

			if(_graphics.PreferredBackBufferWidth != ResolutionWidth || _graphics.PreferredBackBufferHeight != ResolutionHeight)
			{
				_graphics.PreferredBackBufferHeight = ResolutionHeight;
				_graphics.PreferredBackBufferWidth = ResolutionWidth;
				screenCentre = new Vector2(ResolutionWidth / 2, ResolutionHeight / 2);
				_graphics.ApplyChanges();
			}

			currentScene.Update(gameTime);

			Vector2 translation = -cameraWorldPosition + screenCentre;

			camera = Matrix.CreateTranslation(translation.X, translation.Y, 0);

			base.Update(gameTime);
		}

		protected override void Draw(GameTime gameTime)
		{
			GraphicsDevice.Clear(backgroundColor);

			_spriteBatch.Begin(SpriteSortMode.BackToFront, null, null, null, null, null, camera);
			currentScene.Draw(_spriteBatch);
			_spriteBatch.End();
			_spriteBatch.Begin(SpriteSortMode.FrontToBack, null, null, null, null, null, Matrix.Identity);
			if (currentScene.UI != null)
				currentScene.UI.Draw(_spriteBatch);
			_spriteBatch.End();

			base.Draw(gameTime);
		}

		public Vector2 ScreenPointToWorldPoint(Vector2 Point)
		{
			return cameraWorldPosition + Point - screenCentre;
			
		}
	}
}