using System;
using System.Diagnostics;
using System.IO;
using System.Text;
using System.Threading;

namespace Enhancement_Program
{
    class Program_for_Record
    {
        static int trycnt_tmp = 0;
        static int success_tmp = 0;
        static int failure_tmp = 0;

        static float[] attempt_average = new float[5];
        static float[] success_average = new float[5];
        static float[] failure_average = new float[5];

        static void Main(string[] args)
        {
            while (true)
            {
                Console.Clear();
                Console.WriteLine("+++강화 프로그램+++");
                Console.Write("강화를 몇회씩 시행하시겠습니까? ");

                string s_attempt = Console.ReadLine();
                int attempt = Convert.ToInt32(s_attempt);

                int[] normal_trycnt = new int[attempt];
                int[] magic_trycnt = new int[attempt];
                int[] hero_trycnt = new int[attempt];
                int[] legend_trycnt = new int[attempt];
                int[] myth_trycnt = new int[attempt];

                int[] normal_success = new int[attempt];
                int[] magic_success = new int[attempt];
                int[] hero_success = new int[attempt];
                int[] legend_success = new int[attempt];
                int[] myth_success = new int[attempt];

                int[] normal_failure = new int[attempt];
                int[] magic_failure = new int[attempt];
                int[] hero_failure = new int[attempt];
                int[] legend_failure = new int[attempt];
                int[] myth_failure = new int[attempt];

                int[] attempt_sum = new int[5];
                int[] success_sum = new int[5];
                int[] failure_sum = new int[5];

                Thread.Sleep(500);
                Console.WriteLine("각 등급마다 {0:D}회씩 강화를 시행한 뒤 평균값을 도출합니다.", attempt);
                Thread.Sleep(500);
                Console.WriteLine("시뮬레이션 시작하겠습니다.");
                Thread.Sleep(500);

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
                    Console.WriteLine(normal_trycnt[i]);

                    Magic(i);
                    magic_trycnt[i] = trycnt_tmp;
                    magic_success[i] = success_tmp;
                    magic_failure[i] = failure_tmp;
                    attempt_sum[1] += magic_trycnt[i];
                    success_sum[1] += magic_success[i];
                    failure_sum[1] += magic_failure[i];
                    Console.WriteLine(magic_trycnt[i]);

                    Hero(i);
                    hero_trycnt[i] = trycnt_tmp;
                    hero_success[i] = success_tmp;
                    hero_failure[i] = failure_tmp;
                    attempt_sum[2] += hero_trycnt[i];
                    success_sum[2] += hero_success[i];
                    failure_sum[2] += hero_failure[i];
                    Console.WriteLine(hero_trycnt[i]);

                    Legend(i);
                    legend_trycnt[i] = trycnt_tmp;
                    legend_success[i] = success_tmp;
                    legend_failure[i] = failure_tmp;
                    attempt_sum[3] += legend_trycnt[i];
                    success_sum[3] += legend_success[i];
                    failure_sum[3] += legend_failure[i];
                    Console.WriteLine(legend_trycnt[i]);

                    Myth(i);
                    myth_trycnt[i] = trycnt_tmp;
                    myth_success[i] = success_tmp;
                    myth_failure[i] = failure_tmp;
                    attempt_sum[4] += myth_trycnt[i];
                    success_sum[4] += myth_success[i];
                    failure_sum[4] += myth_failure[i];
                    Console.WriteLine(myth_trycnt[i]);
                }

                for (int i = 0; i < 5; i++)
                {
                    attempt_average[i] += (float)attempt_sum[i] / attempt;
                    success_average[i] += (float)success_sum[i] / attempt;
                    failure_average[i] += (float)failure_sum[i] / attempt;
                }

                Console.WriteLine("일반등급 최대 강화까지의 시행 평균값: {0:F} 회", attempt_average[0]);
                Console.WriteLine("매직등급 최대 강화까지의 시행 평균값: {0:F} 회", attempt_average[1]);
                Console.WriteLine("영웅등급 최대 강화까지의 시행 평균값: {0:F} 회", attempt_average[2]);
                Console.WriteLine("전설등급 최대 강화까지의 시행 평균값: {0:F} 회", attempt_average[3]);
                Console.WriteLine("신화등급 최대 강화까지의 시행 평균값: {0:F} 회", attempt_average[4]);

                Console.WriteLine("일반등급 최대 강화까지의 성공 평균값: {0:F} 회", success_average[0]);
                Console.WriteLine("매직등급 최대 강화까지의 성공 평균값: {0:F} 회", success_average[1]);
                Console.WriteLine("영웅등급 최대 강화까지의 성공 평균값: {0:F} 회", success_average[2]);
                Console.WriteLine("전설등급 최대 강화까지의 성공 평균값: {0:F} 회", success_average[3]);
                Console.WriteLine("신화등급 최대 강화까지의 성공 평균값: {0:F} 회", success_average[4]);

                Console.WriteLine("일반등급 최대 강화까지의 실패 평균값: {0:F} 회", failure_average[0]);
                Console.WriteLine("매직등급 최대 강화까지의 실패 평균값: {0:F} 회", failure_average[1]);
                Console.WriteLine("영웅등급 최대 강화까지의 실패 평균값: {0:F} 회", failure_average[2]);
                Console.WriteLine("전설등급 최대 강화까지의 실패 평균값: {0:F} 회", failure_average[3]);
                Console.WriteLine("신화등급 최대 강화까지의 실패 평균값: {0:F} 회", failure_average[4]);

                stopwatch.Stop();
                Console.WriteLine("소요 시간: {0:D} ms", stopwatch.ElapsedMilliseconds);
                WriteICSV_File("Result.csv");

                Console.ReadLine();
            }
        }

