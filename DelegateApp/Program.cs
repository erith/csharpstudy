namespace DelegateApp;

delegate int MyDelegate(int a, int b); //대리자 선언

internal class Program
{
    public int Plus(int a, int b) //대리자는 인스턴스 메소드 참조 가능
    {
        return a + b;
    }

    public static int Minus(int a, int b) //대리자는 정적 메소드도 참고 가능
    {
        return (a - b);
    }


    static void Main(string[] args)
    {
        Program p = new Program();
        MyDelegate Callback;
        Callback = new MyDelegate(p.Plus);
        Console.WriteLine(Callback(3, 4));

        Callback = new MyDelegate(Program.Minus);
        Console.WriteLine(Callback(7, 5));

    }
}