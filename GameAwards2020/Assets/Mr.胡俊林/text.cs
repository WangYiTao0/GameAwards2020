using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class text : MonoBehaviour
{
   // Graphic.CsGraphicManager CS_Graphic;
    // AudioClipScript asd;
    void Start()
    {
      //  CS_Graphic = this.GetComponent<Graphic.CsGraphicManager>();
      //  asd = GetComponent<AudioClipScript>();
        //asd.SetAudioClip(true);//loopand oneshot
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.A))
        {
            //  CS_Graphic.Create(Graphic.Em2DType.Fade);
            Graphic.CSEffectOprate.CreateEffect(Effects.TYPE2D.FadeInOut);
        }
        if (Input.GetKeyDown(KeyCode.B))
        {
            Graphic.CSEffectOprate.CreateEffect(Effects.TYPE2D.ReadBar);
        }
    }
}
