using System;
using System.Collections.Generic;
using System.Globalization;
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
            float intelProciDb = 0;
            float amdProciDb = 0;
            float nvidiaKariDb = 0;
            float amdKariDb = 0;
            float osszProci = 0;
            float osszKari = 0;
            foreach (var item in alkatreszek)
            {
                if (item.Tipus.ToUpper() == "CPU" && item.Nev.ToUpper().Contains("INTEL"))
                    intelProciDb++;
                else if (item.Tipus.ToUpper() == "CPU" && item.Nev.ToUpper().Contains("AMD"))
                    amdProciDb++;

                if (item.Tipus.ToUpper() == "GPU" && item.Nev.ToUpper().Contains("NVIDIA"))
                    nvidiaKariDb++;
                else if (item.Tipus.ToUpper() == "GPU" && item.Nev.ToUpper().Contains("AMD"))
                    amdKariDb++;

                if (item.Tipus == "CPU")
                    osszProci++;
                if (item.Tipus == "GPU")
                    osszKari++;
            }

            Console.WriteLine($"Összesen {osszProci} db processzor szerepel a listában. Ebből {intelProciDb} db Intel ({intelProciDb / osszProci * 100}%) és {amdProciDb} db AMD ({amdProciDb / osszProci * 100}%)");
            Console.WriteLine($"összesen {osszKari} db videókártya van a listában. Ebből {nvidiaKariDb} db Nvidia ({nvidiaKariDb / osszKari * 100}%) és {amdKariDb} db AMD ({amdKariDb / osszKari * 100}%)");
        }

        public void Akcio()
        {
            Console.Write("Válassa ki mely terméktípust (a kategória neve) vagy mindenre (minden) vagy semmire se (semmi) legyen érvényes az akció: ");
            string akciosTipus = Console.ReadLine() ?? "";
            double akcioErteke = 0;
            if (akciosTipus.ToLower() != "semmi")
            {
                Console.Write("Írja be az akció értékét (százalékban): ");
                akcioErteke = Convert.ToDouble(Console.ReadLine());
            }
            foreach (var item in alkatreszek)
            {
                if (akciosTipus.ToLower() == "minden")
                    item.Ar -= Math.Round(item.Ar / 100 * akcioErteke);
                else if (akciosTipus == item.Tipus)
                    item.Ar -= Math.Round(item.Ar / 100 * akcioErteke);
                Console.WriteLine(item.ToString());
            }
        }
    }
}
