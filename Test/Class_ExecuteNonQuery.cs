using System;
using System.Collections.Generic;
using System.ComponentModel.Design;
using System.Data.SqlClient; /*//مكتبة خاصة لدالة   sqlCommand  */
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;


namespace Test
{
    public class Class_ExecuteNonQuery
    {
        public static object Finally { get; private set; }

        public static bool ExcuteNonQuery(string str)  //دالة  بوليان يتعامل مع الترو والفولس
        {
            SQL_CLASS sqlclass = new SQL_CLASS();
            try
            {

                if (!sqlclass.Open())
                {
                    return false; //اذا الدالة ماكانت مفتوحة يتوقف الدالة الى هنا 
                }
                SqlCommand sqlcomm = new SqlCommand(str, sqlclass.sqlconn);

                sqlcomm.ExecuteNonQuery(); // اذا نجح الأمر سوف يكمل العملية
                return true;

            }
            catch (Exception)
            {

                MessageBox.Show("There is an Error with connecting to Database");
                return false;//بما انو عملية فشلت لام نكتب ريترن فولس 
            }

            finally
            {
                sqlclass.Close();
            }
        }
    }
}
