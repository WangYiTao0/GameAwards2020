using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering;

public class QuestControl : MonoBehaviour
{
    [SerializeField] GameObject mRippe;//音波特效
    [SerializeField] bool mIsGoingBack;
    [SerializeField] Light mLight;//点光源
    [SerializeField] float Speed;//点光源变化速度变化范围速度
    
    // Start is called before the first frame update
    void Start()
    {
        mRippe.GetComponent<ParticleSystem>().Play();
        mIsGoingBack = false;
        mLight.range = 0;
    }
     void Update()
    {
        if(Input.GetKeyUp(KeyCode.T))//倾听结束时
        {
            mIsGoingBack = true;//音波范围缩小
            mRippe.GetComponent<ParticleSystem>().Stop();//停掉音波的特效
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
                //GameObject.Find("vThirdPersonCamera").GetComponent<EdgeDetection>().enabled = false;
            }
        }
    }


}
