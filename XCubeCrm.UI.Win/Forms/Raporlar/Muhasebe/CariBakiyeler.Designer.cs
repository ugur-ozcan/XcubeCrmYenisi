namespace XCubeCrm.UI.Win.Forms.Raporlar.Muhasebe
{
    partial class CariBakiyeler
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(CariBakiyeler));
            this.grid = new XCubeCrm.UI.Win.Forms.UserControls.Controls.Grid.MyGridControl();
            this.tablo = new XCubeCrm.UI.Win.Forms.UserControls.Controls.Grid.MyGridView();
            this.colId = new XCubeCrm.UI.Win.Forms.UserControls.Controls.Grid.MyGridColumn();
            this.colKod = new XCubeCrm.UI.Win.Forms.UserControls.Controls.Grid.MyGridColumn();
            this.colUnvan = new XCubeCrm.UI.Win.Forms.UserControls.Controls.Grid.MyGridColumn();
            this.colBakiye = new XCubeCrm.UI.Win.Forms.UserControls.Controls.Grid.MyGridColumn();
            this.colBorc = new XCubeCrm.UI.Win.Forms.UserControls.Controls.Grid.MyGridColumn();
            this.colAlacak = new XCubeCrm.UI.Win.Forms.UserControls.Controls.Grid.MyGridColumn();
            this.colTlBakiye = new XCubeCrm.UI.Win.Forms.UserControls.Controls.Grid.MyGridColumn();
            this.colTlBorc = new XCubeCrm.UI.Win.Forms.UserControls.Controls.Grid.MyGridColumn();
            this.colTlAlacak = new XCubeCrm.UI.Win.Forms.UserControls.Controls.Grid.MyGridColumn();
            this.colUsdBakiye = new XCubeCrm.UI.Win.Forms.UserControls.Controls.Grid.MyGridColumn();
            this.colUsdBorc = new XCubeCrm.UI.Win.Forms.UserControls.Controls.Grid.MyGridColumn();
            this.colUsdAlacak = new XCubeCrm.UI.Win.Forms.UserControls.Controls.Grid.MyGridColumn();
            this.colEuroBakiye = new XCubeCrm.UI.Win.Forms.UserControls.Controls.Grid.MyGridColumn();
            this.colEuroBorc = new XCubeCrm.UI.Win.Forms.UserControls.Controls.Grid.MyGridColumn();
            this.colEuroAlacak = new XCubeCrm.UI.Win.Forms.UserControls.Controls.Grid.MyGridColumn();
            this.colUsdYerelBakiye = new XCubeCrm.UI.Win.Forms.UserControls.Controls.Grid.MyGridColumn();
            this.colUsdYerelBorc = new XCubeCrm.UI.Win.Forms.UserControls.Controls.Grid.MyGridColumn();
            this.colUsdYerelAlacak = new XCubeCrm.UI.Win.Forms.UserControls.Controls.Grid.MyGridColumn();
            this.colEuroYerelBakiye = new XCubeCrm.UI.Win.Forms.UserControls.Controls.Grid.MyGridColumn();
            this.colEuroYerelBorc = new XCubeCrm.UI.Win.Forms.UserControls.Controls.Grid.MyGridColumn();
            this.colEuroYerelAlacak = new XCubeCrm.UI.Win.Forms.UserControls.Controls.Grid.MyGridColumn();
            ((System.ComponentModel.ISupportInitialize)(this.ribbonControl)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.grid)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tablo)).BeginInit();
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
            this.grid.Dock = System.Windows.Forms.DockStyle.Fill;
            this.grid.EmbeddedNavigator.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.grid.Location = new System.Drawing.Point(0, 103);
            this.grid.MainView = this.tablo;
            this.grid.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.grid.MenuManager = this.ribbonControl;
            this.grid.Name = "grid";
            this.grid.Size = new System.Drawing.Size(1134, 371);
            this.grid.TabIndex = 2;
            this.grid.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.tablo});
            this.grid.DoubleClick += new System.EventHandler(this.grid_DoubleClick);
            // 
            // tablo
            // 
            this.tablo.Appearance.EvenRow.BackColor = System.Drawing.SystemColors.ControlDark;
            this.tablo.Appearance.EvenRow.Options.UseBackColor = true;
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
            this.colId,
            this.colKod,
            this.colUnvan,
            this.colBakiye,
            this.colBorc,
            this.colAlacak,
            this.colTlBakiye,
            this.colTlBorc,
            this.colTlAlacak,
            this.colUsdBakiye,
            this.colUsdBorc,
            this.colUsdAlacak,
            this.colEuroBakiye,
            this.colEuroBorc,
            this.colEuroAlacak,
            this.colUsdYerelBakiye,
            this.colUsdYerelBorc,
            this.colUsdYerelAlacak,
            this.colEuroYerelBakiye,
            this.colEuroYerelBorc,
            this.colEuroYerelAlacak});
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
            this.tablo.OptionsView.EnableAppearanceEvenRow = true;
            this.tablo.OptionsView.HeaderFilterButtonShowMode = DevExpress.XtraEditors.Controls.FilterButtonShowMode.Button;
            this.tablo.OptionsView.RowAutoHeight = true;
            this.tablo.OptionsView.ShowAutoFilterRow = true;
            this.tablo.OptionsView.ShowFooter = true;
            this.tablo.OptionsView.ShowGroupPanel = false;
            this.tablo.StatusBarAciklama = null;
            this.tablo.StatusBarKisayol = null;
            this.tablo.StatusBarKisayolAciklama = null;
            this.tablo.ViewCaption = "Cari Bakiyeler Döviz Bazlı";
            // 
            // colId
            // 
            this.colId.Caption = "Id";
            this.colId.FieldName = "Id";
            this.colId.MinWidth = 21;
            this.colId.Name = "colId";
            this.colId.OptionsColumn.AllowEdit = false;
            this.colId.OptionsColumn.ShowInCustomizationForm = false;
            this.colId.StatusBarAciklama = null;
            this.colId.StatusBarKisayol = null;
            this.colId.StatusBarKisayolAciklama = null;
            this.colId.Width = 81;
            // 
            // colKod
            // 
            this.colKod.AppearanceCell.Options.UseTextOptions = true;
            this.colKod.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.colKod.Caption = "Kod";
            this.colKod.FieldName = "Kod";
            this.colKod.MinWidth = 21;
            this.colKod.Name = "colKod";
            this.colKod.OptionsColumn.AllowEdit = false;
            this.colKod.StatusBarAciklama = null;
            this.colKod.StatusBarKisayol = null;
            this.colKod.StatusBarKisayolAciklama = null;
            this.colKod.Summary.AddRange(new DevExpress.XtraGrid.GridSummaryItem[] {
            new DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Count, DevExpress.Data.SummaryMode.Mixed, "Kod", "{0}")});
            this.colKod.Visible = true;
            this.colKod.VisibleIndex = 0;
            this.colKod.Width = 81;
            // 
            // colUnvan
            // 
            this.colUnvan.Caption = "Unvan";
            this.colUnvan.FieldName = "Unvan";
            this.colUnvan.MinWidth = 21;
            this.colUnvan.Name = "colUnvan";
            this.colUnvan.OptionsColumn.AllowEdit = false;
            this.colUnvan.StatusBarAciklama = null;
            this.colUnvan.StatusBarKisayol = null;
            this.colUnvan.StatusBarKisayolAciklama = null;
            this.colUnvan.Visible = true;
            this.colUnvan.VisibleIndex = 1;
            this.colUnvan.Width = 81;
            // 
            // colBakiye
            // 
            this.colBakiye.Caption = "Bakiye";
            this.colBakiye.DisplayFormat.FormatString = "N3";
            this.colBakiye.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Custom;
            this.colBakiye.FieldName = "Bakiye";
            this.colBakiye.MinWidth = 21;
            this.colBakiye.Name = "colBakiye";
            this.colBakiye.OptionsColumn.AllowEdit = false;
            this.colBakiye.StatusBarAciklama = null;
            this.colBakiye.StatusBarKisayol = null;
            this.colBakiye.StatusBarKisayolAciklama = null;
            this.colBakiye.Summary.AddRange(new DevExpress.XtraGrid.GridSummaryItem[] {
            new DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Sum, "Bakiye", "SUM={0:N3}")});
            this.colBakiye.Visible = true;
            this.colBakiye.VisibleIndex = 2;
            this.colBakiye.Width = 81;
            // 
            // colBorc
            // 
            this.colBorc.Caption = "Borç";
            this.colBorc.DisplayFormat.FormatString = "N3";
            this.colBorc.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Custom;
            this.colBorc.FieldName = "Borc";
            this.colBorc.MinWidth = 21;
            this.colBorc.Name = "colBorc";
            this.colBorc.OptionsColumn.AllowEdit = false;
            this.colBorc.StatusBarAciklama = null;
            this.colBorc.StatusBarKisayol = null;
            this.colBorc.StatusBarKisayolAciklama = null;
            this.colBorc.Summary.AddRange(new DevExpress.XtraGrid.GridSummaryItem[] {
            new DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Sum, "Borc", "SUM={0:N3}")});
            this.colBorc.Visible = true;
            this.colBorc.VisibleIndex = 3;
            this.colBorc.Width = 81;
            // 
            // colAlacak
            // 
            this.colAlacak.Caption = "Alacak";
            this.colAlacak.DisplayFormat.FormatString = "N3";
            this.colAlacak.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Custom;
            this.colAlacak.FieldName = "Alacak";
            this.colAlacak.MinWidth = 21;
            this.colAlacak.Name = "colAlacak";
            this.colAlacak.OptionsColumn.AllowEdit = false;
            this.colAlacak.StatusBarAciklama = null;
            this.colAlacak.StatusBarKisayol = null;
            this.colAlacak.StatusBarKisayolAciklama = null;
            this.colAlacak.Summary.AddRange(new DevExpress.XtraGrid.GridSummaryItem[] {
            new DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Sum, "Alacak", "SUM={0:N3}")});
            this.colAlacak.Visible = true;
            this.colAlacak.VisibleIndex = 4;
            this.colAlacak.Width = 81;
            // 
            // colTlBakiye
            // 
            this.colTlBakiye.Caption = "TL Bakiye";
            this.colTlBakiye.DisplayFormat.FormatString = "N3";
            this.colTlBakiye.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Custom;
            this.colTlBakiye.FieldName = "TlBakiye";
            this.colTlBakiye.MinWidth = 21;
            this.colTlBakiye.Name = "colTlBakiye";
            this.colTlBakiye.OptionsColumn.AllowEdit = false;
            this.colTlBakiye.StatusBarAciklama = null;
            this.colTlBakiye.StatusBarKisayol = null;
            this.colTlBakiye.StatusBarKisayolAciklama = null;
            this.colTlBakiye.Summary.AddRange(new DevExpress.XtraGrid.GridSummaryItem[] {
            new DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Sum, "TlBakiye", "SUM={0:N3}")});
            this.colTlBakiye.Visible = true;
            this.colTlBakiye.VisibleIndex = 5;
            this.colTlBakiye.Width = 81;
            // 
            // colTlBorc
            // 
            this.colTlBorc.Caption = "TL Borç";
            this.colTlBorc.DisplayFormat.FormatString = "N3";
            this.colTlBorc.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Custom;
            this.colTlBorc.FieldName = "TlBorc";
            this.colTlBorc.MinWidth = 21;
            this.colTlBorc.Name = "colTlBorc";
            this.colTlBorc.OptionsColumn.AllowEdit = false;
            this.colTlBorc.StatusBarAciklama = null;
            this.colTlBorc.StatusBarKisayol = null;
            this.colTlBorc.StatusBarKisayolAciklama = null;
            this.colTlBorc.Summary.AddRange(new DevExpress.XtraGrid.GridSummaryItem[] {
            new DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Sum, "TlBorc", "SUM={0:N3}")});
            this.colTlBorc.Visible = true;
            this.colTlBorc.VisibleIndex = 6;
            this.colTlBorc.Width = 81;
            // 
            // colTlAlacak
            // 
            this.colTlAlacak.Caption = "TL Alacak";
            this.colTlAlacak.DisplayFormat.FormatString = "N3";
            this.colTlAlacak.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Custom;
            this.colTlAlacak.FieldName = "TlAlacak";
            this.colTlAlacak.MinWidth = 21;
            this.colTlAlacak.Name = "colTlAlacak";
            this.colTlAlacak.OptionsColumn.AllowEdit = false;
            this.colTlAlacak.StatusBarAciklama = null;
            this.colTlAlacak.StatusBarKisayol = null;
            this.colTlAlacak.StatusBarKisayolAciklama = null;
            this.colTlAlacak.Summary.AddRange(new DevExpress.XtraGrid.GridSummaryItem[] {
            new DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Sum, "TlAlacak", "SUM={0:N3}")});
            this.colTlAlacak.Visible = true;
            this.colTlAlacak.VisibleIndex = 7;
            this.colTlAlacak.Width = 81;
            // 
            // colUsdBakiye
            // 
            this.colUsdBakiye.Caption = "USD Bakiye";
            this.colUsdBakiye.DisplayFormat.FormatString = "N3";
            this.colUsdBakiye.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Custom;
            this.colUsdBakiye.FieldName = "UsdBakiye";
            this.colUsdBakiye.MinWidth = 21;
            this.colUsdBakiye.Name = "colUsdBakiye";
            this.colUsdBakiye.OptionsColumn.AllowEdit = false;
            this.colUsdBakiye.StatusBarAciklama = null;
            this.colUsdBakiye.StatusBarKisayol = null;
            this.colUsdBakiye.StatusBarKisayolAciklama = null;
            this.colUsdBakiye.Summary.AddRange(new DevExpress.XtraGrid.GridSummaryItem[] {
            new DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Sum, "UsdBakiye", "SUM={0:N3}")});
            this.colUsdBakiye.Visible = true;
            this.colUsdBakiye.VisibleIndex = 8;
            this.colUsdBakiye.Width = 81;
            // 
            // colUsdBorc
            // 
            this.colUsdBorc.AccessibleDescription = "";
            this.colUsdBorc.Caption = "USD Borç";
            this.colUsdBorc.DisplayFormat.FormatString = "N3";
            this.colUsdBorc.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Custom;
            this.colUsdBorc.FieldName = "UsdBorc";
            this.colUsdBorc.MinWidth = 21;
            this.colUsdBorc.Name = "colUsdBorc";
            this.colUsdBorc.OptionsColumn.AllowEdit = false;
            this.colUsdBorc.StatusBarAciklama = null;
            this.colUsdBorc.StatusBarKisayol = null;
            this.colUsdBorc.StatusBarKisayolAciklama = null;
            this.colUsdBorc.Summary.AddRange(new DevExpress.XtraGrid.GridSummaryItem[] {
            new DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Sum, "UsdBorc", "SUM={0:N3}")});
            this.colUsdBorc.Visible = true;
            this.colUsdBorc.VisibleIndex = 9;
            this.colUsdBorc.Width = 81;
            // 
            // colUsdAlacak
            // 
            this.colUsdAlacak.AccessibleDescription = "";
            this.colUsdAlacak.Caption = "USD Alacak";
            this.colUsdAlacak.DisplayFormat.FormatString = "N3";
            this.colUsdAlacak.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Custom;
            this.colUsdAlacak.FieldName = "UsdAlacak";
            this.colUsdAlacak.MinWidth = 21;
            this.colUsdAlacak.Name = "colUsdAlacak";
            this.colUsdAlacak.OptionsColumn.AllowEdit = false;
            this.colUsdAlacak.StatusBarAciklama = null;
            this.colUsdAlacak.StatusBarKisayol = null;
            this.colUsdAlacak.StatusBarKisayolAciklama = null;
            this.colUsdAlacak.Summary.AddRange(new DevExpress.XtraGrid.GridSummaryItem[] {
            new DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Sum, "UsdAlacak", "SUM={0:N3}")});
            this.colUsdAlacak.Visible = true;
            this.colUsdAlacak.VisibleIndex = 10;
            this.colUsdAlacak.Width = 81;
            // 
            // colEuroBakiye
            // 
            this.colEuroBakiye.AccessibleDescription = "";
            this.colEuroBakiye.Caption = "EURO Bakiye";
            this.colEuroBakiye.DisplayFormat.FormatString = "N3";
            this.colEuroBakiye.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Custom;
            this.colEuroBakiye.FieldName = "EuroBakiye";
            this.colEuroBakiye.MinWidth = 21;
            this.colEuroBakiye.Name = "colEuroBakiye";
            this.colEuroBakiye.OptionsColumn.AllowEdit = false;
            this.colEuroBakiye.StatusBarAciklama = null;
            this.colEuroBakiye.StatusBarKisayol = null;
            this.colEuroBakiye.StatusBarKisayolAciklama = null;
            this.colEuroBakiye.Summary.AddRange(new DevExpress.XtraGrid.GridSummaryItem[] {
            new DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Sum, "EuroBakiye", "SUM={0:N3}")});
            this.colEuroBakiye.Visible = true;
            this.colEuroBakiye.VisibleIndex = 11;
            this.colEuroBakiye.Width = 81;
            // 
            // colEuroBorc
            // 
            this.colEuroBorc.AccessibleDescription = "";
            this.colEuroBorc.Caption = "EURO Borç";
            this.colEuroBorc.DisplayFormat.FormatString = "N3";
            this.colEuroBorc.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Custom;
            this.colEuroBorc.FieldName = "EuroBorc";
            this.colEuroBorc.MinWidth = 21;
            this.colEuroBorc.Name = "colEuroBorc";
            this.colEuroBorc.OptionsColumn.AllowEdit = false;
            this.colEuroBorc.StatusBarAciklama = null;
            this.colEuroBorc.StatusBarKisayol = null;
            this.colEuroBorc.StatusBarKisayolAciklama = null;
            this.colEuroBorc.Summary.AddRange(new DevExpress.XtraGrid.GridSummaryItem[] {
            new DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Sum, "EuroBorc", "SUM={0:N3}")});
            this.colEuroBorc.Visible = true;
            this.colEuroBorc.VisibleIndex = 12;
            this.colEuroBorc.Width = 81;
            // 
            // colEuroAlacak
            // 
            this.colEuroAlacak.AccessibleDescription = "";
            this.colEuroAlacak.Caption = "EURO Alacak";
            this.colEuroAlacak.DisplayFormat.FormatString = "N3";
            this.colEuroAlacak.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Custom;
            this.colEuroAlacak.FieldName = "EuroAlacak";
            this.colEuroAlacak.MinWidth = 21;
            this.colEuroAlacak.Name = "colEuroAlacak";
            this.colEuroAlacak.OptionsColumn.AllowEdit = false;
            this.colEuroAlacak.StatusBarAciklama = null;
            this.colEuroAlacak.StatusBarKisayol = null;
            this.colEuroAlacak.StatusBarKisayolAciklama = null;
            this.colEuroAlacak.Summary.AddRange(new DevExpress.XtraGrid.GridSummaryItem[] {
            new DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Sum, "EuroAlacak", "SUM={0:N3}")});
            this.colEuroAlacak.Visible = true;
            this.colEuroAlacak.VisibleIndex = 13;
            this.colEuroAlacak.Width = 81;
            // 
            // colUsdYerelBakiye
            // 
            this.colUsdYerelBakiye.AccessibleDescription = "";
            this.colUsdYerelBakiye.Caption = "USD Yerel Bakiye";
            this.colUsdYerelBakiye.DisplayFormat.FormatString = "N3";
            this.colUsdYerelBakiye.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Custom;
            this.colUsdYerelBakiye.FieldName = "UsdYerelBakiye";
            this.colUsdYerelBakiye.MinWidth = 21;
            this.colUsdYerelBakiye.Name = "colUsdYerelBakiye";
            this.colUsdYerelBakiye.OptionsColumn.AllowEdit = false;
            this.colUsdYerelBakiye.StatusBarAciklama = null;
            this.colUsdYerelBakiye.StatusBarKisayol = null;
            this.colUsdYerelBakiye.StatusBarKisayolAciklama = null;
            this.colUsdYerelBakiye.Summary.AddRange(new DevExpress.XtraGrid.GridSummaryItem[] {
            new DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Sum, "UsdYerelBakiye", "SUM={0:N3}")});
            this.colUsdYerelBakiye.Visible = true;
            this.colUsdYerelBakiye.VisibleIndex = 14;
            this.colUsdYerelBakiye.Width = 81;
            // 
            // colUsdYerelBorc
            // 
            this.colUsdYerelBorc.AccessibleDescription = "";
            this.colUsdYerelBorc.Caption = "USD Yerel Borç";
            this.colUsdYerelBorc.DisplayFormat.FormatString = "N3";
            this.colUsdYerelBorc.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Custom;
            this.colUsdYerelBorc.FieldName = "UsdYerelBorc";
            this.colUsdYerelBorc.MinWidth = 21;
            this.colUsdYerelBorc.Name = "colUsdYerelBorc";
            this.colUsdYerelBorc.OptionsColumn.AllowEdit = false;
            this.colUsdYerelBorc.StatusBarAciklama = null;
            this.colUsdYerelBorc.StatusBarKisayol = null;
            this.colUsdYerelBorc.StatusBarKisayolAciklama = null;
            this.colUsdYerelBorc.Summary.AddRange(new DevExpress.XtraGrid.GridSummaryItem[] {
            new DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Sum, "UsdYerelBorc", "SUM={0:N3}")});
            this.colUsdYerelBorc.Visible = true;
            this.colUsdYerelBorc.VisibleIndex = 15;
            this.colUsdYerelBorc.Width = 81;
            // 
            // colUsdYerelAlacak
            // 
            this.colUsdYerelAlacak.AccessibleDescription = "";
            this.colUsdYerelAlacak.Caption = "USD Yerel Alacak";
            this.colUsdYerelAlacak.DisplayFormat.FormatString = "N3";
            this.colUsdYerelAlacak.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Custom;
            this.colUsdYerelAlacak.FieldName = "UsdYerelAlacak";
            this.colUsdYerelAlacak.MinWidth = 21;
            this.colUsdYerelAlacak.Name = "colUsdYerelAlacak";
            this.colUsdYerelAlacak.OptionsColumn.AllowEdit = false;
            this.colUsdYerelAlacak.StatusBarAciklama = null;
            this.colUsdYerelAlacak.StatusBarKisayol = null;
            this.colUsdYerelAlacak.StatusBarKisayolAciklama = null;
            this.colUsdYerelAlacak.Summary.AddRange(new DevExpress.XtraGrid.GridSummaryItem[] {
            new DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Sum, "UsdYerelAlacak", "SUM={0:N3}")});
            this.colUsdYerelAlacak.Visible = true;
            this.colUsdYerelAlacak.VisibleIndex = 16;
            this.colUsdYerelAlacak.Width = 81;
            // 
            // colEuroYerelBakiye
            // 
            this.colEuroYerelBakiye.AccessibleDescription = "";
            this.colEuroYerelBakiye.Caption = "EURO Yere lBakiye";
            this.colEuroYerelBakiye.DisplayFormat.FormatString = "N3";
            this.colEuroYerelBakiye.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Custom;
            this.colEuroYerelBakiye.FieldName = "EuroYerelBakiye";
            this.colEuroYerelBakiye.MinWidth = 21;
            this.colEuroYerelBakiye.Name = "colEuroYerelBakiye";
            this.colEuroYerelBakiye.OptionsColumn.AllowEdit = false;
            this.colEuroYerelBakiye.StatusBarAciklama = null;
            this.colEuroYerelBakiye.StatusBarKisayol = null;
            this.colEuroYerelBakiye.StatusBarKisayolAciklama = null;
            this.colEuroYerelBakiye.Summary.AddRange(new DevExpress.XtraGrid.GridSummaryItem[] {
            new DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Sum, "EuroYerelBakiye", "SUM={0:N3}")});
            this.colEuroYerelBakiye.Visible = true;
            this.colEuroYerelBakiye.VisibleIndex = 17;
            this.colEuroYerelBakiye.Width = 81;
            // 
            // colEuroYerelBorc
            // 
            this.colEuroYerelBorc.AccessibleDescription = "";
            this.colEuroYerelBorc.Caption = "EURO Yerel Borç";
            this.colEuroYerelBorc.DisplayFormat.FormatString = "N3";
            this.colEuroYerelBorc.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Custom;
            this.colEuroYerelBorc.FieldName = "EuroYerelBorc";
            this.colEuroYerelBorc.MinWidth = 21;
            this.colEuroYerelBorc.Name = "colEuroYerelBorc";
            this.colEuroYerelBorc.OptionsColumn.AllowEdit = false;
            this.colEuroYerelBorc.StatusBarAciklama = null;
            this.colEuroYerelBorc.StatusBarKisayol = null;
            this.colEuroYerelBorc.StatusBarKisayolAciklama = null;
            this.colEuroYerelBorc.Summary.AddRange(new DevExpress.XtraGrid.GridSummaryItem[] {
            new DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Sum, "EuroYerelBorc", "SUM={0:N3}")});
            this.colEuroYerelBorc.Visible = true;
            this.colEuroYerelBorc.VisibleIndex = 18;
            this.colEuroYerelBorc.Width = 81;
            // 
            // colEuroYerelAlacak
            // 
            this.colEuroYerelAlacak.AccessibleDescription = "";
            this.colEuroYerelAlacak.Caption = "EURO Yerel Alacak";
            this.colEuroYerelAlacak.DisplayFormat.FormatString = "N3";
            this.colEuroYerelAlacak.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Custom;
            this.colEuroYerelAlacak.FieldName = "EuroYerelAlacak";
            this.colEuroYerelAlacak.MinWidth = 21;
            this.colEuroYerelAlacak.Name = "colEuroYerelAlacak";
            this.colEuroYerelAlacak.OptionsColumn.AllowEdit = false;
            this.colEuroYerelAlacak.StatusBarAciklama = null;
            this.colEuroYerelAlacak.StatusBarKisayol = null;
            this.colEuroYerelAlacak.StatusBarKisayolAciklama = null;
            this.colEuroYerelAlacak.Summary.AddRange(new DevExpress.XtraGrid.GridSummaryItem[] {
            new DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Sum, "EuroYerelAlacak", "SUM={0:N3}")});
            this.colEuroYerelAlacak.Visible = true;
            this.colEuroYerelAlacak.VisibleIndex = 19;
            this.colEuroYerelAlacak.Width = 81;
            // 
            // CariBakiyeler
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1134, 501);
            this.Controls.Add(this.grid);
            this.IconOptions.ShowIcon = false;
            this.Name = "CariBakiyeler";
            this.Tag = "TarihCariDoviz";
            this.Text = "Cari Bakiyeler";
            this.Controls.SetChildIndex(this.ribbonControl, 0);
            this.Controls.SetChildIndex(this.ribbonStatusBar1, 0);
            this.Controls.SetChildIndex(this.grid, 0);
            ((System.ComponentModel.ISupportInitialize)(this.ribbonControl)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.grid)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tablo)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private UserControls.Controls.Grid.MyGridControl grid;
        private UserControls.Controls.Grid.MyGridView tablo;
        private UserControls.Controls.Grid.MyGridColumn colId;
        private UserControls.Controls.Grid.MyGridColumn colKod;
        private UserControls.Controls.Grid.MyGridColumn colBakiye;
        private UserControls.Controls.Grid.MyGridColumn colBorc;
        private UserControls.Controls.Grid.MyGridColumn colAlacak;
        private UserControls.Controls.Grid.MyGridColumn colTlBakiye;
        private UserControls.Controls.Grid.MyGridColumn colTlBorc;
        private UserControls.Controls.Grid.MyGridColumn colTlAlacak;
        private UserControls.Controls.Grid.MyGridColumn colUsdBakiye;
        private UserControls.Controls.Grid.MyGridColumn colUsdBorc;
        private UserControls.Controls.Grid.MyGridColumn colUsdAlacak;
        private UserControls.Controls.Grid.MyGridColumn colEuroBakiye;
        private UserControls.Controls.Grid.MyGridColumn colEuroBorc;
        private UserControls.Controls.Grid.MyGridColumn colEuroAlacak;
        private UserControls.Controls.Grid.MyGridColumn colUsdYerelBakiye;
        private UserControls.Controls.Grid.MyGridColumn colUsdYerelBorc;
        private UserControls.Controls.Grid.MyGridColumn colUsdYerelAlacak;
        private UserControls.Controls.Grid.MyGridColumn colEuroYerelBakiye;
        private UserControls.Controls.Grid.MyGridColumn colEuroYerelBorc;
        private UserControls.Controls.Grid.MyGridColumn colEuroYerelAlacak;
        private UserControls.Controls.Grid.MyGridColumn colUnvan;
    }
}