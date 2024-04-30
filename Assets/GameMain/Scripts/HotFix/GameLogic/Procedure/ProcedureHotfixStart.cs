using GameMain;
using UnityGameFramework.Runtime;
using ProcedureOwner = GameFramework.Fsm.IFsm<GameFramework.Procedure.IProcedureManager>;

namespace GameLogic.GameMain.Scripts.HotFix.GameLogic
{
    public class ProcedureHotfixStart : ProcedureBase
    {
        public override bool UseNativeDialog { get { return false; } }
     

        protected override void OnUpdate(ProcedureOwner procedureOwner, float elapseSeconds, float realElapseSeconds)
        {
            procedureOwner.SetData<VarInt32>("NextSceneId", GameModule.Config.GetInt("Scene.Menu"));
            ChangeState<ProcedureChangeScene>(procedureOwner);
        }

        
    }
}