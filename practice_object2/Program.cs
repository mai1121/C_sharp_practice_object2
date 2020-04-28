using System;
using System.Collections.Generic;

namespace practice_object2
{
    class Program
    {
        #region　参照渡し・値渡し練習
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
        #endregion

        //タプル型で戻り値の型定義すれば複数の値を返せる
        public (int max,int min) GetMaxMin(int x, int y)
        {
            //大きい方をmaxに、小さい方をminに代入する三項演算子
            return x >= y ? (x, y) : (y, x);
        }
        public (string name,int age) GetNameAndAge(string x,int y)
        {
            return (x,y+1);
        }

        public IEnumerable<int> FromTo(int from,int to)
        {
            while (from <= to)
            {
                yield return from++;
            }
        }
        public IEnumerable<string> GetNames()
        {
            yield return "あいこ";
            yield return "さき";
            yield return "まきこ";
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

            var t = p1.GetMaxMin(200, 300);
            Console.WriteLine(t.max);
            Console.WriteLine(t.min);

            var t2 =p1.GetNameAndAge("春樹",65);
            Console.WriteLine($"{t2.name}:{t2.age}歳");

            //タプルのリストを作ることができる
            var list = new List<(string name,int age)> { };
            list.Add(("アスカ",14));
            list.Add(("シンジ", 15));
            foreach(var (x,y) in list)
            {
                Console.WriteLine($"{x}は{y}歳です");
            }

            //タプルでディクショナリ作ることできる
            var dic = new Dictionary<(int year,string month),(string name,int old)> { };
            dic.Add((1992,"６月"),("カヲル",14));
            //取り出すときはタプル型で変数型を用意して受け取る
            (string x, int y) tuple;
            Console.WriteLine(dic.TryGetValue((1992, "６月"),out tuple));
            Console.WriteLine(dic[(1992, "６月")]);

            //匿名型：読み取り専用のフィールド
            var info = new {title="君の名は",review=5};
            Console.WriteLine($"{info.title}:{info.review}");

            //イテレーター。メソッドからの戻り値を反復で処理したい場合に便利
            foreach (var i in p1.FromTo(10,15))
            {
                Console.WriteLine(i);
            }
            foreach (var n in p1.GetNames())
            {
                Console.WriteLine(n);
            }
        }
    }


}
