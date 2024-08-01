using Nagybeadando;
using Nagybeadando.Retegek;
using Nagybeadando.RetegStates;

namespace NagybeadandoTest
{
    [TestClass]
    public class UnitTestRetegStates
    {
        Ozon z = null!;
        List<Reteg> retegek = null!;

        [TestInitialize]
        public void TestInit()
        {
            z = new Ozon(NemFelszallo.Instance, 4);
            retegek = new List<Reteg> { z };
        }

        [TestCleanup]
        public void TestCleanup()
        {
            z = null!;
            retegek = null!;
        }

        [TestMethod]
        public void TestFelszall1()
        {
            Legkor.Feltolt(retegek);
            NemFelszallo.Instance.Felszall(z);
            Assert.IsFalse(z.Felszallo());
            z.vastagsag = 0.3;
            NemFelszallo.Instance.Felszall(z);
            Assert.IsTrue(z.Felszallo());
            Assert.AreEqual(0, Legkor.Instance.GetRetegek().Count);
        }

        [TestMethod]
        public void TestFelszall2()
        {
            Legkor.Feltolt(retegek);
            Felszallo.Instance.Felszall(z);
            Assert.AreEqual(1, Legkor.Instance.GetRetegek().Count);
            z.vastagsag = 0.3;
            Felszallo.Instance.Felszall(z);
            Assert.AreEqual(0, Legkor.Instance.GetRetegek().Count);
        }
    }
}
