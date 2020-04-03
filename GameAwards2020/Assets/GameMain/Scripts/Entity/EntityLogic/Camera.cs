
using UnityEngine;

namespace GameName
{
	public class Camera : Entity
	{
		private CameraData m_CameraData = null;

		protected override void OnShow(object userData)
		{
			base.OnShow(userData);

			m_CameraData = (CameraData)userData;

			CachedTransform.SetPositionAndRotation(Vector3.zero, Quaternion.identity);

		}

		protected override void OnUpdate(float elapseSeconds, float realElapseSeconds)
		{
			base.OnUpdate(elapseSeconds, realElapseSeconds);
		}


	}
}
