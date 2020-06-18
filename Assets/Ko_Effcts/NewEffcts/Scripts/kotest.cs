using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class kotest : MonoBehaviour
{
    [SerializeField] GameObject player;
    [SerializeField] GameObject Camera;
    //private Light pointlight;
    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
       
       //if(Input.GetKeyDown(KeyCode.F))//收集声音食物之类
       //{
       //     Graphic.CSEffectOprate.CreateEffect(Effects.TYPE2D.ReadBar);
       //     //生成收集条
       // }
       //if(Input.GetKeyDown(KeyCode.T))//进入认真倾听模式XBOX
       // {
       //     {
       //         Camera.GetComponent<EdgeDetection>().enabled = true ;
       //         Graphic.CSEffectOprate.CreateEffectParent(Effects.TYPE3D.Listen, player);
       //     }
       // }
    }
}
