using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Threading;

namespace deditor
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }


        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void aboutLolToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MessageBox.Show("thus was mad in c# lol and stuff by daniel overwatchhaaha");
        }
        //new doc
        private void newToolStripMenuItem_Click(object sender, EventArgs e)
        {
            richTextBox1.Text = "";
        }
        //html
        private void newHtmlBoilerplateToolStripMenuItem_Click(object sender, EventArgs e)
        {
            richTextBox1.Text = "<html>" +
                Environment.NewLine + 
                "<head>" +
                Environment.NewLine + 
                "<title><title>" +
                Environment.NewLine+
                "<link href=>" +
                Environment.NewLine +
                "</head>" +
                Environment.NewLine +
                "<body>" +
                Environment.NewLine +
                "<script src=>" +
                Environment.NewLine +
                "</body>" +
                Environment.NewLine +
                "</html>";
        }
        //css
        private void cssBoilerplateToolStripMenuItem_Click(object sender, EventArgs e)
        {
            richTextBox1.Text = "body" +
                                    "   {" +
                                    Environment.NewLine +
                                    "background-color:black;" +
                                    Environment.NewLine +
                                    "   }" +
                                    Environment.NewLine +
                                    Environment.NewLine +
                                   "h1" +
                                    "   {" +
                                    Environment.NewLine +
                                    "color:red;" +
                                    Environment.NewLine +
                                    "   }";
                                    
                
        }
        //canvas
        private void newCanvasBoilerplateToolStripMenuItem_Click(object sender, EventArgs e)
        {
            richTextBox1.Text = "var canvas = getElementById('canvas');" +
               Environment.NewLine +
               "var ctx = canvas.getContext('2d');";
            
                
        }
        //redo and undo functions
        private void undoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            richTextBox1.Undo();
            undoToolStripMenuItem.Enabled = false;
            redoToolStripMenuItem.Enabled = true;
        }

        private void redoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            richTextBox1.Redo();
            undoToolStripMenuItem.Enabled = true;
            redoToolStripMenuItem.Enabled = false;
        }

        private void richTextBox1_TextChanged(object sender, EventArgs e)
        {
            if (richTextBox1.Text.Length>0)
            {
                undoToolStripMenuItem.Enabled = true;
                copyToolStripMenuItem.Enabled = true;
                cutToolStripMenuItem.Enabled = true;
            }
            else
            {

                undoToolStripMenuItem.Enabled = false;
                copyToolStripMenuItem.Enabled = false;
                cutToolStripMenuItem.Enabled = false;
            }
        }

        private void cutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            richTextBox1.Cut();
        }

        private void copyToolStripMenuItem_Click(object sender, EventArgs e)
        {
            richTextBox1.Copy();
        }

        private void pasteToolStripMenuItem_Click(object sender, EventArgs e)
        {
            richTextBox1.Paste();
        }

        private void selectAllToolStripMenuItem_Click(object sender, EventArgs e)
        {
            richTextBox1.SelectAll();
        }

        private void boldToolStripMenuItem_Click(object sender, EventArgs e)
        {
            richTextBox1.SelectionFont = new Font(richTextBox1.Font,FontStyle.Bold);
        }

        private void italicToolStripMenuItem_Click(object sender, EventArgs e)
        {
            richTextBox1.SelectionFont = new Font(richTextBox1.Font, FontStyle.Italic);
        }

        private void underlineToolStripMenuItem_Click(object sender, EventArgs e)
        {
            richTextBox1.SelectionFont = new Font(richTextBox1.Font, FontStyle.Underline);
        }
        //color picker
           

        private void display(string text)
        {
            MessageBox.Show(text);
        }

        private void colorPickerToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            if (colorDialog1.ShowDialog() == DialogResult.OK)
            {
                display(colorDialog1.Color.Name);
            }
        }

        private void toolStripButton1_Click(object sender, EventArgs e)
        {
            if (colorDialog1.ShowDialog() == DialogResult.OK)
            {
                display(colorDialog1.Color.Name);
            }
        }

        private void saveToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if(saveFileDialog1.ShowDialog() == DialogResult.OK)
            {
                System.IO.StreamWriter writer = new System.IO.StreamWriter(saveFileDialog1.FileName);
                if(saveFileDialog1.FileName.Contains(".rtf"))
                {
                    writer.Write(richTextBox1.Rtf);
                }
                else
                {
                    writer.Write(richTextBox1.Text);
                }
                writer.Close();
            }
        }

        //open files
        private void openToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if(openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                System.IO.StreamReader reader = new System.IO.StreamReader(openFileDialog1.FileName);
                if(openFileDialog1.FileName.Contains("All Files (*.*)|*.*"))
                {
                    richTextBox1.Rtf = reader.ReadToEnd();
                }
                else
                {
                    richTextBox1.Text = reader.ReadToEnd();
                }
                reader.Close();
            }

        }

        private void toolStripButton2_Click(object sender, EventArgs e)
        {
            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                System.IO.StreamReader reader = new System.IO.StreamReader(openFileDialog1.FileName);
                if (openFileDialog1.FileName.Contains("All Files (*.*)|*.*"))
                {
                    richTextBox1.Rtf = reader.ReadToEnd();
                }
                else
                {
                    richTextBox1.Text = reader.ReadToEnd();
                }
                reader.Close();
            }

        }

        private void toolStripButton3_Click(object sender, EventArgs e)
        {
            if (saveFileDialog1.ShowDialog() == DialogResult.OK)
            {
                System.IO.StreamWriter writer = new System.IO.StreamWriter(saveFileDialog1.FileName);
                if (saveFileDialog1.FileName.Contains(".rtf"))
                {
                    writer.Write(richTextBox1.Rtf);
                }
                else
                {
                    writer.Write(richTextBox1.Text);
                }
                writer.Close();
            }
        }

        private void fontchangerToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            fontDialog1.ShowDialog();

            richTextBox1.Font = fontDialog1.Font;
        }

        private void toolStripButton4_Click(object sender, EventArgs e)
        {
            fontDialog1.ShowDialog();

            richTextBox1.Font = fontDialog1.Font;

        }
    }
}
