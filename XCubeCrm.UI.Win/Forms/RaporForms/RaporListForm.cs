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
using XCubeCrm.Common.Enums;
using XCubeCrm.UI.Win.Forms.BaseForms;
using XCubeCrm.UI.Win.Forms.UserControls.Controls.Navigators;
using XCubeCrm.UI.Win.Show;

namespace XCubeCrm.UI.Win.Forms.RaporForms
{

    public partial class RaporListForm : BaseListForm
    {
        private readonly KartTuru _raporTuru;
        private readonly RaporBolumTuru _raporBolumTuru;
        private readonly byte[] _dosya;

        public RaporListForm(params object[] prm)
        {
            InitializeComponent();

            Bll = new RaporBll();

            _raporTuru = (KartTuru)prm[0];
            _raporBolumTuru = (RaporBolumTuru)prm[1];
            _dosya = (byte[])prm[2];
        }

        protected override void DegiskenleriDoldur()
        {
            Tablo = tablo;
            BaseKartTuru = KartTuru.Rapor;
            FormShow = new ShowEditForms<RaporEditForm>();
            Navigator = longNavigator.Navigator;
        }

        protected override void Listele()
        {
            tablo.GridControl.DataSource = ((RaporBll)Bll).List(x => x.Durum == AktifKartlariGoster && x.RaporTuru == _raporTuru);
        }

        protected override void ShowEditForm(long id)
        {
            var result = ShowEditForms<RaporEditForm>.ShowDialogEditForm(KartTuru.Rapor, id, _raporTuru, _raporBolumTuru, _dosya);
            ShowEditFormDefault(result);
        }
    }
}