using UnityEngine;
using System.Collections;

public class InitCreater : MonoBehaviour
{
		public Transform prefabInit;
		public Transform prefabSceneHelper;

		void InitPrefab ()
		{
				Instantiate (prefabInit);
		}

		void ScenePrefab ()
		{
				Instantiate (prefabSceneHelper);
		}

		void Init ()
		{
			/*	GameObject initObject = GameObject.FindGameObjectWithTag (Tags.INIT);
				if (initObject == null) {
						InitPrefab ();
				}

				GameObject sceneObject = GameObject.FindGameObjectWithTag (Tags.SCENE_HELPER);
				if (sceneObject == null) {
						ScenePrefab ();
				}*/
		}

		public void Awake ()
		{
				Init ();
		
		}

		// Use this for initialization
		void OnEnable ()
		{
				Init ();
		}
	
		// Update is called once per frame
		void Update ()
		{
	
		}
}
