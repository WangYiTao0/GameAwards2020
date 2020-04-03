//------------------------------------------------------------
// Game Framework
// Copyright © 2013-2020 Jiang Yin. All rights reserved.
// Homepage: https://gameframework.cn/
// Feedback: mailto:ellan@gameframework.cn
//------------------------------------------------------------

using GameFramework;
using System.Collections.Generic;
using UnityEngine;
using UnityGameFramework.Runtime;
using ProcedureOwner = GameFramework.Fsm.IFsm<GameFramework.Procedure.IProcedureManager>;

namespace GameName
{
    public class ProcedureMain : ProcedureBase
    {
        public override bool UseNativeDialog
        {
            get
            {
                return false;
            }
        }

        private int m_ScoreFormId = -1;

        protected override void OnEnter(ProcedureOwner procedureOwner)
        {
            base.OnEnter(procedureOwner);
            GameFrameworkLog.Info("OnEnter ProcedureMain");

            m_ScoreFormId = GameEntry.UI.OpenUIForm(UIFormId.ScoreForm).Value;

            //GameEntry.Entity.ShowCamera(new CameraData(GameEntry.Entity.GenerateSerialId(), 4));
            GameEntry.Entity.ShowPlayer(new PlayerData(GameEntry.Entity.GenerateSerialId(), 1));
            GameEntry.Entity.ShowTerrain(new TerrainData(GameEntry.Entity.GenerateSerialId(), 2));

            for (int i = 0; i < 10; i++)
            {
                GameEntry.Entity.ShowSoundItem(new SoundItemData(GameEntry.Entity.GenerateSerialId(), 3,new Vector3(Random.Range(-5f, 5f), 1, Random.Range(-5f, 5f))));
            }
            GameEntry.Entity.ShowStartPoint(new StartPointData(GameEntry.Entity.GenerateSerialId(), 5));
            GameEntry.Entity.ShowEndPoint(new EndPointData(GameEntry.Entity.GenerateSerialId(), 6));
        }


        protected override void OnLeave(ProcedureOwner procedureOwner, bool isShutdown)
        {
            base.OnLeave(procedureOwner, isShutdown);


            GameEntry.UI.CloseUIForm(m_ScoreFormId);
        }

        protected override void OnUpdate(ProcedureOwner procedureOwner, float elapseSeconds, float realElapseSeconds)
        {
            base.OnUpdate(procedureOwner, elapseSeconds, realElapseSeconds);

        }
    }
}
