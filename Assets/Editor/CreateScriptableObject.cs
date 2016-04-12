// CreateGameLevelMenuItem.cs

using UnityEngine;
using UnityEditor;
using System.Collections.Generic;

public static class CreateScriptableObject
{
	[MenuItem("Custom/Create Scriptable Object/Create New Map List Holder")]
    public static void CreateMapHolderHolder()
	{

        ListViewMapHolder mapListHolder =
            ScriptableObject.CreateInstance<ListViewMapHolder>();
        mapListHolder.mapListTiles = new List<SerializableMapsItem>();



        mapListHolder.mapListTiles.Add(new SerializableMapsItem());
		
		AssetDatabase.CreateAsset(mapListHolder,
			"Assets/Resources/ScriptableObjects/MapListHolder.asset");
		AssetDatabase.SaveAssets();
		
		EditorUtility.FocusProjectWindow();
		Selection.activeObject = mapListHolder;
	}
    
    [MenuItem("Custom/Create Scriptable Object/Create New Settings Holder")]
    public static void CreateSettingsHolder()
    {

        AppSettings globalSettingsHolder =
            ScriptableObject.CreateInstance<AppSettings>();
        AssetDatabase.CreateAsset(globalSettingsHolder,
            "Assets/Resources/ScriptableObjects/GlobalSettings.asset");
        AssetDatabase.SaveAssets();

        EditorUtility.FocusProjectWindow();
        Selection.activeObject = globalSettingsHolder;
    }
    [MenuItem("Custom/Create Scriptable Object/Create New Profile Settings Holder")]
    public static void CreateProfileSettingsHolder()
    {

        ProfileSettings profileSettingsHolder =
            ScriptableObject.CreateInstance<ProfileSettings>();
        AssetDatabase.CreateAsset(profileSettingsHolder,
            "Assets/Resources/ScriptableObjects/ProfileSettings.asset");
        AssetDatabase.SaveAssets();

        EditorUtility.FocusProjectWindow();
        Selection.activeObject = profileSettingsHolder;
    }
}
