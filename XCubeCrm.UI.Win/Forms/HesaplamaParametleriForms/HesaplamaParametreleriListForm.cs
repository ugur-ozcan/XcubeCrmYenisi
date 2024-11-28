using DevExpress.XtraEditors;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using XCubeCrm.Bll.General;
using XCubeCrm.UI.Win.Forms.BaseForms;
using XCubeCrm.Common.Enums;
using XCubeCrm.UI.Win.Show;
using XCubeCrm.UI.Win.Functions;
using XCubeCrm.Model.Entities;
using XCubeCrm.UI.Win.Forms.HesaplamaParametreleriForms;
using DevExpress.XtraBars;

namespace XCubeCrm.UI.Win.Forms.HesaplamaParametleriForms
{
    public partial class HesaplamaParametleriListForm : BaseListForm
    {
        public HesaplamaParametleriListForm()
        {
            InitializeComponent();
            Bll =new HesaplamaParametreleriBll();
        }

        protected override void DegiskenleriDoldur()
        {
            Tablo = tablo;
            BaseKartTuru = KartTuru.HesaplamaParametreleri;
            FormShow = new ShowEditForms < HesaplamaParametreleriEditForm>();
            Navigator = longNavigator1.Navigator;


        }
        protected override void Listele()
        {
            btnYeni.Visibility = BarItemVisibility.Never;
            tablo.GridControl.DataSource = ((HesaplamaParametreleriBll)Bll).List(FilterFunctions.Filtre<HesaplamaParametreleri>(AktifKartlariGoster));
        }
    }
}