using UnityEngine;
using System.Collections;

public class TestSceneLogic : MonoBehaviour {

	// Use this for initialization
	void Start () {
        
	}

    void OnJoinedRoom()
    {
        SpawnMonster();
    }
    void Update()
    {
        if (!PhotonNetwork.isMasterClient)
            return;

        
    }
    private void SpawnMonster()
    {
      GameObject player =   PhotonNetwork.InstantiateSceneObject("player_fps",
           transform.position,
            Quaternion.identity,
            0,
            null);
      CharacterController controller = player.GetComponent<CharacterController>();
      controller.enabled = true;

      Camera camera = player.GetComponent<Camera>();
      camera.enabled = true;
    }
}
