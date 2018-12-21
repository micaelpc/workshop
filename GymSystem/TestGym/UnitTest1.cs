using System;
using System.Collections.Generic;
using GymBL.Database;
using GymBL.Entities;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace TestGym
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void TestMethod1()
        {
            Database d = new Database(@"
Data Source=(LocalDB)\MSSQLLocalDB;
AttachDbFilename=C:\dev\workshop\GymSystem\GymGUI\GymBL\Gym.mdf;
Integrated Security=True");
            d.DeleteAll<Trainee>();
            d.DeleteAll<Subscription>();
            var y = new Trainee
                  ("300951212", "מיכאל", "כהן", "לויתן 6 חולון",
                  "0528998829", "0528998829", "micaelpc@gmail.com", DateTime.Now,
                  "רגיש ללקטוז", new List<DayOfWeek>(), new List<Subscription>() { });
            y.Subscriptions.Add(new Subscription("", DateTime.Now, DateTime.Now, 500, false, y));
            
            d.Insert(y);
            var trainee = d.Get<Trainee>("300951212");
            Assert.AreEqual(trainee.Firstname, "מיכאל");
        }
    }
}
