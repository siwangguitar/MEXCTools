using MexcDotNet;
using Newtonsoft.Json;
using System.Diagnostics;
using System.Net.Http;
using System.Net.Sockets;
using System.Text.RegularExpressions;
using System.Xml.Linq;

namespace MEXCTools
{
    public partial class Form1 : Form
    {
        private Config config;
        private CancellationTokenSource ct = null;
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            config = Config.Make("Config.json");
            if (config == null)
            {
                config = new Config();
                config.ToJsonFile("Config.json");
            }

            foreach (var master in config.MasteMexcApis)
            {
                cmbMEXCAccount.Items.Add(master);
            }

            if (cmbMEXCAccount.Items.Count > 0)
            {
                cmbMEXCAccount.SelectedIndex = 0;
            }
            cmbSACoins.SelectedIndex = 0;
            cmbCoins.SelectedIndex = 0;
            cmbNetworks.SelectedIndex = 0;
        }
        private static async Task Account(MexcService MexcService)
        {
            /// Account Information
            using (var response = MexcService.SendSignedAsync("/api/v3/account", HttpMethod.Get))
            {
                Debug.WriteLine(await response);
            };

            /// Coin List
            using (var response = MexcService.SendSignedAsync("/api/v3/capital/config/getall", HttpMethod.Get))
            {
                Debug.WriteLine(await response);
            }
        }

