using Nagybeadando.Retegek;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Nagybeadando.RetegStates;

public class NemFelszallo : RetegState
{
    private static NemFelszallo? instance;

    public static NemFelszallo Instance
    {
        get
        {
            if (instance == null) instance = new NemFelszallo();
            return instance;
        }
    }

    protected NemFelszallo() { }

    public void Felszall(Reteg r)
    {
        if (r.vastagsag < 0.5)
        {
            r.ChangeState(Felszallo.Instance);
            r.Felszall();
        }
    }
}
