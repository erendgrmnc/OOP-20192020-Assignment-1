using System;

namespace NDPOdev1
{
    //  (!!!!!!!!!!!!) PROGRAMIN ÇALIŞABİLMESİ İÇİN DOSYA ADININ "ogrenci.txt" olması gerekir. (!!!!!!!!!!!!)

    class Program
    {
        public static int aa, ba, bb, cb, cc, dc, dd, fd, ff,gr,dz,yt,yz,mu,e,classSize;  
        static void Main(string[] args)
        {

            //Ogrenciler.txt dosyasındaki her bir satırı sırayla lines dizisindeki elemanlara atar.
            string[] lines = System.IO.File.ReadAllLines("ogrenci.txt");

            //Lines dizisindeki her elemanı notlarının hesaplanması için Calculate sınıfından bir nesne oluşturur ve ona parametre olarak gönderir.Ardından hesaplanan her bir not için sınıf mevcudunu bir arttırır.
            foreach (string s in lines)
            {
                Calculate cal = new Calculate(s);
                classSize++;
                cal.PrintStudent();
                
            }
            WriteDataToText();
        }


        //Yüzde hesabının yapılması için gereken fonksiyon.
       static int PercentageCalculation(int grade)
        {

            int percantage;
            percantage = (grade * 100) / classSize;
            return percantage;


        }

        //Sonuçları ve yüzdelik sonuçlarını sayılar.txt dosyasına yazdırır.
        static void WriteDataToText()
        {
            string writeData = "AA : " + aa.ToString() + '\r' + "AA % : " + PercentageCalculation(aa) + '\r' + "BA : " + ba.ToString() + '\r' + "BA % : " + PercentageCalculation(ba) + '\r' + "BB : " + bb.ToString()+ '\r'+ "BB % : " + PercentageCalculation(bb) + '\r' + "CB : " + cb.ToString()+ '\r' +"CB % : " + PercentageCalculation(cb)  + '\r' +  "CC : " + cc.ToString()+ '\r'+ "CC % :" + PercentageCalculation(cc) + '\r' + "DC :" + dc.ToString() + '\r' + "DC % : " + PercentageCalculation(dc) + '\r' + "DD : " + dd.ToString() + '\r' + "DD % : " + PercentageCalculation(dd)+ '\r' + "FD : " + fd.ToString() + '\r'+"FD % : " + PercentageCalculation(fd) + '\r' + "FF : " + ff.ToString()+ '\r' + "FF % : " + PercentageCalculation(ff) + '\r' + "YT : " + yt.ToString() + '\r' + "YT % : " + PercentageCalculation(yt) + '\r' + "YZ : " + yz.ToString() + '\r' + "YZ % : " + PercentageCalculation(yz) + '\r' + "MU : " + mu.ToString() + '\r' + "MU % : " + PercentageCalculation(mu) + '\r' + "E : " + e.ToString() + '\r' + "E % : " + PercentageCalculation(e) + '\r' + "DZ : " + dz.ToString() + '\r' + "DZ % : " + PercentageCalculation(dz) + '\r' + "GR : " + gr.ToString() + '\r' + "GR % : " + PercentageCalculation(gr) + '\r';
            System.IO.File.WriteAllText("sayilar.txt", writeData);

        }
    }

        class Calculate
        {

            string name, surname, id, preGrade;
            float project1, project2, midterm, final, project1Parameter, project2Parameter, midtermParameter, finalParameter;
            string grade;
            float result;

        
         //Caluclate sınıfının Yapıcı Metodu. Bu metedoda gelen parametre string verisi bir öğenciye ait olan bilgiler olmalı. Sınıfın içerdiği diğer metodlar ile veriyi işleyerek gerekli değişkenlere atama yapar. Ardından not hesaplamalarını yapar.
        public Calculate(string splited)
            {

                AssignData(splited);
                if (preGrade == null)
                {
                    RateGrade(CalculateGrade());
                }
                else if (preGrade != null && result == 0)
                {
                    RateGrade(result);
                }
                else
                {
                    RatePregrade(preGrade);
                }



            }

