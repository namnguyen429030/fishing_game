using Assets.Scripts.Abtractions;
using Assets.Scripts.Concretes.Managers;

namespace Assets.Scripts.Concretes.States.BackgroundState.Children
{
    public class StartState : BackgroundState
    {
        public override void PerformState()
        {
            BackgroundManager.Instance.AdjustObject(true);
        }
    }
}
