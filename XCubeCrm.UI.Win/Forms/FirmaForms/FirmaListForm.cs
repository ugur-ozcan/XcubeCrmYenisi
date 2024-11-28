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
using XCubeCrm.UI.Win.Forms.UserControls.Controls.Navigators;

namespace XCubeCrm.UI.Win.Forms.FirmaForms
{
    public partial class FirmaListForm : BaseListForm
    {
        public FirmaListForm()
        {
            InitializeComponent();
            Bll = new FirmaBll();
        }

        protected override void DegiskenleriDoldur()
        {
            Tablo = tablo;
            BaseKartTuru = KartTuru.Firma;
            FormShow = new ShowEditForms<FirmaEditForm>();
            Navigator = longNavigator1.Navigator;



        }
        protected override void Listele()
        {
            tablo.GridControl.DataSource = ((FirmaBll)Bll).List(FilterFunctions.Filtre<Firma>(AktifKartlariGoster));
        }
    }
}