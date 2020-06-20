using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;
using UnityEngine.Events;

namespace Invector.vCharacterController
{
    public class CActionEventsManager : vMonoBehaviour
    {
        [SerializeField] GameObject mAnimator;
        [SerializeField] EdgeDetectNormalsAndDepth mcEdge;
        [SerializeField] bool StaminaRecovery;
        [SerializeField] bl_MiniMapItem[] CSItemIConControys;
        public bool isHaveSound;
        private void Start()
        {
            StaminaRecovery = false;
            isHaveSound = false;
            IconClose();
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
            if(Input.GetKeyDown(KeyCode.Mouse1))
            {
                mAnimator.GetComponent<Rigidbody>().isKinematic = true;
            }
            else if(Input.GetKeyUp(KeyCode.Mouse1))
            {
                mAnimator.GetComponent<Rigidbody>().isKinematic = false;
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
            if(isHaveSound)
            Graphic.CSEffectOprate.CreateEffect(Effects.TYPE2D.ReadBar);
            else
            {
                mcEdge.enabled = true;
                mcEdge.EdgeStart();
                IconOpen();
            }
        }
        public void OnLisenEventEnd()
        {
            if(!isHaveSound)
            mcEdge.EdgeEnd();
            IconClose();
        }
     


        //
        public void RedClickAction()
        {
            //
            StaminaRecovery = true;
            var asd = mAnimator.GetComponent<Animator>();
            asd.CrossFadeInFixedTime("Drink", 0.1f);
        }
        private void IconClose()
        {
            foreach (var Icon in CSItemIConControys)
            {
                Icon.Size = 0;
                Icon.OffScreenSize = 0;
            }
        }
        private void IconOpen()
        {
            foreach (var Icon in CSItemIConControys)
            {
                Icon.Size = 30;
                Icon.OffScreenSize = 10;
            }
        }
    }
}
