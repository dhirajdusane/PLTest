using Prism.Commands;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace ApplicationNamespace
{
    public class ViewModel : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

        private void Notify([CallerMemberName] string name = "" )
        {
            if (PropertyChanged != null)
                PropertyChanged(this, new PropertyChangedEventArgs( name));
        }

        public ICommand WriteFile { get { return new DelegateCommand(WriteFileFunction); } }

        private void WriteFileFunction()
        {
            DataModel model = new DataModel();
            model.WriteXMLFile("sample.xml", 100, RandomDataGenerator.GetDefaultFrequency());
        }
    }
}
