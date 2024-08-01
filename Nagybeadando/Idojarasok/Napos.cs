using Nagybeadando.Retegek;
using Nagybeadando.RetegStates;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Nagybeadando.Idojarasok;

public class Napos : Idojaras
{
    private static Napos? instance;

    public static Napos Instance
    {
        get
        {
            if (instance == null) instance = new Napos();
            return instance;
        }
    }

    protected Napos() { }

    public void Valtozik(Ozon z) { }
    public void Valtozik(Oxigen x)
    {
        Ozon keletkezett = new Ozon(Felszallo.Instance, x.vastagsag * 0.05);
        x.vastagsag -= keletkezett.vastagsag;
        x.legkor.AddFole(x, keletkezett);
    }
    public void Valtozik(Szendioxid s)
    {
        Oxigen keletkezett = new Oxigen(Felszallo.Instance, s.vastagsag * 0.05);
        s.vastagsag -= keletkezett.vastagsag;
        s.legkor.AddFole(s, keletkezett);
    }
}
