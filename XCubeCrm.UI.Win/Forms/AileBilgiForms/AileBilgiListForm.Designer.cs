namespace XCubeCrm.UI.Win.Forms.AileBilgiForms
{
    partial class AileBilgiListForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(AileBilgiListForm));
            this.grid = new XCubeCrm.UI.Win.Forms.UserControls.Controls.Grid.MyGridControl();
            this.tablo = new XCubeCrm.UI.Win.Forms.UserControls.Controls.Grid.MyGridView();
            this.colId = new XCubeCrm.UI.Win.Forms.UserControls.Controls.Grid.MyGridColumn();
            this.colKod = new XCubeCrm.UI.Win.Forms.UserControls.Controls.Grid.MyGridColumn();
            this.colCariKodOn = new XCubeCrm.UI.Win.Forms.UserControls.Controls.Grid.MyGridColumn();
            this.colCariUnvanOn = new XCubeCrm.UI.Win.Forms.UserControls.Controls.Grid.MyGridColumn();
            this.colMuhasebeKod = new XCubeCrm.UI.Win.Forms.UserControls.Controls.Grid.MyGridColumn();
            this.colMuhasebeUnvan = new XCubeCrm.UI.Win.Forms.UserControls.Controls.Grid.MyGridColumn();
            this.colMuhasebeAcilis = new XCubeCrm.UI.Win.Forms.UserControls.Controls.Grid.MyGridColumn();
            this.colMuhasebeBakiye = new XCubeCrm.UI.Win.Forms.UserControls.Controls.Grid.MyGridColumn();
            this.colCariAcilis = new XCubeCrm.UI.Win.Forms.UserControls.Controls.Grid.MyGridColumn();
            this.colCariBakiye = new XCubeCrm.UI.Win.Forms.UserControls.Controls.Grid.MyGridColumn();
            this.Idsi = new XCubeCrm.UI.Win.Forms.UserControls.Controls.Grid.MyGridColumn();
            this.longNavigator1 = new XCubeCrm.UI.Win.Forms.UserControls.Controls.Navigators.LongNavigator();
            ((System.ComponentModel.ISupportInitialize)(this.ribbonControl)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.grid)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tablo)).BeginInit();
            this.SuspendLayout();
            // 
            // ribbonControl
            // 
            this.ribbonControl.ExpandCollapseItem.Id = 0;
            this.ribbonControl.Size = new System.Drawing.Size(1323, 166);
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
            this.grid.Location = new System.Drawing.Point(0, 166);
            this.grid.MainView = this.tablo;
            this.grid.MenuManager = this.ribbonControl;
            this.grid.Name = "grid";
            this.grid.Size = new System.Drawing.Size(1323, 383);
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
            this.colId,
            this.colKod,
            this.colCariKodOn,
            this.colCariUnvanOn,
            this.colMuhasebeKod,
            this.colMuhasebeUnvan,
            this.colMuhasebeAcilis,
            this.colMuhasebeBakiye,
            this.colCariAcilis,
            this.colCariBakiye,
            this.Idsi});
            this.tablo.FocusRectStyle = DevExpress.XtraGrid.Views.Grid.DrawFocusRectStyle.RowFocus;
            this.tablo.GridControl = this.grid;
            this.tablo.Name = "tablo";
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
            // 
            // colId
            // 
            this.colId.Caption = "Id";
            this.colId.FieldName = "Id";
            this.colId.MinWidth = 25;
            this.colId.Name = "colId";
            this.colId.OptionsColumn.AllowEdit = false;
            this.colId.StatusBarAciklama = null;
            this.colId.StatusBarKisayol = null;
            this.colId.StatusBarKisayolAciklama = null;
            this.colId.Visible = true;
            this.colId.VisibleIndex = 10;
            this.colId.Width = 94;
            // 
            // colKod
            // 
            this.colKod.AppearanceCell.Options.UseTextOptions = true;
            this.colKod.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.colKod.Caption = "Kod";
            this.colKod.FieldName = "Kod";
            this.colKod.MinWidth = 25;
            this.colKod.Name = "colKod";
            this.colKod.OptionsColumn.AllowEdit = false;
            this.colKod.StatusBarAciklama = null;
            this.colKod.StatusBarKisayol = null;
            this.colKod.StatusBarKisayolAciklama = null;
            this.colKod.Visible = true;
            this.colKod.VisibleIndex = 0;
            this.colKod.Width = 94;
            // 
            // colCariKodOn
            // 
            this.colCariKodOn.Caption = "Cari Kod Ön";
            this.colCariKodOn.FieldName = "CariKodOn";
            this.colCariKodOn.MinWidth = 25;
            this.colCariKodOn.Name = "colCariKodOn";
            this.colCariKodOn.OptionsColumn.AllowEdit = false;
            this.colCariKodOn.StatusBarAciklama = null;
            this.colCariKodOn.StatusBarKisayol = null;
            this.colCariKodOn.StatusBarKisayolAciklama = null;
            this.colCariKodOn.Visible = true;
            this.colCariKodOn.VisibleIndex = 1;
            this.colCariKodOn.Width = 94;
            // 
            // colCariUnvanOn
            // 
            this.colCariUnvanOn.Caption = "Cari Ünvan Ön";
            this.colCariUnvanOn.FieldName = "CariUnvanOn";
            this.colCariUnvanOn.MinWidth = 25;
            this.colCariUnvanOn.Name = "colCariUnvanOn";
            this.colCariUnvanOn.OptionsColumn.AllowEdit = false;
            this.colCariUnvanOn.StatusBarAciklama = null;
            this.colCariUnvanOn.StatusBarKisayol = null;
            this.colCariUnvanOn.StatusBarKisayolAciklama = null;
            this.colCariUnvanOn.Visible = true;
            this.colCariUnvanOn.VisibleIndex = 2;
            this.colCariUnvanOn.Width = 289;
            // 
            // colMuhasebeKod
            // 
            this.colMuhasebeKod.AppearanceCell.Options.UseTextOptions = true;
            this.colMuhasebeKod.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far;
            this.colMuhasebeKod.Caption = "Muhasebe Kod";
            this.colMuhasebeKod.FieldName = "MuhasebeKod";
            this.colMuhasebeKod.MinWidth = 25;
            this.colMuhasebeKod.Name = "colMuhasebeKod";
            this.colMuhasebeKod.OptionsColumn.AllowEdit = false;
            this.colMuhasebeKod.StatusBarAciklama = null;
            this.colMuhasebeKod.StatusBarKisayol = null;
            this.colMuhasebeKod.StatusBarKisayolAciklama = null;
            this.colMuhasebeKod.Visible = true;
            this.colMuhasebeKod.VisibleIndex = 3;
            this.colMuhasebeKod.Width = 94;
            // 
            // colMuhasebeUnvan
            // 
            this.colMuhasebeUnvan.Caption = "Muhasebe Ünvan";
            this.colMuhasebeUnvan.FieldName = "MuhasebeUnvan";
            this.colMuhasebeUnvan.MinWidth = 25;
            this.colMuhasebeUnvan.Name = "colMuhasebeUnvan";
            this.colMuhasebeUnvan.OptionsColumn.AllowEdit = false;
            this.colMuhasebeUnvan.StatusBarAciklama = null;
            this.colMuhasebeUnvan.StatusBarKisayol = null;
            this.colMuhasebeUnvan.StatusBarKisayolAciklama = null;
            this.colMuhasebeUnvan.Visible = true;
            this.colMuhasebeUnvan.VisibleIndex = 4;
            this.colMuhasebeUnvan.Width = 263;
            // 
            // colMuhasebeAcilis
            // 
            this.colMuhasebeAcilis.Caption = "Muhasebe Açılış";
            this.colMuhasebeAcilis.FieldName = "MuhasebeAcilis";
            this.colMuhasebeAcilis.MinWidth = 25;
            this.colMuhasebeAcilis.Name = "colMuhasebeAcilis";
            this.colMuhasebeAcilis.OptionsColumn.AllowEdit = false;
            this.colMuhasebeAcilis.StatusBarAciklama = null;
            this.colMuhasebeAcilis.StatusBarKisayol = null;
            this.colMuhasebeAcilis.StatusBarKisayolAciklama = null;
            this.colMuhasebeAcilis.Visible = true;
            this.colMuhasebeAcilis.VisibleIndex = 5;
            this.colMuhasebeAcilis.Width = 149;
            // 
            // colMuhasebeBakiye
            // 
            this.colMuhasebeBakiye.Caption = "Muhasebe Bakiye";
            this.colMuhasebeBakiye.FieldName = "MuhasebeBakiye";
            this.colMuhasebeBakiye.MinWidth = 25;
            this.colMuhasebeBakiye.Name = "colMuhasebeBakiye";
            this.colMuhasebeBakiye.OptionsColumn.AllowEdit = false;
            this.colMuhasebeBakiye.StatusBarAciklama = null;
            this.colMuhasebeBakiye.StatusBarKisayol = null;
            this.colMuhasebeBakiye.StatusBarKisayolAciklama = null;
            this.colMuhasebeBakiye.Visible = true;
            this.colMuhasebeBakiye.VisibleIndex = 6;
            this.colMuhasebeBakiye.Width = 120;
            // 
            // colCariAcilis
            // 
            this.colCariAcilis.Caption = "Cari Açılış";
            this.colCariAcilis.FieldName = "CariAcilis";
            this.colCariAcilis.MinWidth = 25;
            this.colCariAcilis.Name = "colCariAcilis";
            this.colCariAcilis.OptionsColumn.AllowEdit = false;
            this.colCariAcilis.StatusBarAciklama = null;
            this.colCariAcilis.StatusBarKisayol = null;
            this.colCariAcilis.StatusBarKisayolAciklama = null;
            this.colCariAcilis.Visible = true;
            this.colCariAcilis.VisibleIndex = 7;
            this.colCariAcilis.Width = 120;
            // 
            // colCariBakiye
            // 
            this.colCariBakiye.Caption = "Cari Bakiye";
            this.colCariBakiye.FieldName = "CariBakiye";
            this.colCariBakiye.MinWidth = 25;
            this.colCariBakiye.Name = "colCariBakiye";
            this.colCariBakiye.OptionsColumn.AllowEdit = false;
            this.colCariBakiye.StatusBarAciklama = null;
            this.colCariBakiye.StatusBarKisayol = null;
            this.colCariBakiye.StatusBarKisayolAciklama = null;
            this.colCariBakiye.Visible = true;
            this.colCariBakiye.VisibleIndex = 8;
            this.colCariBakiye.Width = 94;
            // 
            // Idsi
            // 
            this.Idsi.Caption = "Id si";
            this.Idsi.FieldName = "Idsi";
            this.Idsi.MinWidth = 25;
            this.Idsi.Name = "Idsi";
            this.Idsi.OptionsColumn.AllowEdit = false;
            this.Idsi.StatusBarAciklama = null;
            this.Idsi.StatusBarKisayol = null;
            this.Idsi.StatusBarKisayolAciklama = null;
            this.Idsi.Visible = true;
            this.Idsi.VisibleIndex = 9;
            this.Idsi.Width = 94;
            // 
            // longNavigator1
            // 
            this.longNavigator1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.longNavigator1.Location = new System.Drawing.Point(0, 549);
            this.longNavigator1.Name = "longNavigator1";
            this.longNavigator1.Size = new System.Drawing.Size(1323, 38);
            this.longNavigator1.TabIndex = 3;
            // 
            // AileBilgiListForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1323, 617);
            this.Controls.Add(this.grid);
            this.Controls.Add(this.longNavigator1);
            this.IconOptions.ShowIcon = false;
            this.Name = "AileBilgiListForm";
            this.Text = "Aile Bilgi Kartları";
            this.Controls.SetChildIndex(this.ribbonControl, 0);
            this.Controls.SetChildIndex(this.ribbonStatusBar1, 0);
            this.Controls.SetChildIndex(this.longNavigator1, 0);
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
        private UserControls.Controls.Navigators.LongNavigator longNavigator1;
        private UserControls.Controls.Grid.MyGridColumn colCariKodOn;
        private UserControls.Controls.Grid.MyGridColumn colCariUnvanOn;
        private UserControls.Controls.Grid.MyGridColumn colMuhasebeKod;
        private UserControls.Controls.Grid.MyGridColumn colMuhasebeUnvan;
        private UserControls.Controls.Grid.MyGridColumn colMuhasebeAcilis;
        private UserControls.Controls.Grid.MyGridColumn colMuhasebeBakiye;
        private UserControls.Controls.Grid.MyGridColumn colCariAcilis;
        private UserControls.Controls.Grid.MyGridColumn colCariBakiye;
        private UserControls.Controls.Grid.MyGridColumn Idsi;
    }
}