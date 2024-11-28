namespace XCubeCrm.UI.Win.Forms.Raporlar.Muhasebe
{
    partial class NumaralamaKontrolu
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(NumaralamaKontrolu));
            DevExpress.XtraLayout.ColumnDefinition columnDefinition1 = new DevExpress.XtraLayout.ColumnDefinition();
            DevExpress.XtraLayout.ColumnDefinition columnDefinition2 = new DevExpress.XtraLayout.ColumnDefinition();
            DevExpress.XtraLayout.RowDefinition rowDefinition1 = new DevExpress.XtraLayout.RowDefinition();
            this.grid = new XCubeCrm.UI.Win.Forms.UserControls.Controls.Grid.MyGridControl();
            this.tablo = new XCubeCrm.UI.Win.Forms.UserControls.Controls.Grid.MyGridView();
            this.colId = new XCubeCrm.UI.Win.Forms.UserControls.Controls.Grid.MyGridColumn();
            this.colKod = new XCubeCrm.UI.Win.Forms.UserControls.Controls.Grid.MyGridColumn();
            this.colNumara = new XCubeCrm.UI.Win.Forms.UserControls.Controls.Grid.MyGridColumn();
            this.colFisTuru = new XCubeCrm.UI.Win.Forms.UserControls.Controls.Grid.MyGridColumn();
            this.ColHata = new XCubeCrm.UI.Win.Forms.UserControls.Controls.Grid.MyGridColumn();
            this.myDataLayoutControl1 = new XCubeCrm.UI.Win.Forms.UserControls.Controls.MyDataLayoutControl();
            this.grid1 = new XCubeCrm.UI.Win.Forms.UserControls.Controls.Grid.MyGridControl();
            this.tablo1 = new XCubeCrm.UI.Win.Forms.UserControls.Controls.Grid.MyGridView();
            this.colId1 = new XCubeCrm.UI.Win.Forms.UserControls.Controls.Grid.MyGridColumn();
            this.colKod1 = new XCubeCrm.UI.Win.Forms.UserControls.Controls.Grid.MyGridColumn();
            this.colTip = new XCubeCrm.UI.Win.Forms.UserControls.Controls.Grid.MyGridColumn();
            this.colSeri = new XCubeCrm.UI.Win.Forms.UserControls.Controls.Grid.MyGridColumn();
            this.colSonNumara = new XCubeCrm.UI.Win.Forms.UserControls.Controls.Grid.MyGridColumn();
            this.Root = new DevExpress.XtraLayout.LayoutControlGroup();
            this.layoutControlItem1 = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlItem2 = new DevExpress.XtraLayout.LayoutControlItem();
            ((System.ComponentModel.ISupportInitialize)(this.ribbonControl)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.grid)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tablo)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.myDataLayoutControl1)).BeginInit();
            this.myDataLayoutControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.grid1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tablo1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Root)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem2)).BeginInit();
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
            this.grid.Size = new System.Drawing.Size(776, 347);
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
            this.colNumara,
            this.colFisTuru,
            this.ColHata});
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
            this.tablo.OptionsView.ShowViewCaption = true;
            this.tablo.StatusBarAciklama = null;
            this.tablo.StatusBarKisayol = null;
            this.tablo.StatusBarKisayolAciklama = null;
            this.tablo.ViewCaption = "Atlayan Numara ve Tarih";
            this.tablo.SelectionChanged += new DevExpress.Data.SelectionChangedEventHandler(this.tablo_SelectionChanged);
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
            this.colKod.Visible = true;
            this.colKod.VisibleIndex = 0;
            this.colKod.Width = 81;
            // 
            // colNumara
            // 
            this.colNumara.Caption = "Numara";
            this.colNumara.FieldName = "Numara";
            this.colNumara.MinWidth = 21;
            this.colNumara.Name = "colNumara";
            this.colNumara.OptionsColumn.AllowEdit = false;
            this.colNumara.StatusBarAciklama = null;
            this.colNumara.StatusBarKisayol = null;
            this.colNumara.StatusBarKisayolAciklama = null;
            this.colNumara.Visible = true;
            this.colNumara.VisibleIndex = 1;
            this.colNumara.Width = 81;
            // 
            // colFisTuru
            // 
            this.colFisTuru.Caption = "Fiş Türü";
            this.colFisTuru.FieldName = "FisTuru";
            this.colFisTuru.MinWidth = 21;
            this.colFisTuru.Name = "colFisTuru";
            this.colFisTuru.OptionsColumn.AllowEdit = false;
            this.colFisTuru.StatusBarAciklama = null;
            this.colFisTuru.StatusBarKisayol = null;
            this.colFisTuru.StatusBarKisayolAciklama = null;
            this.colFisTuru.Visible = true;
            this.colFisTuru.VisibleIndex = 2;
            this.colFisTuru.Width = 81;
            // 
            // ColHata
            // 
            this.ColHata.Caption = "Hata Tipi";
            this.ColHata.FieldName = "Hata";
            this.ColHata.Name = "ColHata";
            this.ColHata.OptionsColumn.AllowEdit = false;
            this.ColHata.StatusBarAciklama = null;
            this.ColHata.StatusBarKisayol = null;
            this.ColHata.StatusBarKisayolAciklama = null;
            this.ColHata.Visible = true;
            this.ColHata.VisibleIndex = 3;
            // 
            // myDataLayoutControl1
            // 
            this.myDataLayoutControl1.Controls.Add(this.grid1);
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
            // grid1
            // 
            this.grid1.EmbeddedNavigator.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.grid1.Location = new System.Drawing.Point(792, 12);
            this.grid1.MainView = this.tablo1;
            this.grid1.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.grid1.MenuManager = this.ribbonControl;
            this.grid1.Name = "grid1";
            this.grid1.Size = new System.Drawing.Size(330, 347);
            this.grid1.TabIndex = 4;
            this.grid1.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.tablo1});
            // 
            // tablo1
            // 
            this.tablo1.Appearance.FooterPanel.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
            this.tablo1.Appearance.FooterPanel.ForeColor = System.Drawing.Color.Maroon;
            this.tablo1.Appearance.FooterPanel.Options.UseFont = true;
            this.tablo1.Appearance.FooterPanel.Options.UseForeColor = true;
            this.tablo1.Appearance.HeaderPanel.ForeColor = System.Drawing.Color.Maroon;
            this.tablo1.Appearance.HeaderPanel.Options.UseForeColor = true;
            this.tablo1.Appearance.HeaderPanel.Options.UseTextOptions = true;
            this.tablo1.Appearance.HeaderPanel.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.tablo1.Appearance.Row.Options.UseTextOptions = true;
            this.tablo1.Appearance.Row.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Center;
            this.tablo1.Appearance.ViewCaption.ForeColor = System.Drawing.Color.Maroon;
            this.tablo1.Appearance.ViewCaption.Options.UseForeColor = true;
            this.tablo1.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.colId1,
            this.colKod1,
            this.colTip,
            this.colSeri,
            this.colSonNumara});
            this.tablo1.DetailHeight = 284;
            this.tablo1.FocusRectStyle = DevExpress.XtraGrid.Views.Grid.DrawFocusRectStyle.RowFocus;
            this.tablo1.GridControl = this.grid1;
            this.tablo1.Name = "tablo1";
            this.tablo1.OptionsEditForm.PopupEditFormWidth = 686;
            this.tablo1.OptionsMenu.EnableColumnMenu = false;
            this.tablo1.OptionsMenu.EnableFooterMenu = false;
            this.tablo1.OptionsMenu.EnableGroupPanelMenu = false;
            this.tablo1.OptionsMenu.ShowFooterItem = true;
            this.tablo1.OptionsMenu.ShowSummaryItemMode = DevExpress.Utils.DefaultBoolean.True;
            this.tablo1.OptionsNavigation.EnterMoveNextColumn = true;
            this.tablo1.OptionsPrint.AutoWidth = false;
            this.tablo1.OptionsPrint.PrintFooter = false;
            this.tablo1.OptionsPrint.PrintGroupFooter = false;
            this.tablo1.OptionsView.BestFitMode = DevExpress.XtraGrid.Views.Grid.GridBestFitMode.Fast;
            this.tablo1.OptionsView.ColumnAutoWidth = false;
            this.tablo1.OptionsView.HeaderFilterButtonShowMode = DevExpress.XtraEditors.Controls.FilterButtonShowMode.Button;
            this.tablo1.OptionsView.RowAutoHeight = true;
            this.tablo1.OptionsView.ShowAutoFilterRow = true;
            this.tablo1.OptionsView.ShowFooter = true;
            this.tablo1.OptionsView.ShowGroupPanel = false;
            this.tablo1.OptionsView.ShowViewCaption = true;
            this.tablo1.StatusBarAciklama = null;
            this.tablo1.StatusBarKisayol = null;
            this.tablo1.StatusBarKisayolAciklama = null;
            this.tablo1.ViewCaption = "Tanımlı Numaralar";
            this.tablo1.SelectionChanged += new DevExpress.Data.SelectionChangedEventHandler(this.tablo1_SelectionChanged);
            // 
            // colId1
            // 
            this.colId1.Caption = "Id";
            this.colId1.FieldName = "Id";
            this.colId1.MinWidth = 21;
            this.colId1.Name = "colId1";
            this.colId1.OptionsColumn.AllowEdit = false;
            this.colId1.OptionsColumn.ShowInCustomizationForm = false;
            this.colId1.StatusBarAciklama = null;
            this.colId1.StatusBarKisayol = null;
            this.colId1.StatusBarKisayolAciklama = null;
            this.colId1.Width = 81;
            // 
            // colKod1
            // 
            this.colKod1.AppearanceCell.Options.UseTextOptions = true;
            this.colKod1.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.colKod1.Caption = "Kod";
            this.colKod1.FieldName = "Kod";
            this.colKod1.MinWidth = 21;
            this.colKod1.Name = "colKod1";
            this.colKod1.OptionsColumn.AllowEdit = false;
            this.colKod1.StatusBarAciklama = null;
            this.colKod1.StatusBarKisayol = null;
            this.colKod1.StatusBarKisayolAciklama = null;
            this.colKod1.Width = 81;
            // 
            // colTip
            // 
            this.colTip.Caption = "Tip";
            this.colTip.FieldName = "Tip";
            this.colTip.MinWidth = 21;
            this.colTip.Name = "colTip";
            this.colTip.OptionsColumn.AllowEdit = false;
            this.colTip.StatusBarAciklama = null;
            this.colTip.StatusBarKisayol = null;
            this.colTip.StatusBarKisayolAciklama = null;
            this.colTip.Visible = true;
            this.colTip.VisibleIndex = 0;
            this.colTip.Width = 81;
            // 
            // colSeri
            // 
            this.colSeri.Caption = "Seri";
            this.colSeri.FieldName = "Seri";
            this.colSeri.MinWidth = 21;
            this.colSeri.Name = "colSeri";
            this.colSeri.OptionsColumn.AllowEdit = false;
            this.colSeri.StatusBarAciklama = null;
            this.colSeri.StatusBarKisayol = null;
            this.colSeri.StatusBarKisayolAciklama = null;
            this.colSeri.Visible = true;
            this.colSeri.VisibleIndex = 1;
            this.colSeri.Width = 81;
            // 
            // colSonNumara
            // 
            this.colSonNumara.Caption = "Son Numara";
            this.colSonNumara.FieldName = "SonNumara";
            this.colSonNumara.MinWidth = 21;
            this.colSonNumara.Name = "colSonNumara";
            this.colSonNumara.OptionsColumn.AllowEdit = false;
            this.colSonNumara.StatusBarAciklama = null;
            this.colSonNumara.StatusBarKisayol = null;
            this.colSonNumara.StatusBarKisayolAciklama = null;
            this.colSonNumara.Visible = true;
            this.colSonNumara.VisibleIndex = 2;
            this.colSonNumara.Width = 81;
            // 
            // Root
            // 
            this.Root.EnableIndentsWithoutBorders = DevExpress.Utils.DefaultBoolean.True;
            this.Root.GroupBordersVisible = false;
            this.Root.Items.AddRange(new DevExpress.XtraLayout.BaseLayoutItem[] {
            this.layoutControlItem1,
            this.layoutControlItem2});
            this.Root.LayoutMode = DevExpress.XtraLayout.Utils.LayoutMode.Table;
            this.Root.Name = "Root";
            columnDefinition1.SizeType = System.Windows.Forms.SizeType.Percent;
            columnDefinition1.Width = 70D;
            columnDefinition2.SizeType = System.Windows.Forms.SizeType.Percent;
            columnDefinition2.Width = 30D;
            this.Root.OptionsTableLayoutGroup.ColumnDefinitions.AddRange(new DevExpress.XtraLayout.ColumnDefinition[] {
            columnDefinition1,
            columnDefinition2});
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
            this.layoutControlItem1.Size = new System.Drawing.Size(780, 351);
            this.layoutControlItem1.TextSize = new System.Drawing.Size(0, 0);
            this.layoutControlItem1.TextVisible = false;
            // 
            // layoutControlItem2
            // 
            this.layoutControlItem2.AppearanceItemCaption.ForeColor = System.Drawing.Color.Maroon;
            this.layoutControlItem2.AppearanceItemCaption.Options.UseForeColor = true;
            this.layoutControlItem2.Control = this.grid1;
            this.layoutControlItem2.Location = new System.Drawing.Point(780, 0);
            this.layoutControlItem2.Name = "layoutControlItem2";
            this.layoutControlItem2.OptionsTableLayoutItem.ColumnIndex = 1;
            this.layoutControlItem2.Size = new System.Drawing.Size(334, 351);
            this.layoutControlItem2.TextSize = new System.Drawing.Size(0, 0);
            this.layoutControlItem2.TextVisible = false;
            // 
            // NumaralamaKontrolu
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1134, 501);
            this.Controls.Add(this.myDataLayoutControl1);
            this.IconOptions.ShowIcon = false;
            this.Name = "NumaralamaKontrolu";
            this.Tag = "Tarih";
            this.Text = "Numaralama Kontrol";
            this.Controls.SetChildIndex(this.ribbonControl, 0);
            this.Controls.SetChildIndex(this.ribbonStatusBar1, 0);
            this.Controls.SetChildIndex(this.myDataLayoutControl1, 0);
            ((System.ComponentModel.ISupportInitialize)(this.ribbonControl)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.grid)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tablo)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.myDataLayoutControl1)).EndInit();
            this.myDataLayoutControl1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.grid1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tablo1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Root)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem2)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private UserControls.Controls.Grid.MyGridControl grid;
        private UserControls.Controls.Grid.MyGridView tablo;
        private UserControls.Controls.Grid.MyGridColumn colId;
        private UserControls.Controls.Grid.MyGridColumn colKod;
        private UserControls.Controls.Grid.MyGridColumn colNumara;
        private UserControls.Controls.Grid.MyGridColumn colFisTuru;
        private UserControls.Controls.MyDataLayoutControl myDataLayoutControl1;
        private DevExpress.XtraLayout.LayoutControlGroup Root;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem1;
        private UserControls.Controls.Grid.MyGridControl grid1;
        private UserControls.Controls.Grid.MyGridView tablo1;
        private UserControls.Controls.Grid.MyGridColumn colId1;
        private UserControls.Controls.Grid.MyGridColumn colKod1;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem2;
        private UserControls.Controls.Grid.MyGridColumn colTip;
        private UserControls.Controls.Grid.MyGridColumn colSeri;
        private UserControls.Controls.Grid.MyGridColumn colSonNumara;
        private UserControls.Controls.Grid.MyGridColumn ColHata;
    }
}