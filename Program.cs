using System;
using System.Threading;
using System.IO;
using System.Text;

namespace Enhancement_Program
{
    class Program
    {
        static int normal_trycnt = 0;
        static int magic_trycnt = 0;
        static int hero_trycnt = 0;
        static int legend_trycnt = 0;
        static int myth_trycnt = 0;

        static void Main(string[] args)
        {


            while (true)
            {
                Console.Clear();
                Console.WriteLine("+++강화 프로그램+++");
                Console.WriteLine("원하시는 메뉴를 선택하세요");
                Console.WriteLine("0: 일반등급 장비  1: 매직등급 장비  2: 영웅등급 장비  3: 전설등급 장비  4: 신화등급 장비  5: 기록  6: 종료");

                int grade = 0;
                string sgrade = Console.ReadLine();
                grade = Convert.ToInt32(sgrade);

                switch (grade)
                {
                    case 0:
                        normal();
                        continue;
                    case 1:
                        magic();
                        break;
                    case 2:
                        hero();
                        break;
                    case 3:
                        legend();
                        break;
                    case 4:
                        myth();
                        break;
                    case 5:
                        Record();
                        continue;
                    case 6:
                        Environment.Exit(0);
                        break;
                    default:
                        Console.WriteLine("잘못 입력하셨습니다.");
                        break;
                }
            }
        }

        static void normal()
        {
            int phase = 0;
            int failbonus = 0;
            int maxPhase = 5;
            int normal_trycnt_tmp = 0;
            string str;

            int probnum = 1000 - (50 * phase);
            float probability = ((float)(probnum + failbonus) / 1000);

            Console.WriteLine("현재 일반등급 장비는 {0:D}단계이며 강화 확률은 {1:P}입니다.", phase, probability);
            Console.WriteLine("일반등급 장비의 강화를 시작합니다.");
            Console.WriteLine("아무 키나 입력해주세요.");
            str = Console.ReadLine();
            


            while (true)
            {
                Random rand = new Random();
                int randnum = rand.Next(1000);

                if (phase < maxPhase)
                {
                    //Console.WriteLine("probnum: {0:D}", probnum);
                    //Console.WriteLine("failbonus: {0:D}", failbonus);
                    //Console.WriteLine("probability: {0:F}", probability);
                    Console.WriteLine("일반등급 장비 {0:D}단계 강화를 시작합니다.", phase + 1);
                    if (randnum < probnum + failbonus)
                    {
                        Thread.Sleep(500);
                        Console.WriteLine("...탕...");
                        Thread.Sleep(500);
                        Console.WriteLine("...탕...");
                        Thread.Sleep(500);
                        Console.WriteLine("...탕...");
                        Thread.Sleep(500);

                        Console.WriteLine("강화에 성공했습니다.");
                        ++phase;
                        failbonus = 0;
                        ++normal_trycnt_tmp;


                    }
                    else
                    {
                        Thread.Sleep(500);
                        Console.WriteLine("...깡...");
                        Thread.Sleep(500); 
                        Console.WriteLine("...깡...");
                        Thread.Sleep(500);
                        Console.WriteLine("...깡...");
                        Thread.Sleep(500);

                        Console.WriteLine("\n강화에 실패했습니다.");
                        Console.WriteLine("강화 실패 보정치가 추가됩니다.");
                        failbonus += 50;
                        ++normal_trycnt_tmp;
                    }
                }
                else
                {
                    normal_trycnt = normal_trycnt_tmp;
                    Console.WriteLine("일반등급 장비의 강화를 완료했습니다.");
                    Console.WriteLine("다른 강화를 하시겠습니까? (y/n) ");
                    str = Console.ReadLine();
                    if (str == "y")
                        break;
                    else if (str == "n")
                        Environment.Exit(0);
                    else
                        Console.WriteLine("잘못 입력하셨습니다.");
                }

                if (phase < maxPhase)
                {
                    while (str != "y" || str != "n")
                    {
                        probnum = 1000 - (50 * phase);
                        probability = ((float)(probnum + failbonus) / 1000);

                        Console.WriteLine("현재 일반등급 장비는 {0:D}단계이며 다음 강화 확률은 {1:P}입니다.", phase, probability);

                        Console.WriteLine("\n강화를 계속 하시겠습니까? (y/n) ");
                        str = Console.ReadLine();
                        if (str == "y")
                            break;
                        else if (str == "n")
                            Environment.Exit(0);
                        else
                            Console.WriteLine("잘못 입력하셨습니다.\n");
                    }
                }
            }
        }

        static void magic()
        {
            int phase = 0;
            int failbonus = 0;
            int maxPhase = 7;
            int magic_trycnt_tmp = 0;

            string str;

            int probnum = 900 - (50 * phase);
            float probability = ((float)(probnum + failbonus) / 1000);

            Console.WriteLine("현재 매직등급 장비는 {0:D}단계이며 강화 확률은 {1:P}입니다.", phase, probability);
            Console.WriteLine("매직등급 장비의 강화를 시작합니다.");
            Console.WriteLine("아무 키나 입력해주세요.");
            str = Console.ReadLine();



            while (true)
            {
                Random rand = new Random();
                int randnum = rand.Next(1000);

                if (phase < maxPhase)
                {
                    //Console.WriteLine("probnum: {0:D}", probnum);
                    //Console.WriteLine("failbonus: {0:D}", failbonus);
                    //Console.WriteLine("probability: {0:F}", probability);
                    Console.WriteLine("매직등급 장비 {0:D}단계 강화를 시작합니다.", phase + 1);
                    if (randnum < probnum + failbonus)
                    {
                        Thread.Sleep(500);
                        Console.WriteLine("...탕...");
                        Thread.Sleep(500);
                        Console.WriteLine("...탕...");
                        Thread.Sleep(500);
                        Console.WriteLine("...탕...");
                        Thread.Sleep(500);

                        Console.WriteLine("강화에 성공했습니다.");
                        ++phase;
                        failbonus = 0;
                        ++magic_trycnt_tmp;
                    }
                    else
                    {
                        Thread.Sleep(500);
                        Console.WriteLine("...깡...");
                        Thread.Sleep(500);
                        Console.WriteLine("...깡...");
                        Thread.Sleep(500);
                        Console.WriteLine("...깡...");
                        Thread.Sleep(500);

                        Console.WriteLine("\n강화에 실패했습니다.");
                        Console.WriteLine("강화 실패 보정치가 추가됩니다.");
                        failbonus += 40;
                        ++magic_trycnt_tmp;
                    }
                }
                else
                {

                    magic_trycnt = magic_trycnt_tmp;
                    Console.WriteLine("매직등급 장비의 강화를 완료했습니다.");
                    Console.WriteLine("다른 강화를 하시겠습니까? (y/n) ");
                    str = Console.ReadLine();
                    if (str == "y")
                        break;
                    else if (str == "n")
                        Environment.Exit(0);
                    else
                        Console.WriteLine("잘못 입력하셨습니다.");
                }

                if (phase < maxPhase)
                {
                    while (str != "y" || str != "n")
                    {
                        probnum = 900 - (50 * phase);
                        probability = ((float)(probnum + failbonus) / 1000);

                        Console.WriteLine("현재 매직등급 장비는 {0:D}단계이며 다음 강화 확률은 {1:P}입니다.", phase, probability);

                        Console.WriteLine("\n강화를 계속 하시겠습니까? (y/n) ");
                        str = Console.ReadLine();
                        if (str == "y")
                            break;
                        else if (str == "n")
                            Environment.Exit(0);
                        else
                            Console.WriteLine("잘못 입력하셨습니다.\n");
                    }
                }
            }
        }

        static void hero()
        {
            int phase = 0;
            int failbonus = 0;
            int maxPhase = 10;
            int hero_trycnt_tmp = 0;

            string str;

            int probnum = 750 - (50 * phase);
            float probability = ((float)(probnum + failbonus) / 1000);

            Console.WriteLine("현재 영웅등급 장비는 {0:D}단계이며 강화 확률은 {1:P}입니다.", phase, probability);
            Console.WriteLine("영웅등급 장비의 강화를 시작합니다.");
            Console.WriteLine("아무 키나 입력해주세요.");
            str = Console.ReadLine();



            while (true)
            {
                Random rand = new Random();
                int randnum = rand.Next(1000);

                if (phase < maxPhase)
                {
                    //Console.WriteLine("probnum: {0:D}", probnum);
                    //Console.WriteLine("failbonus: {0:D}", failbonus);
                    //Console.WriteLine("probability: {0:F}", probability);
                    Console.WriteLine("영웅등급 장비 {0:D}단계 강화를 시작합니다.", phase + 1);
                    if (randnum < probnum + failbonus)
                    {
                        Thread.Sleep(500);
                        Console.WriteLine("...탕...");
                        Thread.Sleep(500);
                        Console.WriteLine("...탕...");
                        Thread.Sleep(500);
                        Console.WriteLine("...탕...");
                        Thread.Sleep(500);

                        Console.WriteLine("강화에 성공했습니다.");
                        ++phase;
                        failbonus = 0;
                        ++hero_trycnt_tmp;
                    }
                    else
                    {
                        Thread.Sleep(500);
                        Console.WriteLine("...깡...");
                        Thread.Sleep(500);
                        Console.WriteLine("...깡...");
                        Thread.Sleep(500);
                        Console.WriteLine("...깡...");
                        Thread.Sleep(500);

                        Console.WriteLine("\n강화에 실패했습니다.");
                        Console.WriteLine("강화 실패 보정치가 추가됩니다.");
                        failbonus += 20;
                        ++hero_trycnt_tmp;
                    }
                }
                else
                {
                    hero_trycnt = hero_trycnt_tmp;
                    Console.WriteLine("영웅등급 장비의 강화를 완료했습니다.");
                    Console.WriteLine("다른 강화를 하시겠습니까? (y/n) ");
                    str = Console.ReadLine();
                    if (str == "y")
                        break;
                    else if (str == "n")
                        Environment.Exit(0);
                    else
                        Console.WriteLine("잘못 입력하셨습니다.");
                }

                if (phase < maxPhase)
                {
                    while (str != "y" || str != "n")
                    {
                        probnum = 750 - (50 * phase);
                        probability = ((float)(probnum + failbonus) / 1000);

                        Console.WriteLine("현재 영웅등급 장비는 {0:D}단계이며 다음 강화 확률은 {1:P}입니다.", phase, probability);

                        Console.WriteLine("\n강화를 계속 하시겠습니까? (y/n) ");
                        str = Console.ReadLine();
                        if (str == "y")
                            break;
                        else if (str == "n")
                            Environment.Exit(0);
                        else
                            Console.WriteLine("잘못 입력하셨습니다.\n");
                    }
                }
            }
        }

        static void legend()
        {
            int phase = 0;
            int failbonus = 0;
            int maxPhase = 15;
            int legend_trycnt_tmp = 0;

            string str;

            int probnum = 550 - (25 * phase);
            float probability = ((float)(probnum + failbonus) / 1000);

            Console.WriteLine("현재 전설등급 장비는 {0:D}단계이며 강화 확률은 {1:P}입니다.", phase, probability);
            Console.WriteLine("전설등급 장비의 강화를 시작합니다.");
            Console.WriteLine("아무 키나 입력해주세요.");
            str = Console.ReadLine();



            while (true)
            {
                Random rand = new Random();
                int randnum = rand.Next(1000);

                if (phase < maxPhase)
                {
                    //Console.WriteLine("probnum: {0:D}", probnum);
                    //Console.WriteLine("failbonus: {0:D}", failbonus);
                    //Console.WriteLine("probability: {0:F}", probability);
                    Console.WriteLine("전설등급 장비 {0:D}단계 강화를 시작합니다.", phase + 1);
                    if (randnum < probnum + failbonus)
                    {
                        Thread.Sleep(500);
                        Console.WriteLine("...탕...");
                        Thread.Sleep(500);
                        Console.WriteLine("...탕...");
                        Thread.Sleep(500);
                        Console.WriteLine("...탕...");
                        Thread.Sleep(500);

                        Console.WriteLine("강화에 성공했습니다.");
                        ++phase;
                        failbonus = 0;
                        ++legend_trycnt_tmp;
                    }
                    else
                    {
                        Thread.Sleep(500);
                        Console.WriteLine("...깡...");
                        Thread.Sleep(500);
                        Console.WriteLine("...깡...");
                        Thread.Sleep(500);
                        Console.WriteLine("...깡...");
                        Thread.Sleep(500);

                        Console.WriteLine("\n강화에 실패했습니다.");
                        Console.WriteLine("강화 실패 보정치가 추가됩니다.");
                        failbonus += 15;
                        ++legend_trycnt_tmp;
                    }
                }
                else
                {
                    legend_trycnt = legend_trycnt_tmp;
                    Console.WriteLine("전설등급 장비의 강화를 완료했습니다.");
                    Console.WriteLine("다른 강화를 하시겠습니까? (y/n) ");
                    str = Console.ReadLine();
                    if (str == "y")
                        break;
                    else if (str == "n")
                        Environment.Exit(0);
                    else
                        Console.WriteLine("잘못 입력하셨습니다.");
                }

                if (phase < maxPhase)
                {
                    while (str != "y" || str != "n")
                    {
                        probnum = 550 - (25 * phase);
                        probability = ((float)(probnum + failbonus) / 1000);

                        Console.WriteLine("현재 전설등급 장비는 {0:D}단계이며 다음 강화 확률은 {1:P}입니다.", phase, probability);

                        Console.WriteLine("\n강화를 계속 하시겠습니까? (y/n) ");
                        str = Console.ReadLine();
                        if (str == "y")
                            break;
                        else if (str == "n")
                            Environment.Exit(0);
                        else
                            Console.WriteLine("잘못 입력하셨습니다.\n");
                    }
                }
            }
        }

        static void myth()
        {
            int phase = 0;
            int failbonus = 0;
            int maxPhase = 20;
            int myth_trycnt_tmp = 0;

            string str;

            int probnum = 300 - (15 * phase);
            float probability = ((float)(probnum + failbonus) / 1000);

            Console.WriteLine("현재 신화등급 장비는 {0:D}단계이며 강화 확률은 {1:P}입니다.", phase, probability);
            Console.WriteLine("신화등급 장비의 강화를 시작합니다.");
            Console.WriteLine("아무 키나 입력해주세요.");
            str = Console.ReadLine();



            while (true)
            {
                Random rand = new Random();
                int randnum = rand.Next(1000);

                if (phase < maxPhase)
                {
                    Console.WriteLine("probnum: {0:D}", probnum);
                    Console.WriteLine("failbonus: {0:D}", failbonus);
                    Console.WriteLine("probability: {0:F}", probability);
                    Console.WriteLine("신화등급 장비 {0:D}단계 강화를 시작합니다.", phase + 1);
                    if (randnum < probnum + failbonus)
                    {
                        Thread.Sleep(500);
                        Console.WriteLine("...탕...");
                        Thread.Sleep(500);
                        Console.WriteLine("...탕...");
                        Thread.Sleep(500);
                        Console.WriteLine("...탕...");
                        Thread.Sleep(500);

                        Console.WriteLine("강화에 성공했습니다.");
                        ++phase;
                        failbonus = 0;
                        ++myth_trycnt_tmp;
                    }
                    else
                    {
                        Thread.Sleep(500);
                        Console.WriteLine("...깡...");
                        Thread.Sleep(500);
                        Console.WriteLine("...깡...");
                        Thread.Sleep(500);
                        Console.WriteLine("...깡...");
                        Thread.Sleep(500);

                        Console.WriteLine("\n강화에 실패했습니다.");
                        Console.WriteLine("강화 실패 보정치가 추가됩니다.");
                        failbonus += 5;
                        ++myth_trycnt_tmp;
                    }
                }
                else
                {
                    myth_trycnt = myth_trycnt_tmp;
                    Console.WriteLine("신화등급 장비의 강화를 완료했습니다.");
                    Console.WriteLine("다른 강화를 하시겠습니까? (y/n) ");
                    str = Console.ReadLine();
                    if (str == "y")
                        break;
                    else if (str == "n")
                        Environment.Exit(0);
                    else
                        Console.WriteLine("잘못 입력하셨습니다.");
                }

                if (phase < maxPhase)
                {
                    while (str != "y" || str != "n")
                    {
                        probnum = 300 - (15 * phase);
                        probability = ((float)(probnum + failbonus) / 1000);

                        Console.WriteLine("현재 신화등급 장비는 {0:D}단계이며 다음 강화 확률은 {1:P}입니다.", phase, probability);

                        Console.WriteLine("\n강화를 계속 하시겠습니까? (y/n) ");
                        str = Console.ReadLine();
                        if (str == "y")
                            break;
                        else if (str == "n")
                            Environment.Exit(0);
                        else
                            Console.WriteLine("잘못 입력하셨습니다.\n");
                    }
                }
            }
        }

        static void Record()
        {
            Console.WriteLine("일반등급 장비를 최대치로 강화하기 까지 걸린 시행 횟수: {0:D}", normal_trycnt);
            Console.WriteLine("매직등급 장비를 최대치로 강화하기 까지 걸린 시행 횟수: {0:D}", magic_trycnt);
            Console.WriteLine("영웅등급 장비를 최대치로 강화하기 까지 걸린 시행 횟수: {0:D}", hero_trycnt);
            Console.WriteLine("전설등급 장비를 최대치로 강화하기 까지 걸린 시행 횟수: {0:D}", legend_trycnt);
            Console.WriteLine("신화등급 장비를 최대치로 강화하기 까지 걸린 시행 횟수: {0:D}", myth_trycnt);
            Console.WriteLine("아무 키나 누르면 처음 화면으로 돌아갑니다.");
            Console.ReadLine();

            WriteICSV_File("Record.txt");
        }
}
