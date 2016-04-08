using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using Hashtable = ExitGames.Client.Photon.Hashtable;

public class CreateNewGame : MonoBehaviour {

    EventManager.EventWrapper catchMapName;
    public string mapName;
    public int playerMaxNuber = 32;
    public string roomName = null;
    public Text textMapName;
    public InputField inputFieldPlayerCount;
    public InputField inputFieldRoomName; 


    void OnEnable()
    {
        catchMapName = new EventManager.EventWrapper(delegate(MyEvent myEvent)
        {
            mapName = GetMapName(myEvent);
            UpdateTextMapName(mapName);
        });
        EventManager.instance.Listen(EventManager.SEND_MAP_VALUE, catchMapName);
    }
    void OnDisable()
    {
        EventManager.instance.DestroyListener(EventManager.SEND_MAP_VALUE, catchMapName);
    }
    void Start()
    {
        StartPlayerMaxNumber(playerMaxNuber);
        inputFieldPlayerCount.onEndEdit.AddListener(UpdatePlayerMaxNumber);
        inputFieldRoomName.onEndEdit.AddListener(UpdateTextRoomName);
    }

    string GetMapName(MyEvent myEvent)
    {
        Dictionary<string, object> dictionary = (Dictionary<string, object>)myEvent.parameter;
        string _mapName = (string)dictionary[EventManager.PARAM_VALUE];     
        return _mapName;
    }

    void UpdateTextRoomName(string text)
    {
        roomName = text;
    }
    void UpdateTextMapName(string text)
    {
        textMapName.text = text;
    }
    void StartPlayerMaxNumber(int number)
    {
        inputFieldPlayerCount.text = number.ToString();
    }
    void UpdatePlayerMaxNumber(string arg0)
    {
        int number = int.Parse(arg0);
        if (arg0 == "" || number< 0 || number ==0)
        {
            inputFieldPlayerCount.text = "2";
            playerMaxNuber = 2;
        }
        if (number>32)
        {
            inputFieldPlayerCount.text = "32";
            playerMaxNuber = 32;
        }
    }

    public void ButtonClickPlay()
    {
        if (playerMaxNuber != null && mapName != null)
        {
            PhotonNetwork.CreateRoom(roomName, true, true, playerMaxNuber, new Hashtable
            {
                {"map", mapName},
            }, new[] { "map" });
            PhotonNetwork.LoadLevel(mapName);
        }
    }
}
