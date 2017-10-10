using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Serialization.Json;
using System.Text;
using System.Threading.Tasks;
using Windows.UI.Xaml.Controls;

namespace UwpGame
{
    static class General
    {
        private static MainPage mainPage; 

        public static void InitializeMainPage(MainPage mainPage)
        {
            General.mainPage = mainPage;
        }

        public static void PopupDialogBox(UserControl userControl)
        {
            General.mainPage.AAA(userControl);
        }

        public static string JsonSerialize<T>(T entity)
        {
            DataContractJsonSerializer jsonSerializer = new DataContractJsonSerializer(entity.GetType());
            string result = string.Empty;
            using (MemoryStream stream = new MemoryStream())
            {
                jsonSerializer.WriteObject(stream, entity);
                result = Encoding.UTF8.GetString(stream.ToArray()).Trim();
            }
            return result;
        }

        public static T JsonDeserialize<T>(string _string)
        {
            T result = default(T);
            using (MemoryStream ms = new MemoryStream(Encoding.UTF8.GetBytes(_string)))
            {
                DataContractJsonSerializer jsonSerializer = new DataContractJsonSerializer(typeof(T));
                result = (T)jsonSerializer.ReadObject(ms);
            }
            return result;
        }
    }
}
