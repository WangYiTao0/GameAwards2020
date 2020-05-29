using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class kotest : MonoBehaviour
{
    [SerializeField] GameObject player;
    [SerializeField] GameObject Camera;
    private Light pointlight;
    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
       
       if(Input.GetKeyDown(KeyCode.F))
       {
            Graphic.CSEffectOprate.CreateEffect(Effects.TYPE2D.ReadBar);
        }
       if(Input.GetKeyDown(KeyCode.T))
        {
            if (player.transform.GetChild(3).GetComponent<Light>().enabled)
            {
                Camera.GetComponent<EdgeDetection>().enabled = true ;
                Graphic.CSEffectOprate.CreateEffectParent(Effects.TYPE3D.Listen, player);
                player.transform.GetChild(3).GetComponent<Light>().enabled = false;
            }
        }
    }
}
