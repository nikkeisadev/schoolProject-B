using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project
{
    internal class Feladat
    {
        List<Alkatresz> alkatreszek = new List<Alkatresz>();
        public void Bevitel()
        {
            string alkatresz;
            do
            {
                Console.Write("Adjon meg egy alkatreszt: ");
                alkatresz = Console.ReadLine() ?? "";
                if (alkatresz != "")
                {
                    string[] adat = alkatresz.Split(';');
                    string _tipus = adat[0];
                    string _nev = adat[1];
                    string _parameter = adat[2];
                    int _ar = int.Parse(adat[3]);
                    Alkatresz uj = new Alkatresz(_tipus, _nev, _parameter, _ar);
                    alkatreszek.Add(uj);
                }
            } while (alkatresz != "");
        }

        public void Kereses()
        {
            bool jo = false;
            byte valasztas = 7;
            do
            {
                Console.WriteLine("Tipusra (1) vagy névre (2) szeretne keresni, ha semmire se szeretne akkor (0): ");
                try
                {
                    valasztas = Convert.ToByte(Console.ReadLine());
                    if (valasztas == 0 || valasztas == 1 || valasztas == 2)
                        jo = true;
                }
                catch
                {
                    Console.WriteLine("Hibás bevitel!");
                }
            } while (!jo);
            switch (valasztas)
            {
                case 0:
                    break;
                case 1:
                    Console.Write("Írja be melyik tipusra szeretne keresni: ");
                    string keresettTipus = Console.ReadLine() ?? "";
                    bool voltTipus = false;
                    foreach (var item in alkatreszek)
                    {
                        if (item.Tipus.ToLower() == keresettTipus.ToLower())
                        {
                            Console.WriteLine(item.ToString());
                            voltTipus = true;
                        }
                    }
                    if(!voltTipus)
                        Console.WriteLine("Nincs ilyen tipusú alkatresz.");
                    break;
                case 2:
                    Console.Write("Írja be a keresett alkatrész nevét: ");
                    string keresettNev = Console.ReadLine() ?? "";
                    bool voltNev = false;
                    foreach (var item in alkatreszek)
                    {
                        if (item.Nev.ToLower().Contains(keresettNev.ToLower()) )
                        {
                            Console.WriteLine(item.ToString());
                            voltNev = true;
                        }
                    }
                    if (!voltNev)
                        Console.WriteLine("Nincs ilyen alkatresz.");
                    break;
            }
        }

        public void Statisztika()
        {
            int intelProciDb = 0;
            int amdProciDb = 0;
            int nvidiaKariDb = 0;
            int amdKariDb = 0;
            int osszProci = 0;
            int osszKari = 0;
            foreach (var item in alkatreszek)
            {
                if (item.Tipus == "CPU" && item.Nev.Contains("Intel"))
                    intelProciDb++;
                else if (item.Tipus == "CPU" && item.Nev.Contains("AMD"))
                    amdProciDb++;

                if (item.Tipus == "GPU" && item.Nev.Contains("Nvidia"))
                    nvidiaKariDb++;
                else if (item.Tipus == "GPU" && item.Nev.Contains("AMD"))
                    amdKariDb++;

                if (item.Tipus == "CPU")
                    osszProci++;
                if (item.Tipus == "GPU")
                    osszKari++;
            }

            Console.WriteLine("");
        }
    }
}
