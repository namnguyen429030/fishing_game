using Assets.Scripts.Abtractions;
using Assets.Scripts.Concretes.Managers;

namespace Assets.Scripts.Concretes.States.BackgroundState.Children
{
    public class FinishState : BackgroundState
    {
        public override void PerformState()
        {
            BackgroundManager.Instance.AdjustObject(false);
        }
    }
}
