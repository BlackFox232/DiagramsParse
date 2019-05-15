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
            
            int cnt = 0;
            int[][] a;
            List<DateTime> dt = new List<DateTime>();
            
            txt = LogParser.ReadLog("D:/2019-04-16.log");
            txt = LogParser.FindWorkSections(txt);
            a = LogParser.GetPoints(txt);

            richTextBox1.AppendText("OPENS" + "\n");

            foreach (var item in a[0])
            {
                richTextBox1.AppendText(cnt+$".Значение open: {item}" + "\n");
                cnt++;
            }

            cnt = 0;
            richTextBox1.AppendText("CLOSES" + "\n");

            foreach (var item in a[1])
            {
                richTextBox1.AppendText(cnt + $".Значение close: {item}" + "\n");
                cnt++;
            }

            cnt = 0;

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

        private void Form1_Load(object sender, EventArgs e)
        {

        }
    }
}
