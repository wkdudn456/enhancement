using System;
using System.Diagnostics;
using System.IO;
using System.Text;
using System.Threading;

namespace Enhancement_Program
{
    class Program_Record
    {
        static int trycnt_tmp = 0;
        static int success_tmp = 0;
        static int failure_tmp = 0;

        static int attempt = 0;

        static float[] attempt_average = new float[5];
        static float[] success_average = new float[5];
        static float[] failure_average = new float[5];
        static float[] failbonus_average = new float[5];

        static int[] attempt_sum = new int[5];
        static int[] success_sum = new int[5];
        static int[] failure_sum = new int[5];
        static int[] failbonus_sum = new int[5];

        static int[] normal_trycnt;
        static int[] hero_trycnt;
        static int[] magic_trycnt;
        static int[] legend_trycnt;
        static int[] myth_trycnt;

        static int[] normal_success;
        static int[] magic_success;
        static int[] hero_success;
        static int[] legend_success;
        static int[] myth_success;
        
        static int[] normal_failure;
        static int[] magic_failure;
        static int[] hero_failure;
        static int[] legend_failure;
        static int[] myth_failure;

        static string str;


        static void Main(string[] args)
        {
            while (true)
            {
                Console.Clear();
                Console.WriteLine("+ + + + + 강화 프로그램 + + + + +");
                Console.Write("강화를 몇회씩 시행하시겠습니까? ");

                string s_attempt = Console.ReadLine();
                attempt = Convert.ToInt32(s_attempt);

                normal_trycnt = new int[attempt];
                hero_trycnt = new int[attempt];
                magic_trycnt = new int[attempt];
                legend_trycnt = new int[attempt];
                myth_trycnt = new int[attempt];

                normal_success = new int[attempt];
                magic_success = new int[attempt];
                hero_success = new int[attempt];
                legend_success = new int[attempt];
                myth_success = new int[attempt];

                normal_failure = new int[attempt];
                magic_failure = new int[attempt];
                hero_failure = new int[attempt];
                legend_failure = new int[attempt];
                myth_failure = new int[attempt];

                Thread.Sleep(500);
                Console.WriteLine("각 등급마다 {0:D}회씩 강화를 시행한 뒤 평균값을 도출합니다.", attempt);
                Thread.Sleep(500);
                Console.WriteLine("시뮬레이션 시작...");
                Thread.Sleep(1000);

                Stopwatch stopwatch = new Stopwatch();
                stopwatch.Start();

                for (int i = 0; i < attempt; i++)
                {
                    Normal(i);
                    normal_trycnt[i] = trycnt_tmp;
                    normal_success[i] = success_tmp;
                    normal_failure[i] = failure_tmp;
                    attempt_sum[0] += normal_trycnt[i];
                    success_sum[0] += normal_success[i];
                    failure_sum[0] += normal_failure[i];
                    Console.WriteLine("최대치까지의 시행 수: " + normal_trycnt[i] + "회");

                    Magic(i);
                    magic_trycnt[i] = trycnt_tmp;
                    magic_success[i] = success_tmp;
                    magic_failure[i] = failure_tmp;
                    attempt_sum[1] += magic_trycnt[i];
                    success_sum[1] += magic_success[i];
                    failure_sum[1] += magic_failure[i];
                    Console.WriteLine("최대치까지의 시행 수: " + magic_trycnt[i] + "회");

                    Hero(i);
                    hero_trycnt[i] = trycnt_tmp;
                    hero_success[i] = success_tmp;
                    hero_failure[i] = failure_tmp;
                    attempt_sum[2] += hero_trycnt[i];
                    success_sum[2] += hero_success[i];
                    failure_sum[2] += hero_failure[i];
                    Console.WriteLine("최대치까지의 시행 수: " + hero_trycnt[i] + "회");

                    Legend(i);
                    legend_trycnt[i] = trycnt_tmp;
                    legend_success[i] = success_tmp;
                    legend_failure[i] = failure_tmp;
                    attempt_sum[3] += legend_trycnt[i];
                    success_sum[3] += legend_success[i];
                    failure_sum[3] += legend_failure[i];
                    Console.WriteLine("최대치까지의 시행 수: " + legend_trycnt[i] + "회");

                    Myth(i);
                    myth_trycnt[i] = trycnt_tmp;
                    myth_success[i] = success_tmp;
                    myth_failure[i] = failure_tmp;
                    attempt_sum[4] += myth_trycnt[i];
                    success_sum[4] += myth_success[i];
                    failure_sum[4] += myth_failure[i];
                    Console.WriteLine("최대치까지의 시행 수: " + myth_trycnt[i] + "회\n");
                }

                for (int i = 0; i < 5; i++)
                {
                    attempt_average[i] = (float)attempt_sum[i] / attempt;
                    success_average[i] = (float)success_sum[i] / attempt;
                    failure_average[i] = (float)failure_sum[i] / attempt;
                }

                failbonus_average[0] = (float)failbonus_sum[0] * 50 / attempt_sum[0];
                failbonus_average[1] = (float)failbonus_sum[1] * 40 / attempt_sum[1];
                failbonus_average[2] = (float)failbonus_sum[2] * 20 / attempt_sum[2];
                failbonus_average[3] = (float)failbonus_sum[3] * 15 / attempt_sum[3];
                failbonus_average[4] = (float)failbonus_sum[4] * 5 / attempt_sum[4];

                Console.WriteLine("일반등급 총 시행 횟수: {0:F} 회", attempt_sum[0]);
                Console.WriteLine("매직등급 총 시행 횟수: {0:F} 회", attempt_sum[1]);
                Console.WriteLine("영웅등급 총 시행 횟수: {0:F} 회", attempt_sum[2]);
                Console.WriteLine("전설등급 총 시행 횟수: {0:F} 회", attempt_sum[3]);
                Console.WriteLine("신화등급 총 시행 횟수: {0:F} 회", attempt_sum[4]);

                Console.WriteLine("\n일반등급 최대 강화까지의 시행 평균값: {0:F} 회", attempt_average[0]);
                Console.WriteLine("매직등급 최대 강화까지의 시행 평균값: {0:F} 회", attempt_average[1]);
                Console.WriteLine("영웅등급 최대 강화까지의 시행 평균값: {0:F} 회", attempt_average[2]);
                Console.WriteLine("전설등급 최대 강화까지의 시행 평균값: {0:F} 회", attempt_average[3]);
                Console.WriteLine("신화등급 최대 강화까지의 시행 평균값: {0:F} 회", attempt_average[4]);

                Console.WriteLine("\n일반등급 최대 강화까지의 성공 평균값: {0:F} 회", success_average[0]); // 성공 횟수는 의미가 없다 생각하여 주석 처리
                Console.WriteLine("매직등급 최대 강화까지의 성공 평균값: {0:F} 회", success_average[1]);
                Console.WriteLine("영웅등급 최대 강화까지의 성공 평균값: {0:F} 회", success_average[2]);
                Console.WriteLine("전설등급 최대 강화까지의 성공 평균값: {0:F} 회", success_average[3]);
                Console.WriteLine("신화등급 최대 강화까지의 성공 평균값: {0:F} 회", success_average[4]);

                Console.WriteLine("\n일반등급 최대 강화까지의 실패 평균값: {0:F} 회", failure_average[0]);
                Console.WriteLine("매직등급 최대 강화까지의 실패 평균값: {0:F} 회", failure_average[1]);
                Console.WriteLine("영웅등급 최대 강화까지의 실패 평균값: {0:F} 회", failure_average[2]);
                Console.WriteLine("전설등급 최대 강화까지의 실패 평균값: {0:F} 회", failure_average[3]);
                Console.WriteLine("신화등급 최대 강화까지의 실패 평균값: {0:F} 회", failure_average[4]);

                stopwatch.Stop();
                Console.WriteLine("소요 시간: {0:D} ms", stopwatch.ElapsedMilliseconds);
                WriteICSV_File("Result.csv");

                Console.ReadLine();
                for (int i = 0; i < 5; i++)
                {
                    attempt_average[i] = 0;
                    success_average[i] = 0;
                    failure_average[i] = 0;
                }
            }
        }

