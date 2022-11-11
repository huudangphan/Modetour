namespace ModeTour.Commons.Helper
{
    public class CodeHelper
    {
        public static string GetCabinType(string cabin)
        {
            string result = string.Empty;

            switch (cabin.ToUpper())
            {
                case "W": result = "프리미엄 일반석"; break;
                case "F": result = "일등석"; break;
                case "C": result = "비즈니스석"; break;
                default: result = "일반석"; break;
            }

            return result;
        }
    }
}
