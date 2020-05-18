using UnityEngine;

namespace GameName
{
    public class PlayerData : EntityData
    {
        Vector3 Pos { set; get; }

        public PlayerData(int entityId, int typeId, Vector3 pos) : base(entityId, typeId)
        {

        }
    }
}