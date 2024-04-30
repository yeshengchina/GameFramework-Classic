﻿using GameLogic.GameMain.Scripts.HotFix.GameLogic;
using StarForce;
using UnityEngine;
using UnityGameFramework.Runtime;

namespace GameMain.Scripts.HotFix.GameLogic
{
    public class MenuForm : UGuiForm
    {
        [SerializeField]
        private GameObject m_QuitButton = null;

        private ProcedureMenu m_ProcedureMenu = null;
        
        public void OnStartButtonClick()
        {
            m_ProcedureMenu.StartGame();
        }

        public void OnSettingButtonClick()
        {
            GameModule.UI.OpenUIForm(UIFormId.SettingForm);
        }

        public void OnAboutButtonClick()
        {
            GameModule.UI.OpenUIForm(UIFormId.AboutForm);
        }
        public void OnQuitButtonClick()
        {
            GameModule.UI.OpenDialog(new DialogParams()
            {
                Mode = 2,
                Title = GameModule.Localization.GetString("AskQuitGame.Title"),
                Message = GameModule.Localization.GetString("AskQuitGame.Message"),
                OnClickConfirm = delegate (object userData) { UnityGameFramework.Runtime.GameEntry.Shutdown(ShutdownType.Quit); },
            });
        }

        protected  override void OnOpen(object userData)
        {
            base.OnOpen(userData);

            m_ProcedureMenu = (ProcedureMenu)userData;
            if (m_ProcedureMenu == null)
            {
                Log.Warning("ProcedureMenu is invalid when open MenuForm.");
                return;
            }

            m_QuitButton.SetActive(Application.platform != RuntimePlatform.IPhonePlayer);
        }

        public override void OnClose(bool isShutdown, object userData)
        {
            m_ProcedureMenu = null;
            base.OnClose(isShutdown, userData);
        }
    }
}