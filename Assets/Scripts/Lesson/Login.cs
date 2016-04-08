using UnityEngine;
using System.Collections;

public class Login : Photon.MonoBehaviour
{

    // Use this for initialization
    void Start()
    {
        PhotonNetwork.autoJoinLobby = false;
        PhotonNetwork.ConnectUsingSettings("1.0");
    }

    
    void OnConnectedToMaster()
    {
        Auth();
    }


    private void Auth()
    {
        Loading.Load(Config.SceneLoading);
    }
}