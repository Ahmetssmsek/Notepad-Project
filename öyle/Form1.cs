namespace öyle
{
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

    public partial class Form1 : Form
    {
        private Stack<string> undoStack;
        private Stack<string> redoStack;
        public Form1()
        {
            InitializeComponent();
            undoStack = new Stack<string>();
            redoStack = new Stack<string>();
        }

        private void Load(TextReader read)
        {
            textBox1.Text = read.ReadToEnd();
        }

        private void loadFromFileToolStripMenuItem_Click(object sender, EventArgs e)
        {
            TabPage newTab = new TabPage("New Document");
            RichTextBox newRichTextBox = new RichTextBox()
            {
                Dock = DockStyle.Fill
            };
            newTab.Controls.Add(newRichTextBox);
            tabControl1.TabPages.Add(newTab);

        }

        private void saveToFileToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (saveFileDialog1.ShowDialog() == DialogResult.OK)
            {
                File.WriteAllText(saveFileDialog1.FileName, textBox1.Text);
            }
        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void viewHelpToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void aboutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MessageBox.Show("This application is created by Ahmet Simsek. This is only for learning purposes. Anyone can try this and use this", "About Notepad", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void loadFibonacciNumbersfirst50ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                StreamReader openFile = new StreamReader(openFileDialog1.FileName);
                Load(openFile);
            }
        }

        private void loadFibonacciNumbersfirst100ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            DialogResult dr = printDialog1.ShowDialog();
            if (dr == DialogResult.OK)
            {

            }
        }

        private void undoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (undoStack.Count > 1)
            {
                redoStack.Push(undoStack.Pop());
                textBox1.Text = undoStack.Peek();
            }
        }

        private void redoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (redoStack.Count > 0)
            {
                undoStack.Push(redoStack.Pop());
                textBox1.Text = undoStack.Peek();
            }
        }

        private void copyToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (textBox1.SelectionLength > 0)
            {
                textBox1.Copy();
            }
        }

        private void cutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(textBox1.SelectedText))
            {
                textBox1.Cut();
            }
        }

        private void pasteToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (Clipboard.GetDataObject().GetDataPresent(DataFormats.Text))
            {
                textBox1.Paste();
            }
        }

        private void deleteToolStripMenuItem_Click(object sender, EventArgs e)
        {
            textBox1.SelectedText = string.Empty;
        }

        private void deleteAllToolStripMenuItem_Click(object sender, EventArgs e)
        {
            textBox1.Clear();
        }

        private void selectToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void selectAllToolStripMenuItem_Click(object sender, EventArgs e)
        {
            textBox1.SelectAll();
        }

        private void dateTimeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            DateTime dt = DateTime.Now;
            textBox1.Text = dt.ToString();
        }

        private void fontToolStripMenuItem_Click(object sender, EventArgs e)
        {
            DialogResult dr = fontDialog1.ShowDialog();
            if (dr == DialogResult.OK)
            {
                textBox1.Font = fontDialog1.Font;
            }
        }

        private void onToolStripMenuItem_Click(object sender, EventArgs e)
        {
            textBox1.WordWrap = true;
        }

        private void offToolStripMenuItem_Click(object sender, EventArgs e)
        {
            textBox1.WordWrap = false;
        }

        private void colorToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ColorDialog colorDialog = new ColorDialog();
            if (colorDialog.ShowDialog() == DialogResult.OK)
            {
                textBox1.ForeColor = colorDialog.Color;
            }
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            undoStack.Push(textBox1.Text);
            redoStack.Clear();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
           
        }
    }
}
