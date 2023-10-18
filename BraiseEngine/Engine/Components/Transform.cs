﻿using Microsoft.Xna.Framework;
using System.ComponentModel;

namespace BraiseEngine.Components
{
	public class Transform : Component
	{
		public Vector2 position {  get; set; }
		public Vector2 localPosition { get; set; }
		public double rotation { get; set; }
		public float scale { get; set; }
		public Transform(GameObject parent, Vector2 position, float rotation, float scale) : base(parent)
		{
			this.position = position;
			this.localPosition = position;
			this.rotation = rotation;
			this.scale = scale;

			this.parent = parent;
		}
		public Transform()
		{

		}
	}
}
