
using UnityEngine;

namespace GameName
{
    /// <summary>
    /// 游戏入口。
    /// </summary>
    public partial class GameEntry : MonoBehaviour
    {
        public static BuiltinDataComponent BuiltinData
        {
            get;
            private set;
        }
        public static ILRuntimeComponent ILRuntime
        {
            get;
            private set;
        }

        private static void InitCustomComponents()
        {
            BuiltinData = UnityGameFramework.Runtime.GameEntry.GetComponent<BuiltinDataComponent>();
            ILRuntime = UnityGameFramework.Runtime.GameEntry.GetComponent<ILRuntimeComponent>();
        }

        private static void InitCustomDebuggers()
        {

        }
    }
}
