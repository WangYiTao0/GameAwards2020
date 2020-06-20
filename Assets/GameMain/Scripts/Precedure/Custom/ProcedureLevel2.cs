using GameFramework;
using GameFramework.Event;
using System.Collections.Generic;
using UnityEngine;
using UnityGameFramework.Runtime;
using ProcedureOwner = GameFramework.Fsm.IFsm<GameFramework.Procedure.IProcedureManager>;

namespace GameName
{

    public class ProcedureLevel2 : ProcedureBase
    {
        public override bool UseNativeDialog
        {
            get
            {
                return false;
            }
        }
        private bool isGameClear = false;
        protected override void OnDestroy(ProcedureOwner procedureOwner)
        {
            base.OnDestroy(procedureOwner);
            //GameFrameworkLog.Info("ProcedureLeveel2 OnEnter");
        }

        protected override void OnEnter(ProcedureOwner procedureOwner)
        {
            base.OnEnter(procedureOwner);
            GameFrameworkLog.Info("ProcedureLeveel2 OnEnter");
            GameEntry.Entity.ShowPlayer(new PlayerControllerData(GameEntry.Entity.GenerateSerialId(), 1));
            GameEntry.Event.Subscribe(GotoNextSceneEventArgs.EventId, OnGameClear);

        }
        private void OnGameClear(object sender, GameEventArgs e)
        {
            isGameClear = true;
        }
        protected override void OnInit(ProcedureOwner procedureOwner)
        {
            base.OnInit(procedureOwner);
        }

        protected override void OnLeave(ProcedureOwner procedureOwner, bool isShutdown)
        {
            base.OnLeave(procedureOwner, isShutdown);
            GameEntry.Event.Unsubscribe(GotoNextSceneEventArgs.EventId, OnGameClear);
        }

        protected override void OnUpdate(ProcedureOwner procedureOwner, float elapseSeconds, float realElapseSeconds)
        {
            base.OnUpdate(procedureOwner, elapseSeconds, realElapseSeconds);

            //if (Input.GetKeyDown(KeyCode.A))
            //{
            //    procedureOwner.SetData<VarInt>(Constant.ProcedureData.NextSceneId, GameEntry.Config.GetInt("Scene.Level3"));
            //    ChangeState<ProcedureChangeScene>(procedureOwner);
            //}
            if (isGameClear)
            {
                isGameClear = false;
                procedureOwner.SetData<VarInt>(Constant.ProcedureData.NextSceneId, GameEntry.Config.GetInt("Scene.Level3"));
                ChangeState<ProcedureChangeScene>(procedureOwner);
            }
        }

    }
}