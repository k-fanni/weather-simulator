using Nagybeadando;
using Nagybeadando.Idojarasok;
using Nagybeadando.Retegek;
using Nagybeadando.RetegStates;

namespace NagybeadandoTest
{
    [TestClass]
    public class UnitTestIdojaras
    {
        Ozon z = null!;
        Oxigen x = null!;
        Szendioxid s = null!;
        List<Reteg> retegek = null!;
        Idojaras ido = null!;

        [TestInitialize]
        public void TestInit()
        {
            z = new Ozon(NemFelszallo.Instance, 5);
            x = new Oxigen(NemFelszallo.Instance, 10);
            s = new Szendioxid(Felszallo.Instance, 2);
            retegek = new List<Reteg> { z, x, s };
            Legkor.Feltolt(retegek);
        }

        [TestCleanup]
        public void TestCleanup()
        {
            Legkor.Feltolt(new List<Reteg>());
            z = null!;
            x = null!;
            s = null!;
            retegek = null!;
            ido = null!;
        }

        [TestMethod]
        public void TestValtozikOzon()
        {
            ido = Mas.Instance;
            ido.Valtozik(z);
            Ozon uj = new Ozon(Felszallo.Instance, z.vastagsag * 0.05);
            retegek[0].vastagsag -= uj.vastagsag;
            retegek.Insert(1, uj);
            Legkor.Feltolt(retegek);

            CollectionAssert.AreEqual(retegek, Legkor.Instance.GetRetegek());
        }

        [TestMethod]
        public void TestValtozikOxigen()
        {
            ido = Zivataros.Instance;
            ido.Valtozik(x);
            Ozon uj = new Ozon(Felszallo.Instance, x.vastagsag * 0.5);
            retegek[1].vastagsag -= uj.vastagsag;
            retegek.Insert(2, uj);
            Legkor.Feltolt(retegek);

            CollectionAssert.AreEqual(retegek, Legkor.Instance.GetRetegek());
        }

        [TestMethod]
        public void TestValtozikSzendioxid()
        {
            ido = Napos.Instance;
            ido.Valtozik(s);
            Ozon uj = new Ozon(Felszallo.Instance, s.vastagsag * 0.05);
            retegek[2].vastagsag -= uj.vastagsag;
            retegek.Insert(3, uj);
            Legkor.Feltolt(retegek);

            CollectionAssert.AreEqual(retegek, Legkor.Instance.GetRetegek());
        }
    }
}
