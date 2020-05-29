using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering;

public class QuestControl : MonoBehaviour
{
    [SerializeField] GameObject mRippe;
    [SerializeField] bool mIsGoingBack;
    [SerializeField] Light mLight;
    [SerializeField] float Speed;
    
    // Start is called before the first frame update
    void Start()
    {
        mRippe.GetComponent<ParticleSystem>().Play();
        mIsGoingBack = false;
        mLight.range = 0;
    }
     void Update()
    {
        if(Input.GetKeyUp(KeyCode.T))
        {
            mIsGoingBack = true;
            mRippe.GetComponent<ParticleSystem>().Stop();
        }
        if (!mIsGoingBack)
        {
            if (mLight.range <= 100)
            {
                mLight.range += Speed;
            }
        }
        else 
        {
            if (mLight.range > 1)
            {
                mLight.range -= Speed;
            }
            else
            {
                Destroy(this.gameObject);
                GameObject.Find("Player").transform.GetChild(3).GetComponent<Light>().enabled = true;
                GameObject.Find("vThirdPersonCamera").GetComponent<EdgeDetection>().enabled = false;
            }
        }
    }


}