            //Text dosyasından gelen bir satır bir öğrenciye aittir.Gerekli değişkenlere isim soyisim vb. atamaları yapar.
            void AssignData(string splited)
            {
                string[] words = splited.Split(" ");

                name = words[0];
                surname = words[1];
                id = words[2];
                if (words[3] == "YT" || words[3] == "YZ" || words[3] == "MU" || words[3] == "E")
                {
                    preGrade = words[3];
                }
            
            //Eğer öğrencinin hesaplanmış notu var ise (DZ veya GR) sonuç tabloya göre sıfıra eşitlenir.               
                
            else if (words[3] == "DZ" || words[3] == "GR")
                {

                    preGrade = words[3];
                    result = 0f;
                }

                else
                {
                    project1 = Convert.ToSingle(words[3]);
                    project2 = Convert.ToSingle(words[4]);
                    midterm = Convert.ToSingle(words[5]);
                    final = Convert.ToSingle(words[6]);
                    project1Parameter = Convert.ToSingle(words[7]);
                    project2Parameter = Convert.ToSingle(words[8]);
                    midtermParameter = Convert.ToSingle(words[9]);
                    finalParameter = Convert.ToSingle(words[10]);
                }


            }
             //Öğrencinin notlarını ve notların yüzdeleri ile geçme notunu hesaplayan metod.
            float CalculateGrade()
            {


                float project1Result = (project1 * (project1Parameter / 100));
                float project2Result = (project2 * (project2Parameter / 100));
                float midtermResult = (midterm * (midtermParameter / 100));
                float finalResult = (final * (finalParameter / 100));
                result = project1Result + project2Result + midtermResult + finalResult;

                Console.WriteLine("Result is : " + result);
                return result;
            }
            
            //Eğre öğrencinin Muaf, yeterli ,yetersiz gibi önceden belirlenmiş bir durumu var ise ona göre harf notu değerlendirmesini yapan metod.
            void RatePregrade(string res)
            {
                if (res == "MU")
                {
                    Program.mu++;

                }
                else if (res == "YT")
                {
                    Program.yt++;
                }

                else if (res == "YZ")
                {
                    Program.yz++;
                }

                else if (res == "E")
                {
                    Program.e++;
                }
                Console.WriteLine("Result is : " + preGrade);
            }
            //Geçme notuna göre harf notu derecelendirmesi yapan metod.
            void RateGrade(float res)
            {
               //Eğer öğrencinin hesaplanmış notu var ise (DZ veya GR) sayısı arttırılır.               
                if (preGrade != null)
                {
                    if (preGrade == "DZ")
                    {
                        Program.dz++;
                        Console.WriteLine("Result is : " + result);
                    }
                    else if (preGrade == "GR")
                    {
                        Program.gr++;
                        Console.WriteLine("Result is : " + result);
                    }

                }

                //Not sonucuna göre harf notu belirlenir ve harf notu sayacı arttırılır.
                else if (res >= 90f && res <= 100f)
                {
                    grade = "AA";
                    Program.aa++;
                }
                else if (res >= 85f && res <= 89.99f)
                {
                    grade = "BA";
                    Program.ba++;
                }
                else if (res >= 80f && res <= 84.99f)
                {
                    grade = "BB";
                    Program.bb++;
                }
                else if (res >= 75f && res <= 79.99f)
                {
                    grade = "CB";
                    Program.cb++;
                }
                else if (res >= 65f && res <= 74.99f)
                {
                    grade = "CC";
                    Program.cc++;
                }
                else if (res >= 58f && res <= 64.99f)
                {
                    grade = "DC";
                    Program.dc++;
                }
                else if (res >= 50f && res <= 57.99f)
                {
                    grade = "DD";
                    Program.dd++;
                }
                else if (res >= 40 && res <= 49.99f)
                {
                    grade = "FD";
                    Program.fd++;
                }
                else if (res <= 39.99f)
                {
                    grade = "FF";
                    Program.ff++;
                }



            }


            //Öğrencinin bilgilerini konsola yazdıran metod.
            public void PrintStudent()
            {
                if (preGrade == null)
                {
                    Console.WriteLine("Öğrencinin İsmi : " + name);
                    Console.WriteLine("Öğrencinin Soyismi : " + surname);
                    Console.WriteLine("Öğrencinin Numarası : " + id);
                    Console.WriteLine("Öğrencinin Notu : " + grade);
                    Console.WriteLine("");

                }
                else
                {
                    Console.WriteLine("Öğrencinin İsmi : " + name);
                    Console.WriteLine("Öğrencinin Soyismi : " + surname);
                    Console.WriteLine("Öğrencinin Numarası : " + id);
                    Console.WriteLine("Öğrencinin Notu : " + preGrade);
                    Console.WriteLine("");

                }

            }


        }
  
}
