using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Web;
using Newtonsoft.Json;

namespace MexcDotNet
{
  public sealed class MexcService
  {
    private string baseUrl;
    private string apiKey;
    private string apiSecret;
    private HttpClient httpClient;

    public MexcService(string apiKey, string apiSecret, string baseUrl, HttpClient httpClient)
    {
      this.apiKey = apiKey;
      this.apiSecret = apiSecret;
      this.baseUrl = baseUrl;
      this.httpClient = httpClient;
    }

    private async Task<string> SendAsync(string requestUri, HttpMethod httpMethod, object content = null)
    {
      Console.WriteLine(requestUri);
      using (var request = new HttpRequestMessage(httpMethod, this.baseUrl + requestUri))
      {
        request.Headers.Add("X-MEXC-APIKEY", this.apiKey);

        if (!(content is null))
          request.Content = new StringContent(JsonConvert.SerializeObject(content), Encoding.UTF8, "application/json");

        HttpResponseMessage response = await this.httpClient.SendAsync(request);

        using (HttpContent responseContent = response.Content)
        {
          string jsonString = await responseContent.ReadAsStringAsync();

          return jsonString;
        }
      }
    }

    public async Task<string> SendPublicAsync(string requestUri, HttpMethod httpMethod, Dictionary<string, object> query = null, object content = null)
    {
      if (!(query is null))
      {
        string queryString = string.Join("&", query.Where(kvp => !string.IsNullOrWhiteSpace(kvp.Value?.ToString())).Select(kvp => string.Format("{0}={1}", kvp.Key, Uri.EscapeDataString(kvp.Value.ToString()))));

        if (!string.IsNullOrWhiteSpace(queryString))
        {
          requestUri += "?" + queryString;
        }
      }

      return await this.SendAsync(requestUri, httpMethod, content);
    }

    public async Task<string> SendSignedAsync(string requestUri, HttpMethod httpMethod, Dictionary<string, object> query = null, object content = null)
    {
      StringBuilder queryStringBuilder = new StringBuilder();

      if (!(query is null))
      {
        string queryParameterString = string.Join("&", query.Where(kvp => !string.IsNullOrWhiteSpace(kvp.Value?.ToString())).Select(kvp => string.Format("{0}={1}", kvp.Key, Uri.EscapeDataString(kvp.Value.ToString()))));
        queryStringBuilder.Append(queryParameterString);
      }

      if (queryStringBuilder.Length > 0)
        queryStringBuilder.Append("&");

      long now = DateTimeOffset.UtcNow.ToUnixTimeMilliseconds();
      queryStringBuilder.Append("timestamp=").Append(now);

      string signature = SignatureHelper.Sign(queryStringBuilder.ToString(), this.apiSecret);
      queryStringBuilder.Append("&signature=").Append(signature);

      StringBuilder requestUriBuilder = new StringBuilder(requestUri);
      requestUriBuilder.Append("?").Append(queryStringBuilder.ToString());

      return await this.SendAsync(requestUriBuilder.ToString(), httpMethod, content);
    }
  }

    // Root myDeserializedClass = JsonConvert.DeserializeObject<Root>(myJsonResponse);
    [Serializable]
    public class CreateSubAccountInfo
    {
        public string subAccount { get; set; }
        public string note { get; set; }
    }
    [Serializable]
    public class SubAccountsInfo
    {
        public List<SubAccountInfo> subAccounts { get; set; }
    }
    [Serializable]
    public class SubAccountInfo
    {
        public string subAccount { get; set; }
        public bool isFreeze { get; set; }
        public object createTime { get; set; }
    }
    [Serializable]
    public class SubAccountApiKeyInfo
    {
        public string subAccount { get; set; }
        public string note { get; set; }
        public string apiKey { get; set; }
        public string secretKey { get; set; }
        public string permissions { get; set; }
        public string ip { get; set; }
        public long creatTime { get; set; }
    }
    [Serializable]
    public class Balance
    {
        public string asset { get; set; }
        public string free { get; set; }
        public string locked { get; set; }
    }
    [Serializable]
    public class AccountInfo
    {
        public int makerCommission { get; set; }
        public int takerCommission { get; set; }
        public int buyerCommission { get; set; }
        public int sellerCommission { get; set; }
        public bool canTrade { get; set; }
        public bool canWithdraw { get; set; }
        public bool canDeposit { get; set; }
        public object updateTime { get; set; }
        public string accountType { get; set; }
        public List<Balance> balances { get; set; }
        public List<string> permissions { get; set; }
    }


}
