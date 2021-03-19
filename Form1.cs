using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.IO;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace compilers
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            listview();
            textBox1.Visible = false;
            comboBox1.SelectedText = "scanner";
            comboBox1.Visible = false;
            

        }
        string code;
        string[] word = new string[1000];
        string[] num = new string[1000];
        int x = 0;
        int y = 0;
        private bool is_letter(char c)
        {
            if (c >= 'a' && c <= 'z' || c >= 'A' && c <= 'Z')
                return true;
            else return false;
        
        
        }
        private bool is_number(char c)
        {
            if (c >= '0'  && c <= '9' )
                return true;
            else return false;


        }

        private void listview()    //bta3t el listbox
        {
            // dataGridView1;
            listView1.Clear();
            listView1.View = View.Details;
            listView1.Columns.Add("token value", 200);
            listView1.Columns.Add("token type", 100);
           

            listView1.GridLines = true;
        }

        private void reset()
        {
            Application.Restart();
            richTextBox1.Clear();
            listview();
            button1.Enabled = true;
            button2.Enabled = true;
           
            Array.Clear(word,0,x+1);
            Array.Clear(num, 0, x + 1);
            code = "";
            x = 0;
            y = 0;
        }
        private void scan()
        {
            /*
             
             
             * de el function ely hatshta3'al feha 
             * kol kelma bete5azen fe array esmo word
             * 
             */



            string file_name = "output.txt";
           //string path= File.Create(file_name);
           StreamWriter sw = new StreamWriter(File.Create(file_name));
            
           // richTextBox1.Enabled = false;

           /* sw.Write("StartPositiwon");
            sw.Write(sw.NewLine);
            sw.Write("StartPositiwon");
            */
               // sw.Dispose();



            int i = 0;
           
            for (; i < code.Length; )//i++)

            {//law feh ay 7aga fel tiny de ana mesh katebha zawedha
                //if (code[i] == '\n' ) { i++; continue; }
                if (code[i] == ' ' ) { i++; continue; }
                if (code[i] == '+')//law feh idetifier na2sa kamlha || code[i] == '-' || code[i] == '*' || code[i] == '/' || code[i] == '<'

            {
                
                listView1.Items.Add(Convert.ToString(code[i]));
                listView1.Items[listView1.Items.Count - 1].SubItems.Add("PLUS");
                sw.Write(sw.NewLine);
                sw.Write("\n" + Convert.ToString(code[i]) + ",PLUS"); i++; continue;
            }

                if (code[i] == '-')// code[i] == '*' || code[i] == '/' || code[i] == '<'
                {

                    listView1.Items.Add(Convert.ToString(code[i]));
                    listView1.Items[listView1.Items.Count - 1].SubItems.Add("MINUS");
                    sw.Write(sw.NewLine);
                    sw.Write("\n" + Convert.ToString(code[i]) + ",MINUS"); i++; continue;
                }
                if (code[i] == '*')//  code[i] == '/' || code[i] == '<'
                {

                    listView1.Items.Add(Convert.ToString(code[i]));
                    listView1.Items[listView1.Items.Count - 1].SubItems.Add("MULT");
                    sw.Write(sw.NewLine);
                    sw.Write("\n" + Convert.ToString(code[i]) + ",MULT"); i++; continue;
                }

                if (code[i] == '/')//  code[i] == '/' || code[i] == '<'
                {

                    listView1.Items.Add(Convert.ToString(code[i]));
                    listView1.Items[listView1.Items.Count - 1].SubItems.Add("DIV");
                    sw.Write(sw.NewLine);
                    sw.Write("\n" + Convert.ToString(code[i]) + ",DIV"); i++; continue;
                }

                if (code[i] == '<')//  code[i] == '/' || code[i] == '<'
                {

                    listView1.Items.Add(Convert.ToString(code[i]));
                    listView1.Items[listView1.Items.Count - 1].SubItems.Add("LESSTHAN");
                    sw.Write(sw.NewLine);
                    sw.Write("\n" + Convert.ToString(code[i]) + ",LESSTHAN"); i++; continue;
                }

            if (code[i] == '=')
            {

                listView1.Items.Add(Convert.ToString(code[i]));
                listView1.Items[listView1.Items.Count - 1].SubItems.Add("EQUAL");
                sw.Write(sw.NewLine);
                sw.Write(Convert.ToString(code[i]) + ",EQUAL"); i++; continue;
            }
            if (code[i] == ';')
            {

                listView1.Items.Add(Convert.ToString(code[i]));
                listView1.Items[listView1.Items.Count - 1].SubItems.Add("SEMICOLON");
                sw.Write(sw.NewLine);
                sw.Write(Convert.ToString(code[i]) + ",SEMICOLON"); i++; continue;
            }
                if (code[i] == '(')
                {

                    listView1.Items.Add(Convert.ToString(code[i]));
                    listView1.Items[listView1.Items.Count - 1].SubItems.Add("OPENBRACKET");
                    sw.Write(sw.NewLine);
                    sw.Write(Convert.ToString(code[i]) + ",OPENBRACKET"); i++; continue;
                }

                if (code[i] == ')')
                {

                    listView1.Items.Add(Convert.ToString(code[i]));
                    listView1.Items[listView1.Items.Count - 1].SubItems.Add("CLOSEDBRACKET");
                    sw.Write(sw.NewLine);
                    sw.Write(Convert.ToString(code[i]) + ",CLOSEDBRACKET"); i++; continue;
                }
                if (code[i] == '{')//for comment
            {
                i++; if (i == code.Length) { MessageBox.Show("enter valid code please"); break; }
                    while (code[i]!='}')
                {
                    //word[x] += code[i];
                    i++; if (i == code.Length) { MessageBox.Show("enter valid code please"); break; }

                }
                i++;

                //listView1.Items.Add(word[x]);
                //listView1.Items[listView1.Items.Count - 1].SubItems.Add("comment");
                //sw.Write(sw.NewLine);
                //sw.Write(num[y] + ",comment");

            //    x++;
                continue;
                    //ehab
            }
            if (code[i] == ':')
            {
                if (code[i + 1] == '=')
                {
                    listView1.Items.Add(Convert.ToString(code[i]) + Convert.ToString(code[i+1]));
                    listView1.Items[listView1.Items.Count - 1].SubItems.Add("ASSIGN");
                    sw.Write(sw.NewLine);
                    sw.Write(":=" + ",ASSIGN");
                    i+=2; continue;
                }
            }

            if (is_letter(code[i]))
            {
                while (is_letter(code[i]) || is_number(code[i]) )
                {
                    if (is_number(code[i]))
                    {
                        MessageBox.Show("enter valid code please");
                        reset(); break; 
                    }
                    word[x] += code[i];
                    i++; if (i == code.Length) break;
                    
                }

                //e3ml hena el error check law feh identifier feh 7aga 3'lt aw kdas

                if (word[x] == "if"||word[x] == "then"||word[x] == "else"||word[x] == "end"||word[x] == "repeat"||word[x] == "until"||word[x] == "read"||word[x] == "write")
                {
                    listView1.Items.Add(word[x]);
                    listView1.Items[listView1.Items.Count - 1].SubItems.Add(word[x].ToUpper());
                    sw.Write(sw.NewLine);
                    sw.Write(word[x] + ","  +word[x].ToUpper() );
                }
               /* else if (word[x] == "IF" || word[x] == "THEN" || word[x] == "ELSE" || word[x] == "END" || word[x] == "REPEAT" || word[x] == "UNTIL" || word[x] == "READ" || word[x] == "WRITE")
                {
                    listView1.Items.Add(word[x]);
                    listView1.Items[listView1.Items.Count - 1].SubItems.Add(word[x]);
                    sw.Write(sw.NewLine);
                    sw.Write(word[x] + "," + word[x] );
                }*/
                else
                {

                    listView1.Items.Add(word[x]);
                    listView1.Items[listView1.Items.Count - 1].SubItems.Add("IDENTIFIER");
                    sw.Write(sw.NewLine);
                    sw.Write(word[x] + ",IDENTIFIER");
                }
                x++;
                continue;
            }
             if (is_number(code[i]))
            {


                while (is_letter(code[i]) || is_number(code[i]))
                {
                    if (is_letter(code[i]))
                    {
                        MessageBox.Show("enter valid code please");
                        reset(); break;
                    }
                    num[y] += code[i];
                    i++; if (i == code.Length) break;

                }

                listView1.Items.Add(num[y]);
                listView1.Items[listView1.Items.Count - 1].SubItems.Add("NUMBER");
                sw.Write(sw.NewLine);
                sw.Write(num[y] + ",NUMBER");
               
                y++;
                continue;

            }

             //i++;
             MessageBox.Show("enter valid code please");
             reset();
             
            }

           sw.Dispose();
           
        }


        private void button1_Click(object sender, EventArgs e)
        {
            code = richTextBox1.Text;
            code = code.Replace("\n", " ");
            code = code.Replace("\r", " ");
            code = code.Replace("\t", " ");
            scan();
            button1.Enabled = false;
            button2.Enabled = false;
        }

        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void openFileDialog1_FileOk(object sender, CancelEventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            button2.Enabled = false;
            //button1.Enabled = false;
            OpenFileDialog openFileDialog1 = new OpenFileDialog
            {
                InitialDirectory = @"D:\",
                Title = "Browse Text Files",

                CheckFileExists = true,
                CheckPathExists = true,

                DefaultExt = "txt",
                Filter = "txt files (*.txt)|*.txt",
                FilterIndex = 2,
                RestoreDirectory = true,

                ReadOnlyChecked = true,
                ShowReadOnly = true
            };

            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                if (textBox1.Text != "")
                    textBox1.Text = openFileDialog1.FileName;

                code = File.ReadAllText(openFileDialog1.FileName);
                richTextBox1.Text = code;
            } 
          

        }

        private void button3_Click(object sender, EventArgs e)
        {
            // Application.Restart();    
            reset();
        }

        private void richTextBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            //if (comboBox1.SelectedItem.ToString() == "scanner") { button1.Text = "scan"; }
            //if (comboBox1.SelectedItem.ToString() == "parser") { button1.Text = "parse"; }
            //MessageBox.Show(comboBox1.SelectedItem.ToString());

        }
    }
}
