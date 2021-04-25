using System;
using System.IO;
using System.Threading.Tasks;
using Adapter.Utils;
using Newtonsoft.Json.Linq;

namespace Adapter.Services
{
    public class Tools
    {
        private readonly MonoovaHelper _monoovaHelper;
        private const string baseUrl = "/tools/v1";
        
        public Tools(MonoovaHelper monoovaHelper)
        {
            _monoovaHelper = monoovaHelper;
        }
        
        public async Task Ping()
        {
            var response = await _monoovaHelper.GetClient().GetAsync(baseUrl + "/ping");
            var obj = JObject.Parse(await ResponseHandler.ResponseJson(response));
            PrintObj.print(obj);
        }

        public async Task ValidateAbn(string abn)
        {
            var response = await _monoovaHelper.GetClient().GetAsync(baseUrl + "/abnValidate/" + abn);
            var obj = JObject.Parse(await ResponseHandler.ResponseJson(response));
            PrintObj.print(obj);
        }
        
        public async Task ValidateBsb(string bsb)
        {
            var response = await _monoovaHelper.GetClient().GetAsync(baseUrl + "/bsbValidate/" + bsb);
            var obj = JObject.Parse(await ResponseHandler.ResponseJson(response));
            PrintObj.print(obj);
        }
    }
}