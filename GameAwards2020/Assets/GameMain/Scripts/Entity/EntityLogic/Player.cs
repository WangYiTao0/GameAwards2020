using UnityEngine;

namespace GameName
{
    public class Player : Entity
    {
        PlayerData m_playerData = null;
        protected override void OnShow(object userData)
        {
            base.OnShow(userData);
            m_playerData = (PlayerData)userData;

            CachedTransform.SetPositionAndRotation(Vector3.zero, Quaternion.identity);

        }

        protected override void OnUpdate(float elapseSeconds, float realElapseSeconds)
        {
            base.OnUpdate(elapseSeconds, realElapseSeconds);
        }

    }
}