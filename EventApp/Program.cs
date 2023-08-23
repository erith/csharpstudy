namespace EventApp;

internal class Program
{
    public static void MyHandler(string message)
    {
        Console.WriteLine(message);
    }


    static void Main(string[] args)
    {
        MyNoti noti = new MyNoti();
        noti.SomethingHappend += new EventHandler(MyHandler);

        for (int i = 1; i < 30; i++)
        {
            noti.DoSomething(i);
        }
    }
}

delegate void EventHandler(string message);

class MyNoti
{
    public event EventHandler SomethingHappend;

    public void DoSomething(int number)
    {
        int temp = number % 10;

        if (temp != 0 && temp % 3 == 0)
        {
            SomethingHappend(String.Format("{0} : 짝", number));
        }
    }
}