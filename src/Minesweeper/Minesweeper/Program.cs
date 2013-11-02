using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Minesweeper
{
    class Program
    {
        //oyun henüz bitmedi. ama az kaldı. save/Load olayı ve hint bölümü hariç bitti sayılır
        //oyun henüz bitmedi. ama az kaldı. save/Load olayı ve hint bölümü hariç bitti sayılır
        //oyun henüz bitmedi. ama az kaldı. save/Load olayı ve hint bölümü hariç bitti sayılır
        //oyun henüz bitmedi. ama az kaldı. save/Load olayı ve hint bölümü hariç bitti sayılır


        static void Main(string[] args)
        {

            /* MAYIN TARLASI DİZİSİ */  string[,] MayinTarlasi = new String[7, 7];

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
            Random rnd = new Random();
            int RastgeleSutunDuvar;
            int RastgeleSatirDuvar;

            for (int abc = 0; abc < 10; abc++)
            {
                RastgeleSutunDuvar = rnd.Next(0, 7);
                RastgeleSatirDuvar = rnd.Next(0, 7);



                if (MayinTarlasi[RastgeleSatirDuvar, RastgeleSutunDuvar] != ".")
                {
                    abc = abc - 1;
                    continue;
                }
                else
                    MayinTarlasi[RastgeleSatirDuvar, RastgeleSutunDuvar] = "#";
                
            }
     // Duvar koymak için rastgele döngüsü




     // mayinlari tutmak için tablo
            String[,] RastgeleMayin = new String[7,7];

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


            int pts = 0;

            MayinTarlasiniCiz(MayinTarlasi);

            Console.WriteLine();
            Console.WriteLine(); 
            Console.WriteLine("Command List :");
            Console.WriteLine("ENTER : Open");
            Console.WriteLine("F : Flag");
            Console.WriteLine("U : Unflag");
            Console.WriteLine("H : Hint");
            Console.WriteLine("S : Save");
            Console.WriteLine("E : Exit");


            Console.SetCursorPosition(20, 4);
            Console.Write("point = {0}", pts);


            int DogruFlagSayisi = 0;


            int CursorSatir = 2;
            int CursorSutun = 3;
            Console.SetCursorPosition(CursorSutun, CursorSatir);

     // OYUN DÖNGÜSÜ
            for (; ; )
            {
                ConsoleKeyInfo info = Console.ReadKey();

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
                                  DogruFlagSayisi--;
                             }

                       }


                    Console.SetCursorPosition(20, 4);
                    Console.WriteLine(DogruFlagSayisi);


                    Console.SetCursorPosition(0, 0);

                    MayinTarlasiniCiz(MayinTarlasi);
                    Console.SetCursorPosition(20, 4);
                    Console.Write("point = {0}", pts);
                
                
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
                            DogruFlagSayisi++;
                        }




                        MayinTarlasi[GercekDegerSatir, GercekDegerSutun111] = ".";
                    }

                    Console.SetCursorPosition(25, 7);
                    Console.WriteLine(DogruFlagSayisi);




                    Console.SetCursorPosition(0, 0);

                    MayinTarlasiniCiz(MayinTarlasi);
                    Console.SetCursorPosition(20, 4);
                    Console.Write("point = {0}", pts);
                
                
                }


 // FLAG KAlDIRMA




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
                        Console.WriteLine("Game Over  " + DogruFlagSayisi);
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
                        Console.SetCursorPosition(0, 0);
                        MayinTarlasiniCiz(MayinTarlasi);
                        Console.SetCursorPosition(20, 4);
                        Console.Write("point = {0}", pts);

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




                    Console.SetCursorPosition(0, 0);

                    MayinTarlasiniCiz(MayinTarlasi);
                    Console.SetCursorPosition(20, 4);
                    Console.Write("point = {0}", pts);

                    Console.SetCursorPosition(CursorSutun, CursorSatir);



                }
      // CURSOR

                Console.SetCursorPosition(CursorSutun, CursorSatir);

                if (DogruFlagSayisi == 8)
                {
                    
                    Console.SetCursorPosition(20, 1);                    Console.WriteLine("You Win");
                    break;
                }


               


            }
      // OYUN DÖNGÜSÜ

            Console.SetCursorPosition(0, 0);

            MayinTarlasiniCiz(MayinTarlasi);
            Console.SetCursorPosition(20, 4);

            pts = pts + DogruFlagSayisi * 50;

            Console.Write("point = {0}", pts);


            Console.ReadLine();

        }


        // MAYIN TARLASI ÇİZDİRMEK İÇİN FONKSİYON
        static void MayinTarlasiniCiz(String[,] MayinTarlasi1)
        {
            Console.WriteLine("   1 2 3 4 5 6 7");
            Console.WriteLine("  +-------------+");

            for (int i = 0; i < 7; i++)
            {
                Console.Write((i + 1) + " |");

                for (int j = 0; j < 7; j++)
                {
                    if (j == 6)
                        Console.Write(MayinTarlasi1[i, j]);
                    else
                        Console.Write(MayinTarlasi1[i, j] + " ");
                }

                Console.WriteLine("|");
            }

            Console.WriteLine("  +-------------+");


        }
        // MAYIN TARLASI ÇİZDİRMEK İÇİN FONKSİYON
    }
}
