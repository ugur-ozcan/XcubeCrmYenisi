namespace XCubeCrm.UI.Win.Forms.Raporlar.Muhasebe
{
    partial class MutabakatRaporu
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MutabakatRaporu));
            DevExpress.XtraLayout.ColumnDefinition columnDefinition1 = new DevExpress.XtraLayout.ColumnDefinition();
            DevExpress.XtraLayout.RowDefinition rowDefinition1 = new DevExpress.XtraLayout.RowDefinition();
            this.grid = new XCubeCrm.UI.Win.Forms.UserControls.Controls.Grid.MyGridControl();
            this.tablo = new XCubeCrm.UI.Win.Forms.UserControls.Controls.Grid.MyGridView();
            this.colID = new XCubeCrm.UI.Win.Forms.UserControls.Controls.Grid.MyGridColumn();
            this.colKod = new XCubeCrm.UI.Win.Forms.UserControls.Controls.Grid.MyGridColumn();
            this.colUNVAN = new XCubeCrm.UI.Win.Forms.UserControls.Controls.Grid.MyGridColumn();
            this.colVERGIDAIRE = new XCubeCrm.UI.Win.Forms.UserControls.Controls.Grid.MyGridColumn();
            this.colVERGINO = new XCubeCrm.UI.Win.Forms.UserControls.Controls.Grid.MyGridColumn();
            this.colTCNO = new XCubeCrm.UI.Win.Forms.UserControls.Controls.Grid.MyGridColumn();
            this.colTELNRS1 = new XCubeCrm.UI.Win.Forms.UserControls.Controls.Grid.MyGridColumn();
            this.colTELNRS2 = new XCubeCrm.UI.Win.Forms.UserControls.Controls.Grid.MyGridColumn();
            this.colYETKILI = new XCubeCrm.UI.Win.Forms.UserControls.Controls.Grid.MyGridColumn();
            this.colMAIL = new XCubeCrm.UI.Win.Forms.UserControls.Controls.Grid.MyGridColumn();
            this.colPERIYOT = new XCubeCrm.UI.Win.Forms.UserControls.Controls.Grid.MyGridColumn();
            this.colBAKIYE = new XCubeCrm.UI.Win.Forms.UserControls.Controls.Grid.MyGridColumn();
            this.colTLBAKIYE = new XCubeCrm.UI.Win.Forms.UserControls.Controls.Grid.MyGridColumn();
            this.colUSDBAKIYE = new XCubeCrm.UI.Win.Forms.UserControls.Controls.Grid.MyGridColumn();
            this.colUSDYERELBAKIYE = new XCubeCrm.UI.Win.Forms.UserControls.Controls.Grid.MyGridColumn();
            this.colEUROBAKIYE = new XCubeCrm.UI.Win.Forms.UserControls.Controls.Grid.MyGridColumn();
            this.colEUROYERELBAKIYE = new XCubeCrm.UI.Win.Forms.UserControls.Controls.Grid.MyGridColumn();
            this.myDataLayoutControl1 = new XCubeCrm.UI.Win.Forms.UserControls.Controls.MyDataLayoutControl();
            this.Root = new DevExpress.XtraLayout.LayoutControlGroup();
            this.layoutControlItem1 = new DevExpress.XtraLayout.LayoutControlItem();
            ((System.ComponentModel.ISupportInitialize)(this.ribbonControl)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.grid)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tablo)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.myDataLayoutControl1)).BeginInit();
            this.myDataLayoutControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.Root)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem1)).BeginInit();
            this.SuspendLayout();
            // 
            // ribbonControl
            // 
            this.ribbonControl.EmptyAreaImageOptions.ImagePadding = new System.Windows.Forms.Padding(22, 19, 22, 19);
            this.ribbonControl.ExpandCollapseItem.Id = 0;
            this.ribbonControl.OptionsMenuMinWidth = 243;
            this.ribbonControl.Size = new System.Drawing.Size(1134, 103);
            this.ribbonControl.Toolbar.ShowCustomizeItem = false;
            // 
            // btnDisariAktar
            // 
            this.btnDisariAktar.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("btnDisariAktar.ImageOptions.Image")));
            this.btnDisariAktar.ImageOptions.LargeImage = ((System.Drawing.Image)(resources.GetObject("btnDisariAktar.ImageOptions.LargeImage")));
            // 
            // grid
            // 
            this.grid.EmbeddedNavigator.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.grid.Location = new System.Drawing.Point(12, 12);
            this.grid.MainView = this.tablo;
            this.grid.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.grid.MenuManager = this.ribbonControl;
            this.grid.Name = "grid";
            this.grid.Size = new System.Drawing.Size(1110, 347);
            this.grid.TabIndex = 2;
            this.grid.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.tablo});
            // 
            // tablo
            // 
            this.tablo.Appearance.FooterPanel.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
            this.tablo.Appearance.FooterPanel.ForeColor = System.Drawing.Color.Maroon;
            this.tablo.Appearance.FooterPanel.Options.UseFont = true;
            this.tablo.Appearance.FooterPanel.Options.UseForeColor = true;
            this.tablo.Appearance.HeaderPanel.ForeColor = System.Drawing.Color.Maroon;
            this.tablo.Appearance.HeaderPanel.Options.UseForeColor = true;
            this.tablo.Appearance.HeaderPanel.Options.UseTextOptions = true;
            this.tablo.Appearance.HeaderPanel.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.tablo.Appearance.Row.Options.UseTextOptions = true;
            this.tablo.Appearance.Row.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Near;
            this.tablo.Appearance.ViewCaption.ForeColor = System.Drawing.Color.Maroon;
            this.tablo.Appearance.ViewCaption.Options.UseForeColor = true;
            this.tablo.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.colID,
            this.colKod,
            this.colUNVAN,
            this.colVERGIDAIRE,
            this.colVERGINO,
            this.colTCNO,
            this.colTELNRS1,
            this.colTELNRS2,
            this.colYETKILI,
            this.colMAIL,
            this.colPERIYOT,
            this.colBAKIYE,
            this.colTLBAKIYE,
            this.colUSDBAKIYE,
            this.colUSDYERELBAKIYE,
            this.colEUROBAKIYE,
            this.colEUROYERELBAKIYE});
            this.tablo.DetailHeight = 284;
            this.tablo.FocusRectStyle = DevExpress.XtraGrid.Views.Grid.DrawFocusRectStyle.RowFocus;
            this.tablo.GridControl = this.grid;
            this.tablo.Name = "tablo";
            this.tablo.OptionsEditForm.PopupEditFormWidth = 686;
            this.tablo.OptionsMenu.EnableColumnMenu = false;
            this.tablo.OptionsMenu.EnableFooterMenu = false;
            this.tablo.OptionsMenu.EnableGroupPanelMenu = false;
            this.tablo.OptionsMenu.ShowFooterItem = true;
            this.tablo.OptionsMenu.ShowSummaryItemMode = DevExpress.Utils.DefaultBoolean.True;
            this.tablo.OptionsNavigation.EnterMoveNextColumn = true;
            this.tablo.OptionsPrint.AutoWidth = false;
            this.tablo.OptionsPrint.PrintFooter = false;
            this.tablo.OptionsPrint.PrintGroupFooter = false;
            this.tablo.OptionsView.BestFitMode = DevExpress.XtraGrid.Views.Grid.GridBestFitMode.Fast;
            this.tablo.OptionsView.ColumnAutoWidth = false;
            this.tablo.OptionsView.HeaderFilterButtonShowMode = DevExpress.XtraEditors.Controls.FilterButtonShowMode.Button;
            this.tablo.OptionsView.RowAutoHeight = true;
            this.tablo.OptionsView.ShowAutoFilterRow = true;
            this.tablo.OptionsView.ShowFooter = true;
            this.tablo.OptionsView.ShowGroupPanel = false;
            this.tablo.StatusBarAciklama = null;
            this.tablo.StatusBarKisayol = null;
            this.tablo.StatusBarKisayolAciklama = null;
            this.tablo.ViewCaption = "Stok Son Hareket Tarihleri";
            // 
            // colID
            // 
            this.colID.Caption = "Id";
            this.colID.FieldName = "ID";
            this.colID.MinWidth = 21;
            this.colID.Name = "colID";
            this.colID.OptionsColumn.AllowEdit = false;
            this.colID.OptionsColumn.ShowInCustomizationForm = false;
            this.colID.StatusBarAciklama = null;
            this.colID.StatusBarKisayol = null;
            this.colID.StatusBarKisayolAciklama = null;
            this.colID.Width = 81;
            // 
            // colKod
            // 
            this.colKod.Caption = "Kod";
            this.colKod.FieldName = "KOD";
            this.colKod.Name = "colKod";
            this.colKod.OptionsColumn.AllowEdit = false;
            this.colKod.StatusBarAciklama = null;
            this.colKod.StatusBarKisayol = null;
            this.colKod.StatusBarKisayolAciklama = null;
            this.colKod.Visible = true;
            this.colKod.VisibleIndex = 0;
            // 
            // colUNVAN
            // 
            this.colUNVAN.Caption = "Ünvan";
            this.colUNVAN.FieldName = "UNVAN";
            this.colUNVAN.Name = "colUNVAN";
            this.colUNVAN.OptionsColumn.AllowEdit = false;
            this.colUNVAN.StatusBarAciklama = null;
            this.colUNVAN.StatusBarKisayol = null;
            this.colUNVAN.StatusBarKisayolAciklama = null;
            this.colUNVAN.Visible = true;
            this.colUNVAN.VisibleIndex = 1;
            // 
            // colVERGIDAIRE
            // 
            this.colVERGIDAIRE.Caption = "Vergi Dairesi";
            this.colVERGIDAIRE.FieldName = "VERGIDAIRE";
            this.colVERGIDAIRE.Name = "colVERGIDAIRE";
            this.colVERGIDAIRE.OptionsColumn.AllowEdit = false;
            this.colVERGIDAIRE.StatusBarAciklama = null;
            this.colVERGIDAIRE.StatusBarKisayol = null;
            this.colVERGIDAIRE.StatusBarKisayolAciklama = null;
            this.colVERGIDAIRE.Visible = true;
            this.colVERGIDAIRE.VisibleIndex = 2;
            // 
            // colVERGINO
            // 
            this.colVERGINO.Caption = "Vergi No";
            this.colVERGINO.FieldName = "VERGINO";
            this.colVERGINO.Name = "colVERGINO";
            this.colVERGINO.OptionsColumn.AllowEdit = false;
            this.colVERGINO.StatusBarAciklama = null;
            this.colVERGINO.StatusBarKisayol = null;
            this.colVERGINO.StatusBarKisayolAciklama = null;
            this.colVERGINO.Visible = true;
            this.colVERGINO.VisibleIndex = 3;
            // 
            // colTCNO
            // 
            this.colTCNO.Caption = "TC No";
            this.colTCNO.FieldName = "TCNO";
            this.colTCNO.Name = "colTCNO";
            this.colTCNO.OptionsColumn.AllowEdit = false;
            this.colTCNO.StatusBarAciklama = null;
            this.colTCNO.StatusBarKisayol = null;
            this.colTCNO.StatusBarKisayolAciklama = null;
            this.colTCNO.Visible = true;
            this.colTCNO.VisibleIndex = 4;
            // 
            // colTELNRS1
            // 
            this.colTELNRS1.Caption = "Tel Numara 1";
            this.colTELNRS1.FieldName = "TELNRS1";
            this.colTELNRS1.Name = "colTELNRS1";
            this.colTELNRS1.OptionsColumn.AllowEdit = false;
            this.colTELNRS1.StatusBarAciklama = null;
            this.colTELNRS1.StatusBarKisayol = null;
            this.colTELNRS1.StatusBarKisayolAciklama = null;
            this.colTELNRS1.Visible = true;
            this.colTELNRS1.VisibleIndex = 5;
            // 
            // colTELNRS2
            // 
            this.colTELNRS2.Caption = "Tel Numara 2";
            this.colTELNRS2.FieldName = "TELNRS2";
            this.colTELNRS2.Name = "colTELNRS2";
            this.colTELNRS2.OptionsColumn.AllowEdit = false;
            this.colTELNRS2.StatusBarAciklama = null;
            this.colTELNRS2.StatusBarKisayol = null;
            this.colTELNRS2.StatusBarKisayolAciklama = null;
            this.colTELNRS2.Visible = true;
            this.colTELNRS2.VisibleIndex = 6;
            // 
            // colYETKILI
            // 
            this.colYETKILI.Caption = "Yetkili";
            this.colYETKILI.FieldName = "YETKILI";
            this.colYETKILI.Name = "colYETKILI";
            this.colYETKILI.OptionsColumn.AllowEdit = false;
            this.colYETKILI.StatusBarAciklama = null;
            this.colYETKILI.StatusBarKisayol = null;
            this.colYETKILI.StatusBarKisayolAciklama = null;
            this.colYETKILI.Visible = true;
            this.colYETKILI.VisibleIndex = 7;
            // 
            // colMAIL
            // 
            this.colMAIL.Caption = "Mail Adresi";
            this.colMAIL.FieldName = "MAIL";
            this.colMAIL.Name = "colMAIL";
            this.colMAIL.OptionsColumn.AllowEdit = false;
            this.colMAIL.StatusBarAciklama = null;
            this.colMAIL.StatusBarKisayol = null;
            this.colMAIL.StatusBarKisayolAciklama = null;
            this.colMAIL.Visible = true;
            this.colMAIL.VisibleIndex = 8;
            // 
            // colPERIYOT
            // 
            this.colPERIYOT.Caption = "Periyot";
            this.colPERIYOT.FieldName = "PERIYOT";
            this.colPERIYOT.Name = "colPERIYOT";
            this.colPERIYOT.OptionsColumn.AllowEdit = false;
            this.colPERIYOT.StatusBarAciklama = null;
            this.colPERIYOT.StatusBarKisayol = null;
            this.colPERIYOT.StatusBarKisayolAciklama = null;
            this.colPERIYOT.Visible = true;
            this.colPERIYOT.VisibleIndex = 9;
            // 
            // colBAKIYE
            // 
            this.colBAKIYE.Caption = "Bakiye";
            this.colBAKIYE.DisplayFormat.FormatString = "N3";
            this.colBAKIYE.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Custom;
            this.colBAKIYE.FieldName = "BAKIYE";
            this.colBAKIYE.Name = "colBAKIYE";
            this.colBAKIYE.OptionsColumn.AllowEdit = false;
            this.colBAKIYE.StatusBarAciklama = null;
            this.colBAKIYE.StatusBarKisayol = null;
            this.colBAKIYE.StatusBarKisayolAciklama = null;
            this.colBAKIYE.Visible = true;
            this.colBAKIYE.VisibleIndex = 10;
            // 
            // colTLBAKIYE
            // 
            this.colTLBAKIYE.Caption = "TL Bakiye";
            this.colTLBAKIYE.DisplayFormat.FormatString = "N3";
            this.colTLBAKIYE.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Custom;
            this.colTLBAKIYE.FieldName = "TLBAKIYE";
            this.colTLBAKIYE.Name = "colTLBAKIYE";
            this.colTLBAKIYE.OptionsColumn.AllowEdit = false;
            this.colTLBAKIYE.StatusBarAciklama = null;
            this.colTLBAKIYE.StatusBarKisayol = null;
            this.colTLBAKIYE.StatusBarKisayolAciklama = null;
            this.colTLBAKIYE.Visible = true;
            this.colTLBAKIYE.VisibleIndex = 11;
            // 
            // colUSDBAKIYE
            // 
            this.colUSDBAKIYE.Caption = "USD Bakiye";
            this.colUSDBAKIYE.DisplayFormat.FormatString = "N3";
            this.colUSDBAKIYE.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Custom;
            this.colUSDBAKIYE.FieldName = "USDBAKIYE";
            this.colUSDBAKIYE.Name = "colUSDBAKIYE";
            this.colUSDBAKIYE.OptionsColumn.AllowEdit = false;
            this.colUSDBAKIYE.StatusBarAciklama = null;
            this.colUSDBAKIYE.StatusBarKisayol = null;
            this.colUSDBAKIYE.StatusBarKisayolAciklama = null;
            this.colUSDBAKIYE.Visible = true;
            this.colUSDBAKIYE.VisibleIndex = 12;
            // 
            // colUSDYERELBAKIYE
            // 
            this.colUSDYERELBAKIYE.Caption = "USD Yerel Bakiye";
            this.colUSDYERELBAKIYE.DisplayFormat.FormatString = "N3";
            this.colUSDYERELBAKIYE.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Custom;
            this.colUSDYERELBAKIYE.FieldName = "USDYERELBAKIYE";
            this.colUSDYERELBAKIYE.Name = "colUSDYERELBAKIYE";
            this.colUSDYERELBAKIYE.OptionsColumn.AllowEdit = false;
            this.colUSDYERELBAKIYE.StatusBarAciklama = null;
            this.colUSDYERELBAKIYE.StatusBarKisayol = null;
            this.colUSDYERELBAKIYE.StatusBarKisayolAciklama = null;
            this.colUSDYERELBAKIYE.Visible = true;
            this.colUSDYERELBAKIYE.VisibleIndex = 13;
            // 
            // colEUROBAKIYE
            // 
            this.colEUROBAKIYE.Caption = "Euro Bakiye";
            this.colEUROBAKIYE.DisplayFormat.FormatString = "N3";
            this.colEUROBAKIYE.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Custom;
            this.colEUROBAKIYE.FieldName = "EUROBAKIYE";
            this.colEUROBAKIYE.Name = "colEUROBAKIYE";
            this.colEUROBAKIYE.OptionsColumn.AllowEdit = false;
            this.colEUROBAKIYE.StatusBarAciklama = null;
            this.colEUROBAKIYE.StatusBarKisayol = null;
            this.colEUROBAKIYE.StatusBarKisayolAciklama = null;
            this.colEUROBAKIYE.Visible = true;
            this.colEUROBAKIYE.VisibleIndex = 14;
            // 
            // colEUROYERELBAKIYE
            // 
            this.colEUROYERELBAKIYE.Caption = "Euro Yerel Bakiye";
            this.colEUROYERELBAKIYE.DisplayFormat.FormatString = "N3";
            this.colEUROYERELBAKIYE.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Custom;
            this.colEUROYERELBAKIYE.FieldName = "EUROYERELBAKIYE";
            this.colEUROYERELBAKIYE.Name = "colEUROYERELBAKIYE";
            this.colEUROYERELBAKIYE.OptionsColumn.AllowEdit = false;
            this.colEUROYERELBAKIYE.StatusBarAciklama = null;
            this.colEUROYERELBAKIYE.StatusBarKisayol = null;
            this.colEUROYERELBAKIYE.StatusBarKisayolAciklama = null;
            this.colEUROYERELBAKIYE.Visible = true;
            this.colEUROYERELBAKIYE.VisibleIndex = 15;
            // 
            // myDataLayoutControl1
            // 
            this.myDataLayoutControl1.Controls.Add(this.grid);
            this.myDataLayoutControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.myDataLayoutControl1.Location = new System.Drawing.Point(0, 103);
            this.myDataLayoutControl1.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.myDataLayoutControl1.Name = "myDataLayoutControl1";
            this.myDataLayoutControl1.OptionsFocus.EnableAutoTabOrder = false;
            this.myDataLayoutControl1.Root = this.Root;
            this.myDataLayoutControl1.Size = new System.Drawing.Size(1134, 371);
            this.myDataLayoutControl1.TabIndex = 3;
            this.myDataLayoutControl1.Text = "myDataLayoutControl1";
            // 
            // Root
            // 
            this.Root.EnableIndentsWithoutBorders = DevExpress.Utils.DefaultBoolean.True;
            this.Root.GroupBordersVisible = false;
            this.Root.Items.AddRange(new DevExpress.XtraLayout.BaseLayoutItem[] {
            this.layoutControlItem1});
            this.Root.LayoutMode = DevExpress.XtraLayout.Utils.LayoutMode.Table;
            this.Root.Name = "Root";
            columnDefinition1.SizeType = System.Windows.Forms.SizeType.Percent;
            columnDefinition1.Width = 100D;
            this.Root.OptionsTableLayoutGroup.ColumnDefinitions.AddRange(new DevExpress.XtraLayout.ColumnDefinition[] {
            columnDefinition1});
            rowDefinition1.Height = 100D;
            rowDefinition1.SizeType = System.Windows.Forms.SizeType.Percent;
            this.Root.OptionsTableLayoutGroup.RowDefinitions.AddRange(new DevExpress.XtraLayout.RowDefinition[] {
            rowDefinition1});
            this.Root.Size = new System.Drawing.Size(1134, 371);
            this.Root.TextVisible = false;
            // 
            // layoutControlItem1
            // 
            this.layoutControlItem1.AppearanceItemCaption.ForeColor = System.Drawing.Color.Maroon;
            this.layoutControlItem1.AppearanceItemCaption.Options.UseForeColor = true;
            this.layoutControlItem1.Control = this.grid;
            this.layoutControlItem1.Location = new System.Drawing.Point(0, 0);
            this.layoutControlItem1.Name = "layoutControlItem1";
            this.layoutControlItem1.Size = new System.Drawing.Size(1114, 351);
            this.layoutControlItem1.TextSize = new System.Drawing.Size(0, 0);
            this.layoutControlItem1.TextVisible = false;
            // 
            // MutabakatRaporu
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1134, 501);
            this.Controls.Add(this.myDataLayoutControl1);
            this.IconOptions.ShowIcon = false;
            this.Name = "MutabakatRaporu";
            this.Tag = "TarihCari";
            this.Text = "Mutabakat Raporu";
            this.Controls.SetChildIndex(this.ribbonControl, 0);
            this.Controls.SetChildIndex(this.ribbonStatusBar1, 0);
            this.Controls.SetChildIndex(this.myDataLayoutControl1, 0);
            ((System.ComponentModel.ISupportInitialize)(this.ribbonControl)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.grid)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tablo)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.myDataLayoutControl1)).EndInit();
            this.myDataLayoutControl1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.Root)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private UserControls.Controls.Grid.MyGridControl grid;
        private UserControls.Controls.Grid.MyGridView tablo;
        private UserControls.Controls.Grid.MyGridColumn colID;
        private UserControls.Controls.MyDataLayoutControl myDataLayoutControl1;
        private DevExpress.XtraLayout.LayoutControlGroup Root;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem1;
        private UserControls.Controls.Grid.MyGridColumn colKod;
        private UserControls.Controls.Grid.MyGridColumn colUNVAN;
        private UserControls.Controls.Grid.MyGridColumn colVERGIDAIRE;
        private UserControls.Controls.Grid.MyGridColumn colVERGINO;
        private UserControls.Controls.Grid.MyGridColumn colTCNO;
        private UserControls.Controls.Grid.MyGridColumn colTELNRS1;
        private UserControls.Controls.Grid.MyGridColumn colTELNRS2;
        private UserControls.Controls.Grid.MyGridColumn colYETKILI;
        private UserControls.Controls.Grid.MyGridColumn colMAIL;
        private UserControls.Controls.Grid.MyGridColumn colPERIYOT;
        private UserControls.Controls.Grid.MyGridColumn colBAKIYE;
        private UserControls.Controls.Grid.MyGridColumn colTLBAKIYE;
        private UserControls.Controls.Grid.MyGridColumn colUSDBAKIYE;
        private UserControls.Controls.Grid.MyGridColumn colUSDYERELBAKIYE;
        private UserControls.Controls.Grid.MyGridColumn colEUROBAKIYE;
        private UserControls.Controls.Grid.MyGridColumn colEUROYERELBAKIYE;
    }
}