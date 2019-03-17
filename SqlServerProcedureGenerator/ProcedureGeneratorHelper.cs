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

        public static String IsCreateSqlStatementValidAndPrettyFormatted(String statement) {
            String[] words = statement.Split(' ');
            if (words.Length < 6) { return "Invalid SQL Create statement."; }
            if (words[0] != "CREATE" || words[1] != "TABLE") { return "Can't find CREATE TABLE string."; }
            if (!words[words.Length - 1].Contains("GO")) { return "Can't find 'GO' keyword."; } 
            return "";
        }

        public static String GetProcedures(String createStatement, String prefix, String suffix, String searchBy = "")
        {

            String validationMessage = IsCreateSqlStatementValidAndPrettyFormatted(createStatement);

            if (validationMessage != "") {
                return validationMessage;
            }

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

            String result = "";
            result += GetCreateProcedureRow(createStatement, prefix, "SelectById", suffix);
            result += " @Id ";
            String[] types = GetTableColumnTypes(createStatement);
            if (types.Length == 0) { return "Error: Please type in valid and formatted SQL create statement."; }
            result += types[0];
            result += Enter();
            result += "AS";
            result += Enter();
            result += "SELECT ";

            String[] attributes = GetTableColumnNames(createStatement);
            foreach (String a in attributes)
            {
                String withoutTabs = a.Replace("\t", "");
                result += withoutTabs + ", ";
            }

            result = result.Remove(result.Length - 1);
            result = result.Remove(result.Length - 1);
            result += Enter();

            result += "FROM ";
            result += GetTableName(createStatement);
            result += " WHERE ";
            result += attributes[0].Replace("\t", "");
            result += " = ";
            result += "@Id";
            result += Enter();
            result += "GO";

            return result;
        }

        public static String GetUpdateByIdStatement(String createStatement, String prefix, String suffix)
        {
            String result = "";
            result += GetCreateProcedureRow(createStatement, prefix, "Update", suffix);
            result += " ";

            String[] attributes = GetTableColumnNames(createStatement);
            String[] types = GetTableColumnTypes(createStatement);

            if (attributes.Length < 1 && attributes.Length != types.Length) {
                return "UPDATE BY STATEMENT ERROR: Invalid SQL Query: number of types != number of attributes";
            }

            result += "@Id ";

            String[] colTypes = GetTableColumnTypes(createStatement);
            if (colTypes.Length == 0) { return "Error: Please type in valid and formatted SQL create statement."; }
            result += colTypes[0];
            result += ", ";

            for (int i = 1; i < attributes.Length; i++) {
                String awt = attributes[i].Replace("\t", "");
                String twt = types[i].Replace("\t", "");
                result += "@" + awt + " " + twt + ", ";
            }
            result = result.Remove(result.Length - 1);
            result = result.Remove(result.Length - 1);
            result += Enter();

            result += "AS";
            result += Enter();
            result += "IF EXISTS (SELECT * FROM ";
            result += GetTableName(createStatement);
            result += " WHERE ";
            result += attributes[0].Replace("\t", "");
            result += " = @Id)";
            result += Enter();

            result += "UPDATE ";
            result += GetTableName(createStatement);
            result += Enter();
            result += "SET ";

            for (int i = 1; i < attributes.Length; i++)
            {
                String awt = attributes[i].Replace("\t", "");
                result += awt + " = " + "@" + awt;

                if (i != attributes.Length - 1) {
                    result += ",";
                }
                result += Enter();
            }
            result += "WHERE ";
            result += attributes[0].Replace("\t", "");
            result += " = @Id";
            result += Enter();

            result += "SELECT ";
            foreach (String a in attributes)
            {
                String withoutTabs = a.Replace("\t", "");
                result += withoutTabs + ", ";
            }

            result = result.Remove(result.Length - 1);
            result = result.Remove(result.Length - 1);
            result += Enter();

            result += "FROM ";
            result += GetTableName(createStatement);
            result += " WHERE ";
            result += attributes[0].Replace("\t", "");
            result += " = ";
            result += "@Id";
            result += Enter();

            result += "GO";

            return result;
        }

        public static String GetDeleteByIdStatement(String createStatement, String prefix, String suffix)
        {

            String result = "";
            result += GetCreateProcedureRow(createStatement, prefix, "DeleteById", suffix);
            result += " @Id ";

            String[] colTypes = GetTableColumnTypes(createStatement);
            if (colTypes.Length == 0) { return "Error: Please type in valid and formatted SQL create statement."; }
            result += colTypes[0];
            result += Enter();
            result += "AS";
            result += Enter();
            result += "DELETE FROM ";
            result += GetTableName(createStatement);
            result += " WHERE ";
            result += GetTableColumnNames(createStatement)[0].Replace("\t", "");
            result += " = @Id";
            result += Enter();
            result += "GO";
            return result;

        }

        public static String GetSearchByNameStatement(String createStatement, String prefix, String suffix, String searchBy = "")
        {

            if (searchBy == "") { return ""; }
            String result = "";
            String searchByChecked = FirstCharToUpper(searchBy);
            String[] attributes = GetTableColumnNames(createStatement);

            String columnType = GetColumnType(createStatement, searchBy);
            if (columnType == "") {
                return "SearchByName: ERROR: Attribute with the following name does not exist: " + searchBy;
            }

            result += GetCreateProcedureRow(createStatement, prefix, "SelectBy" + searchByChecked, suffix);
            result += " @" + searchByChecked + " ";
            result += columnType;
            result += Enter();
            result += "AS";
            result += Enter();
            result += "SELECT ";

            foreach (String a in attributes)
            {
                String withoutTabs = a.Replace("\t", "");
                result += withoutTabs + ", ";
            }

            result = result.Remove(result.Length - 1);
            result = result.Remove(result.Length - 1);
            result += Enter();

            result += "FROM ";
            result += GetTableName(createStatement);
            result += " WHERE ";
            result += searchBy;
            result += " = ";
            result += "@" + searchBy;
            result += Enter();
            result += "GO";

            return result;
        }

        private static String[] GetTableColumnNames(String createStatement) {
            String[] lines = createStatement.Split(
            new[] { Environment.NewLine },
            StringSplitOptions.None
            );


            List<String> linesList = lines.ToList();
            if (linesList.Count < 4) { return new String[0]; }
            linesList.RemoveAt(0);
            linesList.RemoveAt(linesList.Count - 1);
            linesList.RemoveAt(linesList.Count - 1);

            List<String> attributes = new List<String>();

            foreach (String line in linesList) {
                String[] parts = line.Split(' ');
                if (parts.Length > 2) {
                    String a = parts[0].Replace("\t", "");
                    attributes.Add(parts[0]);
                }
            }

            return attributes.ToArray();
        }

        private static String GetColumnType(String createStatement, String a) {
            String[] attributes = GetTableColumnNames(createStatement);


            for (int i = 0; i < attributes.Length; i++) {
                String s = attributes[i];
                if (a == s.Replace("\t", ""))
                {
                    String[] types = GetTableColumnTypes(createStatement);
                    if (types.Length > i && types.Length == attributes.Length) {
                        return types[i];
                    }
                }
            }
            return "";
        }

        private static String[] GetTableColumnTypes(String createStatement)
        {
            String[] lines = createStatement.Split(
            new[] { Environment.NewLine },
            StringSplitOptions.None
            );


            List<String> linesList = lines.ToList();
            if (linesList.Count < 4) { return new String[0]; }
            linesList.RemoveAt(0);
            linesList.RemoveAt(linesList.Count - 1);
            linesList.RemoveAt(linesList.Count - 1);

            List<String> attributes = new List<String>();

            foreach (String line in linesList)
            {
                String[] parts = line.Split(' ');
                if (parts.Length > 2)
                {
                    attributes.Add(parts[1]);
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

        private static string FirstCharToUpper(string input)
        {
            if (String.IsNullOrEmpty(input)) {
                return "";
            }
            return input.First().ToString().ToUpper() + input.Substring(1);
        }
    }
}
