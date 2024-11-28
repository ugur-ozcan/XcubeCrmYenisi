using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using XCubeCrm.Common.Enums;
using XCubeCrm.Model.Entities;
using XCubeCrm.UI.Win.Forms.IlceForms;
using XCubeCrm.UI.Win.Forms.IlForms;
using XCubeCrm.UI.Win.Forms.ParametrelerForms;
using XCubeCrm.UI.Win.Forms.TipForms;
using XCubeCrm.UI.Win.Forms.UserControls.Controls;
using XCubeCrm.UI.Win.Show;

namespace XCubeCrm.UI.Win.Functions
{
    public class SelectFunctions : IDisposable
    {
        #region Variables
        private MyButtonEdit _btnEdit;
        private MyButtonEdit _prmEdit;

        private KartTuru _kartTuru; 
        #endregion

        void SecimYap()
        {
            switch (_btnEdit.Name)
            {
                case "txtIl":
                    {
                        var entity = (Il)ShowListForms<IlListForm>.ShowDialogListForm(_kartTuru, _btnEdit.Id);
                        if (entity != null) 
                        {
                            _btnEdit.Id = entity.Id;
                            _btnEdit.EditValue = entity.IlAdi;
                        }
                    }
                    break;
                case "txtIlce":
                    {
                        var entity = (Ilce)ShowListForms<IlceListForm>.ShowDialogListForm(KartTuru.Ilce, _btnEdit.Id, _prmEdit.Id, _prmEdit.Text);
                        if (entity != null)
                        {
                            _btnEdit.Id = entity.Id;
                            _btnEdit.EditValue = entity.IlceAdi;
                        }
                    }
                    break;
                case "txtTip":
                    {
                        var entity = (Tip)ShowListForms<TipListForm>.ShowDialogListForm(_kartTuru, _btnEdit.Id);
                        if (entity != null)
                        {
                            _btnEdit.Id = entity.Id;
                            _btnEdit.EditValue = entity.TipAdi;
                        }
                    }
                    break;
                case "txtParametreler":
                    {
                        var entity = (Parametreler)ShowListForms<ParametrelerListForm>.ShowDialogListForm(KartTuru.Parametreler, _btnEdit.Id, _prmEdit.Id, _prmEdit.Text);
                        if (entity != null)
                        {
                            _btnEdit.Id = entity.Id;
                            _btnEdit.EditValue = entity.ParametreBaslik;
                        }
                    }
                    break;
            }
        }
        public void Sec(MyButtonEdit btnEdit)
        {
            _btnEdit = btnEdit;
            SecimYap();
        }
        public void Sec(MyButtonEdit btnEdit, MyButtonEdit prmEdit)
        {
            _btnEdit = btnEdit;
            _prmEdit = prmEdit;
            SecimYap();

        }
        public void Dispose()
        {
            GC.SuppressFinalize(this);
        }
    }
}
