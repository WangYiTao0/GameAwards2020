using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace Graphic
{


    public static  class CSEffectOprate 
    {
        public static void CreateEffect(Effects.TYPE2D type)
        {
            Effects.CSSGraphicManager _CsGraphic =
            GameObject.Find("GraphicManager").GetComponent<Effects.CSSGraphicManager>();
            _CsGraphic.CreateEffects(type);
        }
        public static void CreateEffect(Effects.TYPE3D type)
        {
            Effects.CSSGraphicManager _CsGraphic =
          GameObject.Find("GraphicManager").GetComponent<Effects.CSSGraphicManager>();
            _CsGraphic.CreateEffects(type);
        }
    }
}
