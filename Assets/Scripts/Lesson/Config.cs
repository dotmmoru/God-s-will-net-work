using UnityEngine;
using System.Collections;

public class Config {

    public const string SceneLogin = "Login";
    public const string SceneLobby = "Lobby";
    public const string SceneGame = "Game";
    public const string SceneLoading = "Loading";

    public const int MaxPlayerHp = 10000;
    public const int HealthingPrice = 500;

    public const int ConvertPointsToMoney = 200;

    public const int MaxChatMessageCount = 7;

    public const string ServerUri = "http://localhost:8080/test/index.php";
}
