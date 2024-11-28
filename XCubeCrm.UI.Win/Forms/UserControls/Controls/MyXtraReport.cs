using DevExpress.XtraReports.UI;
using System;
using System.Collections;
using System.ComponentModel;
using System.Drawing;

namespace XCubeCrm.UI.Win.Forms.UserControls.Controls
{
    [ToolboxItem(true)]
    public partial class MyXtraReport : XtraReport
    {
        public MyXtraReport()
        {
        }

        public string Baslik { get; set; }
    }

}
