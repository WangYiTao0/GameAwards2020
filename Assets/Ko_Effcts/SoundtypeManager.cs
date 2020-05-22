using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundtypeManager :MonoBehaviour
{
    [System.Serializable]
    public struct SOUND_TYPE
    {
       public int SoundID;
        public Sprite SoundImage;
        public UnityEngine.Events.UnityAction ActionName;//需要触发的能力
    }
  protected virtual void SoundAction()
    {

    }
}
