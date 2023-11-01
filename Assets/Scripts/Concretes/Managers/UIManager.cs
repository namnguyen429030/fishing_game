using Assets.Scripts.Abtractions;

namespace Assets.Scripts.Concretes.Managers
{
    public class UIManager : Manager
    {
        public static UIManager Instance { get; private set; }
        private void Awake()
        {
            if (Instance != null && Instance != this)
            {
                Destroy(this);
            }
            else
            {
                Instance = this;
            }
        }
        public override void AdjustObject(bool status)
        {
            throw new System.NotImplementedException();
        }
    }
}
