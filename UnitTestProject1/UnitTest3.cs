using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using WpfApp2;

namespace UnitTestProject1
{
    [TestClass]
    public class UnitTest3
    {
        [TestMethod]
        public void TestMethod1()
        {
            var OurUsers = new List<(string Login, string Password)>
            {
                ("Elizor@gmail.com", "yntiRS"),
                ("Vladlena@gmail.com", "07i7Lb"),
                ("Adam@gmail.com", "7SP9CV")
            };

            var authService = new Autorization();

            foreach (var user in OurUsers)
            {
                bool result = authService.Auth(user.Login, user.Password);
                Assert.IsTrue(result, $"Ошибка входа для пользователя: {user.Login}");
            }
        }
    }
}
