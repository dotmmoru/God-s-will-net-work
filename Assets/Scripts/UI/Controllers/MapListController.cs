using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;

public class MapListController : ListViewAbstractClass
{
    public ScrollRect scrollRect;
    public GameObject prefabListViewItem;
    private ListViewMapHolder listViewMapHolder;

	void Start () {      
        listViewAbstractClassItem = prefabListViewItem.GetComponent<ListViewItemAbstractClass>();
        listViewMapHolder = (ListViewMapHolder)Resources.Load(PathConstants.PATH_MAP_LIST_HOLDER, typeof(ListViewMapHolder));
        AddNewItemsToListView();
        SetScrollBarOnFirstElement(scrollRect);
	}
	
	void Update () {
	
	}

    public void AddNewItemsToListView()
    {
        foreach (SerializableMapsItem item in listViewMapHolder.mapListTiles)
        {
            listViewAbstractClassItem.InitItemStats(item);

            InstantiateItemToListView(gameObject, prefabListViewItem);
        }
    }
}
