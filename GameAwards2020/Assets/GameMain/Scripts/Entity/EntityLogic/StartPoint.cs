
namespace GameName
{
    public class StartPoint : Entity
    {
        private StartPointData m_StartPointData = null;

        protected override void OnShow(object userData)
        {
            base.OnShow(userData);
            m_StartPointData = (StartPointData)userData;
            CachedTransform.SetLocalScaleX(0.3f);
            CachedTransform.SetLocalScaleY(0.3f);
            CachedTransform.SetLocalScaleZ(0.3f);
            CachedTransform.SetPositionZ(10);
        }

        protected override void OnUpdate(float elapseSeconds, float realElapseSeconds)
        {
            base.OnUpdate(elapseSeconds, realElapseSeconds);
        }
    }
}
