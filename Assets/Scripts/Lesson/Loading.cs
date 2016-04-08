using UnityEngine;
using System.Collections;

public enum LoadingScene
{
    Lobby,
    Game,
}

public class Loading : MonoBehaviour
{
    private static LoadingScene _nextScene { get; set; }

    // Use this for initialization 
    void Start()
    {
        if (_nextScene == LoadingScene.Lobby)
        {
            StartCoroutine(JoinLobby());
        }
    }

    private IEnumerator JoinLobby()
    {
        while (PhotonNetwork.networkingPeer.State != PeerState.ConnectedToMaster)
            yield return new WaitForFixedUpdate();

        PhotonNetwork.networkingPeer.OpJoinLobby(TypedLobby.Default);
    }

    void OnJoinedLobby()
    {
        PhotonNetwork.LoadLevel(Config.SceneLobby);
    }

    void OnJoinedRoom()
    {
        PhotonNetwork.LoadLevel(Config.SceneGame);
    }

    public static void Load(LoadingScene nextScene)
    {
        _nextScene = nextScene;

        PhotonNetwork.LoadLevel(Config.SceneLoading);
    }
    public static void Load(string sceneName)
    {
        PhotonNetwork.LoadLevel(sceneName);
    }
}