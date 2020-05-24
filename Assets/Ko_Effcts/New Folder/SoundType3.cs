using UnityEngine;

namespace Invector
{
    public class SoundType3 : SoundtypeManager
    {
        public string tagFilter = "Player";
        [SerializeField] SOUND_TYPE m_information;
        [SerializeField] GameObject Lunpan;

        private void Start()
        {
            m_information.ActionName = SoundAction;
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
            Debug.Log(" i am type3");
        }



    }
}