using DevExpress.CodeParser;
using DevExpress.DataAccess.ConnectionParameters;
using DevExpress.DataAccess.Sql;
using DevExpress.DataProcessing.InMemoryDataProcessor;
using DevExpress.Office.API.Internal;
using DevExpress.XtraEditors;
using DevExpress.XtraGrid.Views.Grid;
using DevExpress.XtraRichEdit.Import.Html;
using DevExpress.XtraRichEdit.Model;
using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Reflection;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Telerik.WinControls.Extensions;
using XCubeCrm.Common.Enums;
using XCubeCrm.Model.Entities;
using XCubeCrm.UI.Win.Forms.BaseForms;
using XCubeCrm.UI.Win.Forms.BaseReport;
using XCubeCrm.UI.Win.Forms.UserControls.Controls.Grid;
using XCubeCrm.UI.Win.GenelForms;
using static DevExpress.Diagram.Core.Native.Either;
using static DevExpress.XtraEditors.TextEdit;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace XCubeCrm.UI.Win.Forms.Raporlar.Muhasebe
{
    public partial class SatisFiyatListesi : BaseReportListForm 
    {
        sqlBaglanti bgl = new sqlBaglanti();
        string araSorgu = "";
        public SatisFiyatListesi( )
        {
 
            InitializeComponent();
        }
        protected override void Listele()
        {
            araSorgu = "";
             
             araSorgu = "";
            if (AnaForm.aktifKayilar != "")
            {
                araSorgu += "AND CLC.ACTIVE IN (" + AnaForm.aktifKayilar + ")";
            }
            if (AnaForm.cariLogicalref != "")
            {
                araSorgu += "AND CLC.LOGICALREF IN (" + AnaForm.cariLogicalref + ")";
            }
            if (AnaForm.ozelKod != "")
            {
                araSorgu += "AND CLC.SPECODE IN (" + AnaForm.ozelKod + ")";
            }
            if (AnaForm.ozelKod2 != "")
            {
                araSorgu += "AND CLC.SPECODE2 IN (" + AnaForm.ozelKod2 + ")";
            }
            if (AnaForm.ozelKod3 != "")
            {
                araSorgu += "AND CLC.SPECODE3 IN (" + AnaForm.ozelKod3 + ")";
            }
            if (AnaForm.ozelKod4 != "")
            {
                araSorgu += "AND CLC.SPECODE4 IN (" + AnaForm.ozelKod4 + ")";
            }
            if (AnaForm.ozelKod5 != "")
            {
                araSorgu += "AND CLC.SPECODE5 IN (" + AnaForm.ozelKod5 + ")";
            }
            if (AnaForm.yetkiKodu != "")
            {
                araSorgu += "AND CLC.CYPHCODE IN (" + AnaForm.yetkiKodu + ")";
            }
            if (AnaForm.dovizTuru != "")
            {
                araSorgu += "AND STL.TRCURR IN (" + AnaForm.dovizTuru + ")";
            }
            if (AnaForm.satisElemani != "")
            {
                araSorgu += " and CLC.LOGICALREF IN (" + " SELECT   LOGICALREF FROM ( " +
" SELECT LOGICALREF,   " +
" (SELECT TOP 1 SL.SALESMANREF FROM  " + AnaForm.db +  ".DBO.LG_" + AnaForm.firma +  "_SLSCLREL SL  " +
" JOIN " + AnaForm.db +  ".DBO.LG_SLSMAN  SLS ON SL.CLIENTREF=CL.LOGICALREF AND SL.SALESMANREF = SLS.LOGICALREF AND SLS.FIRMNR =" + AnaForm.firma +  " ORDER BY  SL.LOGICALREF DESC ) AS SALESMANREF " +
" FROM " + AnaForm.db +  ".DBO.LG_" + AnaForm.firma +  "_CLCARD CL " +
" ) AS AAA WHERE AAA.SALESMANREF IN ( " + AnaForm.satisElemani + "))";
            }
            if (AnaForm.aktifKayitlarUrun != "")
            {
                araSorgu += "AND ITS.ACTIVE IN (" + AnaForm.aktifKayitlarUrun + ")";
            }
            if (AnaForm.urunLogicalref!="")
            {
                araSorgu += "AND ITS.LOGICALREF IN (" + AnaForm.urunLogicalref + ")";
            }
            if (AnaForm.urunOzelKod != "")
            {
                araSorgu += "AND ITS.SPECODE IN (" + AnaForm.urunOzelKod + ")";
            }
            if (AnaForm.urunOzelKod2 != "")
            {
                araSorgu += "AND ITS.SPECODE2 IN (" + AnaForm.urunOzelKod2 + ")";
            }
            if (AnaForm.urunOzelKod3 != "")
            {
                araSorgu += "AND ITS.SPECODE3 IN (" + AnaForm.urunOzelKod3 + ")";
            }
            if (AnaForm.urunOzelKod4 != "")
            {
                araSorgu += "AND ITS.SPECODE4 IN (" + AnaForm.urunOzelKod4 + ")";
            }
            if (AnaForm.urunOzelKod5 != "")
            {
                araSorgu += "AND ITS.SPECODE5 IN (" + AnaForm.urunOzelKod5 + ")";
            }
            if (AnaForm.urunGrup != "")
            {
                araSorgu += "AND ITS.STGRPCODE IN (" + AnaForm.urunGrup + ")";
            }
            if (AnaForm.urunTip != "")
            {
                araSorgu += "AND ITS.CARDTYPE IN (" + AnaForm.urunTip + ")";
            }
            if (AnaForm.ambar != "")
            {
                araSorgu += " AND  L_CAPIDIV.NR IN (" + AnaForm.isyeri + ")";
            }


            string sorgu3 = " SELECT PRC.LOGICALREF ID " +
"  , PRC.CODE KOD " +
"  , ITS.CODE URUNKODU " +
"  , ITS.NAME AS URUNADI " +
"  , PRC.PRICE AS FIYAT " +
"  , UNT.NAME AS BIRIM " +
"  , CASE PRC.UNITCONVERT WHEN 1 THEN 'EVET' " +
" WHEN 0 THEN 'HAYIR' " +
" ELSE 'HATALI' END DIGERBIRIMLERECEVRILEBILIR " +
"  , PRC.PRIORITY AS FIYATSIRA " +
"  , L_CAPIDIV.NAME AS ISYERI " +
"  , CASE WHEN PRC.CURRENCY = 160 THEN 'TL' " +
" WHEN PRC.CURRENCY = 1 THEN 'USD' " +
" WHEN PRC.CURRENCY = 20 THEN 'EUR' " +
" ELSE 'HATALI' " +
" END  AS 'DOVIZTURU' " +
"  , CASE WHEN INCVAT = 0 THEN 'HARİÇ' ELSE 'DAHİL' END AS KDVDAHILMI " +
"  , PRC.PRCALTERLMT1 AS MAXIMIMINDIRIMORANI " +
"  , PRC.CLIENTCODE AS CARIKODU " +
"  , CLC.DEFINITION_ AS CARIADI " +
"  , PRC.BEGDATE BASLANGICTARIHI " +
"  , PRC.ENDDATE BITISTARIHI " +
"  , PYP.CODE AS VADE " +
"  , PRC.CYPHCODE CARIYETKIKOD " +
"  , PRC.CLSPECODE CARIOZELKOD " +
"  , PRC.CLSPECODE2 CARIOZELKOD2 " +
"  , PRC.CLSPECODE2 CARIOZELKOD3 " +
"  , PRC.CLSPECODE2 CARIOZELKOD4 " +
"  , PRC.CLSPECODE2 CARIOZELKOD5 " +
"  , CASE PRCALTERTYP1 WHEN '1' THEN 'TUTAR' " +
" WHEN '0' THEN 'YÜZDE' " +
" ELSE 'HATALI' " +
" END AS ALTDUZEYYETKILI_TURU " +
"  , PRCALTERLMT1 AS ALTDUZEYYETKILI_INDIRIM " +
"  , CASE PRCALTERTYP2 WHEN '1' THEN 'TUTAR' " +
" WHEN '0' THEN 'YÜZDE' " +
" ELSE 'HATALI' " +
" END AS ORTADUZEYYETKILI_TURU " +
"  , PRCALTERLMT2 AS ORTADUZEYYETKILI_INDIRIM " +
"  , CASE PRCALTERTYP3 WHEN '1' THEN 'TUTAR' " +
" WHEN '0' THEN 'YÜZDE' " +
" ELSE 'HATALI' " +
" END AS USTDUZEYYETKILI_TURU " +
"  , PRCALTERLMT3 AS USTDUZEYYETKILI_INDIRIM " +
" FROM " + AnaForm.db + ".DBO.LG_" + AnaForm.firma + "_PRCLIST PRC  " +
" LEFT JOIN " + AnaForm.db + ".DBO.LG_" + AnaForm.firma + "_ITEMS ITS ON ITS.LOGICALREF = PRC.CARDREF " +
" LEFT JOIN " + AnaForm.db + ".DBO.LG_" + AnaForm.firma + "_PAYPLANS PYP ON PYP.LOGICALREF = PRC.PAYPLANREF " +
" LEFT OUTER join " + AnaForm.db + ".DBO.LG_" + AnaForm.firma + "_CLCARD CLC ON PRC.CLIENTCODE = CLC.CODE " +
" JOIN " + AnaForm.db + ".DBO.LG_" + AnaForm.firma + "_UNITSETL UNT ON UNT.LOGICALREF = PRC.UOMREF " +
" JOIN " + AnaForm.db + ".dbo.L_CAPIDIV L_CAPIDIV ON L_CAPIDIV.NR = PRC.BRANCH AND L_CAPIDIV.FIRMNR = '" + AnaForm.firma + "' " +
" WHERE PRC.PTYPE = 2 AND PRC.ACTIVE = 0  AND '" + AnaForm.bitisTarihi +"' BETWEEN BEGDATE AND ENDDATE " + araSorgu +
" ORDER BY ITS.CODE,PYP.CODE " ;





            DataTable dt1 = new DataTable();
            SqlDataAdapter da = new SqlDataAdapter(sorgu3, bgl.baglanti());

            
            da.SelectCommand.CommandTimeout = 0;
            da.Fill(dt1);
            grid.DataSource = dt1;

           // AnaForm frm = new AnaForm();
          
             

           
        }

         
        protected override void DegiskenleriDoldur()
        {
            Tablo = tablo;
             
            BaseKartTuru = KartTuru.SatisFiyatListesi;
        }

          
    }
}