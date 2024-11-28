using XCubeCrm.Bll.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using XCubeCrm.Model.Entities;
using XCubeCrm.Data.Context;
using System.Windows.Forms;
using XCubeCrm.Model.Entities.Base;
using System.Linq.Expressions;
using XCubeCrm.Model.Entities.Dto;
using XCubeCrm.Common.Enums;
using XCubeCrm.Bll.Interfaces;

namespace XCubeCrm.Bll.General
{
    public class OkulBll : BaseGenelBll<Okul>, IBaseGenelBll,IBaseCommonBll
    {
        public OkulBll() : base(KartTuru.Okul) { }
        public OkulBll(Control ctrl):base(ctrl,KartTuru.Okul) { }

        public override BaseEntity Single(Expression<Func<Okul, bool>> filter)
        {
            return BaseSingle(filter, x => new OkulS
            {
                Id = x.Id,
                Kod = x.Kod,
                OkulAdi = x.OkulAdi,
                IlId = x.IlId,
                IlAdi = x.Il.IlAdi,
                IlceId = x.IlceId,
                IlceAdi = x.Ilce.IlceAdi,
                Aciklama = x.Aciklama,
                Durum = x.Durum
            });
        }

        public override IEnumerable<BaseEntity> List(Expression<Func<Okul, bool>> filter)
        {
            return BaseList(filter, x => new OkulL
            {
                Id = x.Id,
                Kod = x.Kod,
                OkulAdi = x.OkulAdi,
                IlAdi = x.Il.IlAdi,
                IlceAdi = x.Ilce.IlceAdi,
                Aciklama = x.Aciklama
            }).OrderBy(x => x.Kod).ToList();
        }


    }
}
