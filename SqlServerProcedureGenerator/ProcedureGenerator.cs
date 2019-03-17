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

            String text = textBoxStatement.Text.Trim();
            RegexOptions options = RegexOptions.None;
            Regex regex = new Regex("[ ]{2,}", options);
            text = regex.Replace(text, " ");
            textBoxStatement.Text = text;

            String createStatement = textBoxStatement.Text;
            String prefix = textBoxProcedurePrefix.Text;
            String sufix = textBoxProcedureSufix.Text;
            String searchBy = textBoxSearchBy.Text;
            textBoxResult.Text = ProcedureGeneratorHelper.GetProcedures(createStatement, prefix, sufix, searchBy);
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
    }
}
