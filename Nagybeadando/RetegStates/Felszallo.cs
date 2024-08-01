using Nagybeadando.Retegek;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Nagybeadando.RetegStates;

public class Felszallo : RetegState
{
    private static Felszallo? instance;

    public static Felszallo Instance
    {
        get
        {
            if (instance == null) instance = new Felszallo();
            return instance;
        }
    }

    protected Felszallo() { }

    public void Felszall(Reteg r)
    {
        r.legkor.RetegFelszall(r);
    }
}
