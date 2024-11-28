namespace XCubeCrm.UI.Win.Forms.Raporlar.Muhasebe
{
    partial class StokSonHareketTarihleri
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(StokSonHareketTarihleri));
            DevExpress.XtraLayout.ColumnDefinition columnDefinition2 = new DevExpress.XtraLayout.ColumnDefinition();
            DevExpress.XtraLayout.RowDefinition rowDefinition2 = new DevExpress.XtraLayout.RowDefinition();
            this.grid = new XCubeCrm.UI.Win.Forms.UserControls.Controls.Grid.MyGridControl();
            this.tablo = new XCubeCrm.UI.Win.Forms.UserControls.Controls.Grid.MyGridView();
            this.colId = new XCubeCrm.UI.Win.Forms.UserControls.Controls.Grid.MyGridColumn();
            this.colKOD = new XCubeCrm.UI.Win.Forms.UserControls.Controls.Grid.MyGridColumn();
            this.colUrunADI = new XCubeCrm.UI.Win.Forms.UserControls.Controls.Grid.MyGridColumn();
            this.colDURUM = new XCubeCrm.UI.Win.Forms.UserControls.Controls.Grid.MyGridColumn();
            this.colTOPLAMSTOK = new XCubeCrm.UI.Win.Forms.UserControls.Controls.Grid.MyGridColumn();
            this.colSONHAREKETTARIHI = new XCubeCrm.UI.Win.Forms.UserControls.Controls.Grid.MyGridColumn();
            this.colMIKTAR = new XCubeCrm.UI.Win.Forms.UserControls.Controls.Grid.MyGridColumn();
            this.colHAREKETTIP = new XCubeCrm.UI.Win.Forms.UserControls.Controls.Grid.MyGridColumn();
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
            this.colKOD,
            this.colUrunADI,
            this.colDURUM,
            this.colTOPLAMSTOK,
            this.colSONHAREKETTARIHI,
            this.colMIKTAR,
            this.colHAREKETTIP});
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
            // colKOD
            // 
            this.colKOD.Caption = "Kod";
            this.colKOD.FieldName = "KOD";
            this.colKOD.Name = "colKOD";
            this.colKOD.OptionsColumn.AllowEdit = false;
            this.colKOD.StatusBarAciklama = null;
            this.colKOD.StatusBarKisayol = null;
            this.colKOD.StatusBarKisayolAciklama = null;
            this.colKOD.Visible = true;
            this.colKOD.VisibleIndex = 0;
            // 
            // colUrunADI
            // 
            this.colUrunADI.Caption = "Ürün Adı";
            this.colUrunADI.FieldName = "URUNADI";
            this.colUrunADI.Name = "colUrunADI";
            this.colUrunADI.OptionsColumn.AllowEdit = false;
            this.colUrunADI.StatusBarAciklama = null;
            this.colUrunADI.StatusBarKisayol = null;
            this.colUrunADI.StatusBarKisayolAciklama = null;
            this.colUrunADI.Visible = true;
            this.colUrunADI.VisibleIndex = 1;
            // 
            // colDURUM
            // 
            this.colDURUM.Caption = "Durum";
            this.colDURUM.FieldName = "DURUM";
            this.colDURUM.Name = "colDURUM";
            this.colDURUM.OptionsColumn.AllowEdit = false;
            this.colDURUM.StatusBarAciklama = null;
            this.colDURUM.StatusBarKisayol = null;
            this.colDURUM.StatusBarKisayolAciklama = null;
            this.colDURUM.Visible = true;
            this.colDURUM.VisibleIndex = 2;
            // 
            // colTOPLAMSTOK
            // 
            this.colTOPLAMSTOK.Caption = "Toplam Stok";
            this.colTOPLAMSTOK.DisplayFormat.FormatString = "N5";
            this.colTOPLAMSTOK.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Custom;
            this.colTOPLAMSTOK.FieldName = "TOPLAMSTOK";
            this.colTOPLAMSTOK.Name = "colTOPLAMSTOK";
            this.colTOPLAMSTOK.OptionsColumn.AllowEdit = false;
            this.colTOPLAMSTOK.StatusBarAciklama = null;
            this.colTOPLAMSTOK.StatusBarKisayol = null;
            this.colTOPLAMSTOK.StatusBarKisayolAciklama = null;
            this.colTOPLAMSTOK.Visible = true;
            this.colTOPLAMSTOK.VisibleIndex = 3;
            // 
            // colSONHAREKETTARIHI
            // 
            this.colSONHAREKETTARIHI.Caption = "Son Hareket Tarihi";
            this.colSONHAREKETTARIHI.DisplayFormat.FormatString = "dd/MM/yyyy";
            this.colSONHAREKETTARIHI.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Custom;
            this.colSONHAREKETTARIHI.FieldName = "SONHAREKETTARIHI";
            this.colSONHAREKETTARIHI.Name = "colSONHAREKETTARIHI";
            this.colSONHAREKETTARIHI.OptionsColumn.AllowEdit = false;
            this.colSONHAREKETTARIHI.StatusBarAciklama = null;
            this.colSONHAREKETTARIHI.StatusBarKisayol = null;
            this.colSONHAREKETTARIHI.StatusBarKisayolAciklama = null;
            this.colSONHAREKETTARIHI.Visible = true;
            this.colSONHAREKETTARIHI.VisibleIndex = 4;
            // 
            // colMIKTAR
            // 
            this.colMIKTAR.Caption = "Miktar";
            this.colMIKTAR.DisplayFormat.FormatString = "N5";
            this.colMIKTAR.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Custom;
            this.colMIKTAR.FieldName = "MIKTAR";
            this.colMIKTAR.Name = "colMIKTAR";
            this.colMIKTAR.OptionsColumn.AllowEdit = false;
            this.colMIKTAR.StatusBarAciklama = null;
            this.colMIKTAR.StatusBarKisayol = null;
            this.colMIKTAR.StatusBarKisayolAciklama = null;
            this.colMIKTAR.Visible = true;
            this.colMIKTAR.VisibleIndex = 5;
            // 
            // colHAREKETTIP
            // 
            this.colHAREKETTIP.Caption = "Hareket Tipi";
            this.colHAREKETTIP.FieldName = "HAREKETTIP";
            this.colHAREKETTIP.Name = "colHAREKETTIP";
            this.colHAREKETTIP.OptionsColumn.AllowEdit = false;
            this.colHAREKETTIP.StatusBarAciklama = null;
            this.colHAREKETTIP.StatusBarKisayol = null;
            this.colHAREKETTIP.StatusBarKisayolAciklama = null;
            this.colHAREKETTIP.Visible = true;
            this.colHAREKETTIP.VisibleIndex = 6;
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
            columnDefinition2.SizeType = System.Windows.Forms.SizeType.Percent;
            columnDefinition2.Width = 100D;
            this.Root.OptionsTableLayoutGroup.ColumnDefinitions.AddRange(new DevExpress.XtraLayout.ColumnDefinition[] {
            columnDefinition2});
            rowDefinition2.Height = 100D;
            rowDefinition2.SizeType = System.Windows.Forms.SizeType.Percent;
            this.Root.OptionsTableLayoutGroup.RowDefinitions.AddRange(new DevExpress.XtraLayout.RowDefinition[] {
            rowDefinition2});
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
            // StokSonHareketTarihleri
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1134, 501);
            this.Controls.Add(this.myDataLayoutControl1);
            this.IconOptions.ShowIcon = false;
            this.Name = "StokSonHareketTarihleri";
            this.Tag = "StokTarih";
            this.Text = "Stok Son Hareket Tarihleri";
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
        private UserControls.Controls.MyDataLayoutControl myDataLayoutControl1;
        private DevExpress.XtraLayout.LayoutControlGroup Root;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem1;
        private UserControls.Controls.Grid.MyGridColumn colKOD;
        private UserControls.Controls.Grid.MyGridColumn colUrunADI;
        private UserControls.Controls.Grid.MyGridColumn colDURUM;
        private UserControls.Controls.Grid.MyGridColumn colTOPLAMSTOK;
        private UserControls.Controls.Grid.MyGridColumn colSONHAREKETTARIHI;
        private UserControls.Controls.Grid.MyGridColumn colMIKTAR;
        private UserControls.Controls.Grid.MyGridColumn colHAREKETTIP;
    }
}