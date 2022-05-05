using System.Windows;
using System.Collections.Generic;
using System.Linq;
using Vodomet.Model;
using System.Windows.Controls;
using Vodomet.View.DisplayAlerts;

namespace Vodomet.View
{
    /// <summary>
    /// Логика взаимодействия для VodomatListWindow.xaml
    /// </summary>
    public partial class VodomatListWindow : Window
    {
        public VodomatListWindow()
        {
            InitializeComponent();
            FillCmbBoxes();
            Update();
        }

        private void Update()
        {
            VodomatLstView.ItemsSource = Vodomat.GetVodomats();
            KeysLstView.ItemsSource = AquaAccount.GetAquaUsers();
            CollectorsLstView.ItemsSource = Collector.GetCollectors();
            AquaHistoryLstView.ItemsSource = AquaAccountHistory.GetAquaAccountHistory();
            CollectHistoryLstView.ItemsSource = CollectionHistory.GetCollectionHistory();
            BonusHistoryLstView.ItemsSource = BonusHistory.GetAquaUsers();
            UsersLstView.ItemsSource = User.GetUsers();
        }

        private void FillCmbBoxes()
        {
            UsersCmbBox.Items.Add("Все");
            foreach (var item in AquaAccount.GetAquaUsers())
            {
                UsersCmbBox.Items.Add($"{item.Fio}");
            }
            GroupsCmbBox.ItemsSource = new List<string>() { "Все","1", "2", "3" };
            CollectorsCmbBox.ItemsSource = Collector.GetCollectors().Select(x => x.CollectorName).ToList();
            VodomatsCmbBox.ItemsSource = Vodomat.GetVodomats().Select(x=>x.Id).ToList();
        }

        private void ListView_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (App.user.IdRole == 1 && VodomatLstView.SelectedItem !=null)
            {
                var vodomat = (Vodomat)VodomatLstView.SelectedItem;
                MessageBox.Show(vodomat.Address);
                VodomatSettingsPage vodomatSettingsPage = new VodomatSettingsPage(vodomat) { vodomat = vodomat };
                vodomatSettingsPage.Show();
            }
            else
            {
                MessageBox.Show("Настройки может редактировать только админ!");
            }
        }

        private void UsersCmbBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            var a = UsersCmbBox.SelectedItem.ToString();
            if(a == "Все")
            {
                KeysLstView.ItemsSource = AquaAccount.GetAquaUsers();
            }
            else
                KeysLstView.ItemsSource = AquaAccount.GetAquaUsers().Where(x => x.Fio == a);
        }

        private void GroupsCmbBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            var a = GroupsCmbBox.SelectedItem.ToString();
            if (a == "Все")
            {
                KeysLstView.ItemsSource = AquaAccount.GetAquaUsers();
            }
            else
                KeysLstView.ItemsSource = AquaAccount.GetAquaUsers().Where(x => x.Group == int.Parse(a));
        }

        private void CollectorEditBtn_Click(object sender, RoutedEventArgs e)
        {
            Collector coll = Collector.GetCollectors().Where(x => x.Id == int.Parse((sender as Button).CommandParameter.ToString())).FirstOrDefault();
            coll.Tankist += CollectorUpdateEvent;
            EditAlertWindow editAlert = new EditAlertWindow(coll);
            editAlert.Show();
        }

        private void CollectorDeleteBtn_Click(object sender, RoutedEventArgs e)
        {
            Collector coll = Collector.GetCollectors().Where(x => x.Id == int.Parse((sender as Button).CommandParameter.ToString())).FirstOrDefault();
            coll.Tankist += CollectorUpdateEvent;
            DeleteAlertWindow editAlert = new DeleteAlertWindow(coll);
            editAlert.Show();
        }

        private void CollectorMasterBtn_Click(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("Вы мастер!");
        }

        private void CollectorUpdateEvent(string mes)
        {
            Update();
            MessageBox.Show(mes);
        }

        private void RemoveBtn_Click(object sender, RoutedEventArgs e)
        {
            Update();
            VodomatsCmbBox.SelectedIndex = -1;
            CollectorsCmbBox.SelectedIndex = -1;
            DatePicker1.SelectedDate = null;
            DatePicker2.SelectedDate = null;
        }

        private void CollectorsCmbBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (CollectorsCmbBox.SelectedItem != null)
            {
                var a = CollectorsCmbBox.SelectedItem.ToString();
                CollectHistoryLstView.ItemsSource = CollectionHistory.GetCollectionHistory().Where(x => x.Name == a).ToList();
            }
        }

        private void VodomatsCmbBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (VodomatsCmbBox.SelectedItem != null)
            {
                var a = VodomatsCmbBox.SelectedItem.ToString();
                CollectHistoryLstView.ItemsSource = CollectionHistory.GetCollectionHistory().Where(x => x.VodomatId == int.Parse(a)).ToList();
            }
        }

        private void UserEditBtn_Click(object sender, RoutedEventArgs e)
        {
            User coll = User.GetUsers().Where(x => x.Id == int.Parse((sender as Button).CommandParameter.ToString())).FirstOrDefault();
            coll.Tankist += CollectorUpdateEvent;
            EditAlertWindowUser editAlert = new EditAlertWindowUser(coll);
            editAlert.Show();
        }

        private void UserDeleteBtn_Click(object sender, RoutedEventArgs e)
        {
            User coll = User.GetUsers().Where(x => x.Id == int.Parse((sender as Button).CommandParameter.ToString())).FirstOrDefault();
            coll.Tankist += CollectorUpdateEvent;
            DeleteAlertWindowUser editAlert = new DeleteAlertWindowUser(coll);
            editAlert.Show();
        }

        private void DatePicker1_SelectedDateChanged(object sender, SelectionChangedEventArgs e)
        {

            if (DatePicker1.SelectedDate != null && DatePicker2.SelectedDate != null)
            {
                var a = DatePicker1.SelectedDate.ToString();
                var ab = DatePicker2.SelectedDate.ToString();
                CollectHistoryLstView.ItemsSource = CollectionHistory.GetCollectionHistory().Where(x => x.Date >= System.DateTime.Parse(a) && x.Date <= System.DateTime.Parse(ab)).ToList();
            }
        }

        private void DatePicker2_SelectedDateChanged(object sender, SelectionChangedEventArgs e)
        {

            if (DatePicker1.SelectedDate != null && DatePicker2.SelectedDate != null)
            {
                var a = DatePicker1.SelectedDate.ToString();
                var ab = DatePicker2.SelectedDate.ToString();
                CollectHistoryLstView.ItemsSource = CollectionHistory.GetCollectionHistory().Where(x => x.Date >= System.DateTime.Parse(a) && x.Date <= System.DateTime.Parse(ab)).ToList();
            }
        }
    }
}