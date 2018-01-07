using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.IO;

namespace RegSide
{

    public partial class Form2 : Form
    {
        String[] dict ={"A", "B", "C", "D", "E", "F", "G", "H", "I", "J", "K", "L", "M", "N", "O", "P", "Q", "R", "S", "T", "U", "V", "W",
        "Y", "Z", "a", "b", "c", "d", "e", "f", "g", "h", "i", "j", "k", "l", "m", "n", "o", "p", "q", "r", "s", "t", "u", "v", "w", "y",
        "z", "0", "1", "2", "3", "4", "5", "6", "7", "8", "9"};

        String[] amyList = { "0", "1", "2", "3", "4", "5", "6", "7", "8", "9", "A", "B", "C", "D", "E", "F", "G", "H", "I", "J", "K", "L",
            "M", "N", "O", "P", "Q", "R", "S", "T", "U", "V", "W", "Y", "Z" };

        String[] serverDPList = {
                "116.10.184.172|7021|摆摊电信4线shiqi.so", "116.10.184.238|7022|石器电信5线shiqi.so",
                "116.10.184.235|9065|石器电信6线shiqi.so", "116.10.184.172|9067|石器电信7线shiqi.so",
                "116.10.184.238|9069|石器电信8线shiqi.so", "116.10.184.237|9071|石器电信9线shiqi.so",
                "116.10.184.141|9073|挂机 10专线shiqi.so", "116.10.184.160|9068|挂机 11专线shiqi.so"
        };

        String[] serverXZList =
        {
            "摆摊电信4线shiqi.so",
            "石器电信5线shiqi.so",
            "石器电信6线shiqi.so",
            "石器挂机7线shiqi.so",
            "石器电信8线shiqi.so",
            "石器电信9线shiqi.so",
            "挂机 10专线shiqi.so",
            "挂机 11专线shiqi.so",
        };

        //String[] serverXZList =
        //{
        //    "摆摊电信4线shiqi.so|116.10.184.172|7021",
        //    "石器电信5线shiqi.so|116.10.184.238|7022",
        //    "石器电信6线shiqi.so|116.10.184.235|9065",
        //    "石器挂机7线shiqi.so|116.10.184.172|9067",
        //    "石器电信8线shiqi.so|116.10.184.238|9069",
        //    "石器电信9线shiqi.so|116.10.184.237|9071",
        //    "挂机 10专线shiqi.so|116.10.184.141|9073",
        //    "挂机 11专线shiqi.so|116.10.184.160|9068",
        //};

        String captionHDSrc = "caption_HD_";
        String TeammateHDSrc = "Teammate_HD_";
        String captionYPSrc = "caption_YP_";
        String TeammateYPSrc = "Teammate_YP_";
        String iniFile = "ProcessIni.ini";
        String iniKeySequeneIndex = "SequeneDPIndex";
        String iniKeyServerIndex = "ServerDPIndex";
        String iniKeyXZServerIndex = "ServerXZIndex";
        String iniSectionName = "ini";
        /*
         * 1. Generate Account, Password, Safecode
         * 2. Create DP data.txt
         * 3. XZ data.txt
         */
        public Form2()
        {
            InitializeComponent();
        }

        private void Form2_Load(object sender, EventArgs e)
        {
            //40倍数
            txtNumber.Text = "120";
        }

        private void btnGenerate_Click(object sender, EventArgs e)
        {
            if (!rbHD.Checked && !rbYP.Checked)
            {
                MessageBox.Show("check one!");
                return;
            }
            GenerateAccountList();
        }

