using ModeTour.Entities.Air;

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
        public static string Base64Decoding(string DecodingText, System.Text.Encoding oEncoding = null)
        {
            if (oEncoding == null)
                oEncoding = System.Text.Encoding.UTF8;

            byte[] arr = System.Convert.FromBase64String(DecodingText);
            return oEncoding.GetString(arr);
        }
        public static string[] SplitArray(string paramsValue)
        {
            string[] splitArray = (string.IsNullOrEmpty(paramsValue) ? string.Empty : paramsValue).Split(',');
            List<string> list = new List<string>();

            foreach (string index in splitArray)
                list.Add(index);
            return list.ToArray();
        }
        public static string ConvertToFXL(string fxl, string fref, string fgid)
        {
            string result = string.Empty;

            try
            {
                var tmp = APIHelper.ConvertJsonToObjectx(APIHelper.PostData(new FXLDowngradeRQModel() { FXL = fxl, FREF = fref, FGID = fgid, RQT = "WEB" }, "http://airservice2.modetour.com/AirService3.asmx/FXLDowngrade").ToString());
                result = XmlHelper.ConvertString(tmp.Data as PriceIndexOrderModel);
            }
            catch (Exception ex)
            {
                result = string.Empty;
            }

            return result;
        }
    }
}
