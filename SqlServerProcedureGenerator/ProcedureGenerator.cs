using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
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
            String createStatement = textBoxStatement.Text;
            String prefix = textBoxProcedurePrefix.Text;
            String sufix = textBoxProcedureSufix.Text;
            String searchBy = textBoxSearchBy.Text;
            textBoxResult.Text = ProcedureGeneratorHelper.GetProcedures(createStatement, prefix, sufix, searchBy);
        }

        
    }
}
