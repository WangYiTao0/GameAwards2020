﻿//------------------------------------------------------------
// Game Framework
// Copyright © 2013-2020 Jiang Yin. All rights reserved.
// Homepage: https://gameframework.cn/
// Feedback: mailto:ellan@gameframework.cn
//------------------------------------------------------------

using GameFramework;
using ProcedureOwner = GameFramework.Fsm.IFsm<GameFramework.Procedure.IProcedureManager>;

namespace GameName
{
    public class ProcedureSplash : ProcedureBase
    {
        public override bool UseNativeDialog
        {
            get
            {
                return true;
            }
        }

        protected override void OnUpdate(ProcedureOwner procedureOwner, float elapseSeconds, float realElapseSeconds)
        {
            base.OnUpdate(procedureOwner, elapseSeconds, realElapseSeconds);
            GameFrameworkLog.Info("OnUpdate ProcedureSplash");
            // TODO: 增加一个 Splash 动画，这里先跳过
            // 编辑器模式下，直接进入预加载流程；否则，检查一下版本
            ChangeState(procedureOwner, GameEntry.Base.EditorResourceMode ? typeof(ProcedurePreload) : typeof(ProcedureCheckVersion));
        }
    }
}
