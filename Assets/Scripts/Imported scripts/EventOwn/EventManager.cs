using UnityEngine;


using System.Collections.Generic;
using System.Runtime.InteropServices;


public class EventManager
{
    public static string REFRESH_GAME_LIST = "REFRESH_GAME_LIST";
    public static string REFRESH_BUTTON_MAP_BACKGROUND = "REFRESH_BUTTON_MAP_BACKGROUND";
    public static string SEND_MAP_VALUE = "SEND_MAP_VALUE";

    public static string PARAM_SOURCE = "PARAM_SOURCE";
    public static string PARAM_VALUE = "PARAM_VALUE";
    public static string PARAM_ACTION = "PARAM_ACTION";

    public static string EVENT_LANGUAGE_CHANGED = "EVENT_LANGUAGE_CHANGED";
    public static string EVENT_BUTTON_CLICK_PLAY_SOUND = "EVENT_BUTTON_CLICK_PLAY_SOUND";
    public static string EVENT_CHANGE_SCENE = "EVENT_CHANGE_SCENE";
    public static string EVENT_CHANGE_FONT = "EVENT_CHANGE_FONT";
    public static string EVENT_CHANGE_FONT_COLOR = "EVENT_CHANGE_FONT_COLOR";
    public static string EVENT_BUTTON_CLICK_PLUG = "EVENT_BUTTON_CLICK_PLUG";               // ***PLUG***
    public static string EVENT_TOOL_BAR_BUTTON_CHARACTER_CLICK = "EVENT_TOOL_BAR_BUTTON_CHARACTER_CLICK";
    public static string EVENT_BUTTON_SETTINGS_SOUND_TOGGLE = "EVENT_BUTTON_SETTINGS_SOUND_TOGGLE";
    public static string EVENT_BUTTON_SETTINGS_MUSIC_TOGGLE = "EVENT_BUTTON_SETTINGS_MUSIC_TOGGLE";
    public static string EVENT_BUTTON_SETTINGS_ALARM = "EVENT_BUTTON_SETTINGS_ALARM";
    public static string SYSTEM_ON_WINDOW_RESIZED = "SYSTEM_ON_WINDOW_RESIZED";
    public static string EVENT_SET_NEW_LANGUAGE = "EVENT_SET_NEW_LANGUAGE";
    public static string EVENT_SWAPPING_CHARACTER = "EVENT_SWAPPING_CHARACTER";
    public static string EVENT_OPEN_CHARACTER_TAB = "EVENT_OPEN_CHARACTER_TAB";
    public static string EVENT_OPEN_INFO_ABOUT_LEVEL = "EVENT_OPEN_INFO_ABOUT_LEVEL";
    public static string SYSTEM_LANGUAGE_CHANGED = "SYSTEM_LANGUAGE_CHANGED";
    public class EventWrapper
    {
        public EventWrapper(OnEvent onEvent)
        {
            this.onEvent = onEvent;
        }




        public OnEvent onEvent;

        public delegate void OnEvent(MyEvent myEvent);
    }


    public static EventManager instance = new EventManager();


    public Dictionary<string, List<EventWrapper>> listeners = new Dictionary<string, List<EventWrapper>>();



    void Dispatch(MyEvent customEvent)
    {
        List<EventWrapper> tempList = new List<EventWrapper>();
        tempList.AddRange(listeners[customEvent.type]);

        foreach (EventWrapper listener in tempList)
        {
            listener.onEvent(customEvent);
        }

    }


    void AddListener(string type, EventWrapper listener)
    {
        if (!listeners.ContainsKey(type))
        {
            listeners.Add(type, new List<EventWrapper>());
        }
        listeners[type].Add(listener);

    }

    public void DestroyAllListeners(string type)
    {
        if (listeners.ContainsKey(type))
        {
            listeners[type].Clear();
        }
    }


    void RemoveListener(string type, EventWrapper wrapper)
    {
        if (listeners.ContainsKey(type))
        {
            listeners[type].Remove(wrapper);
        }

    }

    public void FireEvent(string type, object parameter)
    {
        if (listeners.ContainsKey(type))
        {
            MyEvent event1 = new MyEvent(type, parameter);
            Dispatch(event1);
        }
    }

    public void FireEvent(string type)
    {
        FireEvent(type, null);
    }



    public void Listen(string type, EventWrapper handler)
    {

        //				Log.debug (Log.EVENT, "register listener  for {0} ", type);
        //		EventHandler listener = delegate(Event e) {
        //			MyEvent myEvent = new MyEvent (e.Type, e.Target);
        //			handler.onEvent.Invoke (myEvent);
        //		};
        //		handler.listener = listener;
        AddListener(type, handler);

    }


    public void DestroyListener(string type, EventManager.EventWrapper wrapper)
    {
        if (wrapper != null)
        {

            RemoveListener(type, wrapper);
        }
        else
        {
            Log.error(Log.EVENT, "Null listener for destroy type {0}", type);
        }

    }


}
