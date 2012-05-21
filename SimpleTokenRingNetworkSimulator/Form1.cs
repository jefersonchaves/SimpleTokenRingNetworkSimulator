using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Threading.Tasks;
using SimpleTokenRingNetworkSimulator.Core;
using System.Net;
using System.Threading;

namespace SimpleTokenRingNetworkSimulator
{
    public partial class Form1 : Form
    {
        private TokenRingNetworkSimulator tokenRingNetworkSimulator;
        private CancellationTokenSource cancellationTokenSource;
        private Task startTokenRingSimulatorTask;

        private delegate void MessageReceived(SimpleTokenRingNetworkSimulator.Core.Message message);
        private delegate void DuplicateTokenReceived(SimpleTokenRingNetworkSimulator.Core.Message message);
        private delegate void TokenHidden(SimpleTokenRingNetworkSimulator.Core.Message message);

        public Form1()
        {
            InitializeComponent();
        }

        private void btnStart_Click(object sender, EventArgs e)
        {
            if (ckBxIsTokenManager.Checked && !rbtnNextHop2.Checked)
            {
                DialogResult dialogResult = MessageBox.Show("Are you sure this is the token manager? Usually the token manager is the first hop.", "Are you sure this is the token manager?", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2);
                if (dialogResult == System.Windows.Forms.DialogResult.No)
                    ckBxIsTokenManager.Checked = false;
                else if (dialogResult == System.Windows.Forms.DialogResult.Cancel)
                    return;
            }

            TransitionFormControls(true);

            bool isTokenManager = ckBxIsTokenManager.Checked;
            IPEndPoint hop1Config = new IPEndPoint(IPAddress.Parse(maskTbxIPNextHop1.Text), (int)numUpDwPortNextHop1.Value);
            IPEndPoint hop2Config = new IPEndPoint(IPAddress.Parse(maskTbxIPNextHop2.Text), (int)numUpDwPortNextHop2.Value);
            IPEndPoint hop3Config = new IPEndPoint(IPAddress.Parse(maskTbxIPNextHop3.Text), (int)numUpDwPortNextHop3.Value);
            HopNumbers nextHopNumber = rbtnNextHop1.Checked ? HopNumbers.One : rbtnNextHop2.Checked ? HopNumbers.Two : HopNumbers.Three;

            tokenRingNetworkSimulator = new TokenRingNetworkSimulator(isTokenManager, hop1Config, hop2Config, hop3Config, nextHopNumber);
            cancellationTokenSource = new CancellationTokenSource();
            CancellationToken cancellationToken = cancellationTokenSource.Token;

            tokenRingNetworkSimulator.MessageReceived += tokenRingNetworkSimulator_MessageReceived;
            tokenRingNetworkSimulator.DuplicateTokenReceived += tokenRingNetworkSimulator_DuplicateTokenReceived;
            tokenRingNetworkSimulator.TokenHidden += tokenRingNetworkSimulator_TokenHidden;

            startTokenRingSimulatorTask = Task.Factory.StartNew(() => tokenRingNetworkSimulator.Start(cancellationToken), cancellationToken);
        }

        private void tokenRingNetworkSimulator_MessageReceived(SimpleTokenRingNetworkSimulator.Core.Message message)
        {
            if (this.InvokeRequired)
            {
                MessageReceived messageReceived = new MessageReceived(tokenRingNetworkSimulator_MessageReceived);
                this.Invoke(messageReceived, new object[] { message });
            }
            else
            {
                string formattedMessage = String.Format("Message received from: {0}:{1} to: {2}:{3} Message: {4}.{5}", message.SenderEndPoint.Address, message.SenderEndPoint.Port, message.ReceiverEndPoint.Address, message.ReceiverEndPoint.Port, message.Type.ToString(), Environment.NewLine);
                tbxLog.AppendText(formattedMessage);
            }
        }

