using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Text.RegularExpressions;

namespace DiagramsParse
{
    public partial class Diagrams : Form
    {
        List<string> txt;
        LogParser LogParser = new LogParser();

        public Diagrams()
        {
            InitializeComponent();
            txt = LogParser.ReadLog("D:/2019-04-16.log");
            txt = LogParser.FindWorkSections(txt);           
        }
        public void MakeDiagram()
        {
            int time = 8;
            for (int i = 0; i < 10; i++)
            {
                
                    chart1.Series[0].Points.AddXY($"{time}.00-{time+1}.00", 1);
                
                time++;
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {

        }

        private void Diagrams_Load(object sender, EventArgs e)
        {

        }

        private void chart1_Click(object sender, EventArgs e)
        {

        }
    }
}

