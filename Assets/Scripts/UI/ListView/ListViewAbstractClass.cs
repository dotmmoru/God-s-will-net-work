using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;

public abstract class ListViewAbstractClass : MonoBehaviour {

    protected ListViewItemAbstractClass listViewAbstractClassItem;
    protected List<GameObject> listviewGOItems = new List<GameObject>();



    protected void SetScrollBarOnFirstElement(ScrollRect scrollRect)
    {
        scrollRect.verticalNormalizedPosition = 1;                           // set the vartical scroll possistion , it between 0 and 1 
    }


    public void InstantiateItemToListView(GameObject parent, GameObject children)                     // Instantiate a new item to list 
    {
        GameObject newItem = Instantiate(children) as GameObject;
        newItem.transform.parent = parent.transform;
        listviewGOItems.Add(newItem);
    }
    
}
