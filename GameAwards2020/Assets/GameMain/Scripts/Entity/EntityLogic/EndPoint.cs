﻿
namespace GameName
{
    public class EndPoint : Entity
    {
        private EndPointData m_EndPointData = null;

        protected override void OnShow(object userData)
        {
            base.OnShow(userData);

            m_EndPointData = (EndPointData)userData;
            CachedTransform.SetLocalScaleX(0.3f);
            CachedTransform.SetLocalScaleY(0.3f);
            CachedTransform.SetLocalScaleZ(0.3f);
            CachedTransform.SetPositionZ(-10f);
        }

        protected override void OnUpdate(float elapseSeconds, float realElapseSeconds)
        {
            base.OnUpdate(elapseSeconds, realElapseSeconds);
        }
    }
}
