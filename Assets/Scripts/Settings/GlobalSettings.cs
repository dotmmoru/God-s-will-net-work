using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class GlobalSettings : MonoBehaviour {

    public InputField inputFieldNickName;
    public Slider sliderSoundVolume;
    public Slider sliderMusicVolume;
    public Dropdown dropdownLanguage;

    SerializableSettings serializableSettings;

	void Start () {
        serializableSettings = (SerializableSettings)Resources.Load(PathConstants.PATH_GLOBAL_SETTINGS_HOLDER, typeof(SerializableSettings));
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
        if (serializableSettings.nickName == "" ||
            serializableSettings.nickName == null)
        {
            int nickNameID;
            string nickName;
            nickNameID = Random.Range(0, 1000);
            nickName = "Player" + nickNameID.ToString();
            serializableSettings.nickName = nickName;
        }
        inputFieldNickName.text = serializableSettings.nickName;
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
        serializableSettings.nickName = text;
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
