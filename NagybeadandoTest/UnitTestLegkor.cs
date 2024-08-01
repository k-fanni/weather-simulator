using Nagybeadando;
using Nagybeadando.Idojarasok;
using Nagybeadando.Retegek;
using Nagybeadando.RetegStates;

namespace NagybeadandoTest
{
    [TestClass]
    public class UnitTestLegkor
    {
        Ozon z = null!;
        Oxigen x = null!;
        Szendioxid s = null!;
        List<Reteg> retegek = null!;

        [TestInitialize]
        public void TestInit()
        {
            _ = Legkor.Instance;
            z = new Ozon(NemFelszallo.Instance, 5);
            x = new Oxigen(NemFelszallo.Instance, 10);
            s = new Szendioxid(Felszallo.Instance, 2);
            retegek = new List<Reteg> { z, x, s };
        }

        [TestCleanup]
        public void TestCleanup()
        {
            Legkor.Feltolt(new List<Reteg>());
            z = null!;
            x = null!;
            s = null!;
            retegek = null!;
        }

        [TestMethod]
        public void TestFeltolt()
        {
            Legkor.Feltolt(retegek);
            CollectionAssert.AreEqual(retegek, Legkor.Instance.GetRetegek());
        }

        [TestMethod]
        public void TestAnyagok()
        {
            Legkor.Feltolt(retegek);
            Assert.IsTrue(Legkor.Instance.VanMindenAnyag());

            retegek.Remove(x);
            Legkor.Feltolt(retegek);
            Assert.IsFalse(Legkor.Instance.VanMindenAnyag());

            retegek.Remove(z);
            retegek.Remove(s);
            Legkor.Feltolt(retegek);
            Assert.IsFalse(Legkor.Instance.VanMindenAnyag()); // ha minden réteg elfogy
        }

        [TestMethod]
        public void TestAddFole()
        {
            Legkor.Feltolt(retegek);

            Szendioxid s2 = new Szendioxid(Felszallo.Instance, 4);
            Legkor.Instance.AddFole(z, s2);
            Assert.AreEqual(s2, Legkor.Instance.GetRetegek()[1]);
        }

        [TestMethod]
        public void TestRetegMegszunik()
        {
            retegek[0].ChangeState(Felszallo.Instance);
            retegek[0].vastagsag = 0.3;
            Legkor.Feltolt(retegek);
            Legkor.Instance.RetegFelszall(z);
            retegek.Remove(z);
            CollectionAssert.AreEqual(retegek, Legkor.Instance.GetRetegek());
        }

        [TestMethod]
        public void TestRetegVastagit()
        {
            Oxigen x2 = new Oxigen(Felszallo.Instance, 5);
            retegek.Insert(0, x2);
            Legkor.Feltolt(retegek);
            Legkor.Instance.RetegFelszall(x2);
            retegek.Remove(x2);
            retegek[1].vastagsag += 5;
            CollectionAssert.AreEqual(retegek, Legkor.Instance.GetRetegek());
        }

        [TestMethod]
        public void TestRetegLegfelulre()
        {
            retegek[0].ChangeState(Felszallo.Instance);
            Legkor.Feltolt(retegek);
            Legkor.Instance.RetegFelszall(z);
            retegek.Remove(z);
            retegek.Add(z);
            CollectionAssert.AreEqual(retegek, Legkor.Instance.GetRetegek());
        }

        [TestMethod]
        public void TestNemReagal()
        {
            List<Reteg> retegek1 = new List<Reteg> { z, s };
            Legkor.Feltolt(retegek1);
            Legkor.Instance.Reagal(Zivataros.Instance);
            CollectionAssert.AreEqual(retegek1, Legkor.Instance.GetRetegek());
        }

        [TestMethod]
        public void TestReagal()
        {
            Legkor.Feltolt(retegek);
            Legkor.Instance.Reagal(Zivataros.Instance);
            Assert.AreEqual(4, Legkor.Instance.GetRetegek().Count);
            Assert.AreEqual(5, Legkor.Instance.GetRetegek()[1].vastagsag);
            Assert.AreEqual(5, Legkor.Instance.GetRetegek()[3].vastagsag);
        }
    }
}
