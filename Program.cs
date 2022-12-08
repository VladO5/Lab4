using System;
using System.Linq.Expressions;

/*namespace Lab4_1
{
    class Program
    {
        static void Main(string[] args)
        {
            DRomb romb2 = new DRomb();
            DRomb romb = new DRomb();

            romb[0] = 10;

            romb[1] = 20;

            romb[10] = 1;

            romb[20] = 30;

            Console.WriteLine(romb[0]);
            Console.WriteLine(romb[1]);
            Console.WriteLine();
            Console.WriteLine("Перевантаження операцій ++ та --");
            Console.WriteLine(romb);

            romb++;
            romb++;
            romb--;

            Console.WriteLine(romb);
            Console.WriteLine();
            Console.WriteLine("Перевантаження операцій * ");


            Console.WriteLine(romb * 10);
            Console.WriteLine();

            Console.WriteLine("Конструктор без параметрів");
            if (romb2)
            {
                Console.WriteLine("true");
            }
            else Console.WriteLine("false");

            Console.WriteLine();
            Console.WriteLine("Конструктор з параметрів");
            if (romb)
            {
                Console.WriteLine("true");
            }
            else Console.WriteLine("false");
        }
    }
}
class DRomb
{
    public DRomb()
    {
        this.d1 = 0;
        this.d2 = 0;
    }

    public DRomb(int d1, int d2)
    {
        this.d1 = d1;
        this.d2 = d2;
    }

    public int d1 { get; set; }
    public int d2 { get; set; }

    int color { get; set; }

    public int this[int index]
    {
        get
        {

            if (index == 0)
            {
                return d1;
            }
            else if (index == 1)
            {
                return d2;
            }
            else if (index == 2)
            {
                return color;
            }
            else throw new Exception("Not valid number");

        }
        set
        {
            try
            {
                if (index == 0)
                {
                    d1 = value;
                }
                else if (index == 1)
                {
                    d2 = value;
                }
                else if (index == 2)
                {
                    color = value;
                }
                else throw new Exception("Not valid number");
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
    }

    public static DRomb operator ++(DRomb romb)
    {
        return new DRomb(++romb.d1, ++romb.d2);
    }

    public static DRomb operator --(DRomb romb)
    {
        return new DRomb(--romb.d1, --romb.d2);
    }


    private bool isNotNull()
    {
        if (this == null)
        {
            return false;
        }
        else return true;
    }
    public static bool operator true(DRomb romb)
    {
        if (romb.d1 != 0 && romb.d2 != 0) return true;
        else return false;
    }

    public static bool operator false(DRomb romb)
    {
        if (romb.d1 != 0 && romb.d2 != 0) return true;
        else return false;
    }

    public static DRomb operator *(DRomb romb, int scalar)
    {
        return new DRomb(romb.d1 * scalar, romb.d2 * scalar);
    }

    public override string? ToString()
    {
        return "d1 = " + d1 + " d2 = " + d2 + " color  = " + color;
    }
}
*/
/*
namespace lab4_2
{
    internal class Program
    {
        static void Main(string[] args)
        {
            VectorULong vectorULong = new VectorULong();
            VectorULong vectorULong4 = new VectorULong();
            VectorULong vectorULong2 = new VectorULong(5);
            VectorULong vectorULong3 = new VectorULong(5);

            vectorULong2.printVector();

            vectorULong2.inputVector();

            Console.WriteLine(" Змінюємо елемент вектора");
            vectorULong2.setVectorValue(4, 2);

            vectorULong2.printVector();

            Console.WriteLine("Кількість створених векторів");

            Console.WriteLine(VectorULong.getNumOfVector());

            Console.WriteLine("Використання ++ та -- ");

            vectorULong2++;
            vectorULong2++;
            vectorULong2++;
            vectorULong2--;

            vectorULong2.printVector();

            if (vectorULong2)
            {
                Console.WriteLine("Вектор існує");
            }
            else Console.WriteLine("Вектора 0");

            Console.WriteLine("Оператор ! " + !vectorULong2);

            Console.WriteLine("Операція == та !=");

            Console.WriteLine(vectorULong == vectorULong4);
            Console.WriteLine(vectorULong == vectorULong2);


        }
    }
}

class VectorULong
{
    public long[] intArray;
    uint size { get; }
    int codeEror { get; set; }

    static uint num_vl;

    public VectorULong()
    {
        intArray = new long[1] { 0 };
        size = 1;
        num_vl++;

    }
    public VectorULong(uint size)
    {
        this.size = size;
        intArray = new long[size];
        num_vl++;
    }

    public VectorULong(uint size, long[] array)
    {
        this.size = size;
        intArray = new long[size];
        intArray = array;
        num_vl++;
    }

    ~VectorULong()
    {
        Console.WriteLine("Деструктор класа" + GetType());
        num_vl--;
    }

    public void inputVector()
    {
        Console.WriteLine("Введіть вектор: ");
        for (int i = 0; i < intArray.Length; i++)
        {
            intArray[i] = long.Parse(Console.ReadLine());
        }
        Console.WriteLine();
    }
    public void printVector()
    {
        Console.WriteLine("Вектор: ");
        for (int i = 0; i < intArray.Length; i++)
        {
            Console.Write(intArray[i] + " ");
        }
        Console.WriteLine();
    }

    public void setVectorValue(int index, long value)
    {
        intArray[index] = value;
    }

    public static uint getNumOfVector()
    {
        return num_vl;
    }


    public long this[int index]
    {
        get
        {
            if (index < 0 && index < size)
            {
                codeEror = 0;
                return intArray[index];
            }
            else
            {
                codeEror = -1;
                throw new Exception();
            }
        }

        set
        {
            codeEror = index;
        }
    }

    public static VectorULong operator --(VectorULong vectorULong)
    {

        VectorULong vectorULong1 = new VectorULong(vectorULong.size, vectorULong.intArray);
        for (long i = 0; i < vectorULong.size; i++)
        {
            vectorULong1.intArray[i]--;
        }

        return vectorULong1;

    }

    public static VectorULong operator ++(VectorULong vectorULong)
    {
        VectorULong vectorULong1 = new VectorULong(vectorULong.size, vectorULong.intArray);
        for (long i = 0; i < vectorULong.size; i++)
        {
            vectorULong1.intArray[i]++;
        }

        return vectorULong1;
    }

    public static bool operator true(VectorULong vectorULong)
    {
        if (vectorULong.size == 1)
        {
            for (long i = 0; i < vectorULong.size; i++)
            {
                if (vectorULong.intArray[i] == 0)
                {
                    break;
                }
            }
            return false;
        }
        else return true;
    }

    public static bool operator false(VectorULong vectorULong)
    {
        if (vectorULong.size == 1)
        {
            for (long i = 0; i < vectorULong.size; i++)
            {
                if (vectorULong.intArray[i] == 0)
                {
                    break;
                }
            }
            return false;
        }
        else return true;
    }

    public static bool operator !(VectorULong vectorULong)
    {
        if (vectorULong.size > 0)
        {
            return true;
        }
        else return false;
    }

    public static bool operator ==(VectorULong vectorULong1, VectorULong vectorULong2)
    {
        for (long i = 0; i < vectorULong1.size; i++)
        {
            if (vectorULong1.intArray[i] != vectorULong2.intArray[i])
            {
                return false;
            }
        }
        return true;
    }

    public static bool operator !=(VectorULong vectorULong1, VectorULong vectorULong2)
    {
        for (long i = 0; i < vectorULong1.size; i++)
        {
            if (vectorULong1.intArray[i] != vectorULong2.intArray[i])
            {
                return false;
            }
        }
        return true;
    }
}
*/

