using BraiseEngineTemplate.Components;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;
using System;
using System.Collections.Generic;
using System.Diagnostics;

namespace BraiseEngineTemplate.Engine.GameObjects
{
	public class MouseClickEventArgs : EventArgs
	{
		public Vector2 clickposition { get; set; }
	}
	public class UIButton : GameObject
	{
		public Rectangle boundingBox;
		public UIButton()
		{
			this.Name = "GameObject";
			Initialize();
		}

		public UIButton(string name)
		{
			this.Name = name;
			Initialize();
		}

		public UIButton(string name, List<Component> components)
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
			if(Core.Instance.currentMouseState.LeftButton == ButtonState.Pressed && Core.Instance.lastMouseState.LeftButton == ButtonState.Released)
			{
				Renderer myRender = GetComponent(typeof(Renderer)) as Renderer;
				if (myRender != null)
				{
					boundingBox.Size = myRender.sprite.Bounds.Size;
					boundingBox.Location = transform.position.ToPoint();
				}
				Point mousePoint = Mouse.GetState().Position;
				if (boundingBox.Contains(mousePoint))
				{
					MouseClickEventArgs e = new MouseClickEventArgs();
					e.clickposition = mousePoint.ToVector2();
					OnMouseClick(e);
				}
			}
		}

		protected virtual void OnMouseClick(MouseClickEventArgs e)
		{
			EventHandler<MouseClickEventArgs> handler = onClick;
			if (handler != null)
			{
				handler(this, e);
			}
		}
		public event EventHandler<MouseClickEventArgs> onClick;
	}
}
