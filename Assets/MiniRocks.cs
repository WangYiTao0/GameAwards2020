using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class MiniRocks : MonoBehaviour
{
    [SerializeField] GameObject Mono1;
    [SerializeField] GameObject mParticle;
    [SerializeField] float Distance;
    [SerializeField] float Speed;
    Vector3 Dir;
    // Start is called before the first frame update
    void Start()
    {
        Mono1 = GameObject.Find("WorldWall");
        mParticle = GameObject.Find("Player").transform.Find("SoundAttack").gameObject;
        if(mParticle!=null)
        Dir = Vector3.Normalize(this.transform.position - mParticle.transform.position);
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
        var dis = Vector3.Distance(mParticle.transform.position, this.transform.position);
        if(dis<=Distance)
        {
            this.GetComponent<Rigidbody>().AddForce(Dir * Speed);
        }
       
    }

}
