using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Test
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        

        public MainWindow()
        {

            InitializeComponent(); // ينشأ كل الأزرار وكل  مكونات الفورم
            new SQL_CLASS().Open(); //يفحص الأتصال عن طريق أستدعاء الكلاس


            cbo_Verantw_Arzt.ItemsSource = new SQL_CLASS().GetDataTable("select * from T_Verantw_Arzt").DefaultView;
            cbo_Land.ItemsSource = new SQL_CLASS().GetDataTable("select * from T_Land").DefaultView;
        }

        public void Refresh_ListView() //فويد لا تسترجع قيمة ولا يستقبل متغيرات 
        {

            //هذه الدالة تقوم بجلب البيانات من  سكيو كلاس الى ليست فيو

            LV_Test.ItemsSource = new SQL_CLASS().GetDataTable("select * from T_Test").DefaultView;
            //بعد جلب البيانات رح نحول البانات  اى نظهر البيانات عن طريق امر ديفولت فيو

        }


        private void Btn_Close_Click(object sender, RoutedEventArgs e)
        {
            
            var result = MessageBox.Show("Are you sure?", "Exit", MessageBoxButton.YesNo, MessageBoxImage.Question);
            if (result == MessageBoxResult.Yes)
            {
                MessageBox.Show("Goodbye");
                Close();
            }
            if (result == MessageBoxResult.No)
            {
                MessageBox.Show("Hallo");

            }

        }


        private void Btn_Refresh_Click(object sender, RoutedEventArgs e)
        {
            Refresh_ListView(); // دالة التي انشأتها فوق 
           

        }

        private void Btn_Add_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                if (txt_Patient_Nr.Text.Length == 0)

                {

                    MessageBox.Show("Bitte Patient Nummer Screiben");
                    return;
                }
                //************************************************************
                if (cbo_Verantw_Arzt.SelectedIndex == -1)

                {
                    MessageBox.Show("Bitte  Verantwortliche Arzt Auswählen");
                    return;
                }
                //************************************************************
                if (cbo_Titel.SelectedIndex == -1)

                {
                    MessageBox.Show("Bitte Titel auswählen");
                    return;
                }
                //************************************************************
                if (txt_Nachname.Text.Length == 0)

                {

                    MessageBox.Show("Bitte Nachname Screiben");
                    return;
                }
                //************************************************************
                if (txt_Vorname.Text.Length == 0)

                {

                    MessageBox.Show("Bitte Vorname Screiben");
                    return;
                }
                //************************************************************
                if (txt_Geburtsdatum.Text.Length == 0)

                {

                    MessageBox.Show("Bitte Geburtsdatum Screiben");
                    return;
                }
                //************************************************************
                if (cbo_Geschlecht.SelectedIndex == -1)

                {
                    MessageBox.Show("Bitte Geschlecht auswählen");
                    return;
                }
                //************************************************************
                if (txt_Strasse.Text.Length == 0)

                {

                    MessageBox.Show("Bitte Straße Screiben");
                    return;
                }
                //************************************************************
                if (txt_PLZ.Text.Length == 0)

                {

                    MessageBox.Show("Bitte PLZ Screiben");
                    return;
                }
                //************************************************************
                if (txt_Stadt.Text.Length == 0)

                {

                    MessageBox.Show("Bitte Stadt Screiben");
                    return;
                }
                //************************************************************
                if (cbo_Land.SelectedIndex == -1)

                {
                    MessageBox.Show("Bitte Land auswählen");
                    return;
                }
                //************************************************************
                if (txt_Fax.Text.Length == 0)

                {

                    MessageBox.Show("Bitte Fax Screiben");
                    return;
                }
                //************************************************************
                if (txt_Mobile.Text.Length == 0)

                {

                    MessageBox.Show("Bitte Mobile Screiben");
                    return;
                }
                //************************************************************
                if (txt_Email.Text.Length == 0)

                {

                    MessageBox.Show("Bitte E-Mail Screiben");
                    return;
                }
                //************************************************************

                //أنشاء جملة الأظافة


                string nachname = "'" + txt_Nachname.Text + "'"; //أظافة القيم الى متغيرات 
                string vorname = "'" + txt_Vorname.Text + "'";
                int titel = (int)cbo_Titel.SelectedValue;
                string geburtsdatum = "'" + txt_Geburtsdatum.Text + "'";
                string geschlecht = "'" + cbo_Geschlecht.Text + "'";
                string patient_nr = "'" + txt_Patient_Nr.Text + "'";
                string mobile = "'" + txt_Mobile.Text + "'";
                string verantw_arzt = "'" + cbo_Verantw_Arzt.Text + "'";
                string strasse = "'" + txt_Strasse.Text + "'";
                string plz = "'" + txt_PLZ.Text + "'";
                string stadt = "'" + txt_Stadt.Text + "'";
                string land = "'" + cbo_Land.Text + "'";
                string fax = "'" + txt_Fax.Text + "'";
                string email = "'" + txt_Email.Text + "'";



                //string insert = "insert into T_Test (nachname,vorname,titel,geburtsdatum,patient_nr,mobile,verantw_arzt,strasse,plz,stadt,land,fax,email,geschlecht)" +
                //    " values (" + nachname + "," + vorname + "," + titel + "," + geburtsdatum + "," + geschlecht + " ," + patient_nr + "," + mobile + "," + verantw_arzt + "," + strasse + "," + plz + "," + stadt + "," + land + "," + fax + "," + email + ")";

                string insert = "insert into T_Test (nachname,vorname,titel,geburtsdatum,patient_nr,mobile,verantw_arzt,strasse,plz,stadt,land,fax,email,geschlecht)" +
                   "values (" + txt_Nachname + "," + txt_Vorname + "," + cbo_Titel + "," + txt_Geburtsdatum + "," + cbo_Geschlecht + " ," + txt_Patient_Nr + "," + txt_Mobile + "," + cbo_Verantw_Arzt + "," + txt_Strasse + "," + txt_PLZ + "," + txt_Stadt + "," + cbo_Land + "," + txt_Fax + "," + txt_Email + ")";
                
                //________أرسال جملة الأظافة للتعامل مع القواعد البيانات
                if (Class_ExecuteNonQuery.ExcuteNonQuery(insert) == true)
                {
                    MessageBox.Show("The Data added seccesfully");

                    //تفريغ الحقول 
                    txt_Nachname.Text = "";
                    txt_Vorname.Text = "";
                    cbo_Titel.SelectedIndex = -1;
                    txt_Geburtsdatum.Text = "";
                    cbo_Geschlecht.SelectedIndex = -1;
                    txt_Patient_Nr.Text = "";
                    cbo_Verantw_Arzt.SelectedIndex = -1;
                    txt_Strasse.Text = "";
                    txt_PLZ.Text = "";
                    txt_Stadt.Text = "";
                    txt_Fax.Text = "";
                    txt_Email.Text = "";
                    cbo_Land.SelectedIndex = -1;
                    txt_Mobile.Text = "";





                    Refresh_ListView();
                }

                else
                {
                    MessageBox.Show("There is an error in adding data.!!! ", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                }
            }
            catch (Exception)
            {

                throw;
            }
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            Environment.Exit(1);
        }

       
        
    }
}
