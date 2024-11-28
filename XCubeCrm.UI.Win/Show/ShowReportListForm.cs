using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using XCubeCrm.Common.Enums;
using XCubeCrm.Model.Entities.Base;
using XCubeCrm.UI.Win.Forms.BaseReport;

namespace XCubeCrm.UI.Win.Show
{
    internal class ShowReportListForms  <TForm> where TForm : BaseReportListForm
    {

        public static void ShowReportListForm(KartTuru kartTuru)
        { // yetki kontrolü

            var frm = (TForm)Activator.CreateInstance(typeof(TForm));
            frm.MdiParent = Form.ActiveForm;
          
            frm.Yukle();
            frm.Show();

        }
        public static void ShowReportDialogListForm()
        {
            using (var frm = (TForm)Activator.CreateInstance(typeof(TForm)))
            {
                frm.Yukle();
                frm.ShowDialog();
            }
        }
 
        public static void ShowReportListForm(KartTuru kartTuru, string parametre)
        { // yetki kontrolü

            var frm = (TForm)Activator.CreateInstance(typeof(TForm));
            frm.MdiParent = Form.ActiveForm;

            frm.Yukle();
            frm.Show();

        }


        public static void ShowReportListForm(KartTuru kartTuru, params object[] prm)
        { // yetki kontrolü
            var frm = (TForm)Activator.CreateInstance(typeof(TForm), prm);
            frm.MdiParent = Form.ActiveForm;

            //frm.Yukle(firma, donem, db);
            frm.Show();

        }
        public static void  ShowDialogListForm(KartTuru kartTuru, int id)//, params object[] prm)
        {
            //yetki kontrolü
            //using (var frm = (TForm)Activator.CreateInstance(typeof(TForm)))
            //{
                 
            //    frm.Id = id;
            //    frm.Yukle();
            //    frm.ShowDialog();
                 
            //}


            using (var frm = (TForm)Activator.CreateInstance(typeof(TForm)))
            {
                frm.Id = id;
                frm.Yukle();
                frm.ShowDialog();
            }

        }


    }
}