        static void Normal(int i)
        {
            int phase = 0;
            int failbonus = 0;
            int maxPhase = 5;
            int probnum = 1000 - (50 * phase);

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
                        Console.WriteLine("강화 성공");
                        ++phase;
                        failbonus = 0;
                        ++success_tmp;
                        probnum = 1000 - (50 * phase);
                    }
                    else
                    {
                        Console.WriteLine("강화 실패");
                        failbonus += 50;
                        ++failure_tmp;
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
            int probnum = 900 - (50 * phase);

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
                        Console.WriteLine("강화 성공");
                        ++phase;
                        failbonus = 0;
                        ++success_tmp;
                        probnum = 900 - (50 * phase);
                    }
                    else
                    {
                        Console.WriteLine("강화 실패");
                        failbonus += 40;
                        ++failure_tmp;
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
            int probnum = 750 - (50 * phase);

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
                        Console.WriteLine("강화 성공");
                        ++phase;
                        failbonus = 0;
                        ++success_tmp;
                        probnum = 750 - (50 * phase);
                    }
                    else
                    {
                        Console.WriteLine("강화 실패");
                        failbonus += 20;
                        ++failure_tmp;
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
            int probnum = 550 - (25 * phase);

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
                        Console.WriteLine("강화 성공");
                        ++phase;
                        failbonus = 0;
                        ++success_tmp;
                        probnum = 550 - (25 * phase);
                    }
                    else
                    {
                        Console.WriteLine("강화 실패");
                        failbonus += 15;
                        ++failure_tmp;
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
            int probnum = 300 - (15 * phase);
            int myth_success = 0;
            int myth_failure = 0;

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
                        Console.WriteLine("강화 성공");
                        ++phase;
                        failbonus = 0;
                        ++success_tmp;
                        probnum = 300 - (15 * phase);
                    }
                    else
                    {
                        Console.WriteLine("강화 실패");
                        failbonus += 5;
                        ++failure_tmp;
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

            sw.WriteLine("[ Item Enhancement ]");
            sw.WriteLine("( Normal Grade Item Max Enhancement Average )");
            sw.WriteLine("normal,magic,hero,legend,myth");
            sw.WriteLine("{0},{1},{2},{3},{4}",attempt_average[0], attempt_average[1], attempt_average[2], attempt_average[3], attempt_average[4]);

            //StreamReader sr;

            //sr = new StreamReader("",)
            /*
            tStreamWriter.WriteLine( "{0},{1},{2}",
                sEnhanceAverage.vAttemptCount, 
                sEnhanceAverage.vDowngradeCount,
                sEnhanceAverage.vDestroyCount
                );

            tStreamWriter.WriteLine( "( Simulation Result )" );
            tStreamWriter.WriteLine( "Attemp,Downgrade,Destroy,Enhance" );
            for( index01 = 0; index01 < MAX_SIMULATION_NUM; index01 ++ )
            {
                tStreamWriter.WriteLine( "{0},{1},{2},{3}",
                sEnhance[index01].vAttemptCount, 
                sEnhance[index01].vDowngradeCount,
                sEnhance[index01].vDestroyCount,
                sEnhance[index01].vSuccessCount );
            }
            */
            sw.Close();

            return true;

        }
    }
}
