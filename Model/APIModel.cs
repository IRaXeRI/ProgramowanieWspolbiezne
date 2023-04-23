using System.Collections.ObjectModel;

namespace Presentation.Model
{

    public abstract class APIModel
    {
        public static APIModel CreateApi()
        {
            return new ModelType();
        }

        public abstract ObservableCollection<InterfaceModelBall> GetObservableCollection();

        public abstract void CreateBall();

        public abstract void CreateNBalls(int n);

        public abstract void ClearBalls();

        public abstract void StartBalls();

        public abstract void StopBalls();
    }
}