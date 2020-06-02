
using GameFramework;
using GameFramework.Event;
using GameFramework.Fsm;
using GameFramework.Procedure;
using System.Collections.Generic;
using UnityGameFramework.Runtime;
using ProcedureOwner = GameFramework.Fsm.IFsm<GameFramework.Procedure.IProcedureManager>;

namespace GameName
{
    public class ProcedureLevel1 : ProcedureBase
    {
        public override bool UseNativeDialog
        {
            get
            {
                return false;
            }
        }

        private ScoreForm m_ScoreForm = null;
        private PlayerHUDForm m_PlayerForm = null;


        protected override void OnDestroy(ProcedureOwner procedureOwner)
        {
            base.OnDestroy(procedureOwner);
        }

        protected override void OnEnter(ProcedureOwner procedureOwner)
        {
            base.OnEnter(procedureOwner);
            GameFrameworkLog.Info("ProcedureLevel1 OnEnter");
           // GameEntry.Event.Subscribe(OpenUIFormSuccessEventArgs.EventId, OnOpenUIFormSuccess);
            GameEntry.UI.OpenUIForm(UIFormId.ScoreForm, this);
            GameEntry.UI.OpenUIForm(UIFormId.PlayerHUDForm, this);
        }

        protected override void OnInit(ProcedureOwner procedureOwner)
        {
            base.OnInit(procedureOwner);
        }

        protected override void OnLeave(ProcedureOwner procedureOwner, bool isShutdown)
        {
            base.OnLeave(procedureOwner, isShutdown);
            //GameEntry.Event.Unsubscribe(OpenUIFormSuccessEventArgs.EventId, OnOpenUIFormSuccess);
        }

        protected override void OnUpdate(ProcedureOwner procedureOwner, float elapseSeconds, float realElapseSeconds)
        {
            base.OnUpdate(procedureOwner, elapseSeconds, realElapseSeconds);
        }

        private void OnOpenUIFormSuccess(object sender, GameEventArgs e)
        {
            OpenUIFormSuccessEventArgs ne = (OpenUIFormSuccessEventArgs)e;

            GameFrameworkLog.Info("OpenScoreForm");

            if (ne.UserData != this)
            {
                GameFrameworkLog.Info("OpenScoreForm False");
                return;
            }

            m_ScoreForm = (ScoreForm)ne.UIForm.Logic; ;
            m_PlayerForm = (PlayerHUDForm)ne.UIForm.Logic;
        }
    }
}