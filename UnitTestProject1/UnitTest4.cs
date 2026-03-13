using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using WpfApp2;

namespace UnitTestProject1
{
    [TestClass]
    public class UnitTest4
    {
        [TestMethod]
        public void TestMethod1()
        {
            var negativeCases = new List<(string Login, string Password, string Description)>
            {
                ("admin", "wrong_password", "Неверный пароль"),
                ("nonexistent_user", "password123", "Пользователь не существует"),
                ("", "password123", "Пустой логин"),
                ("admin", "", "Пустой пароль"),
                ("", "", "Оба поля пустые"),
            };
            var authService = new Autorization();
            foreach (var testCase in negativeCases)
            {
                bool result = authService.Auth(testCase.Login, testCase.Password);
                Assert.IsFalse(
                    result,
                    $"Тест провален: '{testCase.Description}'. Система пустила пользователя с логином '{testCase.Login}'.");
            }
        }
    }
}
