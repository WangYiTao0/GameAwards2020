
using GameFramework;

namespace GameName
{
    public class SoundItem : Entity
    {
        private SoundItemData m_SoundItemData = null;

        protected override void OnShow(object userData)
        {
            base.OnShow(userData);

            m_SoundItemData = (SoundItemData)userData;
            CachedTransform.SetLocalScaleX(0.3f);
            CachedTransform.SetLocalScaleY(0.3f);
            CachedTransform.SetLocalScaleZ(0.3f);
            CachedTransform.SetPositionX(m_SoundItemData.Pos.x);
            CachedTransform.SetPositionY(m_SoundItemData.Pos.y);
            CachedTransform.SetPositionZ(m_SoundItemData.Pos.z);
        }

        protected override void OnUpdate(float elapseSeconds, float realElapseSeconds)
        {
            base.OnUpdate(elapseSeconds, realElapseSeconds);
        }

        private void OnTriggerEnter(UnityEngine.Collider other)
        {
            GameEntry.Sound.PlaySound(1);
            GameFrameworkLog.Info("SoundItem");

            GameEntry.Entity.HideEntity(this);
            GameEntry.Event.Fire(this, ReferencePool.Acquire<GetSoundItemEventArgs>().Fill(10));
        }
    }
}
