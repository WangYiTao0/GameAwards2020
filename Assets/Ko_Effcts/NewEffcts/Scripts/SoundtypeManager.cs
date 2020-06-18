using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum TYPE
{
    SoundUI,
    MonoUI
}

public class SoundtypeManager :MonoBehaviour
{
    public bool CanReceive;
    [System.Serializable]
    public struct SOUND_TYPE
    {
       public int SoundID;
        public Sprite SoundImage;
        public UnityEngine.Events.UnityAction ActionName;//需要触发的能力
        public TYPE SoundOrMonoUI;
        public GameObject My_Obj;
    }

    public SOUND_TYPE m_information;
    public GameObject Lunpan;
    protected virtual void SoundAction()
    {

    }
}
