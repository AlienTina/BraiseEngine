using BraiseEngineTemplate.Components;
using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Diagnostics;

namespace BraiseEngineTemplate
{
	/*
	 * 
	 * The base class for making GameObjects
	 * 
	 * 
	 * 
	 */
	public class GameObject
	{
		public string Name { get; set; }
		public string Tag { get; set; }
		private List<Component> components = new List<Component>();
		public Transform transform;

		public bool Active = true;

		//Every way of creating a GameObject (+Initialization which is in it's own function to not duplicate knowledge)
		public GameObject() 
		{
			this.Name = "GameObject";
			Initialize();
		}

		public GameObject(string name)
		{ 
			this.Name = name;
			Initialize();
		}

		public GameObject(string name, List<Component> components)
		{
			this.Name = name;
			this.components = components;
			Initialize();
		}

		private void Initialize()
		{
			transform = new Transform(this, Vector2.Zero, 0, 1);
		}


		//Functions for adding/removing components
		public void AddComponent(Component component)
		{
			component.Start();
			components.Add(component);
		}

		public void RemoveComponent(Component component)
		{
			components.Remove(component);
		}


		//Functions for getting components
		public Component GetComponent(Type componentType)
		{
			foreach(Component component in components)
			{
				if(component.GetType() == componentType || componentType.IsAssignableFrom(component.GetType())) return component;
			}
			return null;
		}

		public List<Component> GetComponents(Type componentType)
		{
			List<Component> found = new List<Component>();
			foreach (Component component in components)
			{
				if (component.GetType() == componentType || component.GetType().IsSubclassOf(componentType))  found.Add(component);
			}
			return found;
		}

		public void Update(GameTime gameTime)
		{
			if (Active)
			{
				foreach (Component component in components)
				{
					component.Update(gameTime);
				}
			}
		}

		public void Draw()
		{
			if (Active)
			{
				foreach (Component component in components)
				{
					component.Draw();
				}
			}
		}
	}
}