        private void tokenRingNetworkSimulator_DuplicateTokenReceived(SimpleTokenRingNetworkSimulator.Core.Message message)
        {
            if (this.InvokeRequired)
            {
                DuplicateTokenReceived duplicateTokenReceived = new DuplicateTokenReceived(tokenRingNetworkSimulator_DuplicateTokenReceived);
                this.Invoke(duplicateTokenReceived, new object[] { message });
            }
            else
            {
                string formattedMessage = String.Format("Duplicate token received from: {0}:{1}.{2}", message.SenderEndPoint.Address, message.SenderEndPoint.Port, Environment.NewLine);
                tbxLog.AppendText(formattedMessage);
            }
        }

        private void tokenRingNetworkSimulator_TokenHidden(SimpleTokenRingNetworkSimulator.Core.Message message)
        {
            if (this.InvokeRequired)
            {
                TokenHidden receivedTokenHidden = new TokenHidden(tokenRingNetworkSimulator_TokenHidden);
                this.Invoke(receivedTokenHidden, new object[] { message });
            }
            else
            {
                string formattedMessage = String.Format("Hidden token received from: {0}:{1}.{2}", message.SenderEndPoint.Address, message.SenderEndPoint.Port, Environment.NewLine);
                tbxLog.AppendText(formattedMessage);
            }
        }

        private void btnStop_Click(object sender, EventArgs e)
        {
            cancellationTokenSource.Cancel();
            try
            {
                startTokenRingSimulatorTask.Wait();
                AggregateException exception = startTokenRingSimulatorTask.Exception;
            }
            catch (AggregateException aggEx)
            {
                if (!startTokenRingSimulatorTask.IsCanceled)
                    MessageBox.Show(String.Format("Error: {0}.", aggEx), "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                startTokenRingSimulatorTask.Dispose();
                cancellationTokenSource.Dispose();
                tokenRingNetworkSimulator = null;

            }
            TransitionFormControls(false);
        }

        private void btnChooseFileSend_Click(object sender, EventArgs e)
        {
            using (OpenFileDialog openFileDialog = new OpenFileDialog())
            {
                openFileDialog.CheckFileExists = true;
                openFileDialog.CheckPathExists = true;
                openFileDialog.AddExtension = true;
                openFileDialog.Multiselect = false;
                openFileDialog.SupportMultiDottedExtensions = true;
                openFileDialog.Title = "Choose a file to send to station";

                DialogResult openFileDialogResult = openFileDialog.ShowDialog();

                if (openFileDialogResult == System.Windows.Forms.DialogResult.OK)
                    txtSendFile.Text = openFileDialog.FileName;
                else if (openFileDialogResult != System.Windows.Forms.DialogResult.Cancel)
                    txtSendFile.Clear();

            }
        }

        private void btnSendFile_Click(object sender, EventArgs e)
        {
            if (!String.IsNullOrEmpty(txtSendFile.Text))
            {
                tokenRingNetworkSimulator.AddFileToSend(new System.IO.FileInfo(txtSendFile.Text), GetSelectedHopNumberToSendFile());
                txtSendFile.Clear();
            }
            else
                MessageBox.Show("Select a file to send first please.", "File not selected.", MessageBoxButtons.OK, MessageBoxIcon.Warning);
        }

        private HopNumbers GetSelectedHopNumberToSendFile()
        {
            if (rBtnChooseStationSendFile1.Checked)
                return HopNumbers.One;
            else if (rBtnChooseStationSendFile2.Checked)
                return HopNumbers.Two;
            else
                return HopNumbers.Three;
        }

        private void TransitionFormControls(bool started)
        {
            btnStart.Enabled = !started;
            btnStop.Enabled = started;
            gpBxSendFile.Enabled = started;
            gpBxNextHop.Enabled = !started;
            ckBxIsTokenManager.Enabled = !started;
            btnGenToken.Enabled = started;
            btnHideNextToken.Enabled = started;
        }

        private void tbxLog_TextChanged(object sender, EventArgs e)
        {
            tbxLog.SelectionStart = tbxLog.TextLength;
            tbxLog.ScrollToCaret();
        }

        private void btnGenToken_Click(object sender, EventArgs e)
        {
            tokenRingNetworkSimulator.SendToken();
        }

        private void btnHideNextToken_Click(object sender, EventArgs e)
        {
            tokenRingNetworkSimulator.HideToken();
        }
    }
}
