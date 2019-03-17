using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SqlServerProcedureGenerator
{
    public class ProcedureGeneratorHelper
    {

        private ProcedureGeneratorHelper() { }

        public static String GetProcedures(String createStatement, String prefix, String suffix, String searchBy = "")
        {

            String result = "";

            result += ProcedureGeneratorHelper.GetSelectAllStatement(createStatement, prefix, suffix);
            result += NewLines();
            result += ProcedureGeneratorHelper.GetSelectByIdStatement(createStatement, prefix, suffix);
            result += NewLines();
            result += ProcedureGeneratorHelper.GetUpdateByIdStatement(createStatement, prefix, suffix);
            result += NewLines();
            result += ProcedureGeneratorHelper.GetDeleteByIdStatement(createStatement, prefix, suffix);
            result += NewLines();
            result += ProcedureGeneratorHelper.GetSearchByNameStatement(createStatement, prefix, suffix, searchBy);

            return result;

        }




        public static String GetSelectAllStatement(String createStatement, String prefix, String suffix)
        {
            String result = "";
            result += GetCreateProcedureRow(createStatement, prefix, "SelectAll", suffix);
            result += Enter();
            result += "AS";
            result += Enter();
            result += "SELECT ";

            String[] attributes = GetTableColumnNames(createStatement);
            foreach (String a in attributes) {
                String withoutTabs = a.Replace("\t", "");
                result += withoutTabs + ", ";
            }

            result = result.Remove(result.Length - 1);
            result = result.Remove(result.Length - 1);
            result += Enter();

            result += "FROM ";
            result += GetTableName(createStatement);
            result += Enter();
            result += "GO";

            return result;

        }

        public static String GetSelectByIdStatement(String createStatement, String prefix, String suffix)
        {
            return "GetSelectByIdStatement";

            /*
             
             */
        }

        public static String GetUpdateByIdStatement(String createStatement, String prefix, String suffix)
        {
            return "GetUpdateByIdStatement";
        }

        public static String GetDeleteByIdStatement(String createStatement, String prefix, String suffix)
        {
            return "GetDeleteByIdStatement";
        }

        public static String GetSearchByNameStatement(String createStatement, String prefix, String suffix, String searchBy = "")
        {
            return "GetSearchByNameStatement";
        }

        private static String[] GetTableColumnNames(String createStatement) {
            String[] lines = createStatement.Split(
            new[] { Environment.NewLine },
            StringSplitOptions.None
            );


            List<String> linesList = lines.ToList();
            linesList.RemoveAt(0);
            linesList.RemoveAt(linesList.Count - 1);
            linesList.RemoveAt(linesList.Count - 1);

            List<String> attributes = new List<String>();

            foreach (String line in linesList) {
                String[] parts = line.Split(' ');
                if (parts.Length > 2) {
                    attributes.Add(parts[0]);
                }
            }

            return attributes.ToArray();
        }


        private static String GetCreateProcedureRow(String createStatement, String prefix, String name, String suffix) {
            String result = "CREATE PROCEDURE ";
            result += GetProcedureName(createStatement, prefix, name, suffix);
            return result;
        }

        private static String GetProcedureName(String createStatement, String prefix, String name, String suffix) {
            String result = "";
            if (prefix != "") {
                result += prefix + "_";
            }
      
            result += GetTableName(createStatement) + "_";
            result += name;

            if (suffix != "")
            {
                result += "_" + suffix;
            }

            return result;

        }

        private static String GetTableName(String createStatement) {
            String[] splitted = createStatement.Split(' ');
            if (splitted.Length > 3) {
                return splitted[2];
            }
            return "";
            
        }

        private static String Enter() {
            return System.Environment.NewLine;
        }

        private static String NewLines()
        {
            return System.Environment.NewLine + System.Environment.NewLine + System.Environment.NewLine;
        }

    }
}
