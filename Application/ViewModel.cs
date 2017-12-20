using Prism.Commands;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;
using System.Windows.Media;

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
        public ICommand DrawFile { get { return new DelegateCommand(DrawFileFunction); } }

        private PointCollection canvasPoints;
        public PointCollection CanvasPoints
        {
            get { return canvasPoints; }
            set { canvasPoints = value; Notify(); }
        }

        private ObservableCollection<LineObject> linesCollection;
        public ObservableCollection<LineObject> LinesCollection
        {
            get { return linesCollection; }
            set { linesCollection = value; Notify(); }
        }

        private int recordCount;
        public int RecordCount
        {
            get { return recordCount; }
            set { recordCount = value;Notify(); }
        }

        public ViewModel()
        {
            //LinesCollection = new ObservableCollection<LineObject>();

            LinesCollection = new ObservableCollection<LineObject>();
        //{
        //    new LineObject { From = new Point(100, 20), To = new Point(180, 180) },
        //    new LineObject { From = new Point(180, 180), To = new Point(20, 180) },
        //    new LineObject { From = new Point(20, 180), To = new Point(100, 20) },
        //    new LineObject { From = new Point(20, 50), To = new Point(180, 150) }
        //};

            CanvasPoints = new PointCollection(new List<Point>());
            CanvasPoints.Add(new Point(5, 5));
            CanvasPoints.Add(new Point(10, 10));
        }

        private async void DrawFileFunction()
        {
            await Task.Run(() =>
            {
                DataModel model = new DataModel();
                Action<Data,int> update = (x,i) =>
                {
                    LinesCollection.Add(new LineObject() { From = new Point(i, 0), To = new Point(i, x.RandomValue) });
                };

                List <LineObject> lObjList = new List<LineObject>();
                int ix = 0;
                foreach (var item in model.ReadXMLFile("sample.xml"))
                {
                    ix++;
                    Application.Current.Dispatcher.BeginInvoke(update, new object[] { item ,ix});
                }
            });
        }

        private void WriteFileFunction()
        {
            DataModel model = new DataModel();
            model.WriteXMLFile("sample.xml", RecordCount, RandomDataGenerator.GetDefaultFrequency());
        }
    }

    public class LineObject
    {
        public Point From { get; set; }
        public Point To { get; set; }
    }
}
