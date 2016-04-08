using UnityEngine;
using System.Collections;

public abstract class ListViewItemAbstractClass : MonoBehaviour {
    public abstract void InitItemStats(SerializableFindItem listViewShopItem);
    public abstract void InitItemStats(SerializableMapsItem SerializableMaps);
}
