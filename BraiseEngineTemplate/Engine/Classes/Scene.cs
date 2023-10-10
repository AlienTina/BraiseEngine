using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BraiseEngineTemplate.Engine.Classes
{
	public class Scene
	{
		public List<GameObject> gameObjects = new List<GameObject>();

		public string Name { get; set; }
		
		//Different ways to create a scene
		public Scene()
		{
			Name = "Scene";
		}
		public Scene(string name)
		{
			this.Name = name;
		}
		public Scene(List<GameObject> gameObjects, string name)
		{
			this.gameObjects = gameObjects;
			this.Name = name;
		}

		//Functions for getting GameObjects
		public GameObject FindGameObject(string Name)
		{
			foreach (GameObject gameObject in gameObjects)
			{
				if (gameObject.Name == Name) return gameObject;
			}
			return null;
		}
		public List<GameObject> FindGameObjects(string Name)
		{
			List<GameObject> found = new List<GameObject>();
			foreach (GameObject gameObject in gameObjects)
			{
				if (gameObject.Name == Name) found.Add(gameObject);
			}
			return found;
		}

		public void Update(GameTime gameTime)
		{
			//Execute the update functions of every GameObject in the scene
			foreach(GameObject gameObject in gameObjects)
			{ gameObject.Update(gameTime); }
		}

		public void Draw()
		{
			//Execute the update functions of every GameObject in the scene
			foreach (GameObject gameObject in gameObjects)
			{ gameObject.Draw(); }
		}
	}
}
