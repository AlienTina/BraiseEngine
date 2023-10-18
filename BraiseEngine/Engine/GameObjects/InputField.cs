using BraiseEngine.Components;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using Microsoft.Xna.Framework.Graphics;

namespace BraiseEngine.Engine.GameObjects
{
	public class InputField : GameObject
	{
		public Rectangle boundingBox;
		bool isSelected = false;

		public string text = "";
		public Color textColor = Color.Black;
		public InputField()
		{
			this.Name = "GameObject";
			Initialize();
		}

		public InputField(string name)
		{
			this.Name = name;
			Initialize();
		}

		public InputField(string name, List<Component> components)
		{
			this.Name = name;
			this.components = components;
			Initialize();
		}

		protected override void Initialize()
		{
			base.Initialize();
			boundingBox = new Rectangle(transform.position.ToPoint(), Vector2.One.ToPoint());
		}

		public override void Update(GameTime gameTime)
		{
			base.Update(gameTime);
			if (Core.Instance.currentMouseState.LeftButton == ButtonState.Pressed && Core.Instance.lastMouseState.LeftButton == ButtonState.Released)
			{
				Renderer myRender = GetComponent(typeof(Renderer)) as Renderer;
				if (myRender != null)
				{
					boundingBox.Location = transform.position.ToPoint();
					boundingBox.Size = myRender.sprite.Bounds.Size;

				}
				Point mousePoint = Mouse.GetState().Position;
				isSelected = boundingBox.Contains(mousePoint);
			}

			if (isSelected)
			{
				if (Core.Instance.currentKeyState.GetPressedKeyCount() > 0 && Core.Instance.lastKeyState.GetPressedKeyCount() < Core.Instance.currentKeyState.GetPressedKeyCount())
				{
					if (!Core.Instance.currentKeyState.IsKeyDown(Keys.Back))
					{
						char newChar = KeyToChar.Convert(Core.Instance.currentKeyState.GetPressedKeys()[0]);
						text += newChar;
					}
					else if(text.Length > 0)
						text = text.Remove(text.Length - 1);
					text = text.Replace("\0", "");
				}
			}
			
		}
		public override void Draw(SpriteBatch _spriteBatch)
		{
			base.Draw(_spriteBatch);
			Core.Instance._spriteBatch.DrawString(Core.Instance.DefaultFont, text, transform.position + (Vector2.UnitY * Core.Instance.DefaultFont.LineSpacing / 2), textColor, 0, Vector2.Zero, 1, Microsoft.Xna.Framework.Graphics.SpriteEffects.None, 1);
		}

	}
}