namespace lab4._3
{
    internal class Program
    {
        static void Main(string[] args)
        {
            MatrixUlong matrixUlong = new MatrixUlong();
            MatrixUlong matrixUlong1 = new MatrixUlong(4, 4);

            matrixUlong.ShowMatrix();

            matrixUlong1.ShowMatrix();

            matrixUlong1.InputMatrix();

            matrixUlong1++;
            matrixUlong1++;
            matrixUlong1++;
            matrixUlong1++;
            matrixUlong1--;

            matrixUlong1.InputNumber(matrixUlong.getN - 1, matrixUlong1.getM - 1, 0);

            matrixUlong1.ShowMatrix();

            MatrixUlong matrixUlong2 = new MatrixUlong(matrixUlong1.getMatrix(), (uint)matrixUlong1.getN, (uint)matrixUlong1.getM);

            MatrixUlong.getNumOfMatrix();

            if (matrixUlong2)
            {
                Console.WriteLine("Матриця існує");
            }
            else Console.WriteLine("Матриця не існує");

            if (matrixUlong)
            {
                Console.WriteLine("Матриця існує");
            }
            else Console.WriteLine("Матриця не існує");


            Console.WriteLine("Оператор ! " + !matrixUlong2);

            Console.WriteLine("Операція == та !=");

            Console.WriteLine(matrixUlong1 == matrixUlong2);
            Console.WriteLine(matrixUlong1 == matrixUlong);






        }
    }
}

class MatrixUlong
{

    private ulong[,] ULArray;
    private uint n, m;
    private int codeEror;
    private static int num_m;



