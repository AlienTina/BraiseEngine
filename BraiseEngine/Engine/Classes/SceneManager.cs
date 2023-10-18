using BraiseEngine.Components;
using BraiseEngine;
using BraiseEngine.Components.Colliders;
using BraiseEngine.Engine;
using BraiseEngine.Engine;
using BraiseEngine.Engine.GameObjects;

using System;
using System.Collections.Generic;
using System.Linq;

using Newtonsoft.Json;
using System.IO;
using System.Reflection;
using BraiseEngine.Tilemaps;

namespace BraiseEngine
{
	public class SceneLoadedArgs
	{
		public string SceneName { get; set; }
		public SceneLoadedArgs(string sceneName)
		{
			SceneName = sceneName;
		}
	}
	public class SceneManagerScript
	{
		//Dictionary<string, Scene> scenes = new Dictionary<string, Scene>();

		public static void LoadSceneJson(string sceneName)
		{
			Assembly assembly = Assembly.GetExecutingAssembly();
			StreamReader reader = new StreamReader(assembly.GetManifestResourceStream($"BraiseEngine.Scenes.{sceneName}.json"));
			string JsonToScene = reader.ReadToEnd();
			Scene newScene = JsonConvert.DeserializeAnonymousType<Scene>(JsonToScene, Core.Instance.currentScene, new JsonSerializerSettings() { TypeNameHandling = TypeNameHandling.Auto });
			Core.Instance.currentScene = newScene;
			
		}

		public static void LoadSceneTiles(string sceneName)
		{
			Assembly assembly = Assembly.GetExecutingAssembly();
			StreamReader reader = new StreamReader(assembly.GetManifestResourceStream($"BraiseEngine.Scenes.{sceneName}.json"));
			string JsonToScene = reader.ReadToEnd();
			Tilemap newMap = new Tilemap();
			newMap = JsonConvert.DeserializeAnonymousType<Tilemap>(JsonToScene, newMap, new JsonSerializerSettings() { TypeNameHandling = TypeNameHandling.Auto });
			Scene newScene = new Scene();
			newScene.map = newMap;
			newScene.InitializeMap();
			Core.Instance.currentScene = newScene;
		}
	}
}
