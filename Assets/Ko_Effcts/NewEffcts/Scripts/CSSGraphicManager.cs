using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Effects
{
    public enum TYPE2D
    {
        ReadBar,
        FadeInOut,
    }
    public enum TYPE3D
    {
        Listen,
    }
    public class CSSGraphicManager : MonoBehaviour
    {
        [SerializeField] GameObject mObj_ReadBar;
        [SerializeField] GameObject mObj_FadeInOut;
        [SerializeField] GameObject mListen;
        // Start is called before the first frame update
        void Awake()
        {
            //DontDestroyOnLoad(this);
        }
        public void CreateEffects(TYPE2D type)
        {
            switch (type)
            {
                case TYPE2D.ReadBar:
                    Instantiate(mObj_ReadBar);
                    break;
                case TYPE2D.FadeInOut:
                    Instantiate(mObj_FadeInOut);
                    break;
            }
        }

        public void CreateEffects(TYPE3D type)
        {
            switch (type)
            {
                case TYPE3D.Listen:
                    Instantiate(mListen);
                    break;
            }
        }
        public void CreateEffects(TYPE3D type, GameObject parent)
        {
            switch (type)
            {
                case TYPE3D.Listen:
                    Instantiate(mListen, parent.transform);
                    break;
            }
        }

    }
}

