using GymBL;
using GymBL.Database;
using GymBL.Entities;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;

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
            y.Picture = new byte[] { 5, 6 };
            y.Subscriptions.Add(new Subscription(DateTime.Now, DateTime.Now, 500, false, y));

            d.Insert(y);
            var trainee = d.Get<Trainee>("300951212");
            Assert.AreEqual(trainee.Picture[0], 5);
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
                  ("there", "address", new List<TimeSpanOfWeek>() { new TimeSpanOfWeek(DayOfWeek.Friday, 6, 8) });

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


        [TestMethod]
        public void TestMethod4()
        {
            Database d = new Database(@"
Data Source=(LocalDB)\MSSQLLocalDB;
AttachDbFilename=C:\dev\workshop\GymSystem\GymGUI\GymBL\Gym.mdf;
Integrated Security=True");
            d.DeleteAll<Trainer>();
            d.DeleteAll<Trainee>();
            d.DeleteAll<PrivateTraining>();
            var trainer = new Trainer
                  ("300951212", "מיכאל", "כהן", "לויתן 6 חולון",
                  "0528998829", "0528998829", "micaelpc@gmail.com", DateTime.Now,
                  "רגיש ללקטוז", new List<TimeSpanOfWeek>());

            var trainee = new Trainee
                  ("300951212", "מיכאל", "כהן", "לויתן 6 חולון",
                  "0528998829", "0528998829", "micaelpc@gmail.com", DateTime.Now,
                  "רגיש ללקטוז", new List<DayOfWeek>(), new List<Subscription>() { });

            d.Insert(trainer);
            d.Insert(trainee);
            var a = new PrivateTraining(trainer, trainee, Utils.Trim(DateTime.Now, TimeSpan.TicksPerSecond), TimeSpan.FromSeconds(10));
            d.Insert(a);
            var b = d.Get<PrivateTraining>(a.Id);
            Assert.AreEqual(a.Id, b.Id);
            Assert.AreEqual(a.Date, b.Date);
            Assert.AreEqual(a.Duration, b.Duration);
            Assert.AreEqual(a.Trainee.IDNumber, b.Trainee.IDNumber);
            Assert.AreEqual(a.Trainer.IDNumber, b.Trainer.IDNumber);

            d.DeleteAll<Trainer>();
            d.DeleteAll<Trainee>();
            d.DeleteAll<PrivateTraining>();
        }
    }
}
