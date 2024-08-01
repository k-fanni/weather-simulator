using Nagybeadando.Retegek;
using Nagybeadando.RetegStates;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Nagybeadando.Idojarasok;

public class Zivataros : Idojaras
{
    private static Zivataros? instance;

    public static Zivataros Instance
    {
        get
        {
            if (instance == null) instance = new Zivataros();
            return instance;
        }
    }

    protected Zivataros() { }

    public void Valtozik(Ozon z) { }
    public void Valtozik(Oxigen x)
    {
        Ozon keletkezett = new Ozon(Felszallo.Instance, x.vastagsag * 0.5);
        x.vastagsag -= keletkezett.vastagsag;
        x.legkor.AddFole(x, keletkezett);
    }
    public void Valtozik(Szendioxid s) { }
}
