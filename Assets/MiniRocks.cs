using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class MiniRocks : MonoBehaviour
{
    [SerializeField] GameObject Mono1;
    [SerializeField] float Speed;
    // Start is called before the first frame update
    void Start()
    {
        Mono1 = GameObject.Find("WorldWall");
    }

    // Update is called once per frame
    void Update()
    {
        if (Mono1 != null)
        {
            var cs =
            Mono1.GetComponentInChildren<CMonoControy>();
            cs.Updatecheck(this.gameObject);
        }
    }
    private void OnParticleCollision(GameObject other)
    {
        Debug.Log("xxxxxxxxxxxxxx");
        if (other.tag == "AttackAction")
        {
            Debug.Log("aaaaaaaaaaaaaaa");
            this.GetComponent<Rigidbody>().AddForce(Vector3.up * Speed);
            Destroy(this.gameObject);
        }
    }
}