        static void Normal(int i)
        {
            int phase = 0;
            int failbonus = 0;
            int maxPhase = 5;
            int decrease = 50;
            int probnum = 1000 - (decrease * phase);

            trycnt_tmp = 0;
            success_tmp = 0;
            failure_tmp = 0;

            while (true)
            {
                Random rand = new Random();
                int randnum = rand.Next(1000);

                if (phase < maxPhase)
                {
                    if (randnum < probnum + failbonus)
                    {
                        //Console.WriteLine("강화 성공");
                        ++phase;
                        failbonus = 0;
                        ++success_tmp;
                        probnum = 1000 - (decrease * phase);
                    }
                    else
                    {
                        //Console.WriteLine("강화 실패");
                        failbonus += 50;
                        ++failure_tmp;
                        ++failbonus_sum[0];
                    }
                }
                else
                {
                    trycnt_tmp = (success_tmp + failure_tmp);
                    Console.WriteLine("일반등급 강화 {0:D}번째 시행 완료", i+1);
                    break;
                }
            }
        }

        static void Magic(int i)
        {
            int phase = 0;
            int failbonus = 0;
            int maxPhase = 7;
            int decrease = 50;
            int probnum = 900 - (decrease * phase);

            trycnt_tmp = 0;
            success_tmp = 0;
            failure_tmp = 0;

            while (true)
            {
                Random rand = new Random();
                int randnum = rand.Next(1000);

                if (phase < maxPhase)
                {
                    if (randnum < probnum + failbonus)
                    {
                        //Console.WriteLine("강화 성공");
                        ++phase;
                        failbonus = 0;
                        ++success_tmp;
                        probnum = 900 - (decrease * phase);
                    }
                    else
                    {
                        //Console.WriteLine("강화 실패");
                        failbonus += 40;
                        ++failure_tmp;
                        ++failbonus_sum[1];
                    }
                }
                else
                {
                    trycnt_tmp = (success_tmp + failure_tmp);
                    Console.WriteLine("매직등급 강화 {0:D}번째 시행 완료", i + 1);
                    break;
                }
            }
        }

