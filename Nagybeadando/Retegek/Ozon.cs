using Nagybeadando.Idojarasok;
using Nagybeadando.RetegStates;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Nagybeadando.Retegek;

public class Ozon : Reteg
{
    public Ozon(RetegState state, double vastagsag) : base(state, vastagsag) { }

    public override void Reagal(Idojaras ido)
    {
        ido.Valtozik(this);
    }

    public override void Felszall()
    {
        state.Felszall(this);
    }

    public override string Anyag()
    {
        return "ozon";
    }
}
