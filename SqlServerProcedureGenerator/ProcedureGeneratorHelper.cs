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

        public static String GetProcedures(String createStatement, String prefix, String sufix, String searchBy = "")
        {

            String result = "";

            result += ProcedureGeneratorHelper.GetSelectAllStatement(createStatement, prefix, sufix);
            result += NewLines();
            result += ProcedureGeneratorHelper.GetSelectByIdStatement(createStatement, prefix, sufix);
            result += NewLines();
            result += ProcedureGeneratorHelper.GetUpdateByIdStatement(createStatement, prefix, sufix);
            result += NewLines();
            result += ProcedureGeneratorHelper.GetDeleteByIdStatement(createStatement, prefix, sufix);
            result += NewLines();
            result += ProcedureGeneratorHelper.GetSearchByNameStatement(createStatement, prefix, sufix, searchBy);

            return result;

        }

        


        public static String GetSelectAllStatement(String createStatement, String prefix, String sufix)
        {
            return "select all statement";      
        }

        public static String GetSelectByIdStatement(String createStatement, String prefix, String sufix)
        {
            return "GetSelectByIdStatement";
        }

        public static String GetUpdateByIdStatement(String createStatement, String prefix, String sufix)
        {
            return "GetUpdateByIdStatement";
        }

        public static String GetDeleteByIdStatement(String createStatement, String prefix, String sufix)
        {
            return "GetDeleteByIdStatement";
        }

        public static String GetSearchByNameStatement(String createStatement, String prefix, String sufix, String searchBy = "")
        {
            return "GetSearchByNameStatement";
        }




        private static String NewLines()
        {
            return System.Environment.NewLine + System.Environment.NewLine + System.Environment.NewLine;
        }

    }
}
