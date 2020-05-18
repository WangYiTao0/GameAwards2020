using GameFramework;
using UnityEngine;
using UnityGameFramework.Runtime;


namespace GameName
{
    public class JumpOverData : EntityData
    {
        public JumpOverData(int entityId, int typeId, Vector3 pos) : base(entityId, typeId)
        {
            Pos = pos;
        }

        public Vector3 Pos { get; private set; }
    }

}

