namespace XCubeCrm.UI.Win.GenelForms
{
    partial class RaporSecim
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(RaporSecim));
            DevExpress.XtraLayout.ColumnDefinition columnDefinition1 = new DevExpress.XtraLayout.ColumnDefinition();
            DevExpress.XtraLayout.ColumnDefinition columnDefinition2 = new DevExpress.XtraLayout.ColumnDefinition();
            DevExpress.XtraLayout.ColumnDefinition columnDefinition3 = new DevExpress.XtraLayout.ColumnDefinition();
            DevExpress.XtraLayout.ColumnDefinition columnDefinition4 = new DevExpress.XtraLayout.ColumnDefinition();
            DevExpress.XtraLayout.RowDefinition rowDefinition1 = new DevExpress.XtraLayout.RowDefinition();
            DevExpress.XtraLayout.RowDefinition rowDefinition2 = new DevExpress.XtraLayout.RowDefinition();
            DevExpress.XtraLayout.RowDefinition rowDefinition3 = new DevExpress.XtraLayout.RowDefinition();
            DevExpress.XtraLayout.RowDefinition rowDefinition4 = new DevExpress.XtraLayout.RowDefinition();
            this.myDataLayoutControl = new XCubeCrm.UI.Win.Forms.UserControls.Controls.MyDataLayoutControl();
            this.myPictureEdit1 = new XCubeCrm.UI.Win.Forms.UserControls.Controls.MyPictureEdit();
            this.smallNavigator = new XCubeCrm.UI.Win.Forms.UserControls.Controls.Navigators.SmallNavigator();
            this.grid = new XCubeCrm.UI.Win.Forms.UserControls.Controls.Grid.MyGridControl();
            this.tablo = new XCubeCrm.UI.Win.Forms.UserControls.Controls.Grid.MyGridView();
            this.colRaporAdi = new XCubeCrm.UI.Win.Forms.UserControls.Controls.Grid.MyGridColumn();
            this.txtKopyaSayisi = new XCubeCrm.UI.Win.Forms.UserControls.Controls.MySpinEdit();
            this.txtYazdirmaSekli = new XCubeCrm.UI.Win.Forms.UserControls.Controls.MyComboBoxEdit();
            this.txtYaziciAdi = new XCubeCrm.UI.Win.Forms.UserControls.Controls.MyComboBoxEdit();
            this.Root = new DevExpress.XtraLayout.LayoutControlGroup();
            this.layoutControlItem1 = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlItem2 = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlItem3 = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlItem4 = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlItem5 = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlItem6 = new DevExpress.XtraLayout.LayoutControlItem();
            this.btnTabloYazdir = new DevExpress.XtraBars.BarButtonItem();
            this.btnTasarimDegistir = new DevExpress.XtraBars.BarButtonItem();
            ((System.ComponentModel.ISupportInitialize)(this.ribbonControl)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.sagMenu)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.myDataLayoutControl)).BeginInit();
            this.myDataLayoutControl.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.myPictureEdit1.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.grid)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tablo)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtKopyaSayisi.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtYazdirmaSekli.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtYaziciAdi.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Root)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem4)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem5)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem6)).BeginInit();
            this.SuspendLayout();
            // 
            // ribbonStatusBar1
            // 
            this.ribbonStatusBar1.Location = new System.Drawing.Point(0, 617);
            this.ribbonStatusBar1.Size = new System.Drawing.Size(1201, 30);
            // 
            // ribbonControl
            // 
            this.ribbonControl.EmptyAreaImageOptions.ImagePadding = new System.Windows.Forms.Padding(37);
            this.ribbonControl.ExpandCollapseItem.Id = 0;
            this.ribbonControl.Items.AddRange(new DevExpress.XtraBars.BarItem[] {
            this.btnTabloYazdir,
            this.btnTasarimDegistir});
            this.ribbonControl.MaxItemId = 69;
            this.ribbonControl.Size = new System.Drawing.Size(1201, 166);
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
            this.btnYeniRapor.Visibility = DevExpress.XtraBars.BarItemVisibility.Never;
            // 
            // myDataLayoutControl
            // 
            this.myDataLayoutControl.Controls.Add(this.myPictureEdit1);
            this.myDataLayoutControl.Controls.Add(this.smallNavigator);
            this.myDataLayoutControl.Controls.Add(this.grid);
            this.myDataLayoutControl.Controls.Add(this.txtKopyaSayisi);
            this.myDataLayoutControl.Controls.Add(this.txtYazdirmaSekli);
            this.myDataLayoutControl.Controls.Add(this.txtYaziciAdi);
            this.myDataLayoutControl.Dock = System.Windows.Forms.DockStyle.Fill;
            this.myDataLayoutControl.Location = new System.Drawing.Point(0, 166);
            this.myDataLayoutControl.Name = "myDataLayoutControl";
            this.myDataLayoutControl.OptionsFocus.EnableAutoTabOrder = false;
            this.myDataLayoutControl.Root = this.Root;
            this.myDataLayoutControl.Size = new System.Drawing.Size(1201, 451);
            this.myDataLayoutControl.TabIndex = 2;
            this.myDataLayoutControl.Text = "myDataLayoutControl1";
            // 
            // myPictureEdit1
            // 
            this.myPictureEdit1.Cursor = System.Windows.Forms.Cursors.Default;
            this.myPictureEdit1.EditValue = global::XCubeCrm.UI.Win.Properties.Resources.printer;
            this.myPictureEdit1.EnterMoveNextControl = true;
            this.myPictureEdit1.Location = new System.Drawing.Point(12, 12);
            this.myPictureEdit1.Margin = new System.Windows.Forms.Padding(4);
            this.myPictureEdit1.MenuManager = this.ribbonControl;
            this.myPictureEdit1.Name = "myPictureEdit1";
            this.myPictureEdit1.Properties.AllowFocused = false;
            this.myPictureEdit1.Properties.Appearance.BackColor = System.Drawing.Color.Transparent;
            this.myPictureEdit1.Properties.Appearance.ForeColor = System.Drawing.Color.Maroon;
            this.myPictureEdit1.Properties.Appearance.Options.UseBackColor = true;
            this.myPictureEdit1.Properties.Appearance.Options.UseForeColor = true;
            this.myPictureEdit1.Properties.AppearanceFocused.BackColor = System.Drawing.Color.LightCyan;
            this.myPictureEdit1.Properties.AppearanceFocused.Options.UseBackColor = true;
            this.myPictureEdit1.Properties.NullText = "Resim seçilmedi.";
            this.myPictureEdit1.Properties.ShowCameraMenuItem = DevExpress.XtraEditors.Controls.CameraMenuItemVisibility.Auto;
            this.myPictureEdit1.Properties.ShowMenu = false;
            this.myPictureEdit1.Properties.SizeMode = DevExpress.XtraEditors.Controls.PictureSizeMode.Squeeze;
            this.myPictureEdit1.Size = new System.Drawing.Size(196, 427);
            this.myPictureEdit1.StatusBarAciklama = null;
            this.myPictureEdit1.StatusBarKisayol = "F4: ";
            this.myPictureEdit1.StatusBarKisayolAciklama = null;
            this.myPictureEdit1.StyleController = this.myDataLayoutControl;
            this.myPictureEdit1.TabIndex = 9;
            // 
            // smallNavigator
            // 
            this.smallNavigator.Location = new System.Drawing.Point(212, 419);
            this.smallNavigator.Name = "smallNavigator";
            this.smallNavigator.Size = new System.Drawing.Size(977, 20);
            this.smallNavigator.TabIndex = 8;
            // 
            // grid
            // 
            this.grid.Location = new System.Drawing.Point(212, 60);
            this.grid.MainView = this.tablo;
            this.grid.MenuManager = this.ribbonControl;
            this.grid.Name = "grid";
            this.grid.Size = new System.Drawing.Size(977, 355);
            this.grid.TabIndex = 7;
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
            this.colRaporAdi});
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
            this.tablo.OptionsView.HeaderFilterButtonShowMode = DevExpress.XtraEditors.Controls.FilterButtonShowMode.Button;
            this.tablo.OptionsView.RowAutoHeight = true;
            this.tablo.OptionsView.ShowAutoFilterRow = true;
            this.tablo.OptionsView.ShowFooter = true;
            this.tablo.OptionsView.ShowGroupPanel = false;
            this.tablo.OptionsView.ShowViewCaption = true;
            this.tablo.StatusBarAciklama = null;
            this.tablo.StatusBarKisayol = null;
            this.tablo.StatusBarKisayolAciklama = null;
            this.tablo.ViewCaption = "Rapor Seçim";
            // 
            // colRaporAdi
            // 
            this.colRaporAdi.Caption = "Rapor Adı";
            this.colRaporAdi.FieldName = "RaporAdi";
            this.colRaporAdi.MinWidth = 25;
            this.colRaporAdi.Name = "colRaporAdi";
            this.colRaporAdi.OptionsColumn.AllowEdit = false;
            this.colRaporAdi.StatusBarAciklama = null;
            this.colRaporAdi.StatusBarKisayol = null;
            this.colRaporAdi.StatusBarKisayolAciklama = null;
            this.colRaporAdi.Visible = true;
            this.colRaporAdi.VisibleIndex = 0;
            this.colRaporAdi.Width = 94;
            // 
            // txtKopyaSayisi
            // 
            this.txtKopyaSayisi.EditValue = new decimal(new int[] {
            0,
            0,
            0,
            0});
            this.txtKopyaSayisi.EnterMoveNextControl = true;
            this.txtKopyaSayisi.Location = new System.Drawing.Point(618, 36);
            this.txtKopyaSayisi.MenuManager = this.ribbonControl;
            this.txtKopyaSayisi.Name = "txtKopyaSayisi";
            this.txtKopyaSayisi.Properties.AllowNullInput = DevExpress.Utils.DefaultBoolean.False;
            this.txtKopyaSayisi.Properties.AppearanceFocused.BackColor = System.Drawing.Color.LightCyan;
            this.txtKopyaSayisi.Properties.AppearanceFocused.Options.UseBackColor = true;
            this.txtKopyaSayisi.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.txtKopyaSayisi.Properties.MaskSettings.Set("mask", "d");
            this.txtKopyaSayisi.Size = new System.Drawing.Size(571, 24);
            this.txtKopyaSayisi.StatusBarAciklama = null;
            this.txtKopyaSayisi.StyleController = this.myDataLayoutControl;
            this.txtKopyaSayisi.TabIndex = 6;
            // 
            // txtYazdirmaSekli
            // 
            this.txtYazdirmaSekli.EnterMoveNextControl = true;
            this.txtYazdirmaSekli.Location = new System.Drawing.Point(308, 36);
            this.txtYazdirmaSekli.MenuManager = this.ribbonControl;
            this.txtYazdirmaSekli.Name = "txtYazdirmaSekli";
            this.txtYazdirmaSekli.Properties.AppearanceFocused.BackColor = System.Drawing.Color.LightCyan;
            this.txtYazdirmaSekli.Properties.AppearanceFocused.Options.UseBackColor = true;
            this.txtYazdirmaSekli.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.txtYazdirmaSekli.Properties.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.DisableTextEditor;
            this.txtYazdirmaSekli.Size = new System.Drawing.Size(170, 22);
            this.txtYazdirmaSekli.StatusBarAciklama = null;
            this.txtYazdirmaSekli.StatusBarKisayol = "F4 : ";
            this.txtYazdirmaSekli.StatusBarKisayolAciklama = null;
            this.txtYazdirmaSekli.StyleController = this.myDataLayoutControl;
            this.txtYazdirmaSekli.TabIndex = 5;
            // 
            // txtYaziciAdi
            // 
            this.txtYaziciAdi.EnterMoveNextControl = true;
            this.txtYaziciAdi.Location = new System.Drawing.Point(308, 12);
            this.txtYaziciAdi.MenuManager = this.ribbonControl;
            this.txtYaziciAdi.Name = "txtYaziciAdi";
            this.txtYaziciAdi.Properties.AppearanceFocused.BackColor = System.Drawing.Color.LightCyan;
            this.txtYaziciAdi.Properties.AppearanceFocused.Options.UseBackColor = true;
            this.txtYaziciAdi.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.txtYaziciAdi.Properties.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.DisableTextEditor;
            this.txtYaziciAdi.Size = new System.Drawing.Size(881, 22);
            this.txtYaziciAdi.StatusBarAciklama = null;
            this.txtYaziciAdi.StatusBarKisayol = "F4 : ";
            this.txtYaziciAdi.StatusBarKisayolAciklama = null;
            this.txtYaziciAdi.StyleController = this.myDataLayoutControl;
            this.txtYaziciAdi.TabIndex = 4;
            // 
            // Root
            // 
            this.Root.EnableIndentsWithoutBorders = DevExpress.Utils.DefaultBoolean.True;
            this.Root.GroupBordersVisible = false;
            this.Root.Items.AddRange(new DevExpress.XtraLayout.BaseLayoutItem[] {
            this.layoutControlItem1,
            this.layoutControlItem2,
            this.layoutControlItem3,
            this.layoutControlItem4,
            this.layoutControlItem5,
            this.layoutControlItem6});
            this.Root.LayoutMode = DevExpress.XtraLayout.Utils.LayoutMode.Table;
            this.Root.Name = "Root";
            columnDefinition1.SizeType = System.Windows.Forms.SizeType.Absolute;
            columnDefinition1.Width = 200D;
            columnDefinition2.SizeType = System.Windows.Forms.SizeType.Absolute;
            columnDefinition2.Width = 270D;
            columnDefinition3.SizeType = System.Windows.Forms.SizeType.Absolute;
            columnDefinition3.Width = 40D;
            columnDefinition4.SizeType = System.Windows.Forms.SizeType.Absolute;
            columnDefinition4.Width = 100D;
            this.Root.OptionsTableLayoutGroup.ColumnDefinitions.AddRange(new DevExpress.XtraLayout.ColumnDefinition[] {
            columnDefinition1,
            columnDefinition2,
            columnDefinition3,
            columnDefinition4});
            rowDefinition1.Height = 24D;
            rowDefinition1.SizeType = System.Windows.Forms.SizeType.Absolute;
            rowDefinition2.Height = 24D;
            rowDefinition2.SizeType = System.Windows.Forms.SizeType.Absolute;
            rowDefinition3.Height = 100D;
            rowDefinition3.SizeType = System.Windows.Forms.SizeType.Percent;
            rowDefinition4.Height = 24D;
            rowDefinition4.SizeType = System.Windows.Forms.SizeType.Absolute;
            this.Root.OptionsTableLayoutGroup.RowDefinitions.AddRange(new DevExpress.XtraLayout.RowDefinition[] {
            rowDefinition1,
            rowDefinition2,
            rowDefinition3,
            rowDefinition4});
            this.Root.Size = new System.Drawing.Size(1201, 451);
            this.Root.TextVisible = false;
            // 
            // layoutControlItem1
            // 
            this.layoutControlItem1.AppearanceItemCaption.ForeColor = System.Drawing.Color.Maroon;
            this.layoutControlItem1.AppearanceItemCaption.Options.UseForeColor = true;
            this.layoutControlItem1.Control = this.txtYaziciAdi;
            this.layoutControlItem1.Location = new System.Drawing.Point(200, 0);
            this.layoutControlItem1.Name = "layoutControlItem1";
            this.layoutControlItem1.OptionsTableLayoutItem.ColumnIndex = 1;
            this.layoutControlItem1.OptionsTableLayoutItem.ColumnSpan = 3;
            this.layoutControlItem1.Size = new System.Drawing.Size(981, 24);
            this.layoutControlItem1.Text = "Yazıcı Adı";
            this.layoutControlItem1.TextSize = new System.Drawing.Size(84, 16);
            // 
            // layoutControlItem2
            // 
            this.layoutControlItem2.AppearanceItemCaption.ForeColor = System.Drawing.Color.Maroon;
            this.layoutControlItem2.AppearanceItemCaption.Options.UseForeColor = true;
            this.layoutControlItem2.Control = this.txtYazdirmaSekli;
            this.layoutControlItem2.Location = new System.Drawing.Point(200, 24);
            this.layoutControlItem2.Name = "layoutControlItem2";
            this.layoutControlItem2.OptionsTableLayoutItem.ColumnIndex = 1;
            this.layoutControlItem2.OptionsTableLayoutItem.RowIndex = 1;
            this.layoutControlItem2.Size = new System.Drawing.Size(270, 24);
            this.layoutControlItem2.Text = "Yazdırma Şekli";
            this.layoutControlItem2.TextSize = new System.Drawing.Size(84, 16);
            // 
            // layoutControlItem3
            // 
            this.layoutControlItem3.AppearanceItemCaption.ForeColor = System.Drawing.Color.Maroon;
            this.layoutControlItem3.AppearanceItemCaption.Options.UseForeColor = true;
            this.layoutControlItem3.Control = this.txtKopyaSayisi;
            this.layoutControlItem3.Location = new System.Drawing.Point(510, 24);
            this.layoutControlItem3.Name = "layoutControlItem3";
            this.layoutControlItem3.OptionsTableLayoutItem.ColumnIndex = 3;
            this.layoutControlItem3.OptionsTableLayoutItem.RowIndex = 1;
            this.layoutControlItem3.Size = new System.Drawing.Size(671, 24);
            this.layoutControlItem3.Text = "Kopya Sayısı";
            this.layoutControlItem3.TextSize = new System.Drawing.Size(84, 16);
            // 
            // layoutControlItem4
            // 
            this.layoutControlItem4.AppearanceItemCaption.ForeColor = System.Drawing.Color.Maroon;
            this.layoutControlItem4.AppearanceItemCaption.Options.UseForeColor = true;
            this.layoutControlItem4.Control = this.grid;
            this.layoutControlItem4.Location = new System.Drawing.Point(200, 48);
            this.layoutControlItem4.Name = "layoutControlItem4";
            this.layoutControlItem4.OptionsTableLayoutItem.ColumnIndex = 1;
            this.layoutControlItem4.OptionsTableLayoutItem.ColumnSpan = 3;
            this.layoutControlItem4.OptionsTableLayoutItem.RowIndex = 2;
            this.layoutControlItem4.Size = new System.Drawing.Size(981, 359);
            this.layoutControlItem4.TextSize = new System.Drawing.Size(0, 0);
            this.layoutControlItem4.TextVisible = false;
            // 
            // layoutControlItem5
            // 
            this.layoutControlItem5.AppearanceItemCaption.ForeColor = System.Drawing.Color.Maroon;
            this.layoutControlItem5.AppearanceItemCaption.Options.UseForeColor = true;
            this.layoutControlItem5.Control = this.smallNavigator;
            this.layoutControlItem5.Location = new System.Drawing.Point(200, 407);
            this.layoutControlItem5.Name = "layoutControlItem5";
            this.layoutControlItem5.OptionsTableLayoutItem.ColumnIndex = 1;
            this.layoutControlItem5.OptionsTableLayoutItem.ColumnSpan = 3;
            this.layoutControlItem5.OptionsTableLayoutItem.RowIndex = 3;
            this.layoutControlItem5.Size = new System.Drawing.Size(981, 24);
            this.layoutControlItem5.TextSize = new System.Drawing.Size(0, 0);
            this.layoutControlItem5.TextVisible = false;
            // 
            // layoutControlItem6
            // 
            this.layoutControlItem6.AppearanceItemCaption.ForeColor = System.Drawing.Color.Maroon;
            this.layoutControlItem6.AppearanceItemCaption.Options.UseForeColor = true;
            this.layoutControlItem6.Control = this.myPictureEdit1;
            this.layoutControlItem6.Location = new System.Drawing.Point(0, 0);
            this.layoutControlItem6.Name = "layoutControlItem6";
            this.layoutControlItem6.OptionsTableLayoutItem.RowSpan = 4;
            this.layoutControlItem6.Size = new System.Drawing.Size(200, 431);
            this.layoutControlItem6.TextSize = new System.Drawing.Size(0, 0);
            this.layoutControlItem6.TextVisible = false;
            // 
            // btnTabloYazdir
            // 
            this.btnTabloYazdir.Caption = "Tablo Yazdır";
            this.btnTabloYazdir.Id = 67;
            this.btnTabloYazdir.ImageOptions.Image = global::XCubeCrm.UI.Win.Properties.Resources.printdialog_16x16;
            this.btnTabloYazdir.ImageOptions.LargeImage = global::XCubeCrm.UI.Win.Properties.Resources.printdialog_32x32;
            this.btnTabloYazdir.ItemShortcut = new DevExpress.XtraBars.BarShortcut(((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.Shift) 
                | System.Windows.Forms.Keys.P));
            this.btnTabloYazdir.Name = "btnTabloYazdir";
            this.btnTabloYazdir.Visibility = DevExpress.XtraBars.BarItemVisibility.Never;
            // 
            // btnTasarimDegistir
            // 
            this.btnTasarimDegistir.Caption = "Tasarım Değiştir";
            this.btnTasarimDegistir.Id = 68;
            this.btnTasarimDegistir.ImageOptions.Image = global::XCubeCrm.UI.Win.Properties.Resources.designreport_16x16;
            this.btnTasarimDegistir.ImageOptions.LargeImage = global::XCubeCrm.UI.Win.Properties.Resources.designreport_32x32;
            this.btnTasarimDegistir.ItemShortcut = new DevExpress.XtraBars.BarShortcut((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.F3));
            this.btnTasarimDegistir.Name = "btnTasarimDegistir";
            this.btnTasarimDegistir.Visibility = DevExpress.XtraBars.BarItemVisibility.Never;
            // 
            // RaporSecim
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1201, 647);
            this.Controls.Add(this.myDataLayoutControl);
            this.IconOptions.ShowIcon = false;
            this.Name = "RaporSecim";
            this.Text = "RaporSecim";
            this.Controls.SetChildIndex(this.ribbonControl, 0);
            this.Controls.SetChildIndex(this.ribbonStatusBar1, 0);
            this.Controls.SetChildIndex(this.myDataLayoutControl, 0);
            ((System.ComponentModel.ISupportInitialize)(this.ribbonControl)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.sagMenu)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.myDataLayoutControl)).EndInit();
            this.myDataLayoutControl.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.myPictureEdit1.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.grid)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tablo)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtKopyaSayisi.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtYazdirmaSekli.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtYaziciAdi.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Root)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem4)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem5)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem6)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Forms.UserControls.Controls.MyDataLayoutControl myDataLayoutControl;
        private Forms.UserControls.Controls.MySpinEdit txtKopyaSayisi;
        private Forms.UserControls.Controls.MyComboBoxEdit txtYazdirmaSekli;
        private Forms.UserControls.Controls.MyComboBoxEdit txtYaziciAdi;
        private DevExpress.XtraLayout.LayoutControlGroup Root;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem1;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem2;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem3;
        private Forms.UserControls.Controls.Grid.MyGridControl grid;
        private Forms.UserControls.Controls.Grid.MyGridView tablo;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem4;
        private Forms.UserControls.Controls.MyPictureEdit myPictureEdit1;
        private Forms.UserControls.Controls.Navigators.SmallNavigator smallNavigator;
        private Forms.UserControls.Controls.Grid.MyGridColumn colRaporAdi;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem5;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem6;
        protected DevExpress.XtraBars.BarButtonItem btnTabloYazdir;
        protected DevExpress.XtraBars.BarButtonItem btnTasarimDegistir;
    }
}