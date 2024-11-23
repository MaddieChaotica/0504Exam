using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;
using System.Collections.ObjectModel;

namespace _05._04.Exam.Entities
{
    internal class ListMovies : ObservableCollection<ClassificationCode>
    {
        public ListMovies()
        {
            App.Context.ClassificationCode.Load();
            foreach (var item in App.Context.ClassificationCode)
            {
                Add(item);
            }
        }

    }
}
