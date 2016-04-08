using UnityEngine;

public class MasterLogic : MonoBehaviour
{
    public float SpawnTime;

    private float _lastSpawn;

    // Update is called once per frame
    void Update()
    {
        if (!PhotonNetwork.isMasterClient)
            return;

        UpdateGameLogic();
    }

    private void UpdateGameLogic()
    {
        if (_lastSpawn < Time.time)
        {
            _lastSpawn = Time.time + SpawnTime;
            SpawnMonster();
        }
    }

    private void SpawnMonster()
    {
        PhotonNetwork.InstantiateSceneObject("Monster1",
            new Vector3(Random.Range(-5f, 5f), Random.Range(-5f, 5f), 0),
            Quaternion.identity,
            0,
            null);
    }
}