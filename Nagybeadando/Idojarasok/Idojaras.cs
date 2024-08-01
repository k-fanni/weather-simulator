using Nagybeadando.Retegek;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Nagybeadando.Idojarasok;

public interface Idojaras
{
    void Valtozik(Ozon z);
    void Valtozik(Oxigen x);
    void Valtozik(Szendioxid s);
}
