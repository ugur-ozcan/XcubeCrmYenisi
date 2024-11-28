namespace XCubeCrm.UI.Win.Forms.Raporlar.Sevkiyat
{
    partial class StokIhtiyacListesi
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(StokIhtiyacListesi));
            DevExpress.XtraLayout.ColumnDefinition columnDefinition1 = new DevExpress.XtraLayout.ColumnDefinition();
            DevExpress.XtraLayout.RowDefinition rowDefinition1 = new DevExpress.XtraLayout.RowDefinition();
            this.grid = new XCubeCrm.UI.Win.Forms.UserControls.Controls.Grid.MyGridControl();
            this.tablo = new XCubeCrm.UI.Win.Forms.UserControls.Controls.Grid.MyGridView();
            this.colDEPO = new XCubeCrm.UI.Win.Forms.UserControls.Controls.Grid.MyGridColumn();
            this.colURUNKOD = new XCubeCrm.UI.Win.Forms.UserControls.Controls.Grid.MyGridColumn();
            this.colURUNAD = new XCubeCrm.UI.Win.Forms.UserControls.Controls.Grid.MyGridColumn();
            this.colMINIMUMSTOK = new XCubeCrm.UI.Win.Forms.UserControls.Controls.Grid.MyGridColumn();
            this.colMAXIMUMSTOK = new XCubeCrm.UI.Win.Forms.UserControls.Controls.Grid.MyGridColumn();
            this.colELDEKISTOK = new XCubeCrm.UI.Win.Forms.UserControls.Controls.Grid.MyGridColumn();
            this.col30GUNLUKSATIS = new XCubeCrm.UI.Win.Forms.UserControls.Controls.Grid.MyGridColumn();
            this.colBEKLEYENSIPARIS = new XCubeCrm.UI.Win.Forms.UserControls.Controls.Grid.MyGridColumn();
            this.colACIKSATINALMASIPARISI = new XCubeCrm.UI.Win.Forms.UserControls.Controls.Grid.MyGridColumn();
            this.colIHTIYAC = new XCubeCrm.UI.Win.Forms.UserControls.Controls.Grid.MyGridColumn();
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
            this.colDEPO,
            this.colURUNKOD,
            this.colURUNAD,
            this.colMINIMUMSTOK,
            this.colMAXIMUMSTOK,
            this.colELDEKISTOK,
            this.col30GUNLUKSATIS,
            this.colBEKLEYENSIPARIS,
            this.colACIKSATINALMASIPARISI,
            this.colIHTIYAC});
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
            this.tablo.ViewCaption = "Satış Siparişleri";
            // 
            // colDEPO
            // 
            this.colDEPO.Caption = "Depo";
            this.colDEPO.FieldName = "DEPO";
            this.colDEPO.Name = "colDEPO";
            this.colDEPO.OptionsColumn.AllowEdit = false;
            this.colDEPO.StatusBarAciklama = null;
            this.colDEPO.StatusBarKisayol = null;
            this.colDEPO.StatusBarKisayolAciklama = null;
            this.colDEPO.Visible = true;
            this.colDEPO.VisibleIndex = 0;
            // 
            // colURUNKOD
            // 
            this.colURUNKOD.Caption = "Ürün Kod";
            this.colURUNKOD.FieldName = "URUNKOD";
            this.colURUNKOD.Name = "colURUNKOD";
            this.colURUNKOD.OptionsColumn.AllowEdit = false;
            this.colURUNKOD.StatusBarAciklama = null;
            this.colURUNKOD.StatusBarKisayol = null;
            this.colURUNKOD.StatusBarKisayolAciklama = null;
            this.colURUNKOD.Visible = true;
            this.colURUNKOD.VisibleIndex = 1;
            // 
            // colURUNAD
            // 
            this.colURUNAD.Caption = "Ürün Adı";
            this.colURUNAD.FieldName = "URUNAD";
            this.colURUNAD.Name = "colURUNAD";
            this.colURUNAD.OptionsColumn.AllowEdit = false;
            this.colURUNAD.StatusBarAciklama = null;
            this.colURUNAD.StatusBarKisayol = null;
            this.colURUNAD.StatusBarKisayolAciklama = null;
            this.colURUNAD.Visible = true;
            this.colURUNAD.VisibleIndex = 2;
            // 
            // colMINIMUMSTOK
            // 
            this.colMINIMUMSTOK.Caption = "Minimum Stok";
            this.colMINIMUMSTOK.DisplayFormat.FormatString = "N2";
            this.colMINIMUMSTOK.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Custom;
            this.colMINIMUMSTOK.FieldName = "MINIMUMSTOK";
            this.colMINIMUMSTOK.Name = "colMINIMUMSTOK";
            this.colMINIMUMSTOK.OptionsColumn.AllowEdit = false;
            this.colMINIMUMSTOK.StatusBarAciklama = null;
            this.colMINIMUMSTOK.StatusBarKisayol = null;
            this.colMINIMUMSTOK.StatusBarKisayolAciklama = null;
            this.colMINIMUMSTOK.Visible = true;
            this.colMINIMUMSTOK.VisibleIndex = 3;
            // 
            // colMAXIMUMSTOK
            // 
            this.colMAXIMUMSTOK.Caption = "Maximum Stok";
            this.colMAXIMUMSTOK.DisplayFormat.FormatString = "N2";
            this.colMAXIMUMSTOK.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Custom;
            this.colMAXIMUMSTOK.FieldName = "MAXIMUMSTOK";
            this.colMAXIMUMSTOK.Name = "colMAXIMUMSTOK";
            this.colMAXIMUMSTOK.OptionsColumn.AllowEdit = false;
            this.colMAXIMUMSTOK.StatusBarAciklama = null;
            this.colMAXIMUMSTOK.StatusBarKisayol = null;
            this.colMAXIMUMSTOK.StatusBarKisayolAciklama = null;
            this.colMAXIMUMSTOK.Visible = true;
            this.colMAXIMUMSTOK.VisibleIndex = 4;
            // 
            // colELDEKISTOK
            // 
            this.colELDEKISTOK.Caption = "Depo Toplamı";
            this.colELDEKISTOK.DisplayFormat.FormatString = "N2";
            this.colELDEKISTOK.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Custom;
            this.colELDEKISTOK.FieldName = "ELDEKISTOK";
            this.colELDEKISTOK.Name = "colELDEKISTOK";
            this.colELDEKISTOK.OptionsColumn.AllowEdit = false;
            this.colELDEKISTOK.StatusBarAciklama = null;
            this.colELDEKISTOK.StatusBarKisayol = null;
            this.colELDEKISTOK.StatusBarKisayolAciklama = null;
            this.colELDEKISTOK.Visible = true;
            this.colELDEKISTOK.VisibleIndex = 5;
            // 
            // col30GUNLUKSATIS
            // 
            this.col30GUNLUKSATIS.Caption = "30 Günlük Satış";
            this.col30GUNLUKSATIS.DisplayFormat.FormatString = "N2";
            this.col30GUNLUKSATIS.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Custom;
            this.col30GUNLUKSATIS.FieldName = "SATIS";
            this.col30GUNLUKSATIS.Name = "col30GUNLUKSATIS";
            this.col30GUNLUKSATIS.OptionsColumn.AllowEdit = false;
            this.col30GUNLUKSATIS.StatusBarAciklama = null;
            this.col30GUNLUKSATIS.StatusBarKisayol = null;
            this.col30GUNLUKSATIS.StatusBarKisayolAciklama = null;
            this.col30GUNLUKSATIS.Visible = true;
            this.col30GUNLUKSATIS.VisibleIndex = 6;
            // 
            // colBEKLEYENSIPARIS
            // 
            this.colBEKLEYENSIPARIS.Caption = "Satış Siparişi";
            this.colBEKLEYENSIPARIS.DisplayFormat.FormatString = "N2";
            this.colBEKLEYENSIPARIS.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Custom;
            this.colBEKLEYENSIPARIS.FieldName = "BEKLEYENSIPARIS";
            this.colBEKLEYENSIPARIS.Name = "colBEKLEYENSIPARIS";
            this.colBEKLEYENSIPARIS.OptionsColumn.AllowEdit = false;
            this.colBEKLEYENSIPARIS.StatusBarAciklama = null;
            this.colBEKLEYENSIPARIS.StatusBarKisayol = null;
            this.colBEKLEYENSIPARIS.StatusBarKisayolAciklama = null;
            this.colBEKLEYENSIPARIS.Visible = true;
            this.colBEKLEYENSIPARIS.VisibleIndex = 7;
            // 
            // colACIKSATINALMASIPARISI
            // 
            this.colACIKSATINALMASIPARISI.Caption = "Açık Satınalma Siparişi";
            this.colACIKSATINALMASIPARISI.DisplayFormat.FormatString = "N2";
            this.colACIKSATINALMASIPARISI.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Custom;
            this.colACIKSATINALMASIPARISI.FieldName = "ACIKSATINALMASIPARISI";
            this.colACIKSATINALMASIPARISI.Name = "colACIKSATINALMASIPARISI";
            this.colACIKSATINALMASIPARISI.OptionsColumn.AllowEdit = false;
            this.colACIKSATINALMASIPARISI.StatusBarAciklama = null;
            this.colACIKSATINALMASIPARISI.StatusBarKisayol = null;
            this.colACIKSATINALMASIPARISI.StatusBarKisayolAciklama = null;
            this.colACIKSATINALMASIPARISI.Visible = true;
            this.colACIKSATINALMASIPARISI.VisibleIndex = 8;
            // 
            // colIHTIYAC
            // 
            this.colIHTIYAC.Caption = "İhtiyaç";
            this.colIHTIYAC.DisplayFormat.FormatString = "N2";
            this.colIHTIYAC.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Custom;
            this.colIHTIYAC.FieldName = "IHTIYAC";
            this.colIHTIYAC.Name = "colIHTIYAC";
            this.colIHTIYAC.OptionsColumn.AllowEdit = false;
            this.colIHTIYAC.StatusBarAciklama = null;
            this.colIHTIYAC.StatusBarKisayol = null;
            this.colIHTIYAC.StatusBarKisayolAciklama = null;
            this.colIHTIYAC.Visible = true;
            this.colIHTIYAC.VisibleIndex = 9;
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
            // StokIhtiyacListesi
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1134, 501);
            this.Controls.Add(this.myDataLayoutControl1);
            this.IconOptions.ShowIcon = false;
            this.Name = "StokIhtiyacListesi";
            this.Tag = "StokIsyeri";
            this.Text = "Stok İhtiyaç Listesi";
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
        private UserControls.Controls.MyDataLayoutControl myDataLayoutControl1;
        private DevExpress.XtraLayout.LayoutControlGroup Root;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem1;
        private UserControls.Controls.Grid.MyGridColumn colDEPO;
        private UserControls.Controls.Grid.MyGridColumn colURUNKOD;
        private UserControls.Controls.Grid.MyGridColumn colURUNAD;
        private UserControls.Controls.Grid.MyGridColumn colMINIMUMSTOK;
        private UserControls.Controls.Grid.MyGridColumn colMAXIMUMSTOK;
        private UserControls.Controls.Grid.MyGridColumn colELDEKISTOK;
        private UserControls.Controls.Grid.MyGridColumn col30GUNLUKSATIS;
        private UserControls.Controls.Grid.MyGridColumn colBEKLEYENSIPARIS;
        private UserControls.Controls.Grid.MyGridColumn colACIKSATINALMASIPARISI;
        private UserControls.Controls.Grid.MyGridColumn colIHTIYAC;
    }
}