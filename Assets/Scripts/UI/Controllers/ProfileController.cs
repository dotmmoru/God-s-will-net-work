using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class ProfileController : MonoBehaviour {

    public Text textPlayerID;
    public Text textPlayerNickName;
    public Text textPlayerLevel;
    public Text textKills;
    public Text textDeaths;
    public Text textWins;
    public Text textLoses;

    ProfileSettings profileSettings;
	void Start () 
    {
        profileSettings = (ProfileSettings)Resources.Load(PathConstants.PATH_PROFILE_SETTINGS_HOLDER, typeof(ProfileSettings));

        SetStartPlayerID();
        SetStartNickName();
        SetStartPlayerLevel();
        SetStartPlayerKills();
        SetStartPlayerDeaths();
        SetStartPlayerWins();
        SetStartPlayerLoses();
	}
	
	
	void Update () {
	
	}
    void SetStartNickName()                         // Потом переделать под бд Парс 
    {
        textPlayerNickName.text = profileSettings.nickName;
    }
    void SetStartPlayerID()
    {
        textPlayerID.text = profileSettings.playerID;
    }
    void SetStartPlayerLevel()
    {
        textPlayerLevel.text = profileSettings.enumLevels.ToString();
    }
    void SetStartPlayerKills()
    {
        textKills.text = profileSettings.killsCount.ToString();
    }
    void SetStartPlayerDeaths()
    {
        textDeaths.text = profileSettings.deathsCount.ToString();
    }
    void SetStartPlayerWins()
    {
        textWins.text = profileSettings.winsCount.ToString();
    }
    void SetStartPlayerLoses()
    {
        textLoses.text = profileSettings.losesCount.ToString();
    }
}
