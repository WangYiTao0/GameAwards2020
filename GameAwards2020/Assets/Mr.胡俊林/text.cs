using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class text : MonoBehaviour
{
    Graphic.CsGraphicManager CS_Graphic;
    // AudioClipScript asd;
    CSSoundPokectManager asddd;
    // Start is called before the first frame update
    void Start()
    {
        CS_Graphic = this.GetComponent<Graphic.CsGraphicManager>();
      //  asd = GetComponent<AudioClipScript>();
        //asd.SetAudioClip(true);//loopand oneshot
        asddd = this.GetComponent<CSSoundPokectManager>();
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.A))
        {
           CS_Graphic.Create(Graphic.Em2DType.Fade);
            asddd.OpenPokect();
        }
        if (Input.GetKeyDown(KeyCode.B))
        {
            //GameObject.Find("AudioManager").GetComponent<AudioManager>().ClearBGM();
            asddd.ClosePokect();
        }
    }
}
