using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace RegSide
{
    public partial class Form1 : Form
    {
        List<NewAccount> lstAccount = new List<NewAccount>();
        
        public Form1()
        {
            InitializeComponent();

            LoadPage();
        }


        private void LoadPage()
        {
            NewAccount();
            LoadAccountList();
            //ChangePassword();

        }

        private void LoadAccountList()
        {
            String fileFolder = Path.Combine(System.IO.Directory.GetCurrentDirectory(), "Output");

            if (!Directory.Exists(fileFolder))
            {
                MessageBox.Show("Output Folder does not exist!");
                return;
            }

            DirectoryInfo dinfo = new DirectoryInfo(fileFolder);
            lstAccount.Add(new NewAccount() { Account= "123", Password="111111111111", SafeCode = "222222222222"});
            foreach (FileInfo f in dinfo.GetFiles())
            {
                String tmpFile = Path.Combine(fileFolder, f.Name);
                StreamReader sr = new StreamReader(tmpFile, Encoding.Default);
                String line;
                while ((line = sr.ReadLine()) != null)
                {
                    NewAccount account = new NewAccount();
                    String[] tmp = line.Split('|');
                    account.Account = tmp[0];
                    account.Password = tmp[1];
                    account.SafeCode = tmp[2];

                    lstAccount.Add(account);
                }
                break;

            }

           
            

        }

        private void NewAccount()
        {
            try
            {
                string url = "http://www.shiqi.so/register2.htm";
                wbPage.Navigate(url);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void ChangePassword()
        {
            try
            {
                string url = "http://www.shiqi.so/changepass.htm";
                wbPage.Navigate(url);


            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }


        private void wbPage_Navigated(object sender, WebBrowserNavigatedEventArgs e)
        {
            
        }

        private void wbPage_DocumentCompleted(object sender, WebBrowserDocumentCompletedEventArgs e)
        {
             CreateAccountInputValue();
            //ChangePasswordInputValue();
        }

        private void CreateAccountInputValue()
        {
            NewAccount account = new NewAccount();
            if(lstAccount.Count >= 1)
            {
                account = lstAccount[0];
            }
            wbPage.Document.GetElementById("name").SetAttribute("value", account.Account);
            wbPage.Document.GetElementById("pass").SetAttribute("value", account.Password);
            wbPage.Document.GetElementById("pass2").SetAttribute("value", account.Password);
            wbPage.Document.GetElementById("pass3").SetAttribute("value", account.SafeCode);
            wbPage.Document.GetElementById("pass4").SetAttribute("value", account.SafeCode);
            wbPage.Document.GetElementById("authinput").SetAttribute("value", "");
            Random ran = new Random();
            int RandKey = ran.Next(100000, 9999999);
            wbPage.Document.GetElementById("qqmsn").SetAttribute("value", RandKey.ToString());
            lstAccount.RemoveAt(0);
        }

        private void ChangePasswordInputValue()
        {
            wbPage.Document.GetElementById("id").SetAttribute("value", "");
            wbPage.Document.GetElementById("oldpass").SetAttribute("value", "xiaohuilili");
            wbPage.Document.GetElementById("oldpass2").SetAttribute("value", "LYJ074");
            wbPage.Document.GetElementById("pass").SetAttribute("value", "HS34243982C");
            wbPage.Document.GetElementById("pass2").SetAttribute("value", "HS34243982C");
            wbPage.Document.GetElementById("pass3").SetAttribute("value", "GHX086");
            wbPage.Document.GetElementById("pass4").SetAttribute("value", "GHX086");
            wbPage.Document.GetElementById("authinput").SetAttribute("value", "");
 
        }

      
    }
}
