namespace XCubeCrm.UI.Win.Forms.Raporlar.Muhasebe
{
    partial class KurFarkiHesaplama
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(KurFarkiHesaplama));
            DevExpress.XtraLayout.ColumnDefinition columnDefinition1 = new DevExpress.XtraLayout.ColumnDefinition();
            DevExpress.XtraLayout.RowDefinition rowDefinition1 = new DevExpress.XtraLayout.RowDefinition();
            this.grid = new XCubeCrm.UI.Win.Forms.UserControls.Controls.Grid.MyGridControl();
            this.tablo = new XCubeCrm.UI.Win.Forms.UserControls.Controls.Grid.MyGridView();
            this.colId = new XCubeCrm.UI.Win.Forms.UserControls.Controls.Grid.MyGridColumn();
            this.colKod = new XCubeCrm.UI.Win.Forms.UserControls.Controls.Grid.MyGridColumn();
            this.colUnvan = new XCubeCrm.UI.Win.Forms.UserControls.Controls.Grid.MyGridColumn();
            this.colDoviz = new XCubeCrm.UI.Win.Forms.UserControls.Controls.Grid.MyGridColumn();
            this.colKur = new XCubeCrm.UI.Win.Forms.UserControls.Controls.Grid.MyGridColumn();
            this.colDolarBakiye = new XCubeCrm.UI.Win.Forms.UserControls.Controls.Grid.MyGridColumn();
            this.colDolarTLBakiye = new XCubeCrm.UI.Win.Forms.UserControls.Controls.Grid.MyGridColumn();
            this.colDolarKurFarki = new XCubeCrm.UI.Win.Forms.UserControls.Controls.Grid.MyGridColumn();
            this.colEuroBakiye = new XCubeCrm.UI.Win.Forms.UserControls.Controls.Grid.MyGridColumn();
            this.colEuroTLBakiye = new XCubeCrm.UI.Win.Forms.UserControls.Controls.Grid.MyGridColumn();
            this.colEuroKurFarki = new XCubeCrm.UI.Win.Forms.UserControls.Controls.Grid.MyGridColumn();
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
            this.colId,
            this.colKod,
            this.colUnvan,
            this.colDoviz,
            this.colKur,
            this.colDolarBakiye,
            this.colDolarTLBakiye,
            this.colDolarKurFarki,
            this.colEuroBakiye,
            this.colEuroTLBakiye,
            this.colEuroKurFarki});
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
            this.tablo.ViewCaption = "Kur Farkı";
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
            this.colKod.FieldName = "KOD";
            this.colKod.MinWidth = 21;
            this.colKod.Name = "colKod";
            this.colKod.OptionsColumn.AllowEdit = false;
            this.colKod.StatusBarAciklama = null;
            this.colKod.StatusBarKisayol = null;
            this.colKod.StatusBarKisayolAciklama = null;
            this.colKod.Visible = true;
            this.colKod.VisibleIndex = 0;
            this.colKod.Width = 81;
            // 
            // colUnvan
            // 
            this.colUnvan.Caption = "Ünvan";
            this.colUnvan.FieldName = "UNVAN";
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
            // colDoviz
            // 
            this.colDoviz.Caption = "Döviz";
            this.colDoviz.FieldName = "DOVIZ";
            this.colDoviz.MinWidth = 21;
            this.colDoviz.Name = "colDoviz";
            this.colDoviz.OptionsColumn.AllowEdit = false;
            this.colDoviz.StatusBarAciklama = null;
            this.colDoviz.StatusBarKisayol = null;
            this.colDoviz.StatusBarKisayolAciklama = null;
            this.colDoviz.Visible = true;
            this.colDoviz.VisibleIndex = 2;
            this.colDoviz.Width = 81;
            // 
            // colKur
            // 
            this.colKur.Caption = "Kur";
            this.colKur.DisplayFormat.FormatString = "N3";
            this.colKur.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Custom;
            this.colKur.FieldName = "KUR";
            this.colKur.MinWidth = 21;
            this.colKur.Name = "colKur";
            this.colKur.OptionsColumn.AllowEdit = false;
            this.colKur.StatusBarAciklama = null;
            this.colKur.StatusBarKisayol = null;
            this.colKur.StatusBarKisayolAciklama = null;
            this.colKur.Visible = true;
            this.colKur.VisibleIndex = 3;
            this.colKur.Width = 81;
            // 
            // colDolarBakiye
            // 
            this.colDolarBakiye.Caption = "Dolar Bakiye";
            this.colDolarBakiye.DisplayFormat.FormatString = "N3";
            this.colDolarBakiye.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Custom;
            this.colDolarBakiye.FieldName = "DOLARBAKIYE";
            this.colDolarBakiye.MinWidth = 21;
            this.colDolarBakiye.Name = "colDolarBakiye";
            this.colDolarBakiye.OptionsColumn.AllowEdit = false;
            this.colDolarBakiye.StatusBarAciklama = null;
            this.colDolarBakiye.StatusBarKisayol = null;
            this.colDolarBakiye.StatusBarKisayolAciklama = null;
            this.colDolarBakiye.Visible = true;
            this.colDolarBakiye.VisibleIndex = 4;
            this.colDolarBakiye.Width = 81;
            // 
            // colDolarTLBakiye
            // 
            this.colDolarTLBakiye.Caption = "Dolar TL Bakiye";
            this.colDolarTLBakiye.DisplayFormat.FormatString = "N3";
            this.colDolarTLBakiye.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Custom;
            this.colDolarTLBakiye.FieldName = "DOLARTLBAKIYE";
            this.colDolarTLBakiye.MinWidth = 21;
            this.colDolarTLBakiye.Name = "colDolarTLBakiye";
            this.colDolarTLBakiye.OptionsColumn.AllowEdit = false;
            this.colDolarTLBakiye.StatusBarAciklama = null;
            this.colDolarTLBakiye.StatusBarKisayol = null;
            this.colDolarTLBakiye.StatusBarKisayolAciklama = null;
            this.colDolarTLBakiye.Visible = true;
            this.colDolarTLBakiye.VisibleIndex = 5;
            this.colDolarTLBakiye.Width = 81;
            // 
            // colDolarKurFarki
            // 
            this.colDolarKurFarki.Caption = "Dolar Kur Farkı";
            this.colDolarKurFarki.DisplayFormat.FormatString = "N3";
            this.colDolarKurFarki.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Custom;
            this.colDolarKurFarki.FieldName = "DOLARKURFARKI";
            this.colDolarKurFarki.MinWidth = 21;
            this.colDolarKurFarki.Name = "colDolarKurFarki";
            this.colDolarKurFarki.OptionsColumn.AllowEdit = false;
            this.colDolarKurFarki.StatusBarAciklama = null;
            this.colDolarKurFarki.StatusBarKisayol = null;
            this.colDolarKurFarki.StatusBarKisayolAciklama = null;
            this.colDolarKurFarki.Visible = true;
            this.colDolarKurFarki.VisibleIndex = 6;
            this.colDolarKurFarki.Width = 81;
            // 
            // colEuroBakiye
            // 
            this.colEuroBakiye.Caption = "Euro Bakiye";
            this.colEuroBakiye.DisplayFormat.FormatString = "N3";
            this.colEuroBakiye.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Custom;
            this.colEuroBakiye.FieldName = "EUROBAKIYE";
            this.colEuroBakiye.MinWidth = 21;
            this.colEuroBakiye.Name = "colEuroBakiye";
            this.colEuroBakiye.OptionsColumn.AllowEdit = false;
            this.colEuroBakiye.StatusBarAciklama = null;
            this.colEuroBakiye.StatusBarKisayol = null;
            this.colEuroBakiye.StatusBarKisayolAciklama = null;
            this.colEuroBakiye.Visible = true;
            this.colEuroBakiye.VisibleIndex = 7;
            this.colEuroBakiye.Width = 81;
            // 
            // colEuroTLBakiye
            // 
            this.colEuroTLBakiye.Caption = "Euro TL Bakiye";
            this.colEuroTLBakiye.DisplayFormat.FormatString = "N3";
            this.colEuroTLBakiye.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Custom;
            this.colEuroTLBakiye.FieldName = "EUROTLBAKIYE";
            this.colEuroTLBakiye.MinWidth = 21;
            this.colEuroTLBakiye.Name = "colEuroTLBakiye";
            this.colEuroTLBakiye.OptionsColumn.AllowEdit = false;
            this.colEuroTLBakiye.StatusBarAciklama = null;
            this.colEuroTLBakiye.StatusBarKisayol = null;
            this.colEuroTLBakiye.StatusBarKisayolAciklama = null;
            this.colEuroTLBakiye.Visible = true;
            this.colEuroTLBakiye.VisibleIndex = 8;
            this.colEuroTLBakiye.Width = 81;
            // 
            // colEuroKurFarki
            // 
            this.colEuroKurFarki.Caption = "Euro Kur Farkı";
            this.colEuroKurFarki.DisplayFormat.FormatString = "N3";
            this.colEuroKurFarki.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Custom;
            this.colEuroKurFarki.FieldName = "EUROKURFARKI";
            this.colEuroKurFarki.MinWidth = 21;
            this.colEuroKurFarki.Name = "colEuroKurFarki";
            this.colEuroKurFarki.OptionsColumn.AllowEdit = false;
            this.colEuroKurFarki.StatusBarAciklama = null;
            this.colEuroKurFarki.StatusBarKisayol = null;
            this.colEuroKurFarki.StatusBarKisayolAciklama = null;
            this.colEuroKurFarki.Visible = true;
            this.colEuroKurFarki.VisibleIndex = 9;
            this.colEuroKurFarki.Width = 81;
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
            // KurFarkiHesaplama
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1134, 501);
            this.Controls.Add(this.myDataLayoutControl1);
            this.IconOptions.ShowIcon = false;
            this.Name = "KurFarkiHesaplama";
            this.Tag = "TarihCariDoviz";
            this.Text = "Kur Farkı Hesaplama";
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
        private UserControls.Controls.Grid.MyGridColumn colId;
        private UserControls.Controls.Grid.MyGridColumn colKod;
        private UserControls.Controls.MyDataLayoutControl myDataLayoutControl1;
        private DevExpress.XtraLayout.LayoutControlGroup Root;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem1;
        private UserControls.Controls.Grid.MyGridColumn colUnvan;
        private UserControls.Controls.Grid.MyGridColumn colDoviz;
        private UserControls.Controls.Grid.MyGridColumn colKur;
        private UserControls.Controls.Grid.MyGridColumn colDolarBakiye;
        private UserControls.Controls.Grid.MyGridColumn colDolarTLBakiye;
        private UserControls.Controls.Grid.MyGridColumn colDolarKurFarki;
        private UserControls.Controls.Grid.MyGridColumn colEuroBakiye;
        private UserControls.Controls.Grid.MyGridColumn colEuroTLBakiye;
        private UserControls.Controls.Grid.MyGridColumn colEuroKurFarki;
    }
}