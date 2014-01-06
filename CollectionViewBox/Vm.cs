using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Data;
using CollectionViewBox.Annotations;

namespace CollectionViewBox
{
    class Vm : INotifyPropertyChanged
    {
        private readonly List<Person> _people = new List<Person>{new Person{Name = "Sean"}}; 
        
        public Vm()
        {
            CollectionView= new ListCollectionView(_people);
        }
        public event PropertyChangedEventHandler PropertyChanged;
        public void AddPerson()
        {
            _people.Add(new Person{Name = "Johan"});
            CollectionView.Refresh();
        }

        public ListCollectionView CollectionView { get; private set; }


        [NotifyPropertyChangedInvocator]
        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChangedEventHandler handler = PropertyChanged;
            if (handler != null) handler(this, new PropertyChangedEventArgs(propertyName));
        }
    }

    public class Person : INotifyPropertyChanged
    {
        private string _name;

        public string Name
        {
            get { return _name; }
            set
            {
                if (value == _name) return;
                _name = value;
                OnPropertyChanged();
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;

        [NotifyPropertyChangedInvocator]
        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChangedEventHandler handler = PropertyChanged;
            if (handler != null) handler(this, new PropertyChangedEventArgs(propertyName));
        }

        public override string ToString()
        {
            return string.Format("Name: {0}", Name);
        }
    }
}
