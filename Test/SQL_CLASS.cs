using System;
using System.Data;
using System.Data.SqlClient;
using System.Windows;



namespace Test
{

    public class SQL_CLASS
    {
        public SqlConnection sqlconn;
        public SQL_CLASS()
        {
            string strconn = "Data Source=.; Initial Catalog=DB_Test; user id= sqluser; password =waleedrizgo; connect timeout=15;";
            sqlconn = new SqlConnection(strconn);
        }




        //check connection التأكيد من الأتصال 
        public bool Open()
        {
            try
            {
                if (sqlconn.State != ConnectionState.Open)
                {
                    sqlconn.Open(); // اذا الأتصال غير مفتوح خلي يفتح بهل دالة
                    if (sqlconn.State == ConnectionState.Open)
                    {
                        MessageBox.Show("connected 100%");
                        return true; //لأن الدالة بولين لازم نستعير ب ترو و فالس

                    }
                    else
                    {
                        MessageBox.Show("failed in connection!!");
                        return false;
                    }
                }
                else
                {
                    return true; // اذا كان الأتصال مفتوح 
                }
            }
            catch (Exception)
            {
                MessageBox.Show("failed in connection !!");
                return false;

            }
        }




        public void Close() // دالة اغلاق الأتصال فويد تعني لا تسترجع قيمة فقط يغلق
        {
            if (sqlconn.State == ConnectionState.Open)
            {
                sqlconn.Close(); //اذا اتصال مفتوح خلي تسكر بهل دالة 

            }
        }






        // Data Table
        public DataTable GetDataTable(string str)
        //تطلب متغير جملة أستدعاء المعلومات من القاعدة البيانات 
        {

            //هاذ الدالة تساعد في تصدي للأخطاء ولا يتوقف البرنامج اذا حدث خطأ في أحدى الدوال
            try
            {
                if (!Open()) //التأكد من الأتصال بالبيانات عن طريق أستدعاء الدالة 

                //(!Open()!=true)
                //(!Open()==false)
                {
                    MessageBox.Show("!! Cann not connect with Database");
                    return null; //اذا مافي اتصال لكي يتوقف البرنامج عن اكمال الشروط 

                }

                //ماعدا ذالك
                SqlCommand comm = new SqlCommand(str, sqlconn);
                // يلزمنا هنا متغيرين واحد لجلب البينات من القاعدة البيانات وواحدة لتحقق من الأتصال بالبيانات
                DataTable dt = new DataTable(); // تعبئة البيانات
                SqlDataAdapter da = new SqlDataAdapter(comm); //جلب البيانات

               

                da.Fill(dt);  // تعبئة الجدول الجديد

                return dt;
            }
            catch (Exception)    //في حالة الفشل جلب البيانات 
            {
                MessageBox.Show("!! Error by calling the data");
                return null;

            }
        }

    }
}
