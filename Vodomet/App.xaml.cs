using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;
using Vodomet.Model;

namespace Vodomet
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        public static readonly string connectionString = @"Data Source=DESKTOP-F0LHM74\SQLEXPRESS;Initial Catalog=Vodomet;Integrated Security=True";
        public static User user;
    }
}
