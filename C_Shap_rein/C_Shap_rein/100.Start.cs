using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Console;        //Write를 쓸때 Console를 안 써도된다 -> 데이터 형식의 이름을 명시하지 않고 참조

namespace C_Shap_rein
{
    class Program
    {
        static void Main(string[] args)
        {
            WriteLine("2.데이터 찾기 및 서식");
            WriteLine("3.데이터");
            WriteLine("4.연산자x");
            WriteLine("5.조건문 및 반복문x\n");
            string input = Console.ReadLine();

            if (input == ("2"))
            {
                _200 test = new _200();
                test.main200();
            }
            if (input == ("3"))
            {
                WriteLine("300 데이터 타입");
                WriteLine("346 박싱, 언박싱");
                WriteLine("347 데이터 타입 변환");
                WriteLine("352 열거");
                WriteLine("360 null널값 포함 가능한값");
                input = Console.ReadLine();
                _300 test = new _300();
                if (input == ("300"))
                {
                    test.main300();
                }
                if (input == ("346"))
                {
                    test.main346();
                }
                if (input == ("347"))
                {
                    test.main347();
                }
                if (input == ("352"))
                {
                    test.main352();
                }
                if (input == ("360"))
                {
                    test.main360();
                }
            }
            
        }
    }
}
