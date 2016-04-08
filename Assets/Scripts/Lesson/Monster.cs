using System.Collections;
using UnityEngine;
using Hashtable = ExitGames.Client.Photon.Hashtable;

public class Monster : Photon.MonoBehaviour
{
    public int Hp;
    public int Dmg;
    public float AttackSpeed;

    private float _lastAttack;

    private bool IsDie { get { return Hp <= 0; } }

    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (!PhotonNetwork.isMasterClient)
            return;

        if (_lastAttack < Time.time)
        {
            _lastAttack = Time.time + AttackSpeed;
            Attack();
        }
    }

    private void Attack()
    {
        photonView.RPC("Attacked", PhotonTargets.All);
    }

    public void PlayerAttack(int dmg)
    {
        if (IsDie)
            return;

        photonView.RPC("ReceivedDmg", PhotonTargets.AllBuffered, dmg);
    }

    [PunRPC]
    private void Attacked()
    {
        //play attack anim
        StartCoroutine(AttackAnim());

        if (Storage.PlayerHp > 0)
        {
            Storage.PlayerHp -= Dmg;

            if (Storage.PlayerHp <= 0)
            {
                Storage.PlayerHp = 0;
                GameChat.Instance.SendChatMessage(Storage.PlayerName + " убит!");
                PhotonNetwork.LeaveRoom();
            }
        }
    }

    [PunRPC]
    private void ReceivedDmg(int dmg, PhotonMessageInfo info)
    {
        if (IsDie)
            return;

        Hp -= dmg;

        if (!PhotonNetwork.isMasterClient)
            return;

        if (IsDie)
        {
            PhotonNetwork.Destroy(photonView);

            string playerName = info.sender.customProperties["name"].ToString();
            var points = (int)info.sender.customProperties["points"];
            points += 1;

            info.sender.SetCustomProperties(new Hashtable { { "points", points } });

           GameChat.Instance.SendChatMessage(playerName + " завалил монстра!");
      
        }
    }

    private IEnumerator AttackAnim()
    {
        Vector3 from = Vector3.one * 0.6f;
        Vector3 to = Vector3.one;
        float time = 0.5f;
        float endTime = Time.time + time;
        transform.localScale = from;

        while (endTime > Time.time)
        {
            transform.localScale = Vector3.Lerp(transform.localScale, to, Time.deltaTime * 2f);
            yield return new WaitForEndOfFrame();
        }

        transform.localScale = to;
    }
}