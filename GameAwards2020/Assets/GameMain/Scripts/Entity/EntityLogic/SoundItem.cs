
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
            CachedTransform.SetPositionZ(-5f);
        }

        protected override void OnUpdate(float elapseSeconds, float realElapseSeconds)
        {
            base.OnUpdate(elapseSeconds, realElapseSeconds);
        }
    }
}
