using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Remoting.Metadata.W3cXsd2001;
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

namespace WpfApp2
{
    /// <summary>
    /// Логика взаимодействия для Autorization.xaml
    /// </summary>
    public partial class Autorization : Page
    {
        public Autorization()
        {
            InitializeComponent();
        }

        private void Enter_Click(object sender, RoutedEventArgs e)
        {
            if (string.IsNullOrEmpty(Log.Text) || string.IsNullOrEmpty(Pass.Password))
            {
                MessageBox.Show("Введите логин и пароль!");
                return;
            }

            using (var db = new Borisov_Pr9_Great_Testing())
            {
                var user = db.User
                .AsNoTracking()
                .FirstOrDefault(u => u.Login == Log.Text && u.Password == Pass.Password);
                if (user == null)
                {
                    MessageBox.Show("Пользователь с такими данными не найден!");
                    return;
                }
                MessageBox.Show("Добро пожаловать! Вход выполнен");
            }
        }

        public bool Auth(string login, string password)
        {
            if (string.IsNullOrEmpty(login) || string.IsNullOrEmpty(password))
            {
                MessageBox.Show("Введите логин и пароль");
                return false;
            }

            using (var db = new Borisov_Pr9_Great_Testing())
            {
                var user = db.User.AsNoTracking().FirstOrDefault(u => u.Login == login && u.Password == password);
                if (user == null)
                {
                    MessageBox.Show("Пользователь с такими данными не найден");
                    return false;
                }
                MessageBox.Show("Пользователь успешно найден");
                Log.Clear();
                Pass.Clear();
                return true;
            }
        }

        private void Reg_Click(object sender, RoutedEventArgs e)
        {
            NavigationService?.Navigate(new Registration());
        }
    }
}
