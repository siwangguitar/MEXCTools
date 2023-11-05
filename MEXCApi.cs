using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.ListView;

namespace MEXCTools
{
    [JsonObject(MemberSerialization.OptOut)]
    public class MEXCApi
    {
        public string Email { set; get; }
        public string ApiKey { set; get; }
        public string ApiSecret { set; get; }
        public MEXCApi()
        {
            Email = "";
            ApiKey = "";
            ApiSecret = "";
        }
        public MEXCApi(string email, string apikey ,string apisecret )
        {
            Email = email;
            ApiKey = apikey;
            ApiSecret = apisecret;
        }
    }

    public class MasterMEXCApi
    {
        public MEXCApi MasterAccount { set; get; }
        public List<MEXCApi> SubAccounts { set; get; }
        public MasterMEXCApi()
        {
            MasterAccount = new MEXCApi();
            SubAccounts = new List<MEXCApi>();
        }
        public MasterMEXCApi(MEXCApi api)
        {
            MasterAccount = api;
            SubAccounts = new List<MEXCApi>();
        }
        public override string ToString()
        {
            if (MasterAccount != null)
            {
                return MasterAccount.Email;
            }
            return "";
        }
    }
}