        static void Hero(int i)
        {
            int phase = 0;
            int failbonus = 0;
            int maxPhase = 10;
            int decrease = 50;
            int probnum = 750 - (decrease * phase);

            trycnt_tmp = 0;
            success_tmp = 0;
            failure_tmp = 0;

            while (true)
            {
                Random rand = new Random();
                int randnum = rand.Next(1000);

                if (phase < maxPhase)
                {
                    if (randnum < probnum + failbonus)
                    {
                        //Console.WriteLine("강화 성공");
                        ++phase;
                        failbonus = 0;
                        ++success_tmp;
                        probnum = 750 - (decrease * phase);
                    }
                    else
                    {
                        //Console.WriteLine("강화 실패");
                        failbonus += 20;
                        ++failure_tmp;
                        ++failbonus_sum[2];
                    }
                }
                else
                {
                    trycnt_tmp = (success_tmp + failure_tmp);
                    Console.WriteLine("영웅등급 강화 {0:D}번째 시행 완료", i + 1);
                    break;
                }
            }
        }

        static void Legend(int i)
        {
            int phase = 0;
            int failbonus = 0;
            int maxPhase = 15;
            int decrease = 25;
            int probnum = 550 - (decrease * phase);

            trycnt_tmp = 0;
            success_tmp = 0;
            failure_tmp = 0;

            while (true)
            {
                Random rand = new Random();
                int randnum = rand.Next(1000);

                if (phase < maxPhase)
                {
                    if (randnum < probnum + failbonus)
                    {
                        //Console.WriteLine("강화 성공");
                        ++phase;
                        failbonus = 0;
                        ++success_tmp;
                        probnum = 550 - (decrease * phase);
                    }
                    else
                    {
                        //Console.WriteLine("강화 실패");
                        failbonus += 15;
                        ++failure_tmp;
                        ++failbonus_sum[3];
                    }
                }
                else
                {
                    trycnt_tmp = (success_tmp + failure_tmp);
                    Console.WriteLine("전설등급 강화 {0:D}번째 시행 완료", i + 1);
                    break;
                }
            }
        }

        static void Myth(int i)
        {
            int phase = 0;
            int failbonus = 0;
            int maxPhase = 20;
            int decrease = 15;
            int probnum = 300 - (decrease * phase);

            trycnt_tmp = 0;
            success_tmp = 0;
            failure_tmp = 0;

            while (true)
            {
                Random rand = new Random();
                int randnum = rand.Next(1000);

                if (phase < maxPhase)
                {
                    if (randnum < probnum + failbonus)
                    {
                        //Console.WriteLine("강화 성공");
                        ++phase;
                        failbonus = 0;
                        ++success_tmp;
                        probnum = 300 - (decrease * phase);
                    }
                    else
                    {
                        //Console.WriteLine("강화 실패");
                        failbonus += 5;
                        ++failure_tmp;
                        ++failbonus_sum[4];
                    }
                }
                else
                {
                    Console.WriteLine("신화등급 강화 {0:D}번째 시행 완료", i + 1);
                    trycnt_tmp += (success_tmp + failure_tmp);
                    break;
                }
            }
        }

        static bool WriteICSV_File(string fileName)
        {
            StreamWriter sw;

            try
            {
                sw = new StreamWriter(fileName, false, Encoding.UTF8);
            }
            catch (IOException)
            {
                return false;
            }

            sw.WriteLine(",,,,,[ Item Enhancement Result ]");
            sw.WriteLine("\n,,,,,( Average of Max Enhancement )");
            sw.WriteLine(",,,,Normal,Magic,Hero,Legend,Myth");
            sw.WriteLine(",,,,{0},{1},{2},{3},{4}", 
                attempt_average[0], 
                attempt_average[1], 
                attempt_average[2], 
                attempt_average[3], 
                attempt_average[4]
                );

            sw.WriteLine("\n,,,,,Number of Each Trial: {0}", attempt);
            sw.WriteLine("\n,,,,,( Sum of Trials )");
            sw.WriteLine(",,,,Normal,Magic,Hero,Legend,Myth");
            sw.WriteLine(",,,,{0},{1},{2},{3},{4}",
                attempt_sum[0],
                attempt_sum[1],
                attempt_sum[2],
                attempt_sum[3],
                attempt_sum[4]
                );

            sw.WriteLine("\n,,,,,( Average of failbonus )");
            sw.WriteLine(",,,,Normal,Magic,Hero,Legend,Myth");
            sw.WriteLine(",,,,{0}%,{1}%,{2}%,{3}%,{4}%",
                failbonus_average[0]/10,
                failbonus_average[1]/10,
                failbonus_average[2]/10,
                failbonus_average[3]/10,
                failbonus_average[4]/10
                );

            sw.WriteLine("\n,,,Trials Log,,,,,,,Failure Log");
            sw.WriteLine(",Normal,Magic,Hero,Legend,Myth," +
                ",,Normal,Magic,Hero,Legend,Myth");
            //TrialsCount(sw);
            for (int i = 0; i < attempt; i++)
            {
                if ((i + 1) % 10 == 1)
                {
                    if ((i + 1) == 11) { 
                        sw.Write("{0}th,", i + 1);
                        str = (i + 1) + "th";
                    }
                    else {
                        sw.Write("{0}st,", i + 1);
                        str = (i + 1) + "st";
                    }
                }
                else if ((i + 1) % 10 == 2)
                {
                    if ((i + 1) == 12) { 
                        sw.Write("{0}th,", i + 1);
                        str = (i + 1) + "th";
                    }
                    else { 
                        sw.Write("{0}nd,", i + 1);
                        str = (i + 1) + "nd";
                    }
                }
                else if ((i + 1) % 10 == 3)
                {
                    if ((i + 1) == 13) { 
                        sw.Write("{0}th,", i + 1);
                        str = (i + 1) + "th";
                    }
                    else { 
                        sw.Write("{0}rd,", i + 1);
                        str = (i + 1) + "rd";
                    }
                }
                else { 
                    sw.Write("{0}th,", i + 1);
                    str = (i + 1) + "th";
                }

                sw.WriteLine("{0},{1},{2},{3},{4},," +
                    "{5},{6},{7},{8},{9},{10}",
                    normal_trycnt[i],
                    magic_trycnt[i],
                    hero_trycnt[i],
                    legend_trycnt[i],
                    myth_trycnt[i],
                    str,
                    normal_failure[i],
                    magic_failure[i],
                    hero_failure[i],
                    legend_failure[i],
                    myth_failure[i]
                    );
            }

            /*sw.WriteLine("\nNormal Trials List");
            TrialsCount(sw);
            for (int i = 0; i < attempt; i++)
            {
                sw.Write("{0},", normal_trycnt[i]);
            }
            
            sw.WriteLine("\nMagic Trials List");
            TrialsCount(sw);
            for (int i = 0; i < attempt; i++)
            {
                sw.Write("{0},", magic_trycnt[i]);
            }

            sw.WriteLine("\nHero Trials List");
            TrialsCount(sw);
            for (int i = 0; i < attempt; i++)
            {
                sw.Write("{0},", hero_trycnt[i]);
            }

            sw.WriteLine("\nLegend Trials List");
            TrialsCount(sw);
            for (int i = 0; i < attempt; i++)
            {
                sw.Write("{0},", legend_trycnt[i]);
            }

            sw.WriteLine("\nMyth Trials List");
            TrialsCount(sw);
            for (int i = 0; i < attempt; i++)
            {
                sw.Write("{0},", myth_trycnt[i]);
            }*/
            sw.Close();

            return true;
        }

        static void TrialsCount(StreamWriter sw_count)
        {            
            for (int i = 0; i < attempt; i++)
            {
                if ((i + 1) % 10 == 1)
                {
                    if ((i + 1) == 11) { sw_count.Write("{0}th,", i + 1); }
                    else { sw_count.Write("{0}st,", i + 1); }
                }
                else if ((i + 1) % 10 == 2)
                {
                    if ((i + 1) == 12) { sw_count.Write("{0}th,", i + 1); }
                    else { sw_count.Write("{0}nd,", i + 1); }
                }
                else if ((i + 1) % 10 == 3)
                {
                    if ((i + 1) == 13) { sw_count.Write("{0}th,", i + 1); }
                    else { sw_count.Write("{0}rd,", i + 1); }
                }
                else { sw_count.Write("{0}th,", i + 1); }
            }
            sw_count.WriteLine();
        }
    }
}