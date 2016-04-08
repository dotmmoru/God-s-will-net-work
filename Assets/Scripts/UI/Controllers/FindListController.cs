using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using System.Collections.Generic;
using Hashtable = ExitGames.Client.Photon.Hashtable;

public class FindListController : ListViewAbstractClass
{

    public ScrollRect scrollRect;
    public List<SerializableFindItem> findListViewItem;
    
    public GameObject prefabListViewItem;

	void Start () 
    {
        listViewAbstractClassItem = prefabListViewItem.GetComponent<ListViewItemAbstractClass>();
        GetRoomList();
        AddNewItemsToListView();
        SetScrollBarOnFirstElement(scrollRect);
	}

    void Update()
    {
        if (Input.GetKeyUp(KeyCode.R))  
        {
            EventManager.instance.FireEvent(EventManager.REFRESH_GAME_LIST); 
            GetRoomList();
            AddNewItemsToListView();
        }
    }

   

    void GetRoomList()
    {
        findListViewItem.Clear();
        var rooms = PhotonNetwork.GetRoomList();
        for (int i = 0; i < rooms.Length; i++)
        {
            SerializableFindItem findItem = new SerializableFindItem();
            findItem.mapName = rooms[i].customProperties["map"] as string;
            findItem.playerCount = rooms[i].playerCount;
            findItem.playerMax = rooms[i].maxPlayers;
            findItem.roomName = rooms[i].name;

            findListViewItem.Add(findItem);           
        }
    }

    public void AddNewItemsToListView()
    {
        foreach (SerializableFindItem item in findListViewItem)
        {
            listViewAbstractClassItem.InitItemStats(item);
          
            InstantiateItemToListView(gameObject, prefabListViewItem);
        }
    }

    public void Refresh()
    {
        EventManager.instance.FireEvent(EventManager.REFRESH_GAME_LIST);
        GetRoomList();
        AddNewItemsToListView();
    }
}
