using UnityEngine.UI;
using GameFramework.Event;
using System;

namespace GameName
{
    /// <summary>
    /// 积分界面脚本
    /// </summary>
    public class ScoreForm : UGuiForm
    {
        public Text scoreText;

        /// <summary>
        /// 积分
        /// </summary>
        private int m_Score = 0;

        /// <summary>
        /// 积分计时器
        /// </summary>
        private float m_ScoreTimer = 0;


        protected override void OnOpen(object userData)
        {
            base.OnOpen(userData);

            GameEntry.Event.Subscribe(GetSoundItemEventArgs.EventId,OnAddScore);
          
        }

        private void OnAddScore(object sender, GameEventArgs e)
        {
            GetSoundItemEventArgs ase = (GetSoundItemEventArgs)e;

            m_Score += ase.AddCount;
            scoreText.text = "Score：" + m_Score;
        }

        protected override void OnUpdate(float elapseSeconds, float realElapseSeconds)
        {
            base.OnUpdate(elapseSeconds, realElapseSeconds);
            m_ScoreTimer += elapseSeconds;
            if (m_ScoreTimer >= 2f)
            {
                m_ScoreTimer = 0;
                m_Score += 1;
                scoreText.text = "总分：" + m_Score;
            }
        }



        protected override void OnPause()
        {
            base.OnPause();

            //清空数据
            m_ScoreTimer = 0;
            m_Score = 0;
            scoreText.text = "总分：" + m_Score;
        }

        protected override void OnClose(bool isShutdown, object userData)
        {
            base.OnClose(isShutdown, userData);

         
        }
    }
}