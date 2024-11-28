namespace XCubeCrm.UI.Win.Forms.ParametrelerForms
{
    partial class ParametrelerListForm
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ParametrelerListForm));
            this.grid = new XCubeCrm.UI.Win.Forms.UserControls.Controls.Grid.MyGridControl();
            this.tablo = new XCubeCrm.UI.Win.Forms.UserControls.Controls.Grid.MyGridView();
            this.colId = new XCubeCrm.UI.Win.Forms.UserControls.Controls.Grid.MyGridColumn();
            this.colKod = new XCubeCrm.UI.Win.Forms.UserControls.Controls.Grid.MyGridColumn();
            this.colParametreBaslik = new XCubeCrm.UI.Win.Forms.UserControls.Controls.Grid.MyGridColumn();
            this.colFirma = new XCubeCrm.UI.Win.Forms.UserControls.Controls.Grid.MyGridColumn();
            this.colParametreDegeri = new XCubeCrm.UI.Win.Forms.UserControls.Controls.Grid.MyGridColumn();
            this.longNavigator = new XCubeCrm.UI.Win.Forms.UserControls.Controls.Navigators.LongNavigator();
            ((System.ComponentModel.ISupportInitialize)(this.ribbonControl)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.sagMenu)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.grid)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tablo)).BeginInit();
            this.SuspendLayout();
            // 
            // ribbonControl
            // 
            this.ribbonControl.EmptyAreaImageOptions.ImagePadding = new System.Windows.Forms.Padding(52, 47, 52, 47);
            this.ribbonControl.ExpandCollapseItem.Id = 0;
            this.ribbonControl.Margin = new System.Windows.Forms.Padding(6, 5, 6, 5);
            this.ribbonControl.OptionsMenuMinWidth = 591;
            this.ribbonControl.Size = new System.Drawing.Size(1134, 135);
            this.ribbonControl.Toolbar.ShowCustomizeItem = false;
            // 
            // btnDisariAktar
            // 
            this.btnDisariAktar.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("btnDisariAktar.ImageOptions.Image")));
            this.btnDisariAktar.ImageOptions.LargeImage = ((System.Drawing.Image)(resources.GetObject("btnDisariAktar.ImageOptions.LargeImage")));
            // 
            // btnYeniRapor
            // 
            this.btnYeniRapor.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("btnYeniRapor.ImageOptions.Image")));
            this.btnYeniRapor.ImageOptions.LargeImage = ((System.Drawing.Image)(resources.GetObject("btnYeniRapor.ImageOptions.LargeImage")));
            // 
            // btnOnTanimliRaporlar
            // 
            this.btnOnTanimliRaporlar.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("btnOnTanimliRaporlar.ImageOptions.Image")));
            // 
            // grid
            // 
            this.grid.Dock = System.Windows.Forms.DockStyle.Fill;
            this.grid.EmbeddedNavigator.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.grid.Location = new System.Drawing.Point(0, 135);
            this.grid.MainView = this.tablo;
            this.grid.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.grid.MenuManager = this.ribbonControl;
            this.grid.Name = "grid";
            this.grid.Size = new System.Drawing.Size(1134, 322);
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
            this.tablo.Appearance.Row.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far;
            this.tablo.Appearance.ViewCaption.ForeColor = System.Drawing.Color.Maroon;
            this.tablo.Appearance.ViewCaption.Options.UseForeColor = true;
            this.tablo.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.colId,
            this.colKod,
            this.colParametreBaslik,
            this.colFirma,
            this.colParametreDegeri});
            this.tablo.DetailHeight = 284;
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
            this.tablo.ViewCaption = "Parametre Kartları";
            // 
            // colId
            // 
            this.colId.Caption = "Id";
            this.colId.FieldName = "Id";
            this.colId.MinWidth = 21;
            this.colId.Name = "colId";
            this.colId.OptionsColumn.AllowEdit = false;
            this.colId.OptionsColumn.AllowFocus = false;
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
            this.colKod.OptionsColumn.AllowFocus = false;
            this.colKod.StatusBarAciklama = null;
            this.colKod.StatusBarKisayol = null;
            this.colKod.StatusBarKisayolAciklama = null;
            this.colKod.Visible = true;
            this.colKod.VisibleIndex = 0;
            this.colKod.Width = 81;
            // 
            // colParametreBaslik
            // 
            this.colParametreBaslik.Caption = "Parametre Adı";
            this.colParametreBaslik.FieldName = "ParametreBaslik";
            this.colParametreBaslik.MinWidth = 21;
            this.colParametreBaslik.Name = "colParametreBaslik";
            this.colParametreBaslik.OptionsColumn.AllowEdit = false;
            this.colParametreBaslik.OptionsColumn.AllowFocus = false;
            this.colParametreBaslik.StatusBarAciklama = null;
            this.colParametreBaslik.StatusBarKisayol = null;
            this.colParametreBaslik.StatusBarKisayolAciklama = null;
            this.colParametreBaslik.Visible = true;
            this.colParametreBaslik.VisibleIndex = 1;
            this.colParametreBaslik.Width = 129;
            // 
            // colFirma
            // 
            this.colFirma.Caption = "Firma";
            this.colFirma.FieldName = "Firma";
            this.colFirma.MinWidth = 21;
            this.colFirma.Name = "colFirma";
            this.colFirma.OptionsColumn.AllowEdit = false;
            this.colFirma.StatusBarAciklama = null;
            this.colFirma.StatusBarKisayol = null;
            this.colFirma.StatusBarKisayolAciklama = null;
            this.colFirma.Visible = true;
            this.colFirma.VisibleIndex = 3;
            this.colFirma.Width = 81;
            // 
            // colParametreDegeri
            // 
            this.colParametreDegeri.Caption = "Parametre Değeri";
            this.colParametreDegeri.FieldName = "ParametreDegeri";
            this.colParametreDegeri.MinWidth = 21;
            this.colParametreDegeri.Name = "colParametreDegeri";
            this.colParametreDegeri.OptionsColumn.AllowEdit = false;
            this.colParametreDegeri.OptionsColumn.AllowFocus = false;
            this.colParametreDegeri.StatusBarAciklama = null;
            this.colParametreDegeri.StatusBarKisayol = null;
            this.colParametreDegeri.StatusBarKisayolAciklama = null;
            this.colParametreDegeri.Visible = true;
            this.colParametreDegeri.VisibleIndex = 2;
            this.colParametreDegeri.Width = 257;
            // 
            // longNavigator
            // 
            this.longNavigator.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.longNavigator.Location = new System.Drawing.Point(0, 457);
            this.longNavigator.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.longNavigator.Name = "longNavigator";
            this.longNavigator.Size = new System.Drawing.Size(1134, 20);
            this.longNavigator.TabIndex = 3;
            // 
            // ParametrelerListForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1134, 501);
            this.Controls.Add(this.grid);
            this.Controls.Add(this.longNavigator);
            this.IconOptions.ShowIcon = false;
            this.Name = "ParametrelerListForm";
            this.Tag = "BOS";
            this.Text = "Parametre Kartları";
            this.Controls.SetChildIndex(this.ribbonControl, 0);
            this.Controls.SetChildIndex(this.ribbonStatusBar1, 0);
            this.Controls.SetChildIndex(this.longNavigator, 0);
            this.Controls.SetChildIndex(this.grid, 0);
            ((System.ComponentModel.ISupportInitialize)(this.ribbonControl)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.sagMenu)).EndInit();
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
        private UserControls.Controls.Navigators.LongNavigator longNavigator;
        private UserControls.Controls.Grid.MyGridColumn colParametreBaslik;
        private UserControls.Controls.Grid.MyGridColumn colParametreDegeri;
        private UserControls.Controls.Grid.MyGridColumn colFirma;
    }
}
