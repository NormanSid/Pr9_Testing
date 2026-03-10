using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using WpfApp2;
using System.Collections.Generic;

namespace FirstTest
{
    [TestClass]
    public class UnitTest3
    {
        [TestMethod]
        public void AuthTestSuccess()
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
