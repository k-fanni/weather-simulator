using Nagybeadando.Idojarasok;
using Nagybeadando.RetegStates;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Nagybeadando.Retegek;

public abstract class Reteg
{
    public double vastagsag { get; set; }
    protected RetegState state;
    public Legkor legkor => Legkor.Instance;

    public Reteg(RetegState state,  double vastagsag)
    {
        this.state = state;
        this.vastagsag = vastagsag;
    }

    public void ChangeState(RetegState state)
    {
        this.state = state;
    }

    public abstract void Reagal(Idojaras ido);

    public abstract void Felszall();

    public bool Felszallo()
    {
        return state == RetegStates.Felszallo.Instance;
    }

    public abstract string Anyag();
}
