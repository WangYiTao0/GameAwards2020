using GameFramework.Procedure;
using ProcedureOwner = GameFramework.Fsm.IFsm<GameFramework.Procedure.IProcedureManager>;
using GameFramework;

namespace GameName
{
    /// <summary>
    /// 主游戏流程
    /// </summary>
    public class ProcedureMainGame : ProcedureBase
    {
        protected override void OnEnter(ProcedureOwner procedureOwner)
        {
            base.OnEnter(procedureOwner);

            Log.Info("MainGame Scene");
        }
    }


}
