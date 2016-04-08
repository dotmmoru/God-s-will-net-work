using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System;
using System.Linq;
using System.Text;
using System.IO;

public class SceneHelper : MonoBehaviour
{
		public static SceneHelper instance;

		public AsyncOperation async;

		public void Start ()
		{
				if (SceneHelper.instance == null) {
						SceneHelper.instance = this;
						GameObject.DontDestroyOnLoad (this.gameObject);
				}
		}

		public static string LOADING_SCENE_ARGUMENT = "LOADING_SCENE_ARGUMENT";

        public static string LOADING_SCENE = "SceneLoading";
		public static string PLAYER_SCENE = "player";
		public static string GAME_SCENE = "game";
        public static string MENU_SCENE = "SceneMainMenu";
		public static string LEVELS_SCENE = "levels";
        public static string SHOP_SCENE = "SceneShop";

		public static string LEVEL_PARAM = "LEVEL_PARAM";
		public static string CHAPTER_PARAM = "CHAPTER_PARAM";
	

		private Dictionary<string, object> sceneArguments = new Dictionary<string, object> ();

		void LoadLevel (string sceneName)
		{
				Application.LoadLevel (sceneName);
		}

		string currentSceneForLoad;

		void LoadLevelAsync (string sceneName)
		{
//				Log.warn ("scene ", sceneName);
				this.currentSceneForLoad = sceneName;
				StartCoroutine ("InnerLoad");
		}


		public void LoadScene (string sceneName, Dictionary<string, object> parameters, bool showLoadScene)
		{
				if (parameters == null) {
						parameters = new Dictionary<string, object> ();
				}
		
				if (showLoadScene) {
//						Log.warn ("loading", sceneName);
						string loadingScene = LOADING_SCENE;
						this.sceneArguments = parameters;
						this.sceneArguments [LOADING_SCENE_ARGUMENT] = sceneName;
						LoadLevel (loadingScene);
				} else {
						
//						Log.warn (Log.SCENES, "Start load scene {0} args = {1}", sceneName, GetLine (parameters));
						this.sceneArguments = parameters;

						LoadLevelAsync (sceneName);

				}

		}

		IEnumerator InnerLoad ()
		{
				
//				Debug.LogWarning ("ASYNC LOAD STARTED - " +
//				"DO NOT EXIT PLAY MODE UNTIL SCENE LOADS... UNITY WILL CRASH");
				async = Application.LoadLevelAsync (currentSceneForLoad);
				async.allowSceneActivation = false;
//				async.allowSceneActivation = false;
				yield return null;
		}

		public void LoadScene (string sceneName, Dictionary<string, object> parameters)
		{

				LoadScene (sceneName, parameters, false);
		}

		public void LoadScene (string sceneName)
		{
		
				LoadScene (sceneName, new Dictionary<string, object> ());
		}

		public Dictionary<string, object> GetSceneArguments ()
		{

		
				Log.debug (Log.SCENES, "get scene args = {0}", GetLine (sceneArguments));
				return this.sceneArguments;
		}

		string GetLine (Dictionary<string, object> d)
		{
				// Build up each line one-by-one and then trim the end
				StringBuilder builder = new StringBuilder ();
				foreach (KeyValuePair<string, object> pair in d) {
						builder.Append (pair.Key).Append (":").Append (pair.Value).Append (',');
				}
				string result = builder.ToString ();
				// Remove the final delimiter
				result = result.TrimEnd (',');
				return result;
		}

}
