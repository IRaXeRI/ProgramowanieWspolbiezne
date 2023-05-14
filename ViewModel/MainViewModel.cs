using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using Presentation.Model;

namespace Presentation.ViewModel {
    public class MainViewModel : INotifyPropertyChanged {
        private readonly APIModel model;
        private bool button = true;
        private string n = "";

        public event PropertyChangedEventHandler? PropertyChanged;

        protected void RaisePropertyChanged([CallerMemberName] string? propertyName = null) {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        public MainViewModel() : this(APIModel.CreateApi()) {
        }

        public MainViewModel(APIModel modelLayer){
            StartCommand = new Command(Start, ButtonDisable);
            StopCommand = new Command(Stop, ButtonEnable);
            model = modelLayer;
        }

        public Command StartCommand { get; }

        public Command StopCommand { get; }

        public bool Button {
            get => button;
            set {
                button = value;
                RaisePropertyChanged();
            }
        }

        public string N {
            get => n;
            set {
                n = value;
                RaisePropertyChanged();
            }
        }

        public ObservableCollection<InterfaceModelBall> Balls {
            get => model.GetObservableCollection();
        }

        private void Start() {
            try {
                int newN = int.Parse(N);
                if (newN < 0) {
                    newN = Math.Abs(newN);
                    RaisePropertyChanged();
                }

                model.CreateNBalls(newN);
                RaisePropertyChanged(nameof(Balls));
                ChangeButtonStatus();
            }
            catch (Exception) {
                N = "";
                RaisePropertyChanged(nameof(Balls));
            }
        }

        private void Stop() {
            model.ClearBalls();
            RaisePropertyChanged(nameof(Balls));
            ChangeButtonStatus();
        }

        private void ChangeButtonStatus() {
            Button = !Button;
            StartCommand.RaiseCanExecuteChanged();
            StopCommand.RaiseCanExecuteChanged();
        }

        private bool ButtonDisable() {
            return Button;
        }

        private bool ButtonEnable() {
            return !Button;
        }
    }
}