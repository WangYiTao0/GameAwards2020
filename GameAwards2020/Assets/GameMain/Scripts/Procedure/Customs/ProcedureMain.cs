//------------------------------------------------------------
// Game Framework
// Copyright © 2013-2020 Jiang Yin. All rights reserved.
// Homepage: https://gameframework.cn/
// Feedback: mailto:ellan@gameframework.cn
//------------------------------------------------------------

using GameFramework;
using System.Collections.Generic;
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



        protected override void OnEnter(ProcedureOwner procedureOwner)
        {
            base.OnEnter(procedureOwner);
            GameFrameworkLog.Info("OnEnter ProcedureMain");
            GameEntry.Entity.ShowPlayer(new PlayerData(GameEntry.Entity.GenerateSerialId(), 1));
            GameEntry.Entity.ShowTerrain(new TerrainData(GameEntry.Entity.GenerateSerialId(), 2));
            GameEntry.Entity.ShowCamera(new CameraData(GameEntry.Entity.GenerateSerialId(), 4));
            GameEntry.Entity.ShowStartPoint(new StartPointData(GameEntry.Entity.GenerateSerialId(), 5));
            GameEntry.Entity.ShowEndPoint(new EndPointData(GameEntry.Entity.GenerateSerialId(), 6));
        }


        protected override void OnLeave(ProcedureOwner procedureOwner, bool isShutdown)
        {
            base.OnLeave(procedureOwner, isShutdown);


        }

        protected override void OnUpdate(ProcedureOwner procedureOwner, float elapseSeconds, float realElapseSeconds)
        {
            base.OnUpdate(procedureOwner, elapseSeconds, realElapseSeconds);

        }
    }
}