        private void GenerateAccountList()
        {
            /*
             * DP Account, 40 account index +1
             * DP Server, 5 account then server index +1
             * XZ Loop, 1 +1
             */
            int sequeneDPIndex = 0;
            int serverDPIndex = 0;
            int serverXZIndex = 0;
            RetrieveIniIndex(ref sequeneDPIndex, ref serverDPIndex, ref serverXZIndex);
            if (sequeneDPIndex > 0) sequeneDPIndex += 1;
            if ((serverDPList.Length - 1) == serverDPIndex) serverDPIndex = 0;
            else serverDPIndex += 1;
            if ((serverXZList.Length - 1) == serverXZIndex) serverXZIndex = 0;
            else serverXZIndex += 1;

            int total = 0;
            int.TryParse(txtNumber.Text.Trim(), out total);
            List<NewAccount> lstAccounts = new List<NewAccount>();

            for (int i = 0; i< total; i++)
            {
                NewAccount account = new NewAccount();
                account.Account = Generate();
                account.Password = Generate();
                account.SafeCode = Generate();

                //Sequence
                if (i == 0)
                {
                    if (rbHD.Checked) account.DPScript = String.Format("{0}{1}.txt", captionHDSrc, sequeneDPIndex);
                    else if (rbYP.Checked) account.DPScript = String.Format(captionYPSrc, sequeneDPIndex);
                }
                else if((i % 40) == 0)
                {
                    sequeneDPIndex += 1;
                    if (rbHD.Checked) account.DPScript = String.Format("{0}{1}.txt", captionHDSrc, sequeneDPIndex);
                    else if (rbYP.Checked) account.DPScript = String.Format(captionYPSrc, sequeneDPIndex);
                }
                else if ((i % 5) == 0)
                {
                    if (rbHD.Checked) account.DPScript = String.Format("{0}{1}.txt", captionHDSrc, sequeneDPIndex);
                    else if (rbYP.Checked) account.DPScript = String.Format(captionYPSrc, sequeneDPIndex);
                }
                else 
                {
                    if (rbHD.Checked) account.DPScript = String.Format("{0}{1}.txt", TeammateHDSrc, sequeneDPIndex);
                    else if (rbYP.Checked) account.DPScript = String.Format(TeammateYPSrc, sequeneDPIndex);
                }
                //Server
                if ((i % 5) == 0 && i != 0)
                {
                    if ((serverDPList.Length - 1) == serverDPIndex) serverDPIndex = 0;
                    else serverDPIndex += 1;
                }
               
                account.DPServer = serverDPList[serverDPIndex];

                if ((i % 10) == 0 && i != 0)
                {
                    account.BreakFlag = 1;
                }
                else
                {
                    account.BreakFlag = 0;
                }
                account.XZServerInfo = serverXZList[serverXZIndex];
                if ((serverXZList.Length - 1) == serverXZIndex) serverXZIndex = 0;
                else serverXZIndex += 1;


                account.DpSequenceIndex = sequeneDPIndex;
                account.DpServerIndex = serverDPIndex;
                account.XZServerIndex = serverXZIndex;
                lstAccounts.Add(account);
            }

            WriteProcessIni(sequeneDPIndex.ToString(), serverDPIndex.ToString(), serverXZIndex.ToString());
            CreateFile(lstAccounts);

            MessageBox.Show("Done");
        }

        private void CreateFile(List<NewAccount> lstNewAccount)
        {
            String fileFolder = Path.Combine(System.IO.Directory.GetCurrentDirectory(), "Output");
            if (!Directory.Exists(fileFolder))
            {
                Directory.CreateDirectory(fileFolder);
            }

            String dpFile = Path.Combine(fileFolder, "startDP.txt");
            String xzFile = String.Empty;
            int i = 1;
            foreach(NewAccount act in lstNewAccount)
            {
                String tmpDP = String.Format("{0}|{1}|{2}|{3}|{4}", act.Account, act.Password, act.SafeCode, act.DPScript, act.DPServer);
                String tmpXZ = String.Format("set 登入帐号,{0}|{1}|{2}|人物一|NW_2\\1.队员.xzs|default.set|{3}",
                    act.Account, act.Password, act.SafeCode,act.XZServerInfo);

                if (act.BreakFlag == 1)
                {
                    dpFile = Path.Combine(fileFolder, String.Format("{0}.txt",DateTime.Now.ToFileTimeUtc()));
                }

                if (!File.Exists(dpFile))
                {
                    File.WriteAllText(dpFile, tmpDP + Environment.NewLine, Encoding.UTF8);
                }
                else
                {
                    File.AppendAllText(dpFile, tmpDP + Environment.NewLine, Encoding.UTF8);
                }
               

                xzFile = Path.Combine(fileFolder, String.Format("{0}_{1}.txt",i, act.XZServerIndex));
                if (!File.Exists(xzFile))
                {
                    File.WriteAllText(xzFile, tmpXZ + Environment.NewLine, Encoding.UTF8);
                }
                else
                {
                    File.AppendAllText(xzFile, tmpXZ + Environment.NewLine, Encoding.UTF8);
                }

                if (i == 40) i = 1;
                else i += 1;
            }

        }

