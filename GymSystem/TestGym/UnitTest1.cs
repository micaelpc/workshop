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
            y.Subscriptions.Add(new Subscription(DateTime.Now, DateTime.Now, 500, false, y));
            
            d.Insert(y);
            var trainee = d.Get<Trainee>("300951212");
            Assert.AreEqual(trainee.Firstname, "מיכאל");
            d.DeleteAll<Trainee>();
            d.DeleteAll<Subscription>();
        }


        [TestMethod]
        public void TestMethod2()
        {
            Database d = new Database(@"
Data Source=(LocalDB)\MSSQLLocalDB;
AttachDbFilename=C:\dev\workshop\GymSystem\GymGUI\GymBL\Gym.mdf;
Integrated Security=True");
            d.DeleteAll<GymLocation>();
            var y = new GymLocation
                  ("there", "address", new List<TimeSpanOfWeek>() { new TimeSpanOfWeek(DayOfWeek.Friday, 6, 8)});

            d.Insert(y);
            var gym = d.Get<GymLocation>("there");
            Assert.AreEqual(gym.Address, "address");
            Assert.AreEqual(gym.OpeningTimes.Count, 1);
            Assert.AreEqual(gym.OpeningTimes[0].Day, DayOfWeek.Friday);
            d.DeleteAll<GymLocation>();
        }

        [TestMethod]
        public void TestMethod3()
        {
            Database d = new Database(@"
Data Source=(LocalDB)\MSSQLLocalDB;
AttachDbFilename=C:\dev\workshop\GymSystem\GymGUI\GymBL\Gym.mdf;
Integrated Security=True");
            d.DeleteAll<Trainer>();
            var y = new Trainer
                  ("300951212", "מיכאל", "כהן", "לויתן 6 חולון",
                  "0528998829", "0528998829", "micaelpc@gmail.com", DateTime.Now,
                  "רגיש ללקטוז", new List<TimeSpanOfWeek>());

            d.Insert(y);
            var trainer = d.Get<Trainer>("300951212");
            Assert.AreEqual(trainer.Address, "לויתן 6 חולון");
            d.DeleteAll<Trainer>();
        }
    }
}
