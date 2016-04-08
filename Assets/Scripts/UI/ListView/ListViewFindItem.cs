using UnityEngine;
using System.Collections;
using UnityEngine.UI;
public class ListViewFindItem: ListViewItemAbstractClass
{

    public Text textMapName;
    public Text textPlayerCount;
    public Text textRoomName;

    public string mapNameToLoad;
    public string roomNameToLoad;

    EventManager.EventWrapper listenerRefreshGameList;

    void OnEnable()
    {
        listenerRefreshGameList = new EventManager.EventWrapper(delegate(MyEvent myEvent)
        {
            SelfDestroy();
        });
        EventManager.instance.Listen(EventManager.REFRESH_GAME_LIST, listenerRefreshGameList);
    }
    void OnDisable()
    {
        EventManager.instance.DestroyListener(EventManager.REFRESH_GAME_LIST, listenerRefreshGameList);
    }

    public override void InitItemStats(SerializableFindItem listViewShopItem)
    {
        SetMapNameText(listViewShopItem.mapName);
        SetPlayerCountText(listViewShopItem.playerCount, listViewShopItem.playerMax);
        SetRoomNameText(listViewShopItem.roomName);
        SetLoadParameters(listViewShopItem.mapName, listViewShopItem.roomName);
    }

    void SetMapNameText(string text)
    {
        textMapName.text = text;
    }
    void SetPlayerCountText(int playerCount, int playerMax)
    {
        textPlayerCount.text = playerCount.ToString() + "/" + playerMax.ToString();
    }
    void SetRoomNameText(string text)
    {
        textRoomName.text = text;
    }
    void SetLoadParameters(string mapName, string roomName)
    { 
        mapNameToLoad = mapName;
        roomNameToLoad = roomName;
    }

    public void ButtonClickJoin()               // set to button join 
    {
        PhotonNetwork.JoinRoom(roomNameToLoad);//PhotonNetwork.JoinRoom(room.name, true);
        Loading.Load(mapNameToLoad);
    }

    public void SelfDestroy()
    {
        Destroy(gameObject);
    }


    public override void InitItemStats(SerializableMapsItem SerializableMaps)
    {
        throw new System.NotImplementedException();
    }
}
