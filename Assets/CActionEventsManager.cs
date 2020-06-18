using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

namespace Invector.vCharacterController
{
    public class CActionEventsManager : vMonoBehaviour
    {
        [SerializeField] GameObject mAnimator;
        [SerializeField] bool StaminaRecovery;
        private void Start()
        {
            StaminaRecovery = false;

        }
        private void Update()
        {
            if(StaminaRecovery)
            {
                var trmono = mAnimator.GetComponent<vThirdPersonMotor>();
                trmono.StaminaRecovery();
              if(trmono.currentStamina==trmono.maxStamina)
                {
                    StaminaRecovery = false;
                    return;
                }
            }
        }
        public void OnPickupMonoStart()
        {

        }
        public void OnPickupMonoEnd()
        {
            GameObject.Find("vUI").transform.GetChild(1).GetChild(0).GetComponent<LunPanControl>().SoundMessageToLunpanForMono();
        }
        public void OnLisenEventStart()
        {
            Graphic.CSEffectOprate.CreateEffect(Effects.TYPE2D.ReadBar);
        }
        public void OnLisenEventEnd()
        {

        }


        //
        public void RedClickAction()
        {
            //
            StaminaRecovery = true;
            var asd = mAnimator.GetComponent<Animator>();
            asd.CrossFadeInFixedTime("Drink", 0.1f);
        }
    }
}
