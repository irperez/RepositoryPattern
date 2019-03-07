using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc.ViewFeatures;
using Newtonsoft.Json;

namespace WebHelper.RazorPlaybook
{
    /// <summary>
    /// Session and temp data serialize
    /// </summary>
    public static class SessionAndTempDataHelper
    {

        /// <summary>
        ///  TempData.StoreObject("FirstVideo", context.Videos.First());
        /// </summary>
        /// <param name="tempData"></param>
        /// <param name="key"></param>
        /// <param name="value"></param>
        public static void StoreObject(this ITempDataDictionary tempData, string key, object value)
        {
            var json = JsonConvert.SerializeObject(value);

            tempData[key] = json;
        }
        /// <summary>
        /// <h3>@(TempData.GetObject<Video>("FirstVideo").Title)</h3>
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="tempData"></param>
        /// <param name="key"></param>
        /// <returns></returns>
        public static T sGetObject<T>(this ITempDataDictionary tempData, string key)
        {
            var json = tempData[key].ToString();

            return JsonConvert.DeserializeObject<T>(json);
        }

        public static void StoreObject(this ISession session, string key, object value)
        {
            var json = JsonConvert.SerializeObject(value);

            session.SetString(key, json);
        }

        public static T GetObject<T>(this ISession session, string key)
        {
            var json = session.GetString(key);

            return JsonConvert.DeserializeObject<T>(json);
        }


        public static string ToOrdinal(this int number)
        {
            const string TH = "th";
            var s = number.ToString();

            number %= 100;

            if ((number >= 11) && (number <= 13))
            {
                return s + TH;
            }

            switch (number % 10)
            {
                case 1:
                    return s + "st";
                case 2:
                    return s + "nd";
                case 3:
                    return s + "rd";
                default:
                    return s + TH;
            }
        }
    }

}
