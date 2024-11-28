namespace XCubeCrm.UI.Win.Forms.Raporlar.njoy
{
    partial class ZRaporu
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ZRaporu));
            DevExpress.XtraLayout.ColumnDefinition columnDefinition1 = new DevExpress.XtraLayout.ColumnDefinition();
            DevExpress.XtraLayout.ColumnDefinition columnDefinition2 = new DevExpress.XtraLayout.ColumnDefinition();
            DevExpress.XtraLayout.RowDefinition rowDefinition1 = new DevExpress.XtraLayout.RowDefinition();
            this.myDataLayoutControl1 = new XCubeCrm.UI.Win.Forms.UserControls.Controls.MyDataLayoutControl();
            this.grid2 = new XCubeCrm.UI.Win.Forms.UserControls.Controls.Grid.MyGridControl();
            this.tablo2 = new XCubeCrm.UI.Win.Forms.UserControls.Controls.Grid.MyGridView();
            this.grid = new XCubeCrm.UI.Win.Forms.UserControls.Controls.Grid.MyGridControl();
            this.tablo = new XCubeCrm.UI.Win.Forms.UserControls.Controls.Grid.MyGridView();
            this.Root = new DevExpress.XtraLayout.LayoutControlGroup();
            this.layoutControlItem1 = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlItem2 = new DevExpress.XtraLayout.LayoutControlItem();
            ((System.ComponentModel.ISupportInitialize)(this.ribbonControl)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.myDataLayoutControl1)).BeginInit();
            this.myDataLayoutControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.grid2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tablo2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.grid)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tablo)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Root)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem2)).BeginInit();
            this.SuspendLayout();
            // 
            // ribbonStatusBar1
            // 
            this.ribbonStatusBar1.Location = new System.Drawing.Point(0, 844);
            this.ribbonStatusBar1.Size = new System.Drawing.Size(1632, 27);
            // 
            // ribbonControl
            // 
            this.ribbonControl.EmptyAreaImageOptions.ImagePadding = new System.Windows.Forms.Padding(22, 19, 22, 19);
            this.ribbonControl.ExpandCollapseItem.Id = 0;
            this.ribbonControl.OptionsMenuMinWidth = 243;
            this.ribbonControl.Size = new System.Drawing.Size(1632, 103);
            this.ribbonControl.Toolbar.ShowCustomizeItem = false;
            // 
            // btnDisariAktar
            // 
            this.btnDisariAktar.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("btnDisariAktar.ImageOptions.Image")));
            this.btnDisariAktar.ImageOptions.LargeImage = ((System.Drawing.Image)(resources.GetObject("btnDisariAktar.ImageOptions.LargeImage")));
            // 
            // myDataLayoutControl1
            // 
            this.myDataLayoutControl1.Controls.Add(this.grid2);
            this.myDataLayoutControl1.Controls.Add(this.grid);
            this.myDataLayoutControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.myDataLayoutControl1.Location = new System.Drawing.Point(0, 103);
            this.myDataLayoutControl1.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.myDataLayoutControl1.Name = "myDataLayoutControl1";
            this.myDataLayoutControl1.OptionsFocus.EnableAutoTabOrder = false;
            this.myDataLayoutControl1.Root = this.Root;
            this.myDataLayoutControl1.Size = new System.Drawing.Size(1632, 741);
            this.myDataLayoutControl1.TabIndex = 7;
            this.myDataLayoutControl1.Text = "myDataLayoutControl1";
            // 
            // grid2
            // 
            this.grid2.EmbeddedNavigator.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.grid2.Location = new System.Drawing.Point(818, 12);
            this.grid2.MainView = this.tablo2;
            this.grid2.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.grid2.MenuManager = this.ribbonControl;
            this.grid2.Name = "grid2";
            this.grid2.Size = new System.Drawing.Size(802, 717);
            this.grid2.TabIndex = 5;
            this.grid2.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.tablo2});
            // 
            // tablo2
            // 
            this.tablo2.Appearance.FooterPanel.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
            this.tablo2.Appearance.FooterPanel.ForeColor = System.Drawing.Color.Maroon;
            this.tablo2.Appearance.FooterPanel.Options.UseFont = true;
            this.tablo2.Appearance.FooterPanel.Options.UseForeColor = true;
            this.tablo2.Appearance.HeaderPanel.ForeColor = System.Drawing.Color.Maroon;
            this.tablo2.Appearance.HeaderPanel.Options.UseForeColor = true;
            this.tablo2.Appearance.HeaderPanel.Options.UseTextOptions = true;
            this.tablo2.Appearance.HeaderPanel.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.tablo2.Appearance.Row.Options.UseTextOptions = true;
            this.tablo2.Appearance.Row.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Center;
            this.tablo2.Appearance.ViewCaption.ForeColor = System.Drawing.Color.Maroon;
            this.tablo2.Appearance.ViewCaption.Options.UseForeColor = true;
            this.tablo2.DetailHeight = 284;
            this.tablo2.FocusRectStyle = DevExpress.XtraGrid.Views.Grid.DrawFocusRectStyle.RowFocus;
            this.tablo2.GridControl = this.grid2;
            this.tablo2.Name = "tablo2";
            this.tablo2.OptionsEditForm.PopupEditFormWidth = 686;
            this.tablo2.OptionsMenu.EnableColumnMenu = false;
            this.tablo2.OptionsMenu.EnableFooterMenu = false;
            this.tablo2.OptionsMenu.EnableGroupPanelMenu = false;
            this.tablo2.OptionsMenu.ShowFooterItem = true;
            this.tablo2.OptionsMenu.ShowSummaryItemMode = DevExpress.Utils.DefaultBoolean.True;
            this.tablo2.OptionsNavigation.EnterMoveNextColumn = true;
            this.tablo2.OptionsPrint.AutoWidth = false;
            this.tablo2.OptionsPrint.PrintFooter = false;
            this.tablo2.OptionsPrint.PrintGroupFooter = false;
            this.tablo2.OptionsView.BestFitMode = DevExpress.XtraGrid.Views.Grid.GridBestFitMode.Fast;
            this.tablo2.OptionsView.ColumnAutoWidth = false;
            this.tablo2.OptionsView.HeaderFilterButtonShowMode = DevExpress.XtraEditors.Controls.FilterButtonShowMode.Button;
            this.tablo2.OptionsView.RowAutoHeight = true;
            this.tablo2.OptionsView.ShowAutoFilterRow = true;
            this.tablo2.OptionsView.ShowFooter = true;
            this.tablo2.OptionsView.ShowGroupPanel = false;
            this.tablo2.StatusBarAciklama = null;
            this.tablo2.StatusBarKisayol = null;
            this.tablo2.StatusBarKisayolAciklama = null;
            // 
            // grid
            // 
            this.grid.EmbeddedNavigator.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.grid.Location = new System.Drawing.Point(12, 12);
            this.grid.MainView = this.tablo;
            this.grid.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.grid.MenuManager = this.ribbonControl;
            this.grid.Name = "grid";
            this.grid.Size = new System.Drawing.Size(802, 717);
            this.grid.TabIndex = 4;
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
            this.tablo.Appearance.Row.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Center;
            this.tablo.Appearance.ViewCaption.ForeColor = System.Drawing.Color.Maroon;
            this.tablo.Appearance.ViewCaption.Options.UseForeColor = true;
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
            columnDefinition2.SizeType = System.Windows.Forms.SizeType.Percent;
            columnDefinition2.Width = 50D;
            this.Root.OptionsTableLayoutGroup.ColumnDefinitions.AddRange(new DevExpress.XtraLayout.ColumnDefinition[] {
            columnDefinition1,
            columnDefinition2});
            rowDefinition1.Height = 100D;
            rowDefinition1.SizeType = System.Windows.Forms.SizeType.Percent;
            this.Root.OptionsTableLayoutGroup.RowDefinitions.AddRange(new DevExpress.XtraLayout.RowDefinition[] {
            rowDefinition1});
            this.Root.Size = new System.Drawing.Size(1632, 741);
            this.Root.TextVisible = false;
            // 
            // layoutControlItem1
            // 
            this.layoutControlItem1.AppearanceItemCaption.ForeColor = System.Drawing.Color.Maroon;
            this.layoutControlItem1.AppearanceItemCaption.Options.UseForeColor = true;
            this.layoutControlItem1.Control = this.grid;
            this.layoutControlItem1.Location = new System.Drawing.Point(0, 0);
            this.layoutControlItem1.Name = "layoutControlItem1";
            this.layoutControlItem1.Size = new System.Drawing.Size(806, 721);
            this.layoutControlItem1.TextSize = new System.Drawing.Size(0, 0);
            this.layoutControlItem1.TextVisible = false;
            // 
            // layoutControlItem2
            // 
            this.layoutControlItem2.AppearanceItemCaption.ForeColor = System.Drawing.Color.Maroon;
            this.layoutControlItem2.AppearanceItemCaption.Options.UseForeColor = true;
            this.layoutControlItem2.Control = this.grid2;
            this.layoutControlItem2.Location = new System.Drawing.Point(806, 0);
            this.layoutControlItem2.Name = "layoutControlItem2";
            this.layoutControlItem2.OptionsTableLayoutItem.ColumnIndex = 1;
            this.layoutControlItem2.Size = new System.Drawing.Size(806, 721);
            this.layoutControlItem2.TextSize = new System.Drawing.Size(0, 0);
            this.layoutControlItem2.TextVisible = false;
            // 
            // ZRaporu
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1632, 871);
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
            ((System.ComponentModel.ISupportInitialize)(this.grid2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tablo2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.grid)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tablo)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Root)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem2)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private UserControls.Controls.MyDataLayoutControl myDataLayoutControl1;
        private DevExpress.XtraLayout.LayoutControlGroup Root;
        private UserControls.Controls.Grid.MyGridControl grid2;
        private UserControls.Controls.Grid.MyGridView tablo2;
        private UserControls.Controls.Grid.MyGridControl grid;
        private UserControls.Controls.Grid.MyGridView tablo;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem1;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem2;
    }
}