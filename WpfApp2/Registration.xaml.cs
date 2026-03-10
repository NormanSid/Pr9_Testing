using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
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
    /// Логика взаимодействия для Registration.xaml
    /// </summary>
    public partial class Registration : Page
    {
        public Registration()
        {
            InitializeComponent();
        }
        public static string RegisterUserLogic(string fio, string login, string password, string confirmPassword)
        {
            if (string.IsNullOrWhiteSpace(fio) ||
                string.IsNullOrWhiteSpace(login) ||
                string.IsNullOrWhiteSpace(password) ||
                string.IsNullOrWhiteSpace(confirmPassword))
            {
                return "Все поля должны быть заполнены";
            }

            using (var db = new Borisov_Pr9_Great_Testing())
            {

                if (db.User.Any(u => u.Login == login))
                {
                    return "Пользователь с таким логином уже существует!";
                }

                if (password.Length < 6)
                {
                    return "Пароль должен содержать не менее 6 символов";
                }

                if (Regex.IsMatch(password, @"[а-яА-ЯЁё]"))
                {
                    return "Пароль должен содержать только английские символы";
                }

                if (!Regex.IsMatch(password, @"\d"))
                {
                    return "Пароль должен содержать хотя бы одну цифру!";
                }

                if (password != confirmPassword)
                {
                    return "Пароли не совпадают!";
                }

                User newUser = new User
                {
                    FIO = fio,
                    Login = login,
                    Password = password
                };
                db.User.Add(newUser);
                db.SaveChanges();
            }

            return string.Empty;
        }
        private void ButtonCancel_Click(object sender, RoutedEventArgs e)
        {
            TextBoxFIO.Clear();
            TextBoxLogin.Clear();
            PasswordBoxPassword.Clear();
            PasswordBoxConfirm.Clear();
            NavigationService.Navigate(new Autorization());
        }

        private void ButtonRegister_Click(object sender, RoutedEventArgs e)
        {
            string fio = TextBoxFIO.Text;
            string login = TextBoxLogin.Text;
            string password = PasswordBoxPassword.Password;
            string confirm = PasswordBoxConfirm.Password;

            string errorMessage = RegisterUserLogic(fio, login, password, confirm);

            if (string.IsNullOrEmpty(errorMessage))
            {
                MessageBox.Show("Регистрация успешна!");
                TextBoxFIO.Clear();
                TextBoxLogin.Clear();
                PasswordBoxPassword.Clear();
                PasswordBoxConfirm.Clear();
                NavigationService.Navigate(new Autorization());
            }
            else
            {
                MessageBox.Show(errorMessage, "Ошибка", MessageBoxButton.OK, MessageBoxImage.Warning);
            }
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {

        }
    }
}
