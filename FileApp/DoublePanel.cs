namespace FileApp
{
    /// <summary>
    /// Double Buffering이 지원되는 패널을 사용하기 위해 상속 클래스를 만듬.
    /// </summary>
    public class DoublePanel : System.Windows.Forms.Panel
    {
        public DoublePanel()
        {
            DoubleBuffered = true;
        }
    }
}
