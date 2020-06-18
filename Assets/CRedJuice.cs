using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Invector.vCharacterController;

namespace Invector
{
    public class CRedJuice : SoundtypeManager
    {
        public string tagFilter = "Player";


        private void Start()
        {
            //m_information.ActionName =
            var xx = GameObject.Find("ActionEventsManager").GetComponent<CActionEventsManager>();
            m_information.ActionName = xx.RedClickAction;
        }


        private void OnTriggerEnter(Collider other)
        {
            Lunpan.GetComponent<LunPanControl>().AddSoundToKnapsack(m_information);
        }
        private void OnTriggerStay(Collider other)
        {
            if (other.gameObject.CompareTag(tagFilter))
            {
                CanReceive = true;
            }
        }
        private void OnTriggerExit(Collider other)
        {
            if (other.gameObject.CompareTag(tagFilter))
            {
                CanReceive = false;
            }
            Lunpan.GetComponent<LunPanControl>().RemoveSoundForKnapsack(m_information.SoundID);
        }
        private void FixedUpdate()
        {
        }

        protected override void SoundAction()
        {
            Debug.Log(" i am type mono1");
        }
      


    }
}
