using Nagybeadando.Idojarasok;
using Nagybeadando.Retegek;
using Nagybeadando.RetegStates;
using System.Globalization;

namespace Nagybeadando
{
    internal class Program
    {
        static void Main(string[] args)
        {
            try
            {
                Console.Write("Adja meg a fájl nevét: ");
                StreamReader reader = new StreamReader(Console.ReadLine()!);

                string? idojaras;
                if ((idojaras = reader.ReadLine()) == null) {
                    throw new Exception("Üres a fájl!");
                }
                Console.WriteLine(idojaras);
                for (int x = 0; x < idojaras.Length; x++)
                {
                    if (!"znm".Contains(idojaras[x]))
                    {
                        throw new Exception("Egy megadott időjárási viszony nem létezik!");
                    }
                }

                List<Reteg> retegek = new List<Reteg>();
                Reteg r = null!;
                string? line;

                while ((line = reader.ReadLine()) != null)
                {
                    Console.WriteLine(line);
                    string[] retegData = line.Split(" ");
                    if (!Double.TryParse(retegData[1], CultureInfo.InvariantCulture, out double vastagsag))
                    {
                        throw new Exception("A réteg vastagsága nem valós szám!");
                    }
                    switch (retegData[0])
                    {
                        case "z":
                            r = new Ozon(NemFelszallo.Instance, vastagsag);
                            break;
                        case "x":
                            r = new Oxigen(NemFelszallo.Instance, vastagsag);
                            break;
                        case "s":
                            r = new Szendioxid(NemFelszallo.Instance, vastagsag);
                            break;
                        default:
                            throw new Exception("A megadott anyag nem létezik!");
                    }
                    retegek.Insert(0, r); // a legalsó réteget akarjuk legelöl tárolni a listában
                }
                reader.Close();

                Console.WriteLine();

                Legkor.Feltolt(retegek);
                Idojaras ido = null!;
                int i = 0;

                while (Legkor.Instance.VanMindenAnyag())
                {
                    switch (idojaras[i])
                    {
                        case 'z':
                            ido = Zivataros.Instance;
                            break;
                        case 'n':
                            ido = Napos.Instance;
                            break;
                        case 'm':
                            ido = Mas.Instance;
                            break;
                    }
                    Legkor.Instance.Reagal(ido);

                    Console.WriteLine("Időjárás: {0}", idojaras[i]);
                    Console.WriteLine(Legkor.Instance.ToString());

                    i = (i + 1) % idojaras.Length;
                }

                Console.WriteLine("A légkörből hiányzik egy vagy több anyag, a folyamatnak vége.");
            }
            catch (FileNotFoundException e)
            {
                Console.WriteLine(e.Message);
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
        }
    }
}
