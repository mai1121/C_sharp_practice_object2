using System;

namespace practice_object2
{
    class Program
    {
        //参照型の値渡し①。実引数の値にも更新処理が影響する
        public int[] Update1(int[] data)
        {
            //配列の値を置き換え
            data[1] = 10;
            return data;
        }

        //参照型の値渡し②。実引数の値にも更新処理が影響しない例
        public int[] Update2(int[] data)
        {
            //配列ごと置き換え
            data = new[] { 25, 50, 75 };
            return data;
        }

        //値型の参照渡し。実引数の値にも更新処理が影響する
        public int Update3(ref int data)
        {
            //値を置き換え
            data = 300;
            return data;
        }

        //参照型の参照渡し。実引数の値にも更新処理が影響する
        public int[] Update4(ref int[] data)
        {
            //配列ごと置き換え
            data = new[] { 25, 50, 75 };
            return data;
        }

        //戻り値の参照渡し
        public ref int ReturnRef(int[] data)
        {
            return ref data[1];
        }

        static void Main(string[] args)
        {
            var data1 = new[]{1,2,3};
            var p1 = new Program();
            Console.WriteLine(p1.Update1(data1)[1]);
            Console.WriteLine(data1[1]);

            var data2 = new[] { 1, 2, 3 };
            Console.WriteLine(p1.Update2(data2)[1]);
            Console.WriteLine(data2[1]);

            var data3 = 100;
            Console.WriteLine(p1.Update3(ref data3));
            Console.WriteLine(data3);

            Console.WriteLine(p1.Update4(ref data2)[1]);
            Console.WriteLine(data2[1]);

            ref int num = ref p1.ReturnRef(data1);
            Console.WriteLine(num);
            num = 24;
            Console.WriteLine(num);
            Console.WriteLine(data1[1]);
        }
    }


}
