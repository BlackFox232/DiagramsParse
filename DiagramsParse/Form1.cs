using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Windows.Forms;

namespace DiagramsParse
{
    public partial class Form1 : Form
    {
        List<string> txt;
        LogParser LogParser = new LogParser();

        public Form1()
        {
            InitializeComponent();            
        }

        private void button1_Click(object sender, EventArgs e)
        {
            
            int cnt = 1;
            List<DateTime> dt = new List<DateTime>();
            
            txt = LogParser.ReadLog("D:/2019-04-16.log");
            txt = LogParser.FindWorkSections(txt);
            //LogParser.GetCalls(txt);
            foreach (var item in txt)
            {
                richTextBox1.AppendText(cnt+$". {item}"+"\n");
                cnt++;
            }

        }

        private void button2_Click(object sender, EventArgs e)
        {
            Diagrams diagrams = new Diagrams();
            //if (txt != null)
            //{
            //    txt.Clear();
            //}
            //txt = LogParser.ReadLog("D:/2019-04-16.log");
            //txt = LogParser.FindWorkSections(txt);           
            diagrams.MakeDiagram();
            diagrams.ShowDialog();           
        }
        
    }
}
