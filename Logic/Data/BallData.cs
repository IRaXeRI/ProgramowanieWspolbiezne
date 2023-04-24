using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using Logic;

namespace Logic.Data
{
    public abstract class BallData : InterfaceBall, INotifyPropertyChanged
    {
        protected int coordX;
        protected int coordY;
        protected int velocityX;
        protected int velocityY;
        protected int radius;

        public override event PropertyChangedEventHandler? PropertyChanged;

        private void RaisePropertyChanged([CallerMemberName] string? propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