    public int CodeEror
    {
        get
        {
            return codeEror;
        }
        set
        {
            codeEror = value;
        }
    }

    public int getN { get { return (int)n; } }
    public int getM { get { return (int)m; } }

    public MatrixUlong()
    {
        ULArray = new ulong[,] { { 0 } };
        n = 1;
        m = 1;
        codeEror = 0;
        num_m++;


    }

    public MatrixUlong(uint n, uint m)
    {
        this.ULArray = new ulong[n, m];

        for (int i = 0; i < n; i++)
        {
            for (int j = 0; j < m; j++)
            {
                ULArray[i, j] = 0;
            }
        }

        this.n = n;
        this.m = m;
        codeEror = 0;
        num_m++;
    }

    public MatrixUlong(ulong[,] uLArray, uint n, uint m)
    {
        ULArray = uLArray;
        this.n = n;
        this.m = m;
        this.codeEror = 0;
        num_m++;
    }

    ~MatrixUlong()
    {
        Console.WriteLine("Деструктор");
    }

    public ulong[,] getMatrix()
    {
        return ULArray;
    }

    public void InputMatrix()
    {
        Console.WriteLine();
        for (int i = 0; i < n; i++)
        {
            for (int j = 0; j < m; j++)
            {
                ULArray[i, j] = ulong.Parse(Console.ReadLine());
            }
            Console.WriteLine();
        }
    }

    public void ShowMatrix()
    {
        Console.WriteLine();
        for (int i = 0; i < n; i++)
        {
            for (int j = 0; j < m; j++)
            {
                Console.Write(ULArray[i, j] + " ");
            }
            Console.WriteLine();
        }
    }

    public void InputNumber(int n, int m, ulong number)
    {
        ULArray[n, m] = number;
    }

    public static int getNumOfMatrix()
    {
        return num_m;
    }

    public ulong this[int n, int m]
    {
        get
        {
            return ULArray[n, m];
        }
    }

    public static MatrixUlong operator ++(MatrixUlong matrixUlong)
    {
        MatrixUlong matrixUlong1 = new MatrixUlong(matrixUlong.ULArray, matrixUlong.m, matrixUlong.n);

        for (int i = 0; i < matrixUlong1.n; i++)
        {
            for (int j = 0; j < matrixUlong1.m; j++)
            {
                matrixUlong1.ULArray[i, j] += 1;
            }
        }


        return matrixUlong1;
    }

    public static MatrixUlong operator --(MatrixUlong matrixUlong)
    {
        MatrixUlong matrixUlong1 = new MatrixUlong(matrixUlong.ULArray, matrixUlong.m, matrixUlong.n);

        for (int i = 0; i < matrixUlong1.n; i++)
        {
            for (int j = 0; j < matrixUlong1.m; j++)
            {
                matrixUlong1.ULArray[i, j] -= 1;
            }
        }

        return matrixUlong1;
    }

    public static bool operator true(MatrixUlong matrixUlong)
    {
        int count = 0;
        for (int i = 0; i < matrixUlong.n; i++)
        {
            for (int j = 0; j < matrixUlong.m; j++)
            {
                if (matrixUlong[i, j] == 0)
                {
                    count++;
                }
            }

        }

        if (matrixUlong.n != 0 && matrixUlong.m != 0)
        {
            if (count == matrixUlong.m)
            {
                return false;
            }
            else
            {
                return true;
            }
        }
        else
        {
            return true;
        }
    }

    public static bool operator false(MatrixUlong matrixUlong)
    {
        int count = 0;
        for (int i = 0; i < matrixUlong.n; i++)
        {
            for (int j = 0; j < matrixUlong.m; j++)
            {
                if (matrixUlong[i, j] == 0)
                {
                    count++;
                }
            }

        }

        if (matrixUlong.n != 0 && matrixUlong.m != 0)
        {
            if (count == matrixUlong.m)
            {
                return false;
            }
            else
            {
                return true;
            }
        }
        else
        {
            return true;
        }
    }

    public static bool operator !(MatrixUlong matrixUlong)
    {
        if (matrixUlong.n == 0 && matrixUlong.m == 0)
        {
            return false;
        }
        else return true;
    }

    public static bool operator ==(MatrixUlong matrixUlong, MatrixUlong matrixUlong2)
    {
        if (matrixUlong.n == matrixUlong2.n && matrixUlong.m == matrixUlong2.m)
        {
            return true;
        }
        else return false;
    }

    public static bool operator !=(MatrixUlong matrixUlong, MatrixUlong matrixUlong2)
    {
        if (matrixUlong.n != matrixUlong2.n && matrixUlong.m != matrixUlong2.m)
        {
            return true;
        }
        else return false;
    }

}