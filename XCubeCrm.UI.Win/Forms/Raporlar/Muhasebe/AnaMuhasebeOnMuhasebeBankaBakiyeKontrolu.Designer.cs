namespace XCubeCrm.UI.Win.Forms.Raporlar.Muhasebe
{
    partial class AnaMuhasebeOnMuhasebeBankaBakiyeKontrolu
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(AnaMuhasebeOnMuhasebeBankaBakiyeKontrolu));
            DevExpress.XtraLayout.ColumnDefinition columnDefinition1 = new DevExpress.XtraLayout.ColumnDefinition();
            DevExpress.XtraLayout.RowDefinition rowDefinition1 = new DevExpress.XtraLayout.RowDefinition();
            this.grid = new XCubeCrm.UI.Win.Forms.UserControls.Controls.Grid.MyGridControl();
            this.tablo = new XCubeCrm.UI.Win.Forms.UserControls.Controls.Grid.MyGridView();
            this.colBANKAADI = new XCubeCrm.UI.Win.Forms.UserControls.Controls.Grid.MyGridColumn();
            this.colSUBEKODU = new XCubeCrm.UI.Win.Forms.UserControls.Controls.Grid.MyGridColumn();
            this.colSUBEADI = new XCubeCrm.UI.Win.Forms.UserControls.Controls.Grid.MyGridColumn();
            this.colONMUHASEBEBAKIYE = new XCubeCrm.UI.Win.Forms.UserControls.Controls.Grid.MyGridColumn();
            this.colMUHASEBEKODU = new XCubeCrm.UI.Win.Forms.UserControls.Controls.Grid.MyGridColumn();
            this.colMUHASEBEHESABI = new XCubeCrm.UI.Win.Forms.UserControls.Controls.Grid.MyGridColumn();
            this.colMUHASEBETUTARI = new XCubeCrm.UI.Win.Forms.UserControls.Controls.Grid.MyGridColumn();
            this.colFARK = new XCubeCrm.UI.Win.Forms.UserControls.Controls.Grid.MyGridColumn();
            this.myDataLayoutControl1 = new XCubeCrm.UI.Win.Forms.UserControls.Controls.MyDataLayoutControl();
            this.Root = new DevExpress.XtraLayout.LayoutControlGroup();
            this.layoutControlItem1 = new DevExpress.XtraLayout.LayoutControlItem();
            this.colLOGICALREF = new XCubeCrm.UI.Win.Forms.UserControls.Controls.Grid.MyGridColumn();
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
            this.grid.DoubleClick += new System.EventHandler(this.grid_DoubleClick);
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
            this.colBANKAADI,
            this.colSUBEKODU,
            this.colSUBEADI,
            this.colONMUHASEBEBAKIYE,
            this.colMUHASEBEKODU,
            this.colMUHASEBEHESABI,
            this.colMUHASEBETUTARI,
            this.colFARK,
            this.colLOGICALREF});
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
            // 
            // colBANKAADI
            // 
            this.colBANKAADI.Caption = "Banka Adı";
            this.colBANKAADI.FieldName = "BANKAADI";
            this.colBANKAADI.Name = "colBANKAADI";
            this.colBANKAADI.OptionsColumn.AllowEdit = false;
            this.colBANKAADI.StatusBarAciklama = null;
            this.colBANKAADI.StatusBarKisayol = null;
            this.colBANKAADI.StatusBarKisayolAciklama = null;
            this.colBANKAADI.Visible = true;
            this.colBANKAADI.VisibleIndex = 0;
            // 
            // colSUBEKODU
            // 
            this.colSUBEKODU.Caption = "Şube Kod";
            this.colSUBEKODU.FieldName = "SUBEKODU";
            this.colSUBEKODU.Name = "colSUBEKODU";
            this.colSUBEKODU.OptionsColumn.AllowEdit = false;
            this.colSUBEKODU.StatusBarAciklama = null;
            this.colSUBEKODU.StatusBarKisayol = null;
            this.colSUBEKODU.StatusBarKisayolAciklama = null;
            this.colSUBEKODU.Visible = true;
            this.colSUBEKODU.VisibleIndex = 1;
            // 
            // colSUBEADI
            // 
            this.colSUBEADI.Caption = "Şube Ad";
            this.colSUBEADI.FieldName = "SUBEADI";
            this.colSUBEADI.Name = "colSUBEADI";
            this.colSUBEADI.OptionsColumn.AllowEdit = false;
            this.colSUBEADI.StatusBarAciklama = null;
            this.colSUBEADI.StatusBarKisayol = null;
            this.colSUBEADI.StatusBarKisayolAciklama = null;
            this.colSUBEADI.Visible = true;
            this.colSUBEADI.VisibleIndex = 2;
            // 
            // colONMUHASEBEBAKIYE
            // 
            this.colONMUHASEBEBAKIYE.Caption = "Ön Muasebe Bakiye";
            this.colONMUHASEBEBAKIYE.DisplayFormat.FormatString = "N5";
            this.colONMUHASEBEBAKIYE.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Custom;
            this.colONMUHASEBEBAKIYE.FieldName = "ONMUHASEBEBAKIYE";
            this.colONMUHASEBEBAKIYE.Name = "colONMUHASEBEBAKIYE";
            this.colONMUHASEBEBAKIYE.OptionsColumn.AllowEdit = false;
            this.colONMUHASEBEBAKIYE.StatusBarAciklama = null;
            this.colONMUHASEBEBAKIYE.StatusBarKisayol = null;
            this.colONMUHASEBEBAKIYE.StatusBarKisayolAciklama = null;
            this.colONMUHASEBEBAKIYE.Visible = true;
            this.colONMUHASEBEBAKIYE.VisibleIndex = 3;
            // 
            // colMUHASEBEKODU
            // 
            this.colMUHASEBEKODU.Caption = "Muhasebe Kod";
            this.colMUHASEBEKODU.FieldName = "MUHASEBEKODU";
            this.colMUHASEBEKODU.Name = "colMUHASEBEKODU";
            this.colMUHASEBEKODU.OptionsColumn.AllowEdit = false;
            this.colMUHASEBEKODU.StatusBarAciklama = null;
            this.colMUHASEBEKODU.StatusBarKisayol = null;
            this.colMUHASEBEKODU.StatusBarKisayolAciklama = null;
            this.colMUHASEBEKODU.Visible = true;
            this.colMUHASEBEKODU.VisibleIndex = 4;
            // 
            // colMUHASEBEHESABI
            // 
            this.colMUHASEBEHESABI.Caption = "Muhasebe Hesap";
            this.colMUHASEBEHESABI.FieldName = "MUHASEBEHESABI";
            this.colMUHASEBEHESABI.Name = "colMUHASEBEHESABI";
            this.colMUHASEBEHESABI.OptionsColumn.AllowEdit = false;
            this.colMUHASEBEHESABI.StatusBarAciklama = null;
            this.colMUHASEBEHESABI.StatusBarKisayol = null;
            this.colMUHASEBEHESABI.StatusBarKisayolAciklama = null;
            this.colMUHASEBEHESABI.Visible = true;
            this.colMUHASEBEHESABI.VisibleIndex = 5;
            // 
            // colMUHASEBETUTARI
            // 
            this.colMUHASEBETUTARI.Caption = "Muhasebe Bakiye";
            this.colMUHASEBETUTARI.DisplayFormat.FormatString = "N5";
            this.colMUHASEBETUTARI.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Custom;
            this.colMUHASEBETUTARI.FieldName = "MUHASEBETUTARI";
            this.colMUHASEBETUTARI.Name = "colMUHASEBETUTARI";
            this.colMUHASEBETUTARI.OptionsColumn.AllowEdit = false;
            this.colMUHASEBETUTARI.StatusBarAciklama = null;
            this.colMUHASEBETUTARI.StatusBarKisayol = null;
            this.colMUHASEBETUTARI.StatusBarKisayolAciklama = null;
            this.colMUHASEBETUTARI.Visible = true;
            this.colMUHASEBETUTARI.VisibleIndex = 6;
            // 
            // colFARK
            // 
            this.colFARK.Caption = "Fark";
            this.colFARK.DisplayFormat.FormatString = "N5";
            this.colFARK.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Custom;
            this.colFARK.FieldName = "FARK";
            this.colFARK.Name = "colFARK";
            this.colFARK.OptionsColumn.AllowEdit = false;
            this.colFARK.StatusBarAciklama = null;
            this.colFARK.StatusBarKisayol = null;
            this.colFARK.StatusBarKisayolAciklama = null;
            this.colFARK.Visible = true;
            this.colFARK.VisibleIndex = 7;
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
            // colLOGICALREF
            // 
            this.colLOGICALREF.Caption = "Id";
            this.colLOGICALREF.FieldName = "LOGICALREF";
            this.colLOGICALREF.Name = "colLOGICALREF";
            this.colLOGICALREF.OptionsColumn.AllowEdit = false;
            this.colLOGICALREF.StatusBarAciklama = null;
            this.colLOGICALREF.StatusBarKisayol = null;
            this.colLOGICALREF.StatusBarKisayolAciklama = null;
            // 
            // AnaMuhasebeOnMuhasebeBankaBakiyeKontrolu
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1134, 501);
            this.Controls.Add(this.myDataLayoutControl1);
            this.IconOptions.ShowIcon = false;
            this.Name = "AnaMuhasebeOnMuhasebeBankaBakiyeKontrolu";
            this.Tag = "Tarih";
            this.Text = "Ana Muhasebe Ön Muhasebe Banka Bakiye Kontrolü";
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
        private UserControls.Controls.Grid.MyGridColumn colBANKAADI;
        private UserControls.Controls.Grid.MyGridColumn colSUBEKODU;
        private UserControls.Controls.Grid.MyGridColumn colSUBEADI;
        private UserControls.Controls.Grid.MyGridColumn colONMUHASEBEBAKIYE;
        private UserControls.Controls.Grid.MyGridColumn colMUHASEBEKODU;
        private UserControls.Controls.Grid.MyGridColumn colMUHASEBEHESABI;
        private UserControls.Controls.Grid.MyGridColumn colMUHASEBETUTARI;
        private UserControls.Controls.Grid.MyGridColumn colFARK;
        private UserControls.Controls.Grid.MyGridColumn colLOGICALREF;
    }
}