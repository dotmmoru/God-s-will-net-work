using UnityEngine;
using System.Collections;

public class PlayerController : MonoBehaviour
{
    public int Dmg;
    public float AttackSpeed;
    public GameObject AttackEffect;

    private float _lastAttack;

    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        UpdateInput();
    }

    private void UpdateInput()
    {
        if (Input.GetMouseButtonDown(0) && _lastAttack < Time.time)
        {
            _lastAttack = Time.time + AttackSpeed;

            RaycastHit hit;
            Ray ray = Camera.main.ScreenPointToRay(new Vector3(Input.mousePosition.x, Input.mousePosition.y, 0));

            if (Physics.Raycast(ray, out hit, float.MaxValue))
            {
                if (hit.collider.tag == "Monster")
                {
                    var monster = hit.collider.GetComponent<Monster>();
                    monster.PlayerAttack(Dmg);
                }
            }

            CreateAttackEffect(hit.point);
        }
    }

    private void CreateAttackEffect(Vector3 point)
    {
        StartCoroutine(Destroy(PhotonNetwork.Instantiate(AttackEffect.name, point, Quaternion.identity, 0), 2f));
    }

    IEnumerator Destroy(GameObject obj, float time)
    {
        yield return new WaitForSeconds(time);
        PhotonNetwork.Destroy(obj);
    }
}