using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class CSSoundPokectManager : MonoBehaviour, iSoundPokect,iSoundOperate
{
    [SerializeField] private eSoundPokect m_SoundPokectState;
    [SerializeField] private eSoundOperate EM_SoundOperateState;
    [SerializeField] private int m_SoundsMax;
    private GameObject OBJ_BarManager;//为了检查进度条OBJ是否出现
    private GameObject OBJ_CheckTarget;//传入要检查的物体
    private List<cSound> CS_mSounds;//无法返回list引用//多体
    private cSound CS_m_Sound; //单体




    // Start is called before the first frame update
    void Start()
    {
        m_SoundPokectState = eSoundPokect.SP_EMPTY;
        EM_SoundOperateState = eSoundOperate.SO_DISABLE;
        CS_mSounds = new List<cSound>();
        OBJ_BarManager = null;
    }


    // Update is called once per frame
    void Update()
    {
        m_SoundPokectState = ((iSoundPokect)this).CheckSoundPokectStatus();
        EM_SoundOperateState = ((iSoundOperate)this).CheckSoundOperateStatus(ref OBJ_CheckTarget);
    }

    eSoundPokect iSoundPokect.CheckSoundPokectStatus()
    {
        eSoundPokect _eSoundPokectState = eSoundPokect.SP_EMPTY;

        if (m_SoundPokectState != eSoundPokect.SP_USING)
        {
            if (CS_mSounds.Count != 0)
            {
                OBJ_BarManager = GameObject.Find("BarObjCanvas(Clone)");
                if (OBJ_BarManager != null)
                {
                    _eSoundPokectState = eSoundPokect.SP_RECEIVING;
                }
                else
                {
                    _eSoundPokectState = eSoundPokect.SP_FREE;
                }
            }
        }
        else
        {
            _eSoundPokectState = eSoundPokect.SP_USING;
        }

        return _eSoundPokectState;
    }

    ref cSound iSoundPokect.GetSound()
    {
        return  ref CS_m_Sound;
    }

    void iSoundPokect.ReceiveSound(ref cSound sound)
    {
        int SoundCount = CS_mSounds.Count;
        if(SoundCount<m_SoundsMax)
            CS_mSounds.Add(sound);
    }

    void iSoundPokect.ReleaseSound()
    {
        for(int i= CS_mSounds.Count-1; i>=0; i--)
        {
            if(CS_mSounds[i])//判断条件
            {
                CS_mSounds.Remove(CS_mSounds[i]);
            }
        }
    }
    public void OpenPokect()
    {
        m_SoundPokectState = eSoundPokect.SP_USING;
    }
    public void ClosePokect()
    {
        m_SoundPokectState = eSoundPokect.SP_EMPTY;
    }
    public void SetCheckTargetObj(ref GameObject obj)
    {
        OBJ_CheckTarget = obj;
    }






    eSoundOperate iSoundOperate.CheckSoundOperateStatus(ref GameObject obj)
    {
        eSoundOperate _EM = eSoundOperate.SO_DISABLE;
        return _EM;
    }

    void iSoundOperate.UseSound(ref GameObject obj)
    {
        if (m_SoundPokectState != eSoundPokect.SP_USING)
        {
            switch (EM_SoundOperateState)
            {
                case eSoundOperate.SO_DISABLE:
                    {
                        //pattern
                        //SE
                    }
                    break;
                case eSoundOperate.SO_ENABLE:
                    {
                        //Action
                    }
                    break;
            }
        }
    }
}
