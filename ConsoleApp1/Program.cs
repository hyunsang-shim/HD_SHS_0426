using System;
using System.Collections.Generic;


public class SungJuk
{
    private string name = "";
    private string hakbun = "";
    private string[] subj = { "국어", "영어", "수학" };
    private int[] Point = { 0, 0, 0 };
    private float grade = 0f;

    public SungJuk() {}

    public SungJuk(string _name, string _hakbun, int _kor, int _eng, int _math)
    {
        name = _name;
        hakbun = _hakbun;
        Point[0] = _kor;
        Point[1] = _eng;
        Point[2] = _math;
        int sum = 0;
        foreach (int num in Point)
            sum += num;

        grade = sum / (float)Point.Length;
    }




    public static void Main()
    {
        bool isQuit = false;
        List<SungJuk> haksa = new List<SungJuk>();

        ConsoleKeyInfo inputNum;

        

        while (isQuit == false)
        {
            ShowMenu();
            inputNum = Console.ReadKey(true);
            isQuit = GetKeyInput(inputNum, haksa);
        }

    }


    static void ShowMenu()
    {
        Console.WriteLine("메뉴> [1] 학생 등록 | [2] 학생 명단 출력 | [3] 프로그램 종료");
        Console.Write("선택 # ");
    }

    static bool GetKeyInput(ConsoleKeyInfo _n, List<SungJuk> haksa) {

        switch(_n.Key)
        {
            case ConsoleKey.D1:
            case ConsoleKey.NumPad1:
                {
                    Console.WriteLine("1");
                    RegistStudent(haksa);
                    Console.Write("\n");
                }
                return false;
            case ConsoleKey.D2:
            case ConsoleKey.NumPad2:
                {
                    Console.WriteLine("2");

                    if (haksa.Count == 0)
                    {
                        Console.WriteLine("저장된 학생 정보가 없습니다.\n");
                    }
                    else
                    {
                        ShowStudents(haksa);
                        Console.Write("\n");
                    }
                }
                return false;
            case ConsoleKey.D3:
            case ConsoleKey.NumPad3:
                {
                    Console.Write("3\n");
                    Console.Write("\n===== 프로그램을 종료합니다. =====\n");
                }
                return true;
        }

        return false;
    }


    static void RegistStudent(List<SungJuk> _h)
    {
        SungJuk student = new SungJuk();
        Console.Write("\n===== 학생 정보를 등록합니다. =====\n");
        Console.Write("이름: ");
        student.name = Console.ReadLine();

        Console.Write("학번: ");
        student.hakbun= Console.ReadLine();

        for (int i = 0; i < student.Point.Length; i++)
        {
            Console.Write($"{student.subj[i]} 점수: ");
            int.TryParse(Console.ReadLine(), out student.Point[i]);
        }

        _h.Add(student);
    }

    static void ShowStudents(List<SungJuk> _p)
    {
        Console.Write("\n===== 저장된 학생 목록 =====\n");
        Console.Write("\t학번\t이름\t평점\n");

        for (int i = 0; i < _p.Count; i++)
        {
            Console.Write($"{_p[i].hakbun} - {_p[i].name} - ");

            int sum = 0;
            foreach (int p in _p[i].Point) sum += p;

            Console.Write($"{sum / (float)_p[i].Point.Length:0.0}\n");
        }
    }
}