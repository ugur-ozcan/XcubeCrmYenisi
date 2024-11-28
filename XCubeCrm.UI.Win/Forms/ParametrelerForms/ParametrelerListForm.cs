using System;
using System.Linq;
using XCubeCrm.Bll.General;
using XCubeCrm.Common.Enums;
using XCubeCrm.Model.Entities;
using XCubeCrm.UI.Win.Forms.BaseForms;
using XCubeCrm.UI.Win.Functions;
using XCubeCrm.UI.Win.Show;

namespace XCubeCrm.UI.Win.Forms.ParametrelerForms
{
    public partial class ParametrelerListForm : BaseListForm
    {
        #region Variables
        private readonly long _tipId;
        private readonly string _tipAdi; 
        #endregion

        public ParametrelerListForm(params object[] prm)
        {
             
            InitializeComponent();
            Bll = new ParametrelerBll();
            _tipId = (long)prm[0];
            _tipAdi= (string)prm[1];
        }
        protected override void DegiskenleriDoldur()
        {
            Tablo = tablo;
            BaseKartTuru = KartTuru.Parametreler;
            Navigator = longNavigator.Navigator;
            Text = Text + $" - ( {_tipAdi} )";
            
            
        }
        protected override void Listele()
        {
            tablo.GridControl.DataSource = ((ParametrelerBll)Bll).List(x => x.Durum == AktifKartlariGoster && x.TipId == _tipId);
        }
  
        protected override void ShowEditForm(long id)
        {
            var result = ShowEditForms<ParametrelerEditForm>.ShowDialogEditForm(KartTuru.Parametreler, id, _tipId, _tipAdi);
           ShowEditFormDefault(result);
        }
    }
}
