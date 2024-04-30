using GameMain;

namespace GameLogic.GameMain.Scripts.HotFix.GameLogic
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
        
    }
}