using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Minesweeper
{
    class Program
    {
        // GENEL HATLAR



        static void Main(string[] args)
        {
            Console.BackgroundColor = ConsoleColor.Gray;
            Console.ForegroundColor = ConsoleColor.Black;
            Console.Clear();



            /* MAYIN TARLASI DİZİSİ */
            string[,] MayinTarlasi = new String[7, 7];
            /* MAYİNSİ TUTMA DİZİSİ */
            String[,] RastgeleMayin = new String[7, 7];
            Random rnd = new Random();

            int pts = 0;
            int HintSayisi = 3;
            int DogruFlagSayisi = 0;
            int YanlisFlagSayisi = 0;
            int PuanYanlisFlag = 0;
            int cikis = 0;

            // NEW GAME DÖNGÜSÜ
            for (; ; )
            {
                Console.Clear();
                Console.SetCursorPosition(0, 0);
                Console.WriteLine();
                Console.WriteLine("-------------------------- MINE SWEEPER -----------------------------");
                Console.WriteLine();
                Console.WriteLine("           N - NEW GAME                                               ");
                Console.WriteLine("                               OR                                    ");
                Console.WriteLine("                                         L - LOAD GAME               ");
                Console.WriteLine();
                Console.WriteLine("---------------------------------------------------------------------");




                Console.SetCursorPosition(20, 23);
                Console.WriteLine("   All Rights Reserved ©");
                Console.SetCursorPosition(25, 12);
                Console.Write("What do you want:");






                ConsoleKeyInfo NewGame = Console.ReadKey();

                // LOAD GAME
                if (NewGame.Key == ConsoleKey.L)
                {
                    StreamReader reader = new StreamReader(@"D:\ödevler ve projeler\Mayın tarlası\MayinTarlasi\MayinTarlasi\Save");

                    for (int i = 0; i < 7; i++)
                    {
                        for (int j = 0; j < 7; j++)
                        {
                            MayinTarlasi[i, j] = reader.ReadLine();
                        }
                    }
                    for (int i = 0; i < 7; i++)
                    {
                        for (int j = 0; j < 7; j++)
                        {
                            RastgeleMayin[i, j] = reader.ReadLine();
                        }
                    }

                    DogruFlagSayisi = Convert.ToInt32(reader.ReadLine());
                    YanlisFlagSayisi = Convert.ToInt32(reader.ReadLine());
                    PuanYanlisFlag = Convert.ToInt32(reader.ReadLine());
                    pts = Convert.ToInt32(reader.ReadLine());
                    HintSayisi = Convert.ToInt32(reader.ReadLine());

                    reader.Close();
                }
                // LOAD GAME




                else if (NewGame.Key == ConsoleKey.N)
                {


                    // OYUN TABLOSUNA BAŞLANGIÇ DEĞERLERİ VERME
                    for (int i = 0; i < 7; i++)
                    {
                        for (int j = 0; j < 7; j++)
                        {
                            MayinTarlasi[i, j] = ".";
                        }
                    }
                    // OYUN TABLOSUNA BAŞLANGIÇ DEĞERLERİ VERME


                    // Duvar koymak için rastgele döngüsü
                    int RastgeleSutunDuvar;
                    int RastgeleSatirDuvar;

                    for (int i = 0; i < 10; i++)
                    {
                        RastgeleSutunDuvar = rnd.Next(0, 7);
                        RastgeleSatirDuvar = rnd.Next(0, 7);



                        if (MayinTarlasi[RastgeleSatirDuvar, RastgeleSutunDuvar] != ".")
                        {
                            i = i - 1;
                            continue;
                        }
                        else
                            MayinTarlasi[RastgeleSatirDuvar, RastgeleSutunDuvar] = "#";

                    }
                    // Duvar koymak için rastgele döngüsü



                    // mayinlari tutmak için tablo

                    for (int i = 0; i < 7; i++)
                    {
                        for (int j = 0; j < 7; j++)
                        {
                            RastgeleMayin[i, j] = ".";
                        }
                    }
                    // mayinlari tutmak için tablo


                    //Mayinlari yerleştirmek için rastgele döngüsü
                    int RastgeleSatirMayin;
                    int RastgeleSutunMayin;

                    for (int xyz = 0; xyz < 8; xyz++)
                    {
                        RastgeleSatirMayin = rnd.Next(0, 7);
                        RastgeleSutunMayin = rnd.Next(0, 7);

                        if (MayinTarlasi[RastgeleSatirMayin, RastgeleSutunMayin] == ".")
                        {
                            if (RastgeleMayin[RastgeleSatirMayin, RastgeleSutunMayin] == ".")
                            {
                                RastgeleMayin[RastgeleSatirMayin, RastgeleSutunMayin] = "M";
                            }
                            else
                            { xyz = xyz - 1; continue; }
                        }
                        else
                        { xyz = xyz - 1; continue; }
                    }
                    //Mayinlari yerleştirmek için rastgele döngüsü
                }
                else
                {

                    continue;
                }
                break;
            }
            // NEW GAME DÖNGÜSÜ

            Console.Clear();
            Console.SetCursorPosition(20, 23);
            Console.WriteLine("   All Rights Reserved ©");


            MayinTarlasiniCiz(MayinTarlasi);
            Console.SetCursorPosition(20, 3);
            Console.WriteLine("Points : {0}", pts);
            Console.SetCursorPosition(20, 5);
            Console.WriteLine("hints : {0}", HintSayisi);

            Console.SetCursorPosition(0, 12);
            Console.WriteLine();
            Console.WriteLine();
            Console.WriteLine("Command List :");
            Console.WriteLine("ENTER : Open");
            Console.WriteLine("F : Flag");
            Console.WriteLine("U : Unflag");
            Console.WriteLine("H : Hint");
            Console.WriteLine("S : Save");
            Console.WriteLine("E : Exit");







            int CursorSatir = 2;
            int CursorSutun = 3;
            Console.SetCursorPosition(CursorSutun, CursorSatir);

            // OYUN DÖNGÜSÜ
            for (; ; )
            {
                ConsoleKeyInfo info = Console.ReadKey();

                if (info.Key == ConsoleKey.E)
                {
                    cikis = 2;
                    break;
                }


                else if (info.Key == ConsoleKey.S)
                {

                    StreamWriter writer = new StreamWriter(@"D:\ödevler ve projeler\Mayın tarlası\MayinTarlasi\MayinTarlasi\Save");

                    for (int i = 0; i < 7; i++)
                    {
                        for (int j = 0; j < 7; j++)
                        {
                            writer.WriteLine(MayinTarlasi[i, j]);

                        }
                    }

                    for (int i = 0; i < 7; i++)
                    {
                        for (int j = 0; j < 7; j++)
                        {
                            writer.WriteLine(RastgeleMayin[i, j]);

                        }
                    }

                    writer.WriteLine(DogruFlagSayisi);
                    writer.WriteLine(YanlisFlagSayisi);
                    writer.WriteLine(PuanYanlisFlag);
                    writer.WriteLine(pts);
                    writer.WriteLine(HintSayisi);



                    writer.Close();

                }





                int GercekDegerSatir, GercekDegerSutun;
                GercekDegerSatir = CursorSatir - 2;
                GercekDegerSutun = CursorSutun - 3;

                // UYUM SORUNU ÇÖZÜMÜ
                int GercekDegerSutun111 = 0;

                if (GercekDegerSutun == 2)
                    GercekDegerSutun111 = GercekDegerSutun - 1;
                else if (GercekDegerSutun == 4)
                    GercekDegerSutun111 = GercekDegerSutun - 2;
                else if (GercekDegerSutun == 6)
                    GercekDegerSutun111 = GercekDegerSutun - 3;
                else if (GercekDegerSutun == 8)
                    GercekDegerSutun111 = GercekDegerSutun - 4;
                else if (GercekDegerSutun == 10)
                    GercekDegerSutun111 = GercekDegerSutun - 5;
                else if (GercekDegerSutun == 12)
                    GercekDegerSutun111 = GercekDegerSutun - 6;
                // UYUM SORUNU ÇÖZÜMÜ




                // FLAG KOYMA
                if (info.Key == ConsoleKey.F)
                {
                    if (MayinTarlasi[GercekDegerSatir, GercekDegerSutun111] == "#")
                    {
                        MayinTarlasi[GercekDegerSatir, GercekDegerSutun111] = "#";
                    }
                    else if (MayinTarlasi[GercekDegerSatir, GercekDegerSutun111] == ".")
                    {
                        MayinTarlasi[GercekDegerSatir, GercekDegerSutun111] = "F";

                        if (RastgeleMayin[GercekDegerSatir, GercekDegerSutun111] == "M")
                        {
                            DogruFlagSayisi++;
                        }
                        else if (RastgeleMayin[GercekDegerSatir, GercekDegerSutun111] == ".")
                        {
                            YanlisFlagSayisi++;
                            PuanYanlisFlag = PuanYanlisFlag + 30;
                        }

                    }


                    //Console.SetCursorPosition(20, 8);
                    //Console.WriteLine(DogruFlagSayisi + "  " + YanlisFlagSayisi);


                    MayinTarlasiniCiz(MayinTarlasi);
                    Console.SetCursorPosition(20, 3);
                    Console.WriteLine("Points : {0}", pts);
                    Console.SetCursorPosition(20, 5);
                    Console.WriteLine("hints : {0}", HintSayisi);


                }
                // FLAG KOYMA


                // FLAG KAlDIRMA

                if (info.Key == ConsoleKey.U)
                {

                    if (MayinTarlasi[GercekDegerSatir, GercekDegerSutun111] == "#")
                    {
                        MayinTarlasi[GercekDegerSatir, GercekDegerSutun111] = "#";
                    }

                    else if (MayinTarlasi[GercekDegerSatir, GercekDegerSutun111] == ".")
                    {
                        MayinTarlasi[GercekDegerSatir, GercekDegerSutun111] = ".";
                    }


                    else if (MayinTarlasi[GercekDegerSatir, GercekDegerSutun111] == "F")
                    {
                        if (RastgeleMayin[GercekDegerSatir, GercekDegerSutun111] == "M")
                        {
                            DogruFlagSayisi--;
                        }
                        else if (RastgeleMayin[GercekDegerSatir, GercekDegerSutun111] == ".")
                        {
                            YanlisFlagSayisi--;
                        }




                        MayinTarlasi[GercekDegerSatir, GercekDegerSutun111] = ".";
                    }




                    MayinTarlasiniCiz(MayinTarlasi);
                    Console.SetCursorPosition(20, 3);
                    Console.WriteLine("Points : {0}", pts);
                    Console.SetCursorPosition(20, 5);
                    Console.WriteLine("hints : {0}", HintSayisi);


                    //Console.SetCursorPosition(20, 8);
                    //Console.WriteLine(DogruFlagSayisi +"  " + YanlisFlagSayisi);
                }


 // FLAG KAlDIRMA




     // HİNT
                else if (info.Key == ConsoleKey.H)
                {
                    if (HintSayisi == 0)
                    {
                        Console.SetCursorPosition(20, 6);
                        Console.WriteLine("We can't help you anymore, sorry :(");
                    }

                    else
                    {

                        int RastgeleSatirHint, RastgeleSutunHint;
                        int EtraftakiMayinSayisi = 0;
                        bool HintSon = true;

                        for (; ; )
                        {



                            for (int i = 0; i < 7; i++)
                            {
                                for (int j = 0; j < 7; j++)
                                {
                                    if (MayinTarlasi[i, j] == ".")
                                    {
                                        if (RastgeleMayin[i, j] != "M")
                                        {
                                            HintSon = false;
                                        }
                                    }
                                }
                            }

                            RastgeleSatirHint = rnd.Next(0, 7);
                            RastgeleSutunHint = rnd.Next(0, 7);

                            if (HintSon == true)
                            {
                                MayinTarlasiniCiz(MayinTarlasi);
                                Console.SetCursorPosition(20, 6);
                                Console.WriteLine("It's time to show your skills, bro!");
                                HintSayisi++;
                                break;
                            }

                            RastgeleSatirHint = rnd.Next(0, 7);
                            RastgeleSutunHint = rnd.Next(0, 7);

                            if (MayinTarlasi[RastgeleSatirHint, RastgeleSutunHint] == "." && RastgeleMayin[RastgeleSatirHint, RastgeleSutunHint] != "M")
                            {
                                if ((RastgeleSatirHint != 6) && (RastgeleSutunHint != 0))
                                {
                                    if (RastgeleMayin[RastgeleSatirHint + 1, RastgeleSutunHint - 1] == "M")
                                        EtraftakiMayinSayisi++;
                                }
                                if ((RastgeleSatirHint != 6) && (RastgeleSutunHint != 6))
                                {
                                    if (RastgeleMayin[RastgeleSatirHint + 1, RastgeleSutunHint + 1] == "M")
                                        EtraftakiMayinSayisi++;
                                }
                                if ((RastgeleSatirHint != 0) && (RastgeleSutunHint != 0))
                                {
                                    if (RastgeleMayin[RastgeleSatirHint - 1, RastgeleSutunHint - 1] == "M")
                                        EtraftakiMayinSayisi++;
                                }
                                if ((RastgeleSatirHint != 0) && (RastgeleSutunHint != 6))
                                {
                                    if (RastgeleMayin[RastgeleSatirHint - 1, RastgeleSutunHint + 1] == "M")
                                        EtraftakiMayinSayisi++;
                                }
                                if (RastgeleSatirHint != 0)
                                {
                                    if (RastgeleMayin[RastgeleSatirHint - 1, RastgeleSutunHint] == "M")
                                        EtraftakiMayinSayisi++;
                                }
                                if (RastgeleSutunHint != 6)
                                {
                                    if (RastgeleMayin[RastgeleSatirHint, RastgeleSutunHint + 1] == "M")
                                        EtraftakiMayinSayisi++;
                                }
                                if (RastgeleSutunHint != 0)
                                {
                                    if (RastgeleMayin[RastgeleSatirHint, RastgeleSutunHint - 1] == "M")
                                        EtraftakiMayinSayisi++;
                                }
                                if (RastgeleSatirHint != 6)
                                {
                                    if (RastgeleMayin[RastgeleSatirHint + 1, RastgeleSutunHint] == "M")
                                        EtraftakiMayinSayisi++;
                                }

                                if (EtraftakiMayinSayisi == 0)
                                {
                                    continue;
                                }


                            }

                            else
                                continue;


                            MayinTarlasi[RastgeleSatirHint, RastgeleSutunHint] = Convert.ToString(EtraftakiMayinSayisi);


                            break;
                        }

                        HintSayisi--;

                    }


                    MayinTarlasiniCiz(MayinTarlasi);
                    Console.SetCursorPosition(20, 3);
                    Console.WriteLine("Points : {0}", pts);
                    Console.SetCursorPosition(20, 5);
                    Console.WriteLine("hints : {0}", HintSayisi);


                }


     // HİNT






// ENTER
                else if (info.Key == ConsoleKey.Enter)
                {




                    if (MayinTarlasi[GercekDegerSatir, GercekDegerSutun111] == "F")
                    {
                        MayinTarlasi[GercekDegerSatir, GercekDegerSutun111] = "F";
                    }




                    else if (RastgeleMayin[GercekDegerSatir, GercekDegerSutun111] == "M")
                    {
                        Console.SetCursorPosition(20, 1);
                        MayinTarlasi[GercekDegerSatir, GercekDegerSutun111] = "M";

                        cikis = 1;

                        break;
                    }
                    else if (MayinTarlasi[GercekDegerSatir, GercekDegerSutun111] == "#")
                    {
                        MayinTarlasi[GercekDegerSatir, GercekDegerSutun111] = "#";
                    }




  // ÇEVREDEKİ MAYIN SAYISI
                    else if (MayinTarlasi[GercekDegerSatir, GercekDegerSutun111] == ".")
                    {
                        int EtraftakiMayinSayisi = 0;



                        if ((GercekDegerSatir != 6) && (GercekDegerSutun111 != 0))
                        {
                            if (RastgeleMayin[GercekDegerSatir + 1, GercekDegerSutun111 - 1] == "M")
                                EtraftakiMayinSayisi++;
                        }
                        if ((GercekDegerSatir != 6) && (GercekDegerSutun111 != 6))
                        {
                            if (RastgeleMayin[GercekDegerSatir + 1, GercekDegerSutun111 + 1] == "M")
                                EtraftakiMayinSayisi++;
                        }
                        if ((GercekDegerSatir != 0) && (GercekDegerSutun111 != 0))
                        {
                            if (RastgeleMayin[GercekDegerSatir - 1, GercekDegerSutun111 - 1] == "M")
                                EtraftakiMayinSayisi++;
                        }
                        if ((GercekDegerSatir != 0) && (GercekDegerSutun111 != 6))
                        {
                            if (RastgeleMayin[GercekDegerSatir - 1, GercekDegerSutun111 + 1] == "M")
                                EtraftakiMayinSayisi++;
                        }
                        if (GercekDegerSatir != 0)
                        {
                            if (RastgeleMayin[GercekDegerSatir - 1, GercekDegerSutun111] == "M")
                                EtraftakiMayinSayisi++;
                        }
                        if (GercekDegerSutun111 != 6)
                        {
                            if (RastgeleMayin[GercekDegerSatir, GercekDegerSutun111 + 1] == "M")
                                EtraftakiMayinSayisi++;
                        }
                        if (GercekDegerSutun111 != 0)
                        {
                            if (RastgeleMayin[GercekDegerSatir, GercekDegerSutun111 - 1] == "M")
                                EtraftakiMayinSayisi++;
                        }
                        if (GercekDegerSatir != 6)
                        {
                            if (RastgeleMayin[GercekDegerSatir + 1, GercekDegerSutun111] == "M")
                                EtraftakiMayinSayisi++;
                        }


                        pts = pts + EtraftakiMayinSayisi * 10;
                        MayinTarlasi[GercekDegerSatir, GercekDegerSutun111] = Convert.ToString(EtraftakiMayinSayisi);

                        MayinTarlasiniCiz(MayinTarlasi);
                        Console.SetCursorPosition(20, 3);
                        Console.WriteLine("Points : {0}", pts);
                        Console.SetCursorPosition(20, 5);
                        Console.WriteLine("hints : {0}", HintSayisi);

                    }
                    // ÇEVREDEKİ MAYIN SAYISI




                }
                // ENTER






    // CURSOR 

                else
                {

                    if (info.Key == ConsoleKey.UpArrow)
                    {
                        CursorSatir = CursorSatir - 1;
                        if (CursorSatir < 2)
                            CursorSatir = CursorSatir + 1;
                    }


                    else if (info.Key == ConsoleKey.DownArrow)
                    {
                        CursorSatir = CursorSatir + 1;
                        if (CursorSatir > 8)
                            CursorSatir = CursorSatir - 1;
                    }


                    else if (info.Key == ConsoleKey.RightArrow)
                    {
                        CursorSutun = CursorSutun + 2;
                        if (CursorSutun > 15)
                            CursorSutun = CursorSutun - 2;
                    }


                    else if (info.Key == ConsoleKey.LeftArrow)
                    {
                        CursorSutun = CursorSutun - 2;
                        if (CursorSutun < 3)
                            CursorSutun = CursorSutun + 2;
                    }






                    MayinTarlasiniCiz(MayinTarlasi);
                    Console.SetCursorPosition(20, 3);
                    Console.WriteLine("Points : {0}", pts);
                    Console.SetCursorPosition(20, 5);
                    Console.WriteLine("hints : {0}", HintSayisi);

                    Console.SetCursorPosition(CursorSutun, CursorSatir);



                }
                // CURSOR

                Console.SetCursorPosition(CursorSutun, CursorSatir);

                if (DogruFlagSayisi == 8 && YanlisFlagSayisi == 0)
                {
                    break;
                }





            }
            // OYUN DÖNGÜSÜ

            int hintpuani;
            hintpuani = 60 - HintSayisi * 20;

            pts = pts + DogruFlagSayisi * 50;
            pts = pts - PuanYanlisFlag;
            pts = pts - hintpuani;

            if (cikis == 0)
            {

                MayinTarlasiniCiz(MayinTarlasi);

                Console.SetCursorPosition(20, 3);
                Console.Write("points = {0}", pts);

                Console.SetCursorPosition(25, 9);
                Console.Write(" YOU WIN !!! YOUR POINT IS {0}. ", pts);
                Console.SetCursorPosition(25, 11);
                Console.Write(" <<< Press E to Exit... >>>");

                Console.ReadLine();
            }
            else if (cikis == 1)
            {

                MayinTarlasiniCiz(MayinTarlasi);

                Console.SetCursorPosition(25, 9);
                Console.Write(" GAME IS OVER !!! YOUR POINT IS {0}. ", pts);
                Console.SetCursorPosition(25, 11);
                Console.Write(" <<< Press Any Key to Exit... >>>");
                Console.ReadKey();

            }

        }
        // GENEL HATLAR











        // MAYIN TARLASI ÇİZDİRMEK İÇİN FONKSİYON
        static void MayinTarlasiniCiz(String[,] MayinTarlasi1)
        {
            Console.SetCursorPosition(0, 0);
            Console.WriteLine("   1 2 3 4 5 6 7");
            Console.WriteLine("  +-------------+");

            for (int i = 0; i < 7; i++)
            {
                Console.Write((i + 1) + " |");

                for (int j = 0; j < 7; j++)
                {

                    if (MayinTarlasi1[i, j] == "F")
                        Console.ForegroundColor = ConsoleColor.Blue;
                    else if (MayinTarlasi1[i, j] == "8")
                        Console.ForegroundColor = ConsoleColor.DarkRed;
                    else if (MayinTarlasi1[i, j] == "7")
                        Console.ForegroundColor = ConsoleColor.DarkRed;
                    else if (MayinTarlasi1[i, j] == "6")
                        Console.ForegroundColor = ConsoleColor.DarkRed;
                    else if (MayinTarlasi1[i, j] == "5")
                        Console.ForegroundColor = ConsoleColor.DarkRed;
                    else if (MayinTarlasi1[i, j] == "4")
                        Console.ForegroundColor = ConsoleColor.DarkRed;
                    else if (MayinTarlasi1[i, j] == "3")
                        Console.ForegroundColor = ConsoleColor.Red;
                    else if (MayinTarlasi1[i, j] == "2")
                        Console.ForegroundColor = ConsoleColor.DarkMagenta;
                    else if (MayinTarlasi1[i, j] == "1")
                        Console.ForegroundColor = ConsoleColor.Magenta;
                    else if (MayinTarlasi1[i, j] == "0")
                        Console.ForegroundColor = ConsoleColor.DarkGreen;



                    Console.Write(MayinTarlasi1[i, j]);

                    Console.BackgroundColor = ConsoleColor.Gray;
                    Console.ForegroundColor = ConsoleColor.Black;

                    if (j != 6)
                        Console.Write(" ");

                }

                Console.WriteLine("|");
            }

            Console.WriteLine("  +-------------+");


        }
        // MAYIN TARLASI ÇİZDİRMEK İÇİN FONKSİYON


    }
}
