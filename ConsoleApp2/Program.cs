using System;
using System.IO;

namespace ConsoleApp2
{
    class Program
    {
        const string IMIE = "[Imie]";
        const string NAZWISKO = "[Nazwisko]";
        const string WIEK = "[Wiek]";
        const string PLEC = "[Plec]";
        public enum Plec
        {
            Kobieta,
            Mezczyzna,
            Pozostale
        }

        public struct Osoba
        {
            public string Imie;
            public string Nazwisko;
            public int Wiek;
            public Plec WybranaPlec ;
        }

        static bool ZapiszDane(string a_sNazwaPliku,ref Osoba a_oOsoba)
        {
            try
            {
                using (StreamWriter _oPlikDoZapisu = new StreamWriter(a_sNazwaPliku))
                {
                    _oPlikDoZapisu.WriteLine(a_oOsoba.Imie);
                    _oPlikDoZapisu.WriteLine(a_oOsoba.Nazwisko);
                    _oPlikDoZapisu.WriteLine(a_oOsoba.Wiek);
                    _oPlikDoZapisu.WriteLine(a_oOsoba.WybranaPlec);
                }

                return true;
            }
            catch (Exception e)
            {
                Console.WriteLine($"Błąd! {e.Message}");
            }

            return false;

        }

        static bool OdczytajDane(string a_sNazwaPliku, ref Osoba a_oOsoba)
        {
            try
            {
                using (StreamReader _oPlikDoOdczytu = new StreamReader(a_sNazwaPliku))
                {
                    a_oOsoba.Imie = _oPlikDoOdczytu.ReadLine();
                    a_oOsoba.Nazwisko = _oPlikDoOdczytu.ReadLine();
                    a_oOsoba.Wiek = int.Parse(_oPlikDoOdczytu.ReadLine());

                    string _sLiniaTekstowa = _oPlikDoOdczytu.ReadLine();

                    if (_sLiniaTekstowa == "Mezczyzna")
                    {
                        a_oOsoba.WybranaPlec = Plec.Mezczyzna;
                    }
                    else if (_sLiniaTekstowa == "Kobieta")
                    {
                        a_oOsoba.WybranaPlec = Plec.Kobieta;
                    }
                    else
                    {
                        a_oOsoba.WybranaPlec = Plec.Pozostale;
                    }
                }

                return true;
            }
            catch (Exception e)
            {
                Console.WriteLine($"Błąd! {e.Message}");
            }

            return false;
        }

        static bool ZapiszDane2(string a_sNazwaPliku, ref Osoba a_oOsoba)
        {
            try
            {
                using (StreamWriter _oPlikDoZapisu = new StreamWriter(a_sNazwaPliku))
                {
                    _oPlikDoZapisu.WriteLine(IMIE);
                    _oPlikDoZapisu.WriteLine(a_oOsoba.Imie);
                    _oPlikDoZapisu.WriteLine(NAZWISKO);
                    _oPlikDoZapisu.WriteLine(a_oOsoba.Nazwisko);
                    _oPlikDoZapisu.WriteLine(WIEK);
                    _oPlikDoZapisu.WriteLine(a_oOsoba.Wiek);
                    _oPlikDoZapisu.WriteLine(PLEC);
                    _oPlikDoZapisu.WriteLine(a_oOsoba.WybranaPlec);
                }

                return true;
            }
            catch (Exception e)
            {
                Console.WriteLine($"Błąd! {e.Message}");
            }

            return false;

        }

        static bool OdczytajDane2(string a_sNazwaPliku, ref Osoba a_oOsoba)
        {
            try
            {
                using (StreamReader _oPlikDoOdczytu = new StreamReader(a_sNazwaPliku))
                {
                    //EndOfStream = true <- kiedy koniec pliku
                    //EndOfStream = false <- kiedy jeszcze cos jest w pliku

                    int _iTag = -1;

                    // 0 - Imie
                    // 1 - Nazwisko
                    // 2 - Wiek
                    // 3 - Plec

                    while (_oPlikDoOdczytu.EndOfStream == false)
                    {
                        string _sLiniaZPliku = _oPlikDoOdczytu.ReadLine();

                        if (_sLiniaZPliku == IMIE)
                        {
                            _iTag = 0;
                        }
                        else if (_sLiniaZPliku == NAZWISKO)
                        {
                            _iTag = 1;
                        }
                        else if (_sLiniaZPliku == WIEK)
                        {
                            _iTag = 2;
                        }
                        else if (_sLiniaZPliku == PLEC)
                        {
                            _iTag = 3;
                        }
                        else
                        {
                            switch (_iTag)
                            {
                                case 0:
                                    a_oOsoba.Imie = _sLiniaZPliku; break;

                                case 1:
                                    a_oOsoba.Nazwisko = _sLiniaZPliku; break;

                                case 2:
                                    {
                                        int _iWiek = 0;

                                        if (int.TryParse(_sLiniaZPliku, out _iWiek))
                                        {
                                            a_oOsoba.Wiek = _iWiek;
                                        }
                                    }
                                    break;

                                case 3:
                                    {
                                        if (_sLiniaZPliku == "Mezczyzna")
                                        {
                                            a_oOsoba.WybranaPlec = Plec.Mezczyzna;
                                        }
                                        else if (_sLiniaZPliku == "Kobieta")
                                        {
                                            a_oOsoba.WybranaPlec = Plec.Kobieta;
                                        }
                                        else
                                        {
                                            a_oOsoba.WybranaPlec = Plec.Pozostale;
                                        }
                                    }
                                    break;
                            }
                        }

                        //Console.WriteLine(_sLiniaZPliku);
                    }
                }

                return true;
            }
            catch (Exception e)
            {
                Console.WriteLine($"Błąd! {e.Message}");
            }
            
            return false;
        }

        static void Main(string[] args)
        {
            /*
            Osoba osoba = new Osoba();
            osoba.Imie = "Jacek";
            osoba.Nazwisko = "K.";
            osoba.Wiek = 39;
            osoba.WybranaPlec = Plec.Mezczyzna;

            ZapiszDane("jacek.txt", ref osoba);
            */

            Osoba osoba = new Osoba();

            if (OdczytajDane2("jacek.txt", ref osoba) == true)
            {
                Console.WriteLine($"Imie:{osoba.Imie}");
                Console.WriteLine($"Nazwisko:{osoba.Nazwisko}");
                Console.WriteLine($"Wiek:{osoba.Wiek}");
                Console.WriteLine($"Plec:{osoba.WybranaPlec}");
            }

        }
    }
}
