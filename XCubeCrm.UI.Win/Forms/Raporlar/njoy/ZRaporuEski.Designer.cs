namespace XCubeCrm.UI.Win.Forms.Raporlar.njoy
{
    partial class ZRaporuEski
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ZRaporuEski));
            DevExpress.XtraLayout.ColumnDefinition columnDefinition1 = new DevExpress.XtraLayout.ColumnDefinition();
            DevExpress.XtraLayout.RowDefinition rowDefinition1 = new DevExpress.XtraLayout.RowDefinition();
            DevExpress.XtraLayout.RowDefinition rowDefinition2 = new DevExpress.XtraLayout.RowDefinition();
            this.myDataLayoutControl1 = new XCubeCrm.UI.Win.Forms.UserControls.Controls.MyDataLayoutControl();
            this.groupControl1 = new DevExpress.XtraEditors.GroupControl();
            this.detayGrid = new XCubeCrm.UI.Win.Forms.UserControls.Controls.Grid.MyGridControl();
            this.detayTablo = new XCubeCrm.UI.Win.Forms.UserControls.Controls.Grid.MyGridView();
            this.grid7 = new XCubeCrm.UI.Win.Forms.UserControls.Controls.Grid.MyGridControl();
            this.tablo7 = new XCubeCrm.UI.Win.Forms.UserControls.Controls.Grid.MyGridView();
            this.colId4 = new XCubeCrm.UI.Win.Forms.UserControls.Controls.Grid.MyGridColumn();
            this.colKod4 = new XCubeCrm.UI.Win.Forms.UserControls.Controls.Grid.MyGridColumn();
            this.zRaporuGrid = new XCubeCrm.UI.Win.Forms.UserControls.Controls.Grid.MyGridControl();
            this.tablo = new XCubeCrm.UI.Win.Forms.UserControls.Controls.Grid.MyGridView();
            this.layoutControlItem7 = new DevExpress.XtraLayout.LayoutControlItem();
            this.Root = new DevExpress.XtraLayout.LayoutControlGroup();
            this.layoutControlItem1 = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlItem2 = new DevExpress.XtraLayout.LayoutControlItem();
            ((System.ComponentModel.ISupportInitialize)(this.ribbonControl)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.myDataLayoutControl1)).BeginInit();
            this.myDataLayoutControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.groupControl1)).BeginInit();
            this.groupControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.detayGrid)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.detayTablo)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.grid7)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tablo7)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.zRaporuGrid)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tablo)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem7)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Root)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem2)).BeginInit();
            this.SuspendLayout();
            // 
            // ribbonStatusBar1
            // 
            this.ribbonStatusBar1.Location = new System.Drawing.Point(0, 1031);
            this.ribbonStatusBar1.Size = new System.Drawing.Size(1621, 27);
            // 
            // ribbonControl
            // 
            this.ribbonControl.EmptyAreaImageOptions.ImagePadding = new System.Windows.Forms.Padding(22, 19, 22, 19);
            this.ribbonControl.ExpandCollapseItem.Id = 0;
            this.ribbonControl.OptionsMenuMinWidth = 243;
            this.ribbonControl.Size = new System.Drawing.Size(1621, 103);
            this.ribbonControl.Toolbar.ShowCustomizeItem = false;
            // 
            // btnDisariAktar
            // 
            this.btnDisariAktar.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("btnDisariAktar.ImageOptions.Image")));
            this.btnDisariAktar.ImageOptions.LargeImage = ((System.Drawing.Image)(resources.GetObject("btnDisariAktar.ImageOptions.LargeImage")));
            // 
            // myDataLayoutControl1
            // 
            this.myDataLayoutControl1.Controls.Add(this.groupControl1);
            this.myDataLayoutControl1.Controls.Add(this.grid7);
            this.myDataLayoutControl1.Controls.Add(this.zRaporuGrid);
            this.myDataLayoutControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.myDataLayoutControl1.HiddenItems.AddRange(new DevExpress.XtraLayout.BaseLayoutItem[] {
            this.layoutControlItem7});
            this.myDataLayoutControl1.Location = new System.Drawing.Point(0, 103);
            this.myDataLayoutControl1.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.myDataLayoutControl1.Name = "myDataLayoutControl1";
            this.myDataLayoutControl1.OptionsFocus.EnableAutoTabOrder = false;
            this.myDataLayoutControl1.Root = this.Root;
            this.myDataLayoutControl1.Size = new System.Drawing.Size(1621, 928);
            this.myDataLayoutControl1.TabIndex = 7;
            this.myDataLayoutControl1.Text = "myDataLayoutControl1";
            // 
            // groupControl1
            // 
            this.groupControl1.Controls.Add(this.detayGrid);
            this.groupControl1.Location = new System.Drawing.Point(12, 466);
            this.groupControl1.Name = "groupControl1";
            this.groupControl1.Size = new System.Drawing.Size(1597, 450);
            this.groupControl1.TabIndex = 11;
            this.groupControl1.Text = "Detay Veriler";
            // 
            // detayGrid
            // 
            this.detayGrid.Dock = System.Windows.Forms.DockStyle.Fill;
            this.detayGrid.Location = new System.Drawing.Point(2, 23);
            this.detayGrid.MainView = this.detayTablo;
            this.detayGrid.Name = "detayGrid";
            this.detayGrid.Size = new System.Drawing.Size(1593, 425);
            this.detayGrid.TabIndex = 0;
            this.detayGrid.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.detayTablo});
            // 
            // detayTablo
            // 
            this.detayTablo.GridControl = this.detayGrid;
            this.detayTablo.Name = "detayTablo";
            this.detayTablo.OptionsMenu.EnableColumnMenu = false;
            this.detayTablo.OptionsView.RowAutoHeight = true;
            this.detayTablo.OptionsView.ShowGroupPanel = false;
            this.detayTablo.StatusBarAciklama = null;
            this.detayTablo.StatusBarKisayol = null;
            this.detayTablo.StatusBarKisayolAciklama = null;
            // 
            // grid7
            // 
            this.grid7.Location = new System.Drawing.Point(12, 466);
            this.grid7.MainView = this.tablo7;
            this.grid7.MenuManager = this.ribbonControl;
            this.grid7.Name = "grid7";
            this.grid7.Size = new System.Drawing.Size(796, 450);
            this.grid7.TabIndex = 10;
            this.grid7.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.tablo7});
            // 
            // tablo7
            // 
            this.tablo7.Appearance.FooterPanel.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
            this.tablo7.Appearance.FooterPanel.ForeColor = System.Drawing.Color.Maroon;
            this.tablo7.Appearance.FooterPanel.Options.UseFont = true;
            this.tablo7.Appearance.FooterPanel.Options.UseForeColor = true;
            this.tablo7.Appearance.HeaderPanel.ForeColor = System.Drawing.Color.Maroon;
            this.tablo7.Appearance.HeaderPanel.Options.UseForeColor = true;
            this.tablo7.Appearance.HeaderPanel.Options.UseTextOptions = true;
            this.tablo7.Appearance.HeaderPanel.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.tablo7.Appearance.Row.Options.UseTextOptions = true;
            this.tablo7.Appearance.Row.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Center;
            this.tablo7.Appearance.ViewCaption.ForeColor = System.Drawing.Color.Maroon;
            this.tablo7.Appearance.ViewCaption.Options.UseForeColor = true;
            this.tablo7.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.colId4,
            this.colKod4});
            this.tablo7.FocusRectStyle = DevExpress.XtraGrid.Views.Grid.DrawFocusRectStyle.RowFocus;
            this.tablo7.GridControl = this.grid7;
            this.tablo7.GroupPanelText = "Gruplamak istediğiniz kolonu buraya sürükleyin";
            this.tablo7.Name = "tablo7";
            this.tablo7.OptionsMenu.ShowFooterItem = true;
            this.tablo7.OptionsMenu.ShowGroupSummaryEditorItem = true;
            this.tablo7.OptionsMenu.ShowSummaryItemMode = DevExpress.Utils.DefaultBoolean.True;
            this.tablo7.OptionsNavigation.EnterMoveNextColumn = true;
            this.tablo7.OptionsPrint.AutoWidth = false;
            this.tablo7.OptionsPrint.PrintFooter = false;
            this.tablo7.OptionsPrint.PrintGroupFooter = false;
            this.tablo7.OptionsView.BestFitMode = DevExpress.XtraGrid.Views.Grid.GridBestFitMode.Fast;
            this.tablo7.OptionsView.ColumnAutoWidth = false;
            this.tablo7.OptionsView.GroupFooterShowMode = DevExpress.XtraGrid.Views.Grid.GroupFooterShowMode.VisibleAlways;
            this.tablo7.OptionsView.HeaderFilterButtonShowMode = DevExpress.XtraEditors.Controls.FilterButtonShowMode.Button;
            this.tablo7.OptionsView.RowAutoHeight = true;
            this.tablo7.OptionsView.ShowAutoFilterRow = true;
            this.tablo7.OptionsView.ShowFooter = true;
            this.tablo7.OptionsView.ShowGroupedColumns = true;
            this.tablo7.OptionsView.ShowViewCaption = true;
            this.tablo7.StatusBarAciklama = null;
            this.tablo7.StatusBarKisayol = null;
            this.tablo7.StatusBarKisayolAciklama = null;
            // 
            // colId4
            // 
            this.colId4.Caption = "Id";
            this.colId4.FieldName = "Id";
            this.colId4.Name = "colId4";
            this.colId4.OptionsColumn.AllowEdit = false;
            this.colId4.OptionsColumn.ShowInCustomizationForm = false;
            this.colId4.StatusBarAciklama = null;
            this.colId4.StatusBarKisayol = null;
            this.colId4.StatusBarKisayolAciklama = null;
            // 
            // colKod4
            // 
            this.colKod4.AppearanceCell.Options.UseTextOptions = true;
            this.colKod4.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.colKod4.Caption = "Kod";
            this.colKod4.FieldName = "Kod";
            this.colKod4.Name = "colKod4";
            this.colKod4.OptionsColumn.AllowEdit = false;
            this.colKod4.StatusBarAciklama = null;
            this.colKod4.StatusBarKisayol = null;
            this.colKod4.StatusBarKisayolAciklama = null;
            this.colKod4.Visible = true;
            this.colKod4.VisibleIndex = 0;
            // 
            // zRaporuGrid
            // 
            this.zRaporuGrid.EmbeddedNavigator.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.zRaporuGrid.Location = new System.Drawing.Point(12, 12);
            this.zRaporuGrid.MainView = this.tablo;
            this.zRaporuGrid.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.zRaporuGrid.MenuManager = this.ribbonControl;
            this.zRaporuGrid.Name = "zRaporuGrid";
            this.zRaporuGrid.Size = new System.Drawing.Size(1597, 450);
            this.zRaporuGrid.TabIndex = 4;
            this.zRaporuGrid.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
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
            this.tablo.Appearance.Row.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Center;
            this.tablo.Appearance.ViewCaption.ForeColor = System.Drawing.Color.Maroon;
            this.tablo.Appearance.ViewCaption.Options.UseForeColor = true;
            this.tablo.DetailHeight = 284;
            this.tablo.FocusRectStyle = DevExpress.XtraGrid.Views.Grid.DrawFocusRectStyle.RowFocus;
            this.tablo.GridControl = this.zRaporuGrid;
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
            // layoutControlItem7
            // 
            this.layoutControlItem7.AppearanceItemCaption.ForeColor = System.Drawing.Color.Maroon;
            this.layoutControlItem7.AppearanceItemCaption.Options.UseForeColor = true;
            this.layoutControlItem7.Control = this.grid7;
            this.layoutControlItem7.Location = new System.Drawing.Point(0, 454);
            this.layoutControlItem7.Name = "layoutControlItem7";
            this.layoutControlItem7.OptionsTableLayoutItem.RowIndex = 1;
            this.layoutControlItem7.Size = new System.Drawing.Size(800, 454);
            this.layoutControlItem7.TextSize = new System.Drawing.Size(0, 0);
            this.layoutControlItem7.TextVisible = false;
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
            columnDefinition1.Width = 50D;
            this.Root.OptionsTableLayoutGroup.ColumnDefinitions.AddRange(new DevExpress.XtraLayout.ColumnDefinition[] {
            columnDefinition1});
            rowDefinition1.Height = 50D;
            rowDefinition1.SizeType = System.Windows.Forms.SizeType.Percent;
            rowDefinition2.Height = 50D;
            rowDefinition2.SizeType = System.Windows.Forms.SizeType.Percent;
            this.Root.OptionsTableLayoutGroup.RowDefinitions.AddRange(new DevExpress.XtraLayout.RowDefinition[] {
            rowDefinition1,
            rowDefinition2});
            this.Root.Size = new System.Drawing.Size(1621, 928);
            this.Root.TextVisible = false;
            // 
            // layoutControlItem1
            // 
            this.layoutControlItem1.AppearanceItemCaption.ForeColor = System.Drawing.Color.Maroon;
            this.layoutControlItem1.AppearanceItemCaption.Options.UseForeColor = true;
            this.layoutControlItem1.Control = this.zRaporuGrid;
            this.layoutControlItem1.Location = new System.Drawing.Point(0, 0);
            this.layoutControlItem1.Name = "layoutControlItem1";
            this.layoutControlItem1.Size = new System.Drawing.Size(1601, 454);
            this.layoutControlItem1.TextSize = new System.Drawing.Size(0, 0);
            this.layoutControlItem1.TextVisible = false;
            // 
            // layoutControlItem2
            // 
            this.layoutControlItem2.AppearanceItemCaption.ForeColor = System.Drawing.Color.Maroon;
            this.layoutControlItem2.AppearanceItemCaption.Options.UseForeColor = true;
            this.layoutControlItem2.Control = this.groupControl1;
            this.layoutControlItem2.Location = new System.Drawing.Point(0, 454);
            this.layoutControlItem2.Name = "layoutControlItem2";
            this.layoutControlItem2.OptionsTableLayoutItem.RowIndex = 1;
            this.layoutControlItem2.Size = new System.Drawing.Size(1601, 454);
            this.layoutControlItem2.TextSize = new System.Drawing.Size(0, 0);
            this.layoutControlItem2.TextVisible = false;
            // 
            // ZRaporu
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1621, 1058);
            this.Controls.Add(this.myDataLayoutControl1);
            this.IconOptions.ShowIcon = false;
            this.Name = "ZRaporu";
            this.Tag = "Stok";
            this.Text = "Z Raporu";
            this.Controls.SetChildIndex(this.ribbonControl, 0);
            this.Controls.SetChildIndex(this.ribbonStatusBar1, 0);
            this.Controls.SetChildIndex(this.myDataLayoutControl1, 0);
            ((System.ComponentModel.ISupportInitialize)(this.ribbonControl)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.myDataLayoutControl1)).EndInit();
            this.myDataLayoutControl1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.groupControl1)).EndInit();
            this.groupControl1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.detayGrid)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.detayTablo)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.grid7)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tablo7)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.zRaporuGrid)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tablo)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem7)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Root)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem2)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private UserControls.Controls.MyDataLayoutControl myDataLayoutControl1;
        private DevExpress.XtraLayout.LayoutControlGroup Root;
        private UserControls.Controls.Grid.MyGridControl zRaporuGrid;
        private UserControls.Controls.Grid.MyGridView tablo;
        private UserControls.Controls.Grid.MyGridControl detayGrid;
        private UserControls.Controls.Grid.MyGridView detayTablo;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem1;
        private UserControls.Controls.Grid.MyGridControl grid7;
        private UserControls.Controls.Grid.MyGridView tablo7;
        private UserControls.Controls.Grid.MyGridColumn colId4;
        private UserControls.Controls.Grid.MyGridColumn colKod4;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem7;
        private DevExpress.XtraEditors.GroupControl groupControl1;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem2;
    }
}
