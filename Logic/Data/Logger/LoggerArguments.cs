using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Logic.Data.Logger;

internal class LoggerArguments : PropertyChangedEventArgs {
    
    private object oldValue;
    private object newValue;

    public object OldValue { get => oldValue; }
    public object NewValue { get => newValue; }

    public LoggerArguments(string? propertyName, object initOldValue, object initNewValue) : base(propertyName) {
        this.oldValue = initOldValue;
        this.newValue = initNewValue;
    }
}
