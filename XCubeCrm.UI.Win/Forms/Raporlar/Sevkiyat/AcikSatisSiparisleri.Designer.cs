namespace XCubeCrm.UI.Win.Forms.Raporlar.Sevkiyat
{
    partial class AcikSatisSiparisleri
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(AcikSatisSiparisleri));
            DevExpress.XtraLayout.ColumnDefinition columnDefinition1 = new DevExpress.XtraLayout.ColumnDefinition();
            DevExpress.XtraLayout.RowDefinition rowDefinition1 = new DevExpress.XtraLayout.RowDefinition();
            this.grid = new XCubeCrm.UI.Win.Forms.UserControls.Controls.Grid.MyGridControl();
            this.tablo = new XCubeCrm.UI.Win.Forms.UserControls.Controls.Grid.MyGridView();
            this.colId = new XCubeCrm.UI.Win.Forms.UserControls.Controls.Grid.MyGridColumn();
            this.colSIPARISNO = new XCubeCrm.UI.Win.Forms.UserControls.Controls.Grid.MyGridColumn();
            this.colSIPARISTARIHI = new XCubeCrm.UI.Win.Forms.UserControls.Controls.Grid.MyGridColumn();
            this.colSEVKTARIHI = new XCubeCrm.UI.Win.Forms.UserControls.Controls.Grid.MyGridColumn();
            this.colGECENGUN = new XCubeCrm.UI.Win.Forms.UserControls.Controls.Grid.MyGridColumn();
            this.colAMBAR = new XCubeCrm.UI.Win.Forms.UserControls.Controls.Grid.MyGridColumn();
            this.colKOD = new XCubeCrm.UI.Win.Forms.UserControls.Controls.Grid.MyGridColumn();
            this.colUNVAN = new XCubeCrm.UI.Win.Forms.UserControls.Controls.Grid.MyGridColumn();
            this.colBELGENO = new XCubeCrm.UI.Win.Forms.UserControls.Controls.Grid.MyGridColumn();
            this.colOZELKOD = new XCubeCrm.UI.Win.Forms.UserControls.Controls.Grid.MyGridColumn();
            this.colSIPARISACIKLAMA = new XCubeCrm.UI.Win.Forms.UserControls.Controls.Grid.MyGridColumn();
            this.colSIPARISIOLUSTURANKULLANICI = new XCubeCrm.UI.Win.Forms.UserControls.Controls.Grid.MyGridColumn();
            this.colSEVKADRESI = new XCubeCrm.UI.Win.Forms.UserControls.Controls.Grid.MyGridColumn();
            this.colILCE = new XCubeCrm.UI.Win.Forms.UserControls.Controls.Grid.MyGridColumn();
            this.colSEHIR = new XCubeCrm.UI.Win.Forms.UserControls.Controls.Grid.MyGridColumn();
            this.colURUNKOD = new XCubeCrm.UI.Win.Forms.UserControls.Controls.Grid.MyGridColumn();
            this.colURUNADI = new XCubeCrm.UI.Win.Forms.UserControls.Controls.Grid.MyGridColumn();
            this.colDEPOTOPLAMI = new XCubeCrm.UI.Win.Forms.UserControls.Controls.Grid.MyGridColumn();
            this.colSIPARISMIKTARI = new XCubeCrm.UI.Win.Forms.UserControls.Controls.Grid.MyGridColumn();
            this.colKARSILANANMIKTAR = new XCubeCrm.UI.Win.Forms.UserControls.Controls.Grid.MyGridColumn();
            this.colACIKSIPARIS = new XCubeCrm.UI.Win.Forms.UserControls.Controls.Grid.MyGridColumn();
            this.colBIRIM = new XCubeCrm.UI.Win.Forms.UserControls.Controls.Grid.MyGridColumn();
            this.colFIYAT = new XCubeCrm.UI.Win.Forms.UserControls.Controls.Grid.MyGridColumn();
            this.colDOVIZ = new XCubeCrm.UI.Win.Forms.UserControls.Controls.Grid.MyGridColumn();
            this.colVADE = new XCubeCrm.UI.Win.Forms.UserControls.Controls.Grid.MyGridColumn();
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
            this.colSIPARISNO,
            this.colSIPARISTARIHI,
            this.colSEVKTARIHI,
            this.colGECENGUN,
            this.colAMBAR,
            this.colKOD,
            this.colUNVAN,
            this.colBELGENO,
            this.colOZELKOD,
            this.colSIPARISACIKLAMA,
            this.colSIPARISIOLUSTURANKULLANICI,
            this.colSEVKADRESI,
            this.colILCE,
            this.colSEHIR,
            this.colURUNKOD,
            this.colURUNADI,
            this.colDEPOTOPLAMI,
            this.colSIPARISMIKTARI,
            this.colKARSILANANMIKTAR,
            this.colACIKSIPARIS,
            this.colBIRIM,
            this.colFIYAT,
            this.colDOVIZ,
            this.colVADE});
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
            this.tablo.ViewCaption = "Satış Siparişleri";
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
            // colSIPARISNO
            // 
            this.colSIPARISNO.Caption = "Sipariş No";
            this.colSIPARISNO.FieldName = "SIPARISNO";
            this.colSIPARISNO.Name = "colSIPARISNO";
            this.colSIPARISNO.OptionsColumn.AllowEdit = false;
            this.colSIPARISNO.StatusBarAciklama = null;
            this.colSIPARISNO.StatusBarKisayol = null;
            this.colSIPARISNO.StatusBarKisayolAciklama = null;
            this.colSIPARISNO.Visible = true;
            this.colSIPARISNO.VisibleIndex = 0;
            // 
            // colSIPARISTARIHI
            // 
            this.colSIPARISTARIHI.Caption = "Sipariş Tarihi";
            this.colSIPARISTARIHI.DisplayFormat.FormatString = "dd.MM.yyyy";
            this.colSIPARISTARIHI.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Custom;
            this.colSIPARISTARIHI.FieldName = "SIPARISTARIHI";
            this.colSIPARISTARIHI.Name = "colSIPARISTARIHI";
            this.colSIPARISTARIHI.OptionsColumn.AllowEdit = false;
            this.colSIPARISTARIHI.StatusBarAciklama = null;
            this.colSIPARISTARIHI.StatusBarKisayol = null;
            this.colSIPARISTARIHI.StatusBarKisayolAciklama = null;
            this.colSIPARISTARIHI.Visible = true;
            this.colSIPARISTARIHI.VisibleIndex = 1;
            // 
            // colSEVKTARIHI
            // 
            this.colSEVKTARIHI.Caption = "Sevk Tarihi";
            this.colSEVKTARIHI.DisplayFormat.FormatString = "dd.MM.yyyy";
            this.colSEVKTARIHI.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Custom;
            this.colSEVKTARIHI.FieldName = "SEVKTARIHI";
            this.colSEVKTARIHI.Name = "colSEVKTARIHI";
            this.colSEVKTARIHI.OptionsColumn.AllowEdit = false;
            this.colSEVKTARIHI.StatusBarAciklama = null;
            this.colSEVKTARIHI.StatusBarKisayol = null;
            this.colSEVKTARIHI.StatusBarKisayolAciklama = null;
            this.colSEVKTARIHI.Visible = true;
            this.colSEVKTARIHI.VisibleIndex = 2;
            // 
            // colGECENGUN
            // 
            this.colGECENGUN.Caption = "Geçen Gün";
            this.colGECENGUN.FieldName = "GECENGUN";
            this.colGECENGUN.Name = "colGECENGUN";
            this.colGECENGUN.OptionsColumn.AllowEdit = false;
            this.colGECENGUN.StatusBarAciklama = null;
            this.colGECENGUN.StatusBarKisayol = null;
            this.colGECENGUN.StatusBarKisayolAciklama = null;
            this.colGECENGUN.Visible = true;
            this.colGECENGUN.VisibleIndex = 3;
            // 
            // colAMBAR
            // 
            this.colAMBAR.Caption = "Ambar";
            this.colAMBAR.FieldName = "AMBAR";
            this.colAMBAR.Name = "colAMBAR";
            this.colAMBAR.OptionsColumn.AllowEdit = false;
            this.colAMBAR.StatusBarAciklama = null;
            this.colAMBAR.StatusBarKisayol = null;
            this.colAMBAR.StatusBarKisayolAciklama = null;
            this.colAMBAR.Visible = true;
            this.colAMBAR.VisibleIndex = 4;
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
            this.colKOD.VisibleIndex = 5;
            // 
            // colUNVAN
            // 
            this.colUNVAN.Caption = "Ünvan";
            this.colUNVAN.FieldName = "UNVAN";
            this.colUNVAN.Name = "colUNVAN";
            this.colUNVAN.OptionsColumn.AllowEdit = false;
            this.colUNVAN.StatusBarAciklama = null;
            this.colUNVAN.StatusBarKisayol = null;
            this.colUNVAN.StatusBarKisayolAciklama = null;
            this.colUNVAN.Visible = true;
            this.colUNVAN.VisibleIndex = 6;
            // 
            // colBELGENO
            // 
            this.colBELGENO.Caption = "Belge No";
            this.colBELGENO.FieldName = "BELGENO";
            this.colBELGENO.Name = "colBELGENO";
            this.colBELGENO.OptionsColumn.AllowEdit = false;
            this.colBELGENO.StatusBarAciklama = null;
            this.colBELGENO.StatusBarKisayol = null;
            this.colBELGENO.StatusBarKisayolAciklama = null;
            this.colBELGENO.Visible = true;
            this.colBELGENO.VisibleIndex = 7;
            // 
            // colOZELKOD
            // 
            this.colOZELKOD.Caption = "Özel Kod";
            this.colOZELKOD.FieldName = "OZELKOD";
            this.colOZELKOD.Name = "colOZELKOD";
            this.colOZELKOD.OptionsColumn.AllowEdit = false;
            this.colOZELKOD.StatusBarAciklama = null;
            this.colOZELKOD.StatusBarKisayol = null;
            this.colOZELKOD.StatusBarKisayolAciklama = null;
            this.colOZELKOD.Visible = true;
            this.colOZELKOD.VisibleIndex = 8;
            // 
            // colSIPARISACIKLAMA
            // 
            this.colSIPARISACIKLAMA.Caption = "Sipariş Açıklama";
            this.colSIPARISACIKLAMA.FieldName = "SIPARISACIKLAMA";
            this.colSIPARISACIKLAMA.Name = "colSIPARISACIKLAMA";
            this.colSIPARISACIKLAMA.OptionsColumn.AllowEdit = false;
            this.colSIPARISACIKLAMA.StatusBarAciklama = null;
            this.colSIPARISACIKLAMA.StatusBarKisayol = null;
            this.colSIPARISACIKLAMA.StatusBarKisayolAciklama = null;
            this.colSIPARISACIKLAMA.Visible = true;
            this.colSIPARISACIKLAMA.VisibleIndex = 9;
            // 
            // colSIPARISIOLUSTURANKULLANICI
            // 
            this.colSIPARISIOLUSTURANKULLANICI.Caption = "Siparişi Oluşturan Kullanıcı";
            this.colSIPARISIOLUSTURANKULLANICI.FieldName = "colSIPARISIOLUSTURANKULLANICI";
            this.colSIPARISIOLUSTURANKULLANICI.Name = "colSIPARISIOLUSTURANKULLANICI";
            this.colSIPARISIOLUSTURANKULLANICI.OptionsColumn.AllowEdit = false;
            this.colSIPARISIOLUSTURANKULLANICI.StatusBarAciklama = null;
            this.colSIPARISIOLUSTURANKULLANICI.StatusBarKisayol = null;
            this.colSIPARISIOLUSTURANKULLANICI.StatusBarKisayolAciklama = null;
            this.colSIPARISIOLUSTURANKULLANICI.Visible = true;
            this.colSIPARISIOLUSTURANKULLANICI.VisibleIndex = 10;
            // 
            // colSEVKADRESI
            // 
            this.colSEVKADRESI.Caption = "Sevk Adresi";
            this.colSEVKADRESI.FieldName = "SEVKADRESI";
            this.colSEVKADRESI.Name = "colSEVKADRESI";
            this.colSEVKADRESI.OptionsColumn.AllowEdit = false;
            this.colSEVKADRESI.StatusBarAciklama = null;
            this.colSEVKADRESI.StatusBarKisayol = null;
            this.colSEVKADRESI.StatusBarKisayolAciklama = null;
            this.colSEVKADRESI.Visible = true;
            this.colSEVKADRESI.VisibleIndex = 11;
            // 
            // colILCE
            // 
            this.colILCE.Caption = "İlçe";
            this.colILCE.FieldName = "ILCE";
            this.colILCE.Name = "colILCE";
            this.colILCE.OptionsColumn.AllowEdit = false;
            this.colILCE.StatusBarAciklama = null;
            this.colILCE.StatusBarKisayol = null;
            this.colILCE.StatusBarKisayolAciklama = null;
            this.colILCE.Visible = true;
            this.colILCE.VisibleIndex = 12;
            // 
            // colSEHIR
            // 
            this.colSEHIR.Caption = "İl";
            this.colSEHIR.FieldName = "SEHIR";
            this.colSEHIR.Name = "colSEHIR";
            this.colSEHIR.OptionsColumn.AllowEdit = false;
            this.colSEHIR.StatusBarAciklama = null;
            this.colSEHIR.StatusBarKisayol = null;
            this.colSEHIR.StatusBarKisayolAciklama = null;
            this.colSEHIR.Visible = true;
            this.colSEHIR.VisibleIndex = 13;
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
            this.colURUNKOD.VisibleIndex = 14;
            // 
            // colURUNADI
            // 
            this.colURUNADI.Caption = "Ürün Adı";
            this.colURUNADI.FieldName = "URUNADI";
            this.colURUNADI.Name = "colURUNADI";
            this.colURUNADI.OptionsColumn.AllowEdit = false;
            this.colURUNADI.StatusBarAciklama = null;
            this.colURUNADI.StatusBarKisayol = null;
            this.colURUNADI.StatusBarKisayolAciklama = null;
            this.colURUNADI.Visible = true;
            this.colURUNADI.VisibleIndex = 15;
            // 
            // colDEPOTOPLAMI
            // 
            this.colDEPOTOPLAMI.Caption = "Depo Toplamı";
            this.colDEPOTOPLAMI.FieldName = "DEPOTOPLAMI";
            this.colDEPOTOPLAMI.Name = "colDEPOTOPLAMI";
            this.colDEPOTOPLAMI.OptionsColumn.AllowEdit = false;
            this.colDEPOTOPLAMI.StatusBarAciklama = null;
            this.colDEPOTOPLAMI.StatusBarKisayol = null;
            this.colDEPOTOPLAMI.StatusBarKisayolAciklama = null;
            this.colDEPOTOPLAMI.Visible = true;
            this.colDEPOTOPLAMI.VisibleIndex = 16;
            // 
            // colSIPARISMIKTARI
            // 
            this.colSIPARISMIKTARI.Caption = "Sipariş Miktarı";
            this.colSIPARISMIKTARI.FieldName = "SIPARISMIKTARI";
            this.colSIPARISMIKTARI.Name = "colSIPARISMIKTARI";
            this.colSIPARISMIKTARI.OptionsColumn.AllowEdit = false;
            this.colSIPARISMIKTARI.StatusBarAciklama = null;
            this.colSIPARISMIKTARI.StatusBarKisayol = null;
            this.colSIPARISMIKTARI.StatusBarKisayolAciklama = null;
            this.colSIPARISMIKTARI.Visible = true;
            this.colSIPARISMIKTARI.VisibleIndex = 17;
            // 
            // colKARSILANANMIKTAR
            // 
            this.colKARSILANANMIKTAR.Caption = "Karşılanan Miktar";
            this.colKARSILANANMIKTAR.FieldName = "KARSILANANMIKTAR";
            this.colKARSILANANMIKTAR.Name = "colKARSILANANMIKTAR";
            this.colKARSILANANMIKTAR.OptionsColumn.AllowEdit = false;
            this.colKARSILANANMIKTAR.StatusBarAciklama = null;
            this.colKARSILANANMIKTAR.StatusBarKisayol = null;
            this.colKARSILANANMIKTAR.StatusBarKisayolAciklama = null;
            this.colKARSILANANMIKTAR.Visible = true;
            this.colKARSILANANMIKTAR.VisibleIndex = 18;
            // 
            // colACIKSIPARIS
            // 
            this.colACIKSIPARIS.Caption = "Açık Sipariş";
            this.colACIKSIPARIS.FieldName = "ACIKSIPARIS";
            this.colACIKSIPARIS.Name = "colACIKSIPARIS";
            this.colACIKSIPARIS.OptionsColumn.AllowEdit = false;
            this.colACIKSIPARIS.StatusBarAciklama = null;
            this.colACIKSIPARIS.StatusBarKisayol = null;
            this.colACIKSIPARIS.StatusBarKisayolAciklama = null;
            this.colACIKSIPARIS.Visible = true;
            this.colACIKSIPARIS.VisibleIndex = 19;
            // 
            // colBIRIM
            // 
            this.colBIRIM.Caption = "Birim";
            this.colBIRIM.FieldName = "BIRIM";
            this.colBIRIM.Name = "colBIRIM";
            this.colBIRIM.OptionsColumn.AllowEdit = false;
            this.colBIRIM.StatusBarAciklama = null;
            this.colBIRIM.StatusBarKisayol = null;
            this.colBIRIM.StatusBarKisayolAciklama = null;
            this.colBIRIM.Visible = true;
            this.colBIRIM.VisibleIndex = 20;
            // 
            // colFIYAT
            // 
            this.colFIYAT.Caption = "Fiyat";
            this.colFIYAT.FieldName = "FIYAT";
            this.colFIYAT.Name = "colFIYAT";
            this.colFIYAT.OptionsColumn.AllowEdit = false;
            this.colFIYAT.StatusBarAciklama = null;
            this.colFIYAT.StatusBarKisayol = null;
            this.colFIYAT.StatusBarKisayolAciklama = null;
            this.colFIYAT.Visible = true;
            this.colFIYAT.VisibleIndex = 21;
            // 
            // colDOVIZ
            // 
            this.colDOVIZ.Caption = "Döviz";
            this.colDOVIZ.FieldName = "DOVIZ";
            this.colDOVIZ.Name = "colDOVIZ";
            this.colDOVIZ.OptionsColumn.AllowEdit = false;
            this.colDOVIZ.StatusBarAciklama = null;
            this.colDOVIZ.StatusBarKisayol = null;
            this.colDOVIZ.StatusBarKisayolAciklama = null;
            this.colDOVIZ.Visible = true;
            this.colDOVIZ.VisibleIndex = 22;
            // 
            // colVADE
            // 
            this.colVADE.Caption = "Vade";
            this.colVADE.FieldName = "VADE";
            this.colVADE.Name = "colVADE";
            this.colVADE.OptionsColumn.AllowEdit = false;
            this.colVADE.StatusBarAciklama = null;
            this.colVADE.StatusBarKisayol = null;
            this.colVADE.StatusBarKisayolAciklama = null;
            this.colVADE.Visible = true;
            this.colVADE.VisibleIndex = 23;
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
            // AcikSatisSiparisleri
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1134, 501);
            this.Controls.Add(this.myDataLayoutControl1);
            this.IconOptions.ShowIcon = false;
            this.Name = "AcikSatisSiparisleri";
            this.Tag = "TarihCariStokIsyeriDoviz";
            this.Text = "Satış Siparişleri";
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
        private UserControls.Controls.Grid.MyGridColumn colSIPARISNO;
        private UserControls.Controls.Grid.MyGridColumn colSIPARISTARIHI;
        private UserControls.Controls.Grid.MyGridColumn colSEVKTARIHI;
        private UserControls.Controls.Grid.MyGridColumn colGECENGUN;
        private UserControls.Controls.Grid.MyGridColumn colAMBAR;
        private UserControls.Controls.Grid.MyGridColumn colKOD;
        private UserControls.Controls.Grid.MyGridColumn colUNVAN;
        private UserControls.Controls.Grid.MyGridColumn colBELGENO;
        private UserControls.Controls.Grid.MyGridColumn colOZELKOD;
        private UserControls.Controls.Grid.MyGridColumn colSIPARISACIKLAMA;
        private UserControls.Controls.Grid.MyGridColumn colSIPARISIOLUSTURANKULLANICI;
        private UserControls.Controls.Grid.MyGridColumn colSEVKADRESI;
        private UserControls.Controls.Grid.MyGridColumn colILCE;
        private UserControls.Controls.Grid.MyGridColumn colSEHIR;
        private UserControls.Controls.Grid.MyGridColumn colURUNKOD;
        private UserControls.Controls.Grid.MyGridColumn colURUNADI;
        private UserControls.Controls.Grid.MyGridColumn colDEPOTOPLAMI;
        private UserControls.Controls.Grid.MyGridColumn colSIPARISMIKTARI;
        private UserControls.Controls.Grid.MyGridColumn colKARSILANANMIKTAR;
        private UserControls.Controls.Grid.MyGridColumn colACIKSIPARIS;
        private UserControls.Controls.Grid.MyGridColumn colBIRIM;
        private UserControls.Controls.Grid.MyGridColumn colFIYAT;
        private UserControls.Controls.Grid.MyGridColumn colDOVIZ;
        private UserControls.Controls.Grid.MyGridColumn colVADE;
    }
}