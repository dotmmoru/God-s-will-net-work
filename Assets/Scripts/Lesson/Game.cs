using UnityEngine;
using Hashtable = ExitGames.Client.Photon.Hashtable;

public class Game : Photon.MonoBehaviour
{
    private bool _isLeaving;

    private PhotonPlayer[] Players { get { return PhotonNetwork.playerList; } }

    // Use this for initialization
    void Start()
    {
        PhotonNetwork.player.SetCustomProperties(new Hashtable
        {
            {"points", 0},
            {"name", Storage.PlayerName},
        });

       GameChat.Instance.SendChatMessage(Storage.PlayerName + " вошел");
    }

    // Update is called once per frame
    void Update()
    {
        if (_isLeaving)
            return;

        UpdateInput();
    }

    private void UpdateInput()
    {
        if (Input.GetKeyUp(KeyCode.Escape) && !_isLeaving)
        {
            _isLeaving = true;
            GameChat.Instance.SendChatMessage(Storage.PlayerName + " вышел");
            PhotonNetwork.LeaveRoom();
        }
    }

    void OnGUI()
    {
        if (_isLeaving)
            return;

        GUILayout.BeginArea(new Rect(10, 10, 200, 20));
        GUILayout.Label("HP:" + Storage.PlayerHp);
        GUILayout.EndArea();

        if (Input.GetKey(KeyCode.Tab))
        {
            GUILayout.BeginArea(new Rect(100, 100, 400, 400));
            GUILayout.BeginVertical();
            GUILayout.BeginHorizontal();
            GUILayout.Label("Name", GUILayout.Width(150));
            GUILayout.Label("Points");
            GUILayout.EndHorizontal();
            GUILayout.Space(10);
            foreach (var player in Players)
            {
                GUILayout.BeginHorizontal();
                string playerName = player.customProperties.ContainsKey("name")
                    ? player.customProperties["name"].ToString()
                    : "~";
                int points = player.customProperties.ContainsKey("points") ? (int)player.customProperties["points"] : 0;

                GUILayout.Label(playerName, GUILayout.Width(150));
                GUILayout.Label(points + "");

                GUILayout.EndHorizontal();
            }
            GUILayout.EndVertical();
            GUILayout.EndArea();
        }
    }

    void OnLeftRoom()
    {
        var points = (int)PhotonNetwork.player.customProperties["points"];

        Storage.PlayerPoints += points;
        Storage.PlayerMoney += points * Config.ConvertPointsToMoney;

        Loading.Load("");
    }
}