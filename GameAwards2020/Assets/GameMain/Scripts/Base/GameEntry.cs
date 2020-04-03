using GameFramework;
using UnityEngine;

namespace GameName
{
    public partial class GameEntry : MonoBehaviour
    {
        // Start is called before the first frame update
        private void Start()
        {
            GameFrameworkLog.Info("GameEntry Start");
            InitBuiltinComponents();
            InitCustomComponents();
            InitCustomDebuggers();
        }
    }
}