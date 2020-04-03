using UnityEngine;

namespace GameName
{
    public class Terrain : Entity
    {

        private TerrainData m_TerrainData = null;
        protected override void OnShow(object userData)
        {
            base.OnShow(userData);
            m_TerrainData = (TerrainData)userData;
            CachedTransform.SetPositionAndRotation(Vector3.zero, Quaternion.identity);
            CachedTransform.SetLocalScaleX(10f);
            CachedTransform.SetLocalScaleZ(10f);
        }

        protected override void OnUpdate(float elapseSeconds, float realElapseSeconds)
        {
            base.OnUpdate(elapseSeconds, realElapseSeconds);
        }
    }
}