using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class text : MonoBehaviour
{
<<<<<<< HEAD
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
=======
   // Graphic.CsGraphicManager CS_Graphic;
    // AudioClipScript asd;
    void Start()
    {
      //  CS_Graphic = this.GetComponent<Graphic.CsGraphicManager>();
      //  asd = GetComponent<AudioClipScript>();
        //asd.SetAudioClip(true);//loopand oneshot
>>>>>>> 640b5b4... Merge pull request #5 from WangYiTao0/feature/胡俊林FirstBlood
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.A))
        {
<<<<<<< HEAD
           CS_Graphic.Create(Graphic.Em2DType.Fade);
            asddd.OpenPokect();
        }
        if (Input.GetKeyDown(KeyCode.B))
        {
            //GameObject.Find("AudioManager").GetComponent<AudioManager>().ClearBGM();
            asddd.ClosePokect();
=======
            //  CS_Graphic.Create(Graphic.Em2DType.Fade);
            Graphic.CSEffectOprate.CreateEffect(Effects.TYPE2D.FadeInOut);
        }
        if (Input.GetKeyDown(KeyCode.B))
        {
            Graphic.CSEffectOprate.CreateEffect(Effects.TYPE2D.ReadBar);
>>>>>>> 640b5b4... Merge pull request #5 from WangYiTao0/feature/胡俊林FirstBlood
        }
    }
}
