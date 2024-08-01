using Nagybeadando.Retegek;
using Nagybeadando.RetegStates;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Nagybeadando.Idojarasok;

public class Mas : Idojaras
{
    private static Mas? instance;

    public static Mas Instance
    {
        get
        {
            if (instance == null) instance = new Mas();
            return instance;
        }
    }

    protected Mas() { }

    public void Valtozik(Ozon z)
    {
        Oxigen keletkezett = new Oxigen(Felszallo.Instance, z.vastagsag * 0.05);
        z.vastagsag -= keletkezett.vastagsag;
        z.legkor.AddFole(z, keletkezett);
    }

    public void Valtozik(Oxigen x)
    {
        Szendioxid keletkezett = new Szendioxid(Felszallo.Instance, x.vastagsag * 0.15);
        x.vastagsag -= keletkezett.vastagsag;
        x.legkor.AddFole(x, keletkezett);
    }

    public void Valtozik(Szendioxid s) { }
}