        private void RetrieveIniIndex(ref int sequeneDPIndex, ref int serverDPIndex, ref int serverXZIndex)
        {
            string iniValueDPSequenceIndex = String.Empty;
            string iniValueDPServerIndex = String.Empty;
            string iniValueXZServerIndex = String.Empty;
            GetProcessFromIni(ref iniValueDPSequenceIndex, ref iniValueDPServerIndex, ref iniValueXZServerIndex);

            int.TryParse(iniValueDPSequenceIndex, out sequeneDPIndex);
            int.TryParse(iniValueDPServerIndex, out serverDPIndex);
            int.TryParse(iniValueXZServerIndex, out serverXZIndex);
        }

        private String Generate()
        {
            String str = String.Empty;
            int num = GetRandomNumberForGenerate();
            for (int i = 0; i < num; i++)
            {
                String tmp = GetStrFromDict();
                str += tmp;
            }
            return str;
        }

        private String GetStrFromDict()
        {
            String str = String.Empty;
            int num;
            num = GenerateRandomNumber(0, dict.Length);
            str = dict[num];
            return str;
        }

        private int GetRandomNumberForGenerate()
        {
            int num;
            num = GenerateRandomNumber(6, 12);
            return num;
        }

        private int GenerateRandomNumber(int start, int end)
        {
            long tick = DateTime.Now.Ticks;
            Random ran = new Random((int)(tick & 0xffffffffL) | (int)(tick >> 32));
            System.Threading.Thread.Sleep(10);

            int iResult;
            int iUp = end;
            int iDown = start;
            iResult = ran.Next(iDown, iUp);

            return iResult;
        }

        private void GetProcessFromIni(ref string iniValueDPSequenceIndex, ref string iniValueDPServerIndex, ref string iniValueXZServerIndex)
        {
            String iniPath = Path.Combine(System.IO.Directory.GetCurrentDirectory(), iniFile);
            if (!File.Exists(iniPath))
            {
                WriteProcessIni(iniValueDPSequenceIndex, iniValueDPServerIndex, iniValueXZServerIndex);
            }

            iniValueDPSequenceIndex = INIOperationClass.INIGetStringValue(iniPath, iniSectionName, iniKeySequeneIndex, "0");
            iniValueDPServerIndex = INIOperationClass.INIGetStringValue(iniPath, iniSectionName, iniKeyServerIndex, "0");
            iniValueXZServerIndex = INIOperationClass.INIGetStringValue(iniPath, iniSectionName, iniKeyXZServerIndex, "0");
        }

        private void WriteProcessIni(string iniValueDPSequenceIndex, string iniValueDPServerIndex, string iniValueXZServerIndex)
        {
            String iniPath = Path.Combine(System.IO.Directory.GetCurrentDirectory(), iniFile);
            if (!File.Exists(iniPath))
            {
                using (File.Create(iniPath))
                {
                    INIOperationClass.INIWriteItems(iniPath, iniSectionName, iniKeySequeneIndex);
                    INIOperationClass.INIWriteItems(iniPath, iniSectionName, iniKeyServerIndex);
                    INIOperationClass.INIWriteItems(iniPath, iniSectionName, iniKeyXZServerIndex);

                    iniValueDPSequenceIndex = "0";
                    iniValueDPServerIndex = "0";
                    iniValueXZServerIndex = "0";
                }
            }

            INIOperationClass.INIWriteValue(iniPath, iniSectionName, iniKeySequeneIndex, iniValueDPSequenceIndex);
            INIOperationClass.INIWriteValue(iniPath, iniSectionName, iniKeyServerIndex, iniValueDPServerIndex);
            INIOperationClass.INIWriteValue(iniPath, iniSectionName, iniKeyXZServerIndex, iniValueXZServerIndex);


        }
    }
}
