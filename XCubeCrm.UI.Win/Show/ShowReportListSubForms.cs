using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using XCubeCrm.Common.Enums;
using XCubeCrm.Model.Entities.Base.Interfaces;
using XCubeCrm.UI.Win.Forms.BaseForms;
using XCubeCrm.UI.Win.Forms.BaseReport;

namespace XCubeCrm.UI.Win.Show.Interfaces
{
    public class ShowReportListSubForms<TForm> : IBaseFormSubReportShow where TForm : BaseReportListSubForm
    {
        //public long ShowDialogEditForm(KartTuru kartTuru, long id)//, params object[] prm)
        //{
        //    //yetki kontrolü
        //    using (var frm = (TForm)Activator.CreateInstance(typeof(TForm)))
        //    {
        //        frm.BaseIslemTuru = id > 0 ? IslemTuru.EntityUpdate : IslemTuru.EntityInsert;
        //        frm.Id = id;
        //        frm.Yukle();
        //        frm.ShowDialog();
        //        return frm.RefreshYapilacak ? frm.Id : 0;
        //    }

        //}
        //public static long ShowDialogEditForm(KartTuru kartTuru, long id, params object[] prm)
        //{
        //    //yetki kontrolü
        //    using (var frm = (TForm)Activator.CreateInstance(typeof(TForm), prm))
        //    {
        //        frm.BaseIslemTuru = id > 0 ? IslemTuru.EntityUpdate : IslemTuru.EntityInsert;
        //        frm.Id = id;
        //        frm.Yukle();
        //        frm.ShowDialog();
        //        return frm.RefreshYapilacak ? frm.Id : 0;
        //    }
        //}





        public long ShowDialogSubForm(KartTuru kartTuru, long id)
        {
            using (var frm = (TForm)Activator.CreateInstance(typeof(TForm)))
            {

                frm.Id = id;
                frm.Yukle();
                frm.ShowDialog();
                return frm.RefreshYapilacak ? frm.Id : 0;
            }
        }
    }
}