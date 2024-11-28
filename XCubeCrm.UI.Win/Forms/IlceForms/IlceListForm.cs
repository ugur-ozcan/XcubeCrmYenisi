using System;
using System.Linq;
using XCubeCrm.Bll.General;
using XCubeCrm.Common.Enums;
using XCubeCrm.Model.Entities;
using XCubeCrm.UI.Win.Forms.BaseForms;
using XCubeCrm.UI.Win.Forms.IlForms;
using XCubeCrm.UI.Win.Forms.UserControls.Controls.Navigators;
using XCubeCrm.UI.Win.Functions;
using XCubeCrm.UI.Win.Show;

namespace XCubeCrm.UI.Win.Forms.IlceForms
{
    public partial class IlceListForm : BaseListForm
    {
        #region Variables
        private readonly long _ilId;
        private readonly string _ilAdi;
        #endregion

        public IlceListForm(params object[] prm)
        {

            InitializeComponent();
            Bll = new IlceBll();
            _ilId = (long)prm[0];
            _ilAdi = (string)prm[1];
        }
        protected override void DegiskenleriDoldur()
        {
            Tablo = tablo;
            BaseKartTuru = KartTuru.Ilce;
            Navigator = longNavigator.Navigator;
            Text = Text + $" - ( {_ilAdi} )";


        }
        protected override void Listele()
        {
            tablo.GridControl.DataSource = ((IlceBll)Bll).List(x => x.Durum == AktifKartlariGoster && x.IlId == _ilId);
        }

        protected override void ShowEditForm(long id)
        {
            var result = ShowEditForms<IlceEditForm>.ShowDialogEditForm(KartTuru.Ilce, id, _ilId, _ilAdi);
            ShowEditFormDefault(result);
        }
    }
}
