using GameFramework.Event;

namespace GameName
{
    public class GetSoundItemEventArgs : GameEventArgs

    {

        public static readonly int EventId = typeof(GetSoundItemEventArgs).GetHashCode();

        public override int Id
        {
            get
            {
                return EventId;
            }
        }
        /// <summary>
        /// 加分数量
        /// </summary>
        public int AddCount { get; private set; }

        /// <summary>
        /// 填充事件
        /// </summary>
        public GetSoundItemEventArgs Fill(int addCount)
        {
            AddCount = addCount;

            return this;
        }

        public override void Clear()
        {
            AddCount = 0;
        }
    }
}