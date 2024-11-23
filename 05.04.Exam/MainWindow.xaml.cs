using _05._04.Exam.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Remoting.Contexts;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace _05._04.Exam
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {

        public List<Videoteka> VideoT { get; set; }

        public MainWindow()
        {
            InitializeComponent();

            VideoT = App.Context.Videoteka.ToList();
            this.CassetesGrid.ItemsSource = VideoT;
            CassetesGrid.IsReadOnly = true;
        }

        private void Create_Click(object sender, RoutedEventArgs e)
        {
            Videoteka videoteka = new Videoteka();
            videoteka.Availability = "yes";
            videoteka.MovieID = 1;
            try
            {
                App.Context.Videoteka.Add(videoteka);
                VideoT.Add(videoteka);
                CassetesGrid.ScrollIntoView(videoteka);
                CassetesGrid.SelectedIndex = CassetesGrid.Items.Count - 1;
                CassetesGrid.Focus();
                CassetesGrid.IsReadOnly = false;
                CassetesGrid.Items.Refresh();

            }
            catch (Exception ex)
            {
                throw new ApplicationException("Error adding new cassette to data context " + ex.ToString());
            }
        }

        private void Save_Click(object sender, RoutedEventArgs e)
        {
            App.Context.SaveChanges();
            CassetesGrid.IsReadOnly = true;
        }

        private void Edit_Click(object sender, RoutedEventArgs e)
        {

            CassetesGrid.IsReadOnly = false;

        }

        private void Delete_Click(object sender, RoutedEventArgs e)
        {
            Videoteka videoteka = CassetesGrid.SelectedItem as Videoteka;
            if (videoteka != null)
            {
                MessageBoxResult result = MessageBox.Show("Удалить касету?","Предупреждение", MessageBoxButton.OKCancel);
                if (result == MessageBoxResult.OK)
                {
                    App.Context.Videoteka.Remove(videoteka);
                    VideoT.Remove(videoteka);
                    App.Context.SaveChanges();
                    CassetesGrid.Items.Refresh();

                }
            }
        }
    }
}