        private void cmbMEXCAccount_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cmbMEXCAccount.SelectedIndex == -1) return;
            var master = config.MasteMexcApis[cmbMEXCAccount.SelectedIndex];
            lvSubAccount.Items.Clear();
            int i = 1;
            foreach (var item in master.SubAccounts)
            {
                string[] strItems = new string[] { (i++).ToString(), item.Email, "" };
                lvSubAccount.Items.Add(new ListViewItem(strItems));
            }
        }
        private void tslvImport_Click(object sender, EventArgs e)
        {
            // 从剪贴板读取文本
            string clipboardText = Clipboard.GetText();

            // 将文本按行分割并添加到ListView控件中
            string[] lines = clipboardText.Split(new[] { "\r\n", "\r", "\n" }, StringSplitOptions.None);
            for (int i = 0; i < lines.Length; i++)
            {
                string[] items = lines[i].Split(new[] { '\t', ' ', ',' }, StringSplitOptions.RemoveEmptyEntries);
                if (items.Length == 0) continue;
                string[] item = new string[listView1.Columns.Count];
                if (items.Length >= 2)
                {
                    item[colSeq.Index] = (i + 1).ToString();
                    item[colAddress.Index] = items[0];
                    item[colAmount.Index] = items[1];
                }
                else if (items[0] != "")
                {
                    item[0] = (i + 1).ToString();
                    item[1] = items[0];
                }
                else
                {
                    continue;
                }

                listView1.Items.Add(new ListViewItem(item));
            }
        }
        private async void btnMW_Click(object sender, EventArgs e)
        {
            if (cmbMEXCAccount.SelectedIndex < 0) return;
            int index = cmbMEXCAccount.SelectedIndex;
            MasterMEXCApi api = config.MasteMexcApis[index];

            string asset = cmbCoins.Text;
            string network = cmbNetworks.Text;
            if (!int.TryParse(txtMinDelay.Text, out int minDelay)) return;
            if (!int.TryParse(txtMaxDelay.Text, out int maxDelay)) return;
            Random random = new Random();
            DialogResult dialogResult = MessageBox.Show("批量提现资产: " + asset + "\r 地址数: " + listView1.CheckedItems.Count, "转账确认", MessageBoxButtons.YesNo);
            if (dialogResult == DialogResult.No)
            {
                return;
            }
            ct = new CancellationTokenSource();
            Regex validAddressRegex = new Regex(@"^(0x)[0-9A-Fa-f]{40}$");

            var MexcService = GetMexcService(api.MasterAccount.ApiKey, api.MasterAccount.ApiSecret);
            btnMW.Enabled = false;
            try
            {
                for (int i = 0; i < listView1.CheckedItems.Count; i++)
                {
                    if (ct.IsCancellationRequested)
                        return;

                    ListViewItem item = listView1.CheckedItems[i];
                    string address = item.SubItems[colAddress.Index].Text;
                    if (!validAddressRegex.IsMatch(address))
                    {
                        item.SubItems[colInfo.Index].Text = $"{network} 充值地址格式错误";
                        continue;
                    }
                    if (!decimal.TryParse(item.SubItems[colAmount.Index].Text, out decimal amount))
                    {
                        item.SubItems[colInfo.Index].Text = "数值错误";
                        continue;
                    }
                    var response = await MexcService.SendSignedAsync("/api/v3/capital/withdraw/apply", HttpMethod.Post, new Dictionary<string, object> {
                                    {"coin", asset}, {"address", address}, {"amount", amount.ToString()}, {"network", network} });

                    item.SubItems[colInfo.Index].Text = response;


                    if (i + 1 >= listView1.CheckedItems.Count)
                        return;

                    int delay = minDelay;
                    if (minDelay < maxDelay)
                    {
                        delay = random.Next(minDelay, maxDelay);
                    }
                    await CountdownAsync(delay, labCountdown, ct.Token);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {
                ct.Dispose();
                ct = null;
                btnMW.Enabled = true;
            }
        }
        private void btnStop_Click(object sender, EventArgs e)
        {
            if (ct != null && !ct.IsCancellationRequested)
            {
                ct.Cancel();
            }
        }
        private async Task CountdownAsync(int seconds, Label label, CancellationToken cancellationToken)
        {
            for (int i = seconds; i > 0; i--)
            {
                if (cancellationToken.IsCancellationRequested)
                {
                    label.Invoke(new Action(() => label.Text = "已取消"));
                    return;
                }
                label.Invoke(new Action(() => label.Text = $"下一次提现 {i} 秒后"));
                await Task.Delay(1000);
            }
            label.Invoke(new Action(() => label.Text = "Time's up!"));
        }

        private void btnSelectAll_Click(object sender, EventArgs e)
        {
            ListViewEx lv;
            if (tabControl1.SelectedIndex == 0)
            {
                lv = listView1;
            }
            else
            {
                lv = lvSubAccount;
            }
            foreach (ListViewItem item in lv.Items)
            {
                item.Checked = true;
            }
        }

        private void btnDeselect_Click(object sender, EventArgs e)
        {
            ListViewEx lv;
            if (tabControl1.SelectedIndex == 0)
            {
                lv = listView1;
            }
            else
            {
                lv = lvSubAccount;
            }
            foreach (ListViewItem item in lv.Items)
            {
                item.Checked = false;
            }
        }

        private void btnclearLv_Click(object sender, EventArgs e)
        {
            ListViewEx lv;
            if (tabControl1.SelectedIndex == 0)
            {
                lv = listView1;
            }
            else
            {
                lv = lvSubAccount;
            }
            lv.Items.Clear();
        }

        private async void btnGetAccountInfo_Click(object sender, EventArgs e)
        {
            if (cmbMEXCAccount.SelectedIndex < 0) return;
            int index = cmbMEXCAccount.SelectedIndex;
            MasterMEXCApi api = config.MasteMexcApis[index];

            var MexcService = GetMexcService(api.MasterAccount.ApiKey, api.MasterAccount.ApiSecret);

            try
            {
                var response = await MexcService.SendSignedAsync("/api/v3/account", HttpMethod.Get);
                if (response != null)
                {
                    txtLog.Text = response;
                }
            }
            catch (Exception ex)
            {
                txtLog.Text = ex.Message;
            }
        }

        private MexcService GetMexcService(string apiKey, string apiSecret)
        {
            HttpClient httpClient = new HttpClient();
            return new MexcService(apiKey, apiSecret, config.BaseUrl, httpClient);
        }

        private async void btnCreateSubAccount_Click(object sender, EventArgs e)
        {
            if (cmbMEXCAccount.SelectedIndex < 0) return;
            int index = cmbMEXCAccount.SelectedIndex;
            MasterMEXCApi api = config.MasteMexcApis[index];

            var MexcService = GetMexcService(api.MasterAccount.ApiKey, api.MasterAccount.ApiSecret);

            string name = txtSAName.Text;
            if (!int.TryParse(txtSANameSeq.Text, out int seq)) return;
            if (!int.TryParse(txtSACount.Text, out int count)) return;

            int saCount = Math.Min(30, count);
            btnCreateSubAccount.Enabled = false;
            ct = new CancellationTokenSource();
            try
            {
                for (int i = 0; i < saCount; i++)
                {
                    if (ct.IsCancellationRequested)
                        return;
                    // Create SubAccount
                    string subAccountName = $"{name}{seq + i}";
                    var response = await MexcService.SendSignedAsync("/api/v3/sub-account/virtualSubAccount", HttpMethod.Post,
                                  new Dictionary<string, object> {
                                 {"subAccount", subAccountName}, {"note", i+1} ,{"recvWindow", "5000"} });
                    if (response != null)
                    {
                        CreateSubAccountInfo? subAccount = JsonConvert.DeserializeObject<CreateSubAccountInfo>(response);
                        if (subAccount != null)
                        {
                            if (subAccount.subAccount == null)
                            {
                                throw new Exception(response);
                            }
                            string[] strItems = new string[] { lvSubAccount.Items.Count.ToString(), subAccount.subAccount, "" };
                            ListViewItem item = new ListViewItem(strItems);
                            lvSubAccount.Items.Add(item);
                            api.SubAccounts.Add(new MEXCApi(subAccount.subAccount, "", ""));
                            config.ToJsonFile("Config.json");
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                txtLog.Text = ex.Message;
            }
            finally
            {
                ct.Dispose();
                ct = null;
                btnCreateSubAccount.Enabled = true;
            }
        }

        private async void btnListSunAccount_Click(object sender, EventArgs e)
        {
            if (cmbMEXCAccount.SelectedIndex < 0) return;
            int index = cmbMEXCAccount.SelectedIndex;
            MasterMEXCApi api = config.MasteMexcApis[index];

            var MexcService = GetMexcService(api.MasterAccount.ApiKey, api.MasterAccount.ApiSecret);
            btnListSunAccount.Enabled = false;
            try
            {
                // Get SubAccount List
                var response = await MexcService.SendSignedAsync("/api/v3/sub-account/list", HttpMethod.Get, new Dictionary<string, object>
                {
                    {"limit", 200},{"recvWindow", "5000"}
                });

                if (response != null)
                {
                    lvSubAccount.Items.Clear();
                    SubAccountsInfo? subAccounts = JsonConvert.DeserializeObject<SubAccountsInfo>(response);
                    if (subAccounts != null)
                    {
                        if (subAccounts.subAccounts == null)
                        {
                            throw new Exception(response);
                        }
                        //api.SubAccounts.Clear();
                        int i = 1;
                        foreach (var subAccount in subAccounts.subAccounts)
                        {
                            string[] strItems = new string[] { (i++).ToString(), subAccount.subAccount, "" };
                            ListViewItem item = new ListViewItem(strItems);
                            lvSubAccount.Items.Add(item);
                            //                             api.SubAccounts.Add(new MEXCApi(subAccount.subAccount,"",""));
                            //                             config.ToJsonFile("Config.json");
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                txtLog.Text = ex.Message;
            }
            finally
            {
                btnListSunAccount.Enabled = true;
            }

        }

        private async void btnGetSubAccountInfo_Click(object sender, EventArgs e)
        {
            if (cmbMEXCAccount.SelectedIndex < 0) return;
            int index = cmbMEXCAccount.SelectedIndex;
            MasterMEXCApi api = config.MasteMexcApis[index];
            ct = new CancellationTokenSource();
            btnGetSubAccountInfo.Enabled = false;
            try
            {
                foreach (ListViewItem item in lvSubAccount.CheckedItems)
                {
                    if (ct.Token.IsCancellationRequested) return;
                    MEXCApi subAccountApi = api.SubAccounts[item.Index];
                    if (subAccountApi.ApiKey == "")
                    {
                        item.SubItems[colSAInfo.Index].Text = "api 未创建";
                        break;
                    }
                    var MexcService = GetMexcService(subAccountApi.ApiKey, subAccountApi.ApiSecret);
                    var response = await MexcService.SendSignedAsync("/api/v3/account", HttpMethod.Get, new Dictionary<string, object> { { "recvWindow", "5000" } });

                    if (response != null)
                    {
                        AccountInfo? accountInfo = JsonConvert.DeserializeObject<AccountInfo>(response);
                        if (accountInfo != null)
                        {
                            if (accountInfo.balances == null)
                            {
                                throw new Exception(response);
                            }
                            string info = "余额: ";
                            foreach (var balance in accountInfo.balances)
                            {
                                if (balance.free != "0" || balance.locked != "0")
                                {
                                    info += $"{balance.asset}:{balance.free}|{balance.locked} ";
                                }
                            }
                            if (info == "余额: ")
                            {
                                item.SubItems[colSAInfo.Index].Text = info + "0";
                            }
                            else
                            {
                                item.SubItems[colSAInfo.Index].Text = info;
                            }

                        }
                    }
                }
            }
            catch (Exception ex)
            {
                txtLog.Text = ex.Message;
            }
            finally
            {
                ct.Dispose();
                ct = null;
                btnGetSubAccountInfo.Enabled = true;
            }
        }

        private async void btnCreateSubAccountApi_Click(object sender, EventArgs e)
        {
            // APIKey权限:
            // 账户读 / SPOT_ACCOUNT_READ,
            // 账户写 / SPOT_ACCOUNT_WRITE,
            // 现货交易信息读 / SPOT_DEAL_READ,
            // 现货交易信息写 / SPOT_DEAL_WRITE,
            // 合约账户信息读 / CONTRACT_ACCOUNT_READ,
            // 合约账户信息写 / CONTRACT_ACCOUNT_WRITE,
            // 合约交易信息读 / CONTRACT_DEAL_READ,
            // 合约交易信息写 / CONTRACT_DEAL_WRITE,
            // 资金划转读 / SPOT_TRANSFER_READ,
            // 资金划转写 / SPOT_TRANSFER_WRITE

            // Create SubAccount APIKey

            if (cmbMEXCAccount.SelectedIndex < 0) return;
            int index = cmbMEXCAccount.SelectedIndex;
            string ip = txtIp.Text;
            Regex regex = new Regex(@"^(25[0-5]|2[0-4][0-9]|[01]?[0-9][0-9]?)\.(25[0-5]|2[0-4][0-9]|[01]?[0-9][0-9]?)\.(25[0-5]|2[0-4][0-9]|[01]?[0-9][0-9]?)\.(25[0-5]|2[0-4][0-9]|[01]?[0-9][0-9]?)$");
            string[] ipLst = ip.Split(',');
            foreach (var ipItem in ipLst)
            {
                if (!regex.IsMatch(ipItem))
                {
                    MessageBox.Show("IP格式不正确");
                    return;
                }
            }
            ct = new CancellationTokenSource();
            btnCreateSubAccountApi.Enabled = false;
            MasterMEXCApi api = config.MasteMexcApis[index];
            var MexcService = GetMexcService(api.MasterAccount.ApiKey, api.MasterAccount.ApiSecret);
            try
            {
                foreach (ListViewItem item in lvSubAccount.CheckedItems)
                {
                    if (ct.Token.IsCancellationRequested) return;
                    string subAccount = item.SubItems[colSASubAccount.Index].Text;
                    var response = await MexcService.SendSignedAsync("/api/v3/sub-account/apiKey", HttpMethod.Post, new Dictionary<string, object> {
                {"subAccount", subAccount}, {"note", "test"}, {"permissions", "SPOT_ACCOUNT_READ"},{"ip", ip},{"recvWindow", "5000"} });

                    if (response != null)
                    {
                        SubAccountApiKeyInfo? subAccountApiKeyInfo = JsonConvert.DeserializeObject<SubAccountApiKeyInfo>(response);
                        if (subAccountApiKeyInfo != null)
                        {
                            if (subAccountApiKeyInfo.apiKey == null)
                            {
                                throw new Exception(response);
                            }
                            item.SubItems[colSAInfo.Index].Text = subAccountApiKeyInfo.apiKey;
                            api.SubAccounts[item.Index].ApiKey = subAccountApiKeyInfo.apiKey;
                            api.SubAccounts[item.Index].ApiSecret = subAccountApiKeyInfo.secretKey;
                            config.ToJsonFile("Config.json");
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                txtLog.Text = ex.Message;
            }
            finally
            {
                ct.Dispose();
                ct = null;
                btnCreateSubAccountApi.Enabled = true;
            }
        }

        private void btnCancelTask_Click(object sender, EventArgs e)
        {
            if (ct != null && !ct.IsCancellationRequested)
            {
                ct.Cancel();
            }
        }

        private void btnAddAccount_Click(object sender, EventArgs e)
        {
            MEXCApi? tmpApi = null;
            AddAccountForm fm = new()
            {
                AddAccountHandler = (api) => { tmpApi = api; },
                StartPosition = FormStartPosition.CenterParent
            };
            if (fm.ShowDialog() == DialogResult.OK)
            {
                if (tmpApi != null)
                {
                    MasterMEXCApi master = new(tmpApi);
                    config.MasteMexcApis.Add(master);
                    cmbMEXCAccount.Items.Add(master);
                    config.ToJsonFile("Config.json");
                }
            }
        }

        private void btnTransferFromSA_Click(object sender, EventArgs e)
        {

        }

        private void tsSACopyTable_Click(object sender, EventArgs e)
        {
            if (lvSubAccount.SelectedItems.Count > 0)
            {
                string text = "";
                foreach (ListViewItem item in lvSubAccount.SelectedItems)
                {
                    for (int i = 0; i < lvSubAccount.Columns.Count; i++)
                    {
                        text += item.SubItems[i].Text;
                        if (i != colSAInfo.Index)
                            text += '\t';
                    }
                    text += "\r\n";
                }
                Clipboard.SetText(text);
            }
        }

        private async void btnGetSAAddress_Click(object sender, EventArgs e)
        {
            if (cmbMEXCAccount.SelectedIndex < 0) return;
            int index = cmbMEXCAccount.SelectedIndex;
            MasterMEXCApi api = config.MasteMexcApis[index];
            ct = new CancellationTokenSource();
            btnGetSAAddress.Enabled = false;
            try
            {
                foreach (ListViewItem item in lvSubAccount.CheckedItems)
                {
                    if (ct.Token.IsCancellationRequested) return;
                    MEXCApi subAccountApi = api.SubAccounts[item.Index];
                    if (subAccountApi.ApiKey == "")
                    {
                        item.SubItems[colSAInfo.Index].Text = "api 未创建";
                        break;
                    }
                    var MexcService = GetMexcService(subAccountApi.ApiKey, subAccountApi.ApiSecret);
                    var response = await MexcService.SendSignedAsync("/api/v3/capital/deposit/address", HttpMethod.Get, new Dictionary<string, object> { 
                        { "coin", "OKB" },{ "network", "OKT" } });

                    if (response != null)
                    {
                        //AccountInfo? accountInfo = JsonConvert.DeserializeObject<AccountInfo>(response);
                        item.SubItems[colSAInfo.Index].Text = response;
                    }
                }
            }
            catch (Exception ex)
            {
                txtLog.Text = ex.Message;
            }
            finally
            {
                ct.Dispose();
                ct = null;
                btnGetSAAddress.Enabled = true;
            }
        }
    }
}