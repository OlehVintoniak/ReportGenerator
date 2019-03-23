namespace ReportGenerator
{
    public static class Extensions
    {
        public static string ToMonthName(this int monthNumber)
        {
            switch (monthNumber)
            {
                case 1: return "січня";
                case 2: return "лютого";
                case 3: return "березня";
                case 4: return "квітня";
                case 5: return "травня"; 
                case 6: return "червня";
                case 7: return "липня";
                case 8: return "серпня"; 
                case 9: return "вересня";
                case 10: return "жовтня";
                case 11: return "листопада";
                case 12: return "грудня";
                default: return string.Empty;
            }
        }
    }
}
