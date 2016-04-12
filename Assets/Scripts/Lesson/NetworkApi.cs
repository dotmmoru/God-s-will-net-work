using System;
using System.Linq;
using UnityEngine;
using System.Collections;

public class NetworkApi : MonoBehaviour {

    ProfileSettings profileSettings;
    private static NetworkApi _instance;
    public static NetworkApi Instance { get { return _instance; } }

    public bool IsLoggedIn { get; private set; }
    // Use this for initialization
    void Start()
    {
        profileSettings = (ProfileSettings)Resources.Load(PathConstants.PATH_PROFILE_SETTINGS_HOLDER, typeof(ProfileSettings));
        _instance = this;
        DontDestroyOnLoad(gameObject);
    }


    public IEnumerator Login(string login)
    {
        var www = new WWW(string.Format("{0}?method=login&login={1}", Config.ServerUri, login));

        if (!www.isDone)
            yield return www;

        if (!string.IsNullOrEmpty(www.error))
        {
            Debug.LogException(new Exception("NetworkApi.Login error:" + www.error));
            IsLoggedIn = true;
            yield break;
        }

        Debug.Log("result:" + www.text);

        var pars = www.text.Split(new[] { '&' }, StringSplitOptions.RemoveEmptyEntries);
        var dic = pars.Select(n => n.Split(new[] { '=' }, StringSplitOptions.RemoveEmptyEntries))
            .ToDictionary(k => k[0], v => v[1]);

        profileSettings.nickName = dic["nickname"];
        profileSettings.enumLevels = dic["level"];
        profileSettings.killsCount = int.Parse(dic["kills"]);
        profileSettings.deathsCount = int.Parse(dic["deaths"]);
        profileSettings.winsCount = int.Parse(dic["wins"]);
        profileSettings.losesCount = int.Parse(dic["loses"]);

        IsLoggedIn = true;
    }

    public IEnumerator UpdateInfo(string login, string nickName,string level, int kills, int deaths, int wins, int loses)
    {
        var www = new WWW(string.Format("{0}?method=update&login={1}&nick_name={2}&level={3}&kills={4}&deaths={5}&wins={6}&loses={7}",
            Config.ServerUri,
            login,
            nickName,
            level,
            kills,
            deaths,
            wins,
            loses
            ));

        if (!www.isDone)
            yield return www;

        if (!string.IsNullOrEmpty(www.error))
        {
            Debug.LogException(new Exception("NetworkApi.Login error:" + www.error));
            yield break;
        }

        Debug.Log("NetworkApi.Update result: " + www.text);
    }
}
