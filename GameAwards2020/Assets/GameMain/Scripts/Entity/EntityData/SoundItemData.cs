using UnityEngine;

namespace GameName
{
    public class SoundItemData : EntityData
    {
        public SoundItemData(int entityId, int typeId, Vector3 pos) : base(entityId, typeId)
        {
            Pos = pos;
        }

        public Vector3 Pos { get; private set; }
    }
}