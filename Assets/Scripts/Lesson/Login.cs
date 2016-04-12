using UnityEngine;
using System.Collections;

public class Login : Photon.MonoBehaviour
{
    ProfileSettings profileSettings;
    void Start()
    {
        profileSettings = (ProfileSettings)Resources.Load(PathConstants.PATH_PROFILE_SETTINGS_HOLDER, typeof(ProfileSettings));
       
        PhotonNetwork.autoJoinLobby = false;
        PhotonNetwork.ConnectUsingSettings("1.0");
    }
    void Update()
    {
        if (NetworkApi.Instance.IsLoggedIn)
        {
            Loading.Load(LoadingScene.Lobby);
        }
    }

    void SetPlayerSettings()        
    {
        if (profileSettings.nickName == "" ||
               profileSettings.nickName == null)
        {
            int nickNameID;
            string nickName;
            nickNameID = Random.Range(0, 1000);
            nickName = "Player" + nickNameID.ToString();
            profileSettings.nickName = nickName;
        }
        if (profileSettings.playerID=="" ||
                profileSettings.playerID==null)
        {
            int randomInt = Random.Range(0, 1000);
            profileSettings.playerID = "User" + randomInt.ToString();
            profileSettings.enumLevels = EnumLevels.low.ToString();
        }
    }

    void OnConnectedToMaster()
    {
        Auth();
    }


    private void Auth()
    {
        SetPlayerSettings();
        string login = profileSettings.playerID;
        StartCoroutine(NetworkApi.Instance.Login(login));
    }
}