using Nagybeadando.Idojarasok;
using Nagybeadando.Retegek;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Nagybeadando;

public class Legkor
{
    private static Legkor? instance;
    private List<Reteg> retegek;

    public static Legkor Instance
    {
        get
        {
            if (instance == null) instance = new Legkor();
            return instance;
        }
    }

    private Legkor()
    {
        retegek = new List<Reteg>();
    }

    public static void Feltolt(List<Reteg> _retegek)
    {
        Instance.retegek.Clear();
        foreach (Reteg r in _retegek) Instance.retegek.Add(r);
    }

    public void Reagal(Idojaras ido)
    {
        for (int i = 0; i < retegek.Count; i++)
        {
            if (!retegek[i].Felszallo()) retegek[i].Reagal(ido);
        }

        for (int i = 0; i < retegek.Count; i++)
        {
            retegek[i].Felszall();
        }
    }

    public void RetegFelszall(Reteg r)
    {
        int i = RetegIndex(r);
        retegek.RemoveAt(i);

        while (i < retegek.Count && (retegek[i].Felszallo() || r.Anyag() != retegek[i].Anyag()))
        {
            i++;
        }

        if (i < retegek.Count)
        {
            retegek[i].vastagsag += r.vastagsag;
        }
        else if (r.vastagsag >= 0.5)
        {
            retegek.Add(r);
        }
    }

    public void AddFole(Reteg also, Reteg uj)
    {
        int i = RetegIndex(also);
        retegek.Insert(i + 1, uj);
    }

    public bool VanMindenAnyag()
    {
        return VanOzon() && VanOxigen() && VanSzendioxid();
    }

    private bool VanOzon()
    {
        foreach (Reteg e in retegek)
        {
            if (e is Ozon) return true;
        }
        return false;
    }
    private bool VanOxigen()
    {
        foreach (Reteg e in retegek)
        {
            if (e is Oxigen) return true;
        }
        return false;
    }

    private bool VanSzendioxid()
    {
        foreach (Reteg e in retegek)
        {
            if (e is Szendioxid) return true;
        }
        return false;
    }

    private int RetegIndex(Reteg r)
    {
        int i = 0;
        while (retegek[i] != r) i++;
        return i;
    }

    public List<Reteg> GetRetegek()
    {
        return retegek;
    }

    public override string ToString()
    {
        StringBuilder sb = new StringBuilder();
        for (int i = retegek.Count - 1; i >= 0; i--)
        {
            if (retegek[i] is Ozon) sb.Append('z');
            else if (retegek[i] is Oxigen) sb.Append('x');
            else sb.Append('s');
            sb.AppendFormat(" {0}\n", retegek[i].vastagsag);
        }
        return sb.ToString();
    }
}
