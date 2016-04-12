using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class GlobalSettings : MonoBehaviour {

    public InputField inputFieldNickName;
    public Slider sliderSoundVolume;
    public Slider sliderMusicVolume;
    public Dropdown dropdownLanguage;

    AppSettings serializableSettings;
    ProfileSettings profileSettings;

	void Start () {
        serializableSettings = (AppSettings)Resources.Load(PathConstants.PATH_GLOBAL_SETTINGS_HOLDER, typeof(AppSettings));
        profileSettings = (ProfileSettings)Resources.Load(PathConstants.PATH_PROFILE_SETTINGS_HOLDER, typeof(ProfileSettings));
        AddListener();
        SetStartNickName();
        SetStartSoundVolume();
        SetStartMusicVolume();
	}
	
	
	void Update () {
	
	}

    void AddListener()
    {
        inputFieldNickName.onEndEdit.AddListener(UpdateNickName);
        sliderSoundVolume.onValueChanged.AddListener(UpdateSoundVolume);
        sliderMusicVolume.onValueChanged.AddListener(UpdateMusicVolume);
    }

    // SET START VALUES
    void SetStartNickName()                         // Потом переделать под бд Парс 
    {
        inputFieldNickName.text = profileSettings.nickName;
    }
    void SetStartSoundVolume()
    {
        serializableSettings.soundValue = 1;
    }
    void SetStartMusicVolume()
    {
        serializableSettings.musicValue = 1;
    }

    // UPDATE VALUES 
    void UpdateNickName(string text)
    {
        profileSettings.nickName = text;
    }
    void UpdateSoundVolume(float value)
    {
        serializableSettings.soundValue = value;
    }
    void UpdateMusicVolume(float value)
    {
        serializableSettings.musicValue = value;
    }
}
