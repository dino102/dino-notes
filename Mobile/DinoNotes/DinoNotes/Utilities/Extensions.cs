using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DinoNotes.Utilities {
    public static class Extensions {
        public static ObservableCollection<T> ToObservableCollection<T>(this List<T> list) {
            var ocoll = new ObservableCollection<T>();
            foreach (var item in list) {
                ocoll.Add(item);
            }
            return ocoll;
        }
    }
}
