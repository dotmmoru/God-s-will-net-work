using System.Collections.Generic;
using UnityEngine;

public class GameChat : Photon.MonoBehaviour
{
    //private static GameChat _instance;
    public static GameChat Instance;

    private readonly List<string> _messages = new List<string>();
    private string _messageText = "";
    private bool _showInput;

    public void Awake()
    {
        if (GameChat.Instance == null)
        {
            GameChat.Instance = this;
            GameObject.DontDestroyOnLoad(this.gameObject);
        }
    }

    void Update()
    {
        if (Input.GetKeyUp(KeyCode.Return) && !_showInput)
            _showInput = true;
    }

    void OnGUI()
    {
        GUILayout.BeginArea(new Rect(10, Screen.height - 20 * Config.MaxChatMessageCount - 30, 250, 20 * Config.MaxChatMessageCount));

        GUILayout.Label(string.Join("\n", _messages.ToArray()));

        GUILayout.EndArea();

        if (_showInput)
        {
            GUI.SetNextControlName("tbMessage");
            _messageText = GUI.TextField(new Rect(10, Screen.height - 25, 150, 20), _messageText, 20);
            GUI.FocusControl("tbMessage");

            if (Event.current != null && Event.current.character == '\n')
            {
                if (!string.IsNullOrEmpty(_messageText))
                {
                    SendChatMessage(PhotonNetwork.player.customProperties["name"] + ": " + _messageText);
                }

                _messageText = "";
                _showInput = false;
            }
        }
    }

    void OnLeftRoom()
    {
        _messages.Clear();
    }

    public void SendChatMessage(string msg)
    {
        photonView.RPC("ReceivedMessage", PhotonTargets.All, msg);
    }

    [PunRPC]
    private void ReceivedMessage(string message)
    {
      _messages.Add(message);

        if (_messages.Count > Config.MaxChatMessageCount)
            _messages.RemoveAt(0);
    }
}