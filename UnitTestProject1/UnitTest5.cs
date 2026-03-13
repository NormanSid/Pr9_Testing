using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using WpfApp2;

namespace UnitTestProject1
{
    [TestClass]
    public class UnitTest5
    {
        [TestMethod]

        // Позитивный сценарий:
        public void RegisterTest_Success()
        {
            string uniqueLogin = "testuser_" + System.DateTime.Now.Ticks;
            string result = Registration.RegisterUserLogic
                ("Тестовый Пользователь", uniqueLogin, "Password123", "Password123");
            Assert.IsTrue(string.IsNullOrEmpty(result),
                $"Ожидался успех, но получена ошибка: {result}");
        }
        [TestMethod]

        // Негативные сценарии:
        public void RegisterTest_Failure_EmptyFields()
        {
            string result = Registration.RegisterUserLogic("", "login", "Password123", "Password123");
            Assert.AreEqual("Все поля должны быть заполнены", result);
        }

        [TestMethod]
        public void RegisterTest_Failure_ShortPassword()
        {
            string result = Registration.RegisterUserLogic("Иванов", "ivanov", "12345", "12345");
            Assert.AreEqual("Пароль должен содержать не менее 6 символов", result);
        }

        [TestMethod]
        public void RegisterTest_Failure_CyrillicInPassword()
        {
            string result = Registration.RegisterUserLogic("Иванов", "ivanov", "Пароль123", "Пароль123");
            Assert.AreEqual("Пароль должен содержать только английские символы", result);
        }

        [TestMethod]
        public void RegisterTest_Failure_NoDigitInPassword()
        {
            string result = Registration.RegisterUserLogic("Иванов", "ivanov", "Password", "Password");
            Assert.AreEqual("Пароль должен содержать хотя бы одну цифру!", result);
        }

        [TestMethod]
        public void RegisterTest_Failure_PasswordsNotMatch()
        {
            string result = Registration.RegisterUserLogic("Иванов", "ivanov", "Password123", "Different456");
            Assert.AreEqual("Пароли не совпадают!", result);
        }

        [TestMethod]
        public void RegisterTest_Failure_DuplicateLogin()
        {
            string uniqueLogin = "dupuser_" + System.DateTime.Now.Ticks;
            Registration.RegisterUserLogic("Первый", uniqueLogin, "Password123", "Password123");
            string result = Registration.RegisterUserLogic("Второй", uniqueLogin, "Password123", "Password123");
            Assert.AreEqual("Пользователь с таким логином уже существует!", result);
        }
    }
}

