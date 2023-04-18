using Newtonsoft.Json;
using prjFarmAttractions.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;

namespace prjFarmAttractions.Controllers
{
    public class HomeController : Controller
    {
        public async Task<ActionResult> Index()
        {
            //下載全國休閒農業區旅遊資訊JSON開放資料
            string url = "https://data.coa.gov.tw/Service/OpenData/ODwsv/ODwsvAttractions.aspx";
            HttpClient httpClient = new HttpClient();
            httpClient.MaxResponseContentBufferSize = Int32.MaxValue;
            var response = await httpClient.GetStringAsync(url);
            string path = $"{Server.MapPath("JSON").Replace("HOME\\", "")}\\ODwsvAttractions.json"; ;
            FileInfo fileInfo = new FileInfo(path);
            StreamWriter streamWriter = new StreamWriter(path, false, System.Text.Encoding.UTF8);
            streamWriter.WriteLine(response);
            streamWriter.Close();
            //將資訊JSON資料反序列化成FarmAttractions陣列物件
            StreamReader streamReader = new StreamReader(path);
            FarmAttractions[] farmAttractions = JsonConvert.DeserializeObject<FarmAttractions[]>(streamReader.ReadToEnd());
            //將陣列物件先依City遞增排序，接著再依Town鄉鎮遞增排序
            //將排序後的陣列物件傳送至View
            return View(farmAttractions.OrderBy(m => m.City).ThenBy(m => m.Town).ToList());
        }

    }
}