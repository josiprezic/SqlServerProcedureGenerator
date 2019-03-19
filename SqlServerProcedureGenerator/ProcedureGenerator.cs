using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SqlServerProcedureGenerator
{
    public partial class ProcedureGenerator : Form
    {
        public ProcedureGenerator()
        {
            InitializeComponent();
        }

        private void buttonCreateProcedures_Click(object sender, EventArgs e)
        {
            formatText();   
            textBoxResult.Text = ProcedureGeneratorHelper.GetProcedures(textBoxStatement.Text, textBoxProcedurePrefix.Text, textBoxProcedureSufix.Text, textBoxSearchBy.Text);
        }

        private void buttonPasteClipboard_Click(object sender, EventArgs e)
        {
            if (Clipboard.GetText().Length == 0) { return; }
            textBoxStatement.Text = Clipboard.GetText();
        }

        private void buttonCopyClipboard_Click(object sender, EventArgs e)
        {
            if (textBoxResult.Text.Length == 0) { return; }
            Clipboard.SetText(textBoxResult.Text);
        }

        private void buttonClear_Click(object sender, EventArgs e)
        {
            textBoxStatement.Text = "";
        }

        private void textBoxStatement_Click(object sender, EventArgs e)
        {
            if (textBoxStatement.Text.Length != 0) { return; }
            if(Clipboard.GetText().Length == 0) { return; }
            textBoxStatement.Text = Clipboard.GetText();
        }

        private void formatText()
        {
            String text = textBoxStatement.Text.Trim();
            RegexOptions options = RegexOptions.None;
            Regex regex = new Regex("[ ]{2,}", options);
            text = regex.Replace(text, " ");
            textBoxStatement.Text = text;
        }
    }
}
