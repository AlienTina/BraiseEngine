using BraiseEngine.Components;
using BraiseEngine.Components.Colliders;
using BraiseEngine.Tilemaps;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Reflection;
using System.Text.Json.Serialization;

namespace BraiseEngine
{
	public class Scene
	{
		public List<GameObject> gameObjects = new List<GameObject>();

		[JsonInclude]
		public Scene UI { get; set; }
		public string Name { get; set; }

		public Tilemap map {  get; set; }
		
		//Different ways to create a scene
		public Scene()
		{
			Name = "Scene";
			InitializeMap();
		}
		public Scene(string name)
		{
			this.Name = name;
			InitializeMap();
		}
		public Scene(List<GameObject> gameObjects, string name)
		{
			this.gameObjects = gameObjects;
			this.Name = name;
			InitializeMap();
		}

		public void InitializeMap()
		{
			if (map != null)
			{
				foreach (Layer layer in this.map.layers)
				{
					Texture2D tilemap = Core.Instance.LibContent.Load<Texture2D>("undefined");
					if (layer.tileset != null)
					{
						tilemap = Core.Instance.Content.Load<Texture2D>(layer.tileset);
					}
					if (layer.data2D != null)
					{
						for (int y = 0; y < layer.data2D.GetLength(0); y++)
						{
							for (int x = 0; x < layer.data2D.GetLength(1); x++)
							{
								if (layer.data2D[y, x] == -1) continue;
								string coords = layer.data2D[y, x].ToString();
								int yObject = 0;
								int xObject = 0;
								if (coords.Length > 1){
									yObject = coords[0] - '0';
									xObject = coords[1] - '0';
								}
								else
								{
									xObject = coords[0] - '0';
								}
								GameObject tile = new GameObject("Tile");
								tile.transform.position = new Vector2(x * layer.gridCellWidth, y * layer.gridCellHeight);
								SheetRenderer render = new SheetRenderer(tile, new List<Rectangle>() { new Rectangle(xObject * layer.gridCellWidth, yObject * layer.gridCellHeight, layer.gridCellWidth, layer.gridCellHeight) }, tilemap);
								render.framerate = 0;
								tile.AddComponent(render);
								gameObjects.Add(tile);
							}
						}
					}
					if(layer.entities != null)
					{
						foreach(Entity entity in layer.entities)
						{
							if (Core.Instance.entityList.ContainsKey(entity.name))
							{
								GameObject gameObject = (GameObject)Activator.CreateInstance(Core.Instance.entityList[entity.name], new object[] { entity.id.ToString() });
								gameObject.transform.position = new Vector2(entity.x, entity.y);

								gameObjects.Add(gameObject);
							}
						}
					}
					if(layer.grid2D != null)
					{
						for (int y = 0; y < layer.grid2D.GetLength(0); y++)
						{

							for (int x = 0; x < layer.grid2D.GetLength(1); x++)
							{
								if (layer.grid2D[y, x] == 1)
								{
									GameObject gameObject = new GameObject("Tilemap Collision");
									gameObject.transform.position = new Vector2(x * layer.gridCellWidth, y * layer.gridCellHeight);
									RectangleCollider collider = new RectangleCollider(gameObject, new Rectangle(x * layer.gridCellWidth, y * layer.gridCellHeight, layer.gridCellWidth, layer.gridCellHeight));
									gameObject.AddComponent(collider);
									gameObjects.Add(gameObject);
								}
							}
						}
					}
				}
			}
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

			if(UI != null)
				UI.Update(gameTime);
		}

		public void Draw(SpriteBatch _spriteBatch)
		{
			//Execute the update functions of every GameObject in the scene
			foreach (GameObject gameObject in gameObjects)
			{ gameObject.Draw(_spriteBatch); }
		}
	}
}
