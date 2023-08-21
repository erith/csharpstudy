namespace WinFormsApp1.Models
{
    public class BirthdayInfo
    {
        private string name;
        private DateTime birthday;

        public string Name
        {
            get { return name; }
            set { name = value; }
        }

        public DateTime DateTime
        {
            get { return birthday; }
            set { birthday = value; }
        }

        public int Age
        {
            get
            {
                return new DateTime(DateTime.Now.Subtract(birthday).Ticks).Year;
            }
        }
    }

}
