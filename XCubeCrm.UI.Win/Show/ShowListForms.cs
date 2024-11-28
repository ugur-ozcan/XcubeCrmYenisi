using System;
using System.Linq;
using System.Windows.Forms;
using XCubeCrm.Common.Enums;
using XCubeCrm.Model.Entities.Base;
using XCubeCrm.UI.Win.Forms.BaseForms;

namespace XCubeCrm.UI.Win.Show
{

    public class ShowListForms<TForm> where TForm : BaseListForm
    {
        public static void ShowListForm(KartTuru kartTuru)
        { // yetki kontrolü
            var frm = (TForm)Activator.CreateInstance(typeof(TForm));
            frm.MdiParent = Form.ActiveForm;

            frm.Yukle();
            frm.Show();

        }

        public static BaseEntity ShowDialogListForm(KartTuru kartTuru, long? seciliGelecekId, params object[] prm)
        {
            //Yetki kontrolü
            using (var frm = (TForm)Activator.CreateInstance(typeof(TForm), prm))
            {
                frm.SeciliGelecekId = seciliGelecekId;
                frm.Yukle();
                frm.ShowDialog();

                return frm.DialogResult == DialogResult.OK ? frm.SelectedEntity : null;
            }
        }

        public static void ShowListForm(KartTuru kartTuru, params object[] prm)
        { // yetki kontrolü
            var frm = (TForm)Activator.CreateInstance(typeof(TForm), prm);
            frm.MdiParent = Form.ActiveForm;

            frm.Yukle();
            frm.Show();

        }
    }
}
