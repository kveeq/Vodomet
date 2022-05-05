using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using Vodomet.Model;

namespace Vodomet.View.DisplayAlerts
{
    /// <summary>
    /// Логика взаимодействия для EditAlertWindow.xaml
    /// </summary>
    public partial class EditAlertWindow : Window
    {
        public Collector collector;
        public EditAlertWindow(Collector coll)
        {
            InitializeComponent();
            collector = coll;
            this.DataContext = collector;
        }

        private void SaveBtn_Click(object sender, RoutedEventArgs e)
        {
            if (App.user.IdRole == 1)
            {
                collector.Update();
            }
            else
            {
                collector.Tankist.Invoke("Может редактировать только администратор");
            }
            this.Close();
        }

        private void CancelBtn_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}
