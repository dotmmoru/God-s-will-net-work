using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;

public class ListViewMapItem : ListViewItemAbstractClass
{
    public Image imageBackGround;
    public Image imageMap;
    public string mapName;

    private Color32 blackColor = new Color32(60,62,60,255);
    private Color32 redColor = new Color32(255, 0, 0, 255);

    EventManager.EventWrapper refreshMapBackGround;

    void OnEnable()
    {
        refreshMapBackGround = new EventManager.EventWrapper(delegate(MyEvent myEvent)
        {
            SetStartColor();
        });
        EventManager.instance.Listen(EventManager.REFRESH_BUTTON_MAP_BACKGROUND, refreshMapBackGround);
    }
    void OnDisable()
    {
        EventManager.instance.DestroyListener(EventManager.REFRESH_BUTTON_MAP_BACKGROUND, refreshMapBackGround);
    }

    public override void InitItemStats(SerializableMapsItem serializableMapsItem)
    {
        SetMapImage(serializableMapsItem.mapSprite);
        SetMapName(serializableMapsItem.mapName);
    }

    public override void InitItemStats(SerializableFindItem listViewShopItem)
    {
        throw new System.NotImplementedException();
    }

    void SetMapImage(Sprite sprite)
    {
        imageMap.sprite = sprite;
    }

    void SetMapName(string name)
    {
        mapName = name;
    }

    void SetStartColor()
    {
        imageBackGround.color = blackColor;
    }

    public void ButtonClickMap()
    {
        Dictionary<string, object> parameter = new Dictionary<string, object>();                    // send name of selected map 
        parameter.Add(EventManager.PARAM_VALUE, mapName);
        EventManager.instance.FireEvent(EventManager.SEND_MAP_VALUE,parameter);
        EventManager.instance.FireEvent(EventManager.REFRESH_BUTTON_MAP_BACKGROUND);
        imageBackGround.color = redColor;
    }
}
