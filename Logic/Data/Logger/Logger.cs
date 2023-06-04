using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Logic.Data.Logger {
    internal class Logger {
        private string pathPattern = "./../../../../Logs/logs-{0}.json";
        private string path;
        private object fileBarrier = new();
        private Timer Timer;
        private bool enabled = true;
        private Stopwatch measure = new Stopwatch();
        private Queue<string> messages = new Queue<string>();

        public bool Enabled { get => enabled; set => enabled = value; }
        public Queue<string> Messages { get => messages; set => messages = value; }

        public Logger() {
            path = string.Format(pathPattern, DateTime.Now.ToFileTime());
            Timer = new Timer(LogLoop, null, 0, 8);
        }

        public void LogCreateMessage(object? s, PropertyChangedEventArgs propertyChangedEventArgs) {
            LoggerArguments? e = propertyChangedEventArgs as LoggerArguments;
            string message = string.Format(
               "\t\t{{\n" +
               "\t\t\t\"time_stamp\": \"{0}\",\n" +
               "\t\t\t\"object_type\": \"{1}\",\n" +
               "\t\t\t\"object_id\": {2},\n" +
               "\t\t\t\"changed_property\": \"{3}\",\n" +
               "\t\t\t\"old_value\": {4},\n" +
               "\t\t\t\"new_value\": {5}\n" +
               "\t\t}},",
               GetTimestamp(), s?.GetType().Name, s?.GetHashCode(),
               e?.PropertyName, e.OldValue, e.NewValue
            );
            messages.Enqueue( message );
        }

        private string GetTimestamp() {
            return DateTime.Now.ToString(CultureInfo.CurrentCulture) + ":" + DateTime.Now.Millisecond;
        }

        private void LogLoop(Object? stateInfo) {
            while (Enabled) {
                measure.Reset();
                if (Messages.Count>0) {
                    measure.Start();
                    Log(Messages.Dequeue());
                    measure.Stop();
                }
            }
        }

        private void Log (string message) {
            lock (fileBarrier) {
                Write(message);
            }
        }

        private void Write(string text) {
            StreamWriter writer = File.AppendText(path);
            writer.WriteLineAsync(text);
            writer.Close();
        }


    }
}
