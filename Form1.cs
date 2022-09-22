using DevExpress.Utils.Extensions;
using DevExpress.XtraPrinting;
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

namespace ShopList
{
    public partial class frmMain : Form
    {
        string yol = "ShopList.Txt";
        
        
        public frmMain()
        {
            if (!File.Exists(yol))
            { File.Create(yol); }
            
            InitializeComponent();
            string[] former = File.ReadAllLines(yol).ToArray();
            
            foreach (string s in former)
            {
                lstBox.Items.Add(s);
            }
            
            

        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            lstBox.Items.Add(textEdit1.Text);
            string[] str = new string[lstBox.Items.Count];
            for(int i=0; i<lstBox.Items.Count;i++)
            {
                str[i] = lstBox.Items[i].ToString();
                
            }
            File.WriteAllLines(yol, str);
            textEdit1.Text = string.Empty;

        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            lstBox.Items.Remove(lstBox.SelectedItem);
            string[] str = new string[lstBox.Items.Count];
            for (int i = 0; i < lstBox.Items.Count; i++)
            {
                str[i] = lstBox.Items[i].ToString();

            }
            File.WriteAllLines(yol, str);

        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            lstBox.SetItemValue(textEdit1.Text,lstBox.SelectedIndex);
            string[] str = new string[lstBox.Items.Count];
            for (int i = 0; i < lstBox.Items.Count; i++)
            {
                str[i] = lstBox.Items[i].ToString();

            }
            File.WriteAllLines(yol, str);
        }

        private void btnComplete_Click(object sender, EventArgs e)
        {
            int s = lstBox.ItemCount;
            for(int i=0; i<s; i++)
            {
               lstBox.Items.RemoveAt(0);
            }
            File.WriteAllText(yol, String.Empty);
        }

        private void lstBox_ItemCheck(object sender, DevExpress.XtraEditors.Controls.ItemCheckEventArgs e)
        {
            
        }
    }

   
}
