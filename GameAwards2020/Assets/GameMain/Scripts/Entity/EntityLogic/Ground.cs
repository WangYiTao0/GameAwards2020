using UnityEngine;

namespace GameName
{
    public class Ground : Entity
    {
        GroundData m_groundData = null;
        protected override void OnShow(object userData)
        {
            base.OnShow(userData);
            m_groundData = (GroundData)userData;

            CachedTransform.SetPositionAndRotation(Vector3.zero, Quaternion.identity);

        }

        protected override void OnUpdate(float elapseSeconds, float realElapseSeconds)
        {
            base.OnUpdate(elapseSeconds, realElapseSeconds);
        }

    }
}