using UnityEngine;
using System.Collections;

public class Storage
{
    public static string Login = "";

    public static string PlayerName = "Player" + Random.Range(0, 1000);
    public static int PlayerPoints = 0;
    public static int PlayerMoney = 0;
    public static int PlayerHp = Config.MaxPlayerHp;
}