using Nagybeadando.Idojarasok;
using Nagybeadando;
using Nagybeadando.Retegek;
using Nagybeadando.RetegStates;

namespace NagybeadandoTest
{
    [TestClass]
    public class UnitTestReteg
    {
        Ozon z = null!;
        Oxigen x = null!;
        Szendioxid s = null!;

        [TestInitialize]
        public void TestInit()
        {
            z = new Ozon(NemFelszallo.Instance, 4);
            x = new Oxigen(NemFelszallo.Instance, 2);
            s = new Szendioxid(NemFelszallo.Instance, 1);
        }

        [TestCleanup]
        public void TestCleanup()
        {
            z = null!;
            x = null!;
            s = null!;
        }

        [TestMethod]
        public void TestChangeState()
        {
            z.ChangeState(Felszallo.Instance);
            Assert.IsTrue(z.Felszallo());
            z.ChangeState(NemFelszallo.Instance);
            Assert.IsFalse(z.Felszallo());
        }

        [TestMethod]
        public void TestAnyag()
        {
            Assert.AreEqual("ozon", z.Anyag());
            Assert.AreEqual("oxigen", x.Anyag());
            Assert.AreEqual("szendioxid", s.Anyag());
        }

        [TestMethod]
        public void TestVastagsag()
        {
            x.vastagsag = 10;
            Assert.AreEqual(10, x.vastagsag);
            s.vastagsag = 0;
            Assert.AreEqual(0, s.vastagsag);
        }

        [TestMethod]
        public void TestNemReagal()
        {
            List<Reteg> retegek = new List<Reteg> { z, x };
            Legkor.Feltolt(retegek);
            z.Reagal(Zivataros.Instance);
            Assert.AreEqual(retegek[0], Legkor.Instance.GetRetegek()[0]);
        }

        [TestMethod]
        public void TestReagal()
        {
            List<Reteg> retegek = new List<Reteg> { z, x };
            Legkor.Feltolt(retegek);
            z.Reagal(Mas.Instance);
            Assert.AreNotEqual(4, Legkor.Instance.GetRetegek()[0].vastagsag);
        }

        [TestMethod]
        public void TestNemFelszall()
        {
            List<Reteg> retegek = new List<Reteg> { z, x };
            Legkor.Feltolt(retegek);
            z.Felszall();
            Assert.AreEqual(retegek[0], Legkor.Instance.GetRetegek()[0]);
        }

        [TestMethod]
        public void TestFelszall()
        {
            List<Reteg> retegek = new List<Reteg> { z, x };
            Legkor.Feltolt(retegek);
            z.ChangeState(Felszallo.Instance);
            z.Felszall();
            Assert.AreNotEqual(retegek[0], Legkor.Instance.GetRetegek()[0]);
        }
    }
}