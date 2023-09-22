using myApp.Interfaces;
namespace myApp.Classes
{
    public class DayTimeService:IDayTimeService
    {
        private string? DayBackColor { get; set; }
        private string? DayFrontColor { get; set; }
        private string? DayTimePhrase { get; set; }
        public DayTimeService()
        {
            DateTime now = DateTime.Now;
            int hour = now.Hour;
   

            switch (hour)
            {
                case int h when (h >= 12 && h < 18):
                    DayTimePhrase = "Good afternoon";
                    DayBackColor = "#17B6FF";
                    DayFrontColor = "#FFF200";
                    break;

                case int h when (h >= 18 && h < 24):
                    DayTimePhrase = "Good evening";
                    DayBackColor = "#8A1845";
                    DayFrontColor = "#FF7F27";
                    break;

                case int h when (h >= 0 && h < 6):
                    DayTimePhrase = "Good night";
                    DayBackColor = "#273581";
                    DayFrontColor = "#ABABAB";
                    break;

                default:
                    DayTimePhrase = "Good morning";
                    DayBackColor = "#BD3C4D";
                    DayFrontColor = "#FFF200";
                    break;
            }
        } 
        public string GetDayTimePhrase()
            {
                if (DayTimePhrase == null)
                {
                    throw new NullReferenceException("Server is not able to process time");
                }
                return DayTimePhrase;
            }

        public string GetDayBackColor()
            {
                if (DayBackColor == null)
                {
                    throw new NullReferenceException("Server is not able to process time");
                }
                return DayBackColor;
            }
        public string GetDayFrontColor()
            {
            if (DayFrontColor == null)
            {
                throw new NullReferenceException("Server is not able to process time");
            }
            return DayFrontColor;
        }
    }
}
