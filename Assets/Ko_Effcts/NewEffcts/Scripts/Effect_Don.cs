﻿using Invector.vCharacterController;
using UnityEngine;

namespace Invector
{
    public class Effect_Don :  SoundtypeManager
    {
        [SerializeField] GameObject player;
        public string tagFilter = "Player";
        //public bool isReceive;
        //public bool CanReceive;
        //[System.Serializable]
        //public class aasd 
        //    {
        //    float sss;
        //    string asd;
        //    }
        //[SerializeField] aasd asdxxxx;
        float timer;
        //public GameObject CsBar;
        private void Start()
        {
            m_information.ActionName = SoundAction;
        }


        private void OnTriggerEnter(Collider other)
        {
            //if (other.gameObject.CompareTag(tagFilter))
            //{
            //    this.transform.localScale = new Vector3(3.0f, 3.0f, 3.0f);
            //}
            Lunpan.GetComponent<LunPanControl>().AddSoundToKnapsack(m_information);
            
        }
        private void OnTriggerStay(Collider other)
        {
            if (other.gameObject.CompareTag(tagFilter))
            {
                CanReceive = true;
                GameObject.Find("ActionEventsManager").GetComponent<CActionEventsManager>().isHaveSound = true;
            }
        }
        private void OnTriggerExit(Collider other)
        {
            if (other.gameObject.CompareTag(tagFilter))
            {
                CanReceive = false;
                GameObject.Find("ActionEventsManager").GetComponent<CActionEventsManager>().isHaveSound = false;
            }
            Lunpan.GetComponent<LunPanControl>().RemoveSoundForKnapsack(m_information.SoundID);
        }
        private void FixedUpdate()
        {
            timer += Time.deltaTime;
            if(timer>=1.5f)
            {
                this.gameObject.GetComponent<ParticleSystem>().Play();
                timer = 0;
            }
        }

        private void Actionx()
        {
            Debug.Log("xxx");
        }
        protected override void SoundAction()
        {
            player.GetComponent<SoundAttcakControl>().SetMode(SoundAttcakControl.ACTION_MODE.Don);
            var ReleaseSound =
          player.GetComponent<SoundAttcakControl>();
            ReleaseSound.SoundAttackPlay();
        }

      

    }
}