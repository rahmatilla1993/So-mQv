using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AdvancedCompiler
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        const int rows = 30;
        private void Form1_Load(object sender, EventArgs e)
        {
            int row = 5;
            for (int i = 0; i < rows; i++)
            {
                dataGridView1.Rows.Add();
                dataGridView1.Rows[i].Cells[0].Value = row;
                row += 5;
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            int row = 0;
            int col = 2;

            dataGridView1.Rows[row].Cells[col++].Value = "COPY";
            dataGridView1.Rows[row].Cells[col++].Value = "START";
            dataGridView1.Rows[row].Cells[col++].Value = textBox1.Text;

            row++;
            col = 2;
            dataGridView1.Rows[row].Cells[col++].Value = "";
            dataGridView1.Rows[row].Cells[col++].Value = "STL";
            dataGridView1.Rows[row].Cells[col++].Value = "BUTUN";

            row++;
            col = 2;
            dataGridView1.Rows[row].Cells[col++].Value = "BOSHLA";
            dataGridView1.Rows[row].Cells[col++].Value = "JSUB";
            dataGridView1.Rows[row].Cells[col++].Value = "#QAYTA";

            row++;
            col = 2;
            dataGridView1.Rows[row].Cells[col++].Value = "";
            dataGridView1.Rows[row].Cells[col++].Value = "+LDA";
            dataGridView1.Rows[row].Cells[col++].Value = "UZUNLIK";

            row++;
            col = 2;
            dataGridView1.Rows[row].Cells[col++].Value = "BOSH";
            dataGridView1.Rows[row].Cells[col++].Value = "JSUB";
            dataGridView1.Rows[row].Cells[col++].Value = "WRREC";

            row++;
            col = 2;
            dataGridView1.Rows[row].Cells[col++].Value = "ENDFIL";
            dataGridView1.Rows[row].Cells[col++].Value = "J";
            dataGridView1.Rows[row].Cells[col++].Value = "@CLOOP";

            row++;
            col = 2;
            dataGridView1.Rows[row].Cells[col++].Value = "UZUNLIK";
            dataGridView1.Rows[row].Cells[col++].Value = "STA";
            dataGridView1.Rows[row].Cells[col++].Value = "UZUNLIK";

            row++;
            col = 2;
            dataGridView1.Rows[row].Cells[col++].Value = "";
            dataGridView1.Rows[row].Cells[col++].Value = "+JSUB";
            dataGridView1.Rows[row].Cells[col++].Value = "WRREC";

            row++;
            col = 2;
            dataGridView1.Rows[row].Cells[col++].Value = "EOF";
            dataGridView1.Rows[row].Cells[col++].Value = "LDL";
            dataGridView1.Rows[row].Cells[col++].Value = "#7";

            row++;
            col = 2;
            dataGridView1.Rows[row].Cells[col++].Value = "UCH";
            dataGridView1.Rows[row].Cells[col++].Value = "RSUB";
            dataGridView1.Rows[row].Cells[col++].Value = "BUTUN";

            row++;
            col = 2;
            dataGridView1.Rows[row].Cells[col++].Value = "";
            dataGridView1.Rows[row].Cells[col++].Value = "=C'WEBS'";
            dataGridView1.Rows[row].Cells[col++].Value = "";

            row++;
            col = 2;
            dataGridView1.Rows[row].Cells[col++].Value = "BUTUN";
            dataGridView1.Rows[row].Cells[col++].Value = "WORD";
            dataGridView1.Rows[row].Cells[col++].Value = "363";

            row++;
            col = 2;
            dataGridView1.Rows[row].Cells[col++].Value = "BUFFER";
            dataGridView1.Rows[row].Cells[col++].Value = "RESW";
            dataGridView1.Rows[row].Cells[col++].Value = "193";

            row++;
            col = 2;
            dataGridView1.Rows[row].Cells[col++].Value = "";
            dataGridView1.Rows[row].Cells[col++].Value = "+STX";
            dataGridView1.Rows[row].Cells[col++].Value = "#153";

            row++;
            col = 2;
            dataGridView1.Rows[row].Cells[col++].Value = "QAYTA";
            dataGridView1.Rows[row].Cells[col++].Value = "RESB";
            dataGridView1.Rows[row].Cells[col++].Value = "325";

            row++;
            col = 2;
            dataGridView1.Rows[row].Cells[col++].Value = "";
            dataGridView1.Rows[row].Cells[col++].Value = "LDX";
            dataGridView1.Rows[row].Cells[col++].Value = "BOSH";

            row++;
            col = 2;
            dataGridView1.Rows[row].Cells[col++].Value = "RLOOP";
            dataGridView1.Rows[row].Cells[col++].Value = "+COMP";
            dataGridView1.Rows[row].Cells[col++].Value = "BOSH,X";

            row++;
            col = 2;
            dataGridView1.Rows[row].Cells[col++].Value = "";
            dataGridView1.Rows[row].Cells[col++].Value = "JEQ";
            dataGridView1.Rows[row].Cells[col++].Value = "@EXIT";

            row++;
            col = 2;
            dataGridView1.Rows[row].Cells[col++].Value = "KIRIT";
            dataGridView1.Rows[row].Cells[col++].Value = "STCH";
            dataGridView1.Rows[row].Cells[col++].Value = "BUFFER,X";

            row++;
            col = 2;
            dataGridView1.Rows[row].Cells[col++].Value = "KATUZ";
            dataGridView1.Rows[row].Cells[col++].Value = "+JLT";
            dataGridView1.Rows[row].Cells[col++].Value = "#RLOOP";

            row++;
            col = 2;
            dataGridView1.Rows[row].Cells[col++].Value = "";
            dataGridView1.Rows[row].Cells[col++].Value = "STX";
            dataGridView1.Rows[row].Cells[col++].Value = "UZUNLIK";

            row++;
            col = 2;
            dataGridView1.Rows[row].Cells[col++].Value = "EXIT";
            dataGridView1.Rows[row].Cells[col++].Value = "BYTE";
            dataGridView1.Rows[row].Cells[col++].Value = "X'F1A'";

            row++;
            col = 2;
            dataGridView1.Rows[row].Cells[col++].Value = "";
            dataGridView1.Rows[row].Cells[col++].Value = "WORD";
            dataGridView1.Rows[row].Cells[col++].Value = "256";

            row++;
            col = 2;
            dataGridView1.Rows[row].Cells[col++].Value = "CLOOP";
            dataGridView1.Rows[row].Cells[col++].Value = "LDX";
            dataGridView1.Rows[row].Cells[col++].Value = "BOSH";

            row++;
            col = 2;
            dataGridView1.Rows[row].Cells[col++].Value = "WRREC";
            dataGridView1.Rows[row].Cells[col++].Value = "JEQ";
            dataGridView1.Rows[row].Cells[col++].Value = "@WLOOP";

            row++;
            col = 2;
            dataGridView1.Rows[row].Cells[col++].Value = "";
            dataGridView1.Rows[row].Cells[col++].Value = "+LDCH";
            dataGridView1.Rows[row].Cells[col++].Value = "BUFFER,X";

            row++;
            col = 2;
            dataGridView1.Rows[row].Cells[col++].Value = "WLOOP";
            dataGridView1.Rows[row].Cells[col++].Value = "TIX";
            dataGridView1.Rows[row].Cells[col++].Value = "UZUNLIK";

            row++;
            col = 2;
            dataGridView1.Rows[row].Cells[col++].Value = "";
            dataGridView1.Rows[row].Cells[col++].Value = "JLT";
            dataGridView1.Rows[row].Cells[col++].Value = "WLOOP";

            row++;
            col = 2;
            dataGridView1.Rows[row].Cells[col++].Value = "";
            dataGridView1.Rows[row].Cells[col++].Value = "BYTE";
            dataGridView1.Rows[row].Cells[col++].Value = "X'125'";

            row++;
            col = 2;
            dataGridView1.Rows[row].Cells[col++].Value = "OUTPUT";
            dataGridView1.Rows[row].Cells[col++].Value = "END";
            dataGridView1.Rows[row].Cells[col++].Value = "BOSH";

        }

        Kompilyator kompilyator = new Kompilyator();
        private void Create(int n)
        {
            for (int i = n; i < rows - 1; i++)
            {
                if (dataGridView1.Rows[i].Cells[2].Value == null)
                    dataGridView1.Rows[i].Cells[2].Value = "";

                else if (dataGridView1.Rows[i].Cells[4].Value == null)
                    dataGridView1.Rows[i].Cells[4].Value = "";

                else if (dataGridView1.Rows[i].Cells[4].Value.ToString().StartsWith("="))
                {
                    for (int j = n; j < rows - 1; j++)
                    {
                        if (dataGridView1.Rows[j].Cells[3].Value.ToString().StartsWith("="))
                        {
                            dataGridView1.Rows[j].Cells[3].Value = dataGridView1.Rows[i].Cells[4].Value.ToString();
                            break;
                        }
                    }
                }
            }

            for (int i = n; i < rows - 1; i++)
            {
                kompilyator.SetListsElements(dataGridView1.Rows[i].Cells[2].Value.ToString(), dataGridView1.Rows[i].Cells[3].Value.ToString());
            }

            for (int i = n; i < rows - 1; i++)
            {
                string str = kompilyator.GetAddress(dataGridView1.Rows[i].Cells[4].Value.ToString(), dataGridView1.Rows[i].Cells[3].Value.ToString());
                for (int j = str.Length; j < 4; j++)
                    str = "0" + str;
                dataGridView1.Rows[i + 1].Cells[1].Value = str;
            }
            int k = 0;
            for (int i = n; i < rows - 1; i++)
            {
                dataGridView1.Rows[i].Cells[5].Value = kompilyator.CreateObjectCode(dataGridView1.Rows[i].Cells[3].Value.ToString(),
                    dataGridView1.Rows[i].Cells[4].Value.ToString(), ++k) ;
            }
        }
        private void button2_Click(object sender, EventArgs e)
        {
            kompilyator.RemoveListsElements();
            for (int i = 1; i < rows - 1; i++)
            {
                dataGridView1.Rows[i].Cells[1].Value = "";
                dataGridView1.Rows[i].Cells[5].Value = "";
            }
            string s = textBox1.Text;
            for (int i = s.Length; i < 4; i++)
                s = "0" + s;

            int n = 0;
            for (int i = 0; i < rows - 1; i++)
            {
                try
                {
                    if (dataGridView1.Rows[rows - 1].Cells[4].Value.ToString().Equals(dataGridView1.Rows[i].Cells[2].Value.ToString()))
                    {
                        kompilyator.SetFirstAddress(textBox1.Text);
                        dataGridView1.Rows[i].Cells[1].Value = s;
                        n = i;
                        break;
                    }
                }
                catch(Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
            Create(n);
        }
    }
}
