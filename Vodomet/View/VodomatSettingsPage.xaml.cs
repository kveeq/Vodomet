using System;
using System.Collections.Generic;
using System.Windows;
using Vodomet.Model;

namespace Vodomet.View
{
    /// <summary>
    /// Логика взаимодействия для VodomatSettingsPage.xaml
    /// </summary>
    public partial class VodomatSettingsPage : Window
    {
        public Vodomat? vodomat;
        public VodomatSettingsPage(Vodomat vod)
        {
            InitializeComponent();
            vodomat = vod;
            vodomat.GetSetting();
            IdLbl.Content = $"Автомат {vodomat.Id}";
            DataContext = vodomat;
            Fill();
        }

        private void Fill()
        {
            List<string> vs = new List<string>() { "1", "2", "5", "10" };
            DrebezgHitCmbBox.ItemsSource = vs;
            DrebezgFullTankCmbBox.ItemsSource = vs;
            DrebezgLowWaterCmbBox.ItemsSource = vs;
            DrebezgMovementCmbBox.ItemsSource = vs;
            DrebezgNo220BCmbBox.ItemsSource = vs;
            DrebezgNoWaterCmbBox.ItemsSource = vs;
            DrebezgTempCmbBox.ItemsSource = vs;
            RecoveryFullTankCmbBox.ItemsSource = vs;
            RecoveryHitCmbBox.ItemsSource = vs;
            RecoveryLowWaterCmbBox.ItemsSource = vs;
            RecoveryMovementCmbBox.ItemsSource = vs;
            RecoveryNo220BCmbBox.ItemsSource = vs;
            RecoveryNoWaterCmbBox.ItemsSource = vs;
            RecoveryTempCmbBox.ItemsSource = vs;
            //PulsePerLitreTxt.Text = vodomat.Settings.PulsePerLitre.ToString();
        }

        private void SaveSettingsBtn_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                vodomat.Update();
                vodomat.Settings.Update();
                vodomat.Settings.Tankist += Update;
                this.Close();
            }
            catch(Exception ex)
            {
                MessageBox.Show("ошибка обновления настроек" + ex.Message);
            }
        }

        private void Update(string mess)
        {
            vodomat.GetSetting();
            DataContext = vodomat;
            Fill();
            MessageBox.Show(mess);
        }

        private void CancelBtn_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}