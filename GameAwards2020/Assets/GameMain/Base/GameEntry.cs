using UnityEngine;

namespace GameName
{
    public partial class GameEntry : MonoBehaviour
    {
        // Start is called before the first frame update
        void Start()
        {
            InitBuiltinComponents();
            InitCustomComponents();
            InitCustomDebuggers();
        }
    }
}