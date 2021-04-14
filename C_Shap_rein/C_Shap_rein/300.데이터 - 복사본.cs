using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace C_Shap_rein
{
    partial class _300
    {
        public void main300()
        {
            byte a = 255;           // byte =    0 ~ 255 = 1111 1111
            sbyte b = (sbyte)a;     //sbyte = -128 ~ 127 = 1111 1111 이므로 음수로 변한됨
            decimal c = 10m;        //double보다 큰 실수형
            Console.WriteLine(a + " / " + b + " / " + c);
        }

        public void main346()
        {
            int a = 123;
            object b = (object)a;       //박싱 -> 힙에 저장
            int c = (int)b;             //언박싱 -> 스택에 저장
        }
        public void main347()
        {
            int a = int.Parse("12345");     //데이터 타입 변환
            string b = a.ToString();
            int c = Convert.ToInt32(b);
        }
        enum Test { YES = 1, NO  }
        public void main352()
        {
            Test a = Test.NO;
        }

        /// <summary>
        /// null널값 포함 가능한값
        /// </summary>
        public void main360()
        {
            int? a = null;

            Console.WriteLine(a.HasValue);
            Console.WriteLine(a.GetType().ToString());
        }

        public void main411()
        {

        }
    }
}
