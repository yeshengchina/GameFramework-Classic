using GameFramework.Event;
using GameFramework.Fsm;
using GameFramework.Procedure;
using GameFramework.UI;
using GameMain.Scripts.HotFix.GameLogic;
using UnityGameFramework.Runtime;
using StarForce;
using OpenUIFormSuccessEventArgs = UnityGameFramework.Runtime.OpenUIFormSuccessEventArgs;
using ProcedureBase = GameMain.ProcedureBase;
using UIFormId = StarForce.UIFormId;

namespace GameLogic.GameMain.Scripts.HotFix.GameLogic
{
    public class ProcedureMenu : ProcedureBase
    {
        bool m_startGame = false;
        private MenuForm m_MenuForm = null;
        public override bool UseNativeDialog
        {
            get
            {
                return false;
            }
        }
        public void StartGame()
        {
            m_startGame = true;
        }
        protected override void OnEnter(IFsm<IProcedureManager> procedureOwner)
        {
            base.OnEnter(procedureOwner);
            GameModule.Event.Subscribe(OpenUIFormSuccessEventArgs.EventId, OnOpenUIFormSuccess);
            m_startGame = false;
            GameModule.UI.OpenUIForm(UIFormId.MenuForm, this);
        }

        protected override void OnLeave(IFsm<IProcedureManager> procedureOwner, bool isShutdown)
        {
            base.OnLeave(procedureOwner, isShutdown);

            GameModule.Event.Unsubscribe(OpenUIFormSuccessEventArgs.EventId, OnOpenUIFormSuccess);

            if (m_MenuForm != null)
            {
                m_MenuForm.Close(isShutdown);
                m_MenuForm = null;
            }
        }

        private void OnOpenUIFormSuccess(object sender, GameEventArgs e)
        {
            OpenUIFormSuccessEventArgs ne = (OpenUIFormSuccessEventArgs)e;
            if (ne.UserData != this)
            {
                return;
            }

            m_MenuForm = (MenuForm)ne.UIForm.Logic;
        }
    }
}