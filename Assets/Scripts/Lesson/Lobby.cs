using UnityEngine;
using Hashtable = ExitGames.Client.Photon.Hashtable;

public class Lobby : MonoBehaviour
{
    public enum MenuState
    {
        Home,
        Lobby,
    }

    private Vector2 scrollPosition;

    public Vector2 LobbyTableOffset = new Vector2(0, 80);
    public Vector2 LobbyTableSize = new Vector2(280, 225);

    private string _newRoomMap = "Angle";
    private int _maxPlayerCount = 32;

    private MenuState _state;

    void Start()
    {
        _state = MenuState.Lobby;

    }

    void OnGUI()
    {
        DrawTopNavigation();

        switch (_state)
        {
            case MenuState.Home:
                DrawHome();
                break;
            case MenuState.Lobby:
                DrawLobby();
                break;
        }
    }

    private void DrawTopNavigation()
    {
        GUILayout.BeginArea(new Rect(Screen.width / 2 - 100, 40, 200, 25));
        GUILayout.BeginHorizontal();
        if (GUILayout.Button("Home", GUILayout.Width(90)))
            _state = MenuState.Home;
        GUILayout.FlexibleSpace();
        if (GUILayout.Button("Play", GUILayout.Width(90)))
            _state = MenuState.Lobby;
        GUILayout.EndHorizontal();
        GUILayout.EndArea();
    }

    private void DrawHome()
    {
        GUILayout.BeginArea(new Rect(150, 100, 200, 200));
        GUILayout.Label("Name: " + Storage.PlayerName);
        GUILayout.Label("HP:" + Storage.PlayerHp);
        GUILayout.Label("Points: " + Storage.PlayerPoints);
        GUILayout.Label("Money: " + Storage.PlayerMoney);

        if (Storage.PlayerHp == 0)
        {
            if (GUILayout.Button("Healthing(" + Config.HealthingPrice + " �����)") && Storage.PlayerMoney >= Config.HealthingPrice)
            {
                Storage.PlayerHp = Config.MaxPlayerHp;
                Storage.PlayerMoney -= Config.HealthingPrice;

            /*    StartCoroutine(NetworkApi.Instance.UpdateInfo(Storage.Login, Storage.PlayerPoints, Storage.PlayerMoney,
                    Storage.PlayerHp));
           */ }
        }
        GUILayout.EndArea();
    }

    private void DrawLobby()
    {
        var rooms = PhotonNetwork.GetRoomList();

        GUILayout.BeginArea(new Rect(Screen.width / 2 - LobbyTableSize.x / 2f - LobbyTableOffset.x, LobbyTableOffset.y, LobbyTableSize.x, LobbyTableSize.y));
        GUILayout.BeginHorizontal();

        GUILayout.Label("Map name", GUILayout.Width(100));
        GUILayout.Label("Кол-во игроков");

        GUILayout.EndHorizontal();
        scrollPosition = GUILayout.BeginScrollView(scrollPosition,
            GUILayout.Width(LobbyTableSize.x - 10),
            GUILayout.Height(LobbyTableSize.y - 25));


        for (int i = 0; i < rooms.Length; i++)
        {
            var room = rooms[i];
            if (room.removedFromList)
                continue;
            var mapName = room.customProperties["map"] as string;

            GUILayout.BeginHorizontal();

            GUILayout.Label(mapName, GUILayout.Width(100));
            GUILayout.Label(room.playerCount + "/" + room.maxPlayers, GUILayout.Width(40));

            if (GUILayout.Button("Join"))
            {
                PhotonNetwork.JoinRoom(room.name);//PhotonNetwork.JoinRoom(room.name, true);
                Loading.Load("");
            }
            GUILayout.EndHorizontal();
        }

        GUILayout.EndScrollView();

        GUILayout.EndArea();

        //create room

        GUILayout.BeginArea(new Rect(Screen.width - 100f, LobbyTableOffset.y, 95, LobbyTableSize.y));
        GUILayout.Label("Room map:");
        GUILayout.Label(_newRoomMap);
        GUILayout.Label("Max players:");
        GUILayout.Label(_maxPlayerCount + "");

        if (GUILayout.Button("Create"))
        {
            PhotonNetwork.CreateRoom(null, true, true, _maxPlayerCount, new Hashtable
            {
                {"map", _newRoomMap},
            }, new[] { "map" });
            Loading.Load("");
        }
        GUILayout.EndArea();
    }
}