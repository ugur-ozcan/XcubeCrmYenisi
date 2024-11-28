namespace XCubeCrm.UI.Win.GenelForms
{
    partial class GirisForms
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
            this.components = new System.ComponentModel.Container();
            this.txtKullaniciAdi = new DevExpress.XtraEditors.TextEdit();
            this.txtParola = new DevExpress.XtraEditors.TextEdit();
            this.btnGiris = new DevExpress.XtraEditors.SimpleButton();
            this.btnVazgec = new DevExpress.XtraEditors.SimpleButton();
            this.lblSonGuncellemeTarihi = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.lblBilgisayar = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.lblIpAdresi = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.lblsonYenidenBaslama = new System.Windows.Forms.Label();
            this.pictureBox2 = new System.Windows.Forms.PictureBox();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.label8 = new System.Windows.Forms.Label();
            this.lblCapsLockStatus = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.tglBeniAnimsa = new DevExpress.XtraEditors.ToggleSwitch();
            this.label10 = new System.Windows.Forms.Label();
            this.cmbFirma = new DevExpress.XtraEditors.GridLookUpEdit();
            this.grdFirma = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.colFirmaNo = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colDonem = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colFirmaAdi = new DevExpress.XtraGrid.Columns.GridColumn();
            this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.varsayılanFirmaYapToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.colLOGICALREF = new DevExpress.XtraGrid.Columns.GridColumn();
            ((System.ComponentModel.ISupportInitialize)(this.txtKullaniciAdi.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtParola.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tglBeniAnimsa.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cmbFirma.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.grdFirma)).BeginInit();
            this.contextMenuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // txtKullaniciAdi
            // 
            this.txtKullaniciAdi.EditValue = "";
            this.txtKullaniciAdi.Location = new System.Drawing.Point(237, 120);
            this.txtKullaniciAdi.Margin = new System.Windows.Forms.Padding(2);
            this.txtKullaniciAdi.Name = "txtKullaniciAdi";
            this.txtKullaniciAdi.Size = new System.Drawing.Size(269, 20);
            this.txtKullaniciAdi.TabIndex = 0;
            this.txtKullaniciAdi.KeyUp += new System.Windows.Forms.KeyEventHandler(this.txtKullaniciAdi_KeyUp);
            // 
            // txtParola
            // 
            this.txtParola.EditValue = "";
            this.txtParola.Location = new System.Drawing.Point(237, 171);
            this.txtParola.Margin = new System.Windows.Forms.Padding(2);
            this.txtParola.Name = "txtParola";
            this.txtParola.Properties.Mask.UseMaskAsDisplayFormat = true;
            this.txtParola.Properties.MaskSettings.Set("mask", "*");
            this.txtParola.Properties.PasswordChar = '*';
            this.txtParola.Size = new System.Drawing.Size(269, 20);
            this.txtParola.TabIndex = 1;
            this.txtParola.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtParola_KeyDown);
            this.txtParola.KeyUp += new System.Windows.Forms.KeyEventHandler(this.txtParola_KeyUp);
            // 
            // btnGiris
            // 
            this.btnGiris.Appearance.Font = new System.Drawing.Font("Tahoma", 7.8F, System.Drawing.FontStyle.Bold);
            this.btnGiris.Appearance.Options.UseFont = true;
            this.btnGiris.Location = new System.Drawing.Point(239, 271);
            this.btnGiris.Margin = new System.Windows.Forms.Padding(2);
            this.btnGiris.Name = "btnGiris";
            this.btnGiris.Size = new System.Drawing.Size(131, 24);
            this.btnGiris.TabIndex = 4;
            this.btnGiris.Text = "Giriş";
            this.btnGiris.Click += new System.EventHandler(this.btnGiris_Click);
            // 
            // btnVazgec
            // 
            this.btnVazgec.Appearance.Font = new System.Drawing.Font("Tahoma", 7.8F, System.Drawing.FontStyle.Bold);
            this.btnVazgec.Appearance.Options.UseFont = true;
            this.btnVazgec.Location = new System.Drawing.Point(375, 271);
            this.btnVazgec.Margin = new System.Windows.Forms.Padding(2);
            this.btnVazgec.Name = "btnVazgec";
            this.btnVazgec.Size = new System.Drawing.Size(131, 24);
            this.btnVazgec.TabIndex = 5;
            this.btnVazgec.Text = "Vazgeç";
            this.btnVazgec.Click += new System.EventHandler(this.btnVazgec_Click);
            // 
            // lblSonGuncellemeTarihi
            // 
            this.lblSonGuncellemeTarihi.AutoSize = true;
            this.lblSonGuncellemeTarihi.BackColor = System.Drawing.Color.LightBlue;
            this.lblSonGuncellemeTarihi.Font = new System.Drawing.Font("Century Gothic", 8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblSonGuncellemeTarihi.Location = new System.Drawing.Point(0, 29);
            this.lblSonGuncellemeTarihi.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblSonGuncellemeTarihi.Name = "lblSonGuncellemeTarihi";
            this.lblSonGuncellemeTarihi.Size = new System.Drawing.Size(40, 15);
            this.lblSonGuncellemeTarihi.TabIndex = 6;
            this.lblSonGuncellemeTarihi.Text = "label2";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.BackColor = System.Drawing.Color.LightBlue;
            this.label2.Font = new System.Drawing.Font("Century Gothic", 8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(0, 11);
            this.label2.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(102, 15);
            this.label2.TabIndex = 7;
            this.label2.Text = "Son Güncelleme: ";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.BackColor = System.Drawing.Color.LightBlue;
            this.label3.Font = new System.Drawing.Font("Century Gothic", 8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(0, 58);
            this.label3.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(65, 15);
            this.label3.TabIndex = 9;
            this.label3.Text = "Bilgisayar: ";
            // 
            // lblBilgisayar
            // 
            this.lblBilgisayar.AutoSize = true;
            this.lblBilgisayar.BackColor = System.Drawing.Color.LightBlue;
            this.lblBilgisayar.Font = new System.Drawing.Font("Century Gothic", 8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblBilgisayar.Location = new System.Drawing.Point(-1, 77);
            this.lblBilgisayar.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblBilgisayar.Name = "lblBilgisayar";
            this.lblBilgisayar.Size = new System.Drawing.Size(93, 15);
            this.lblBilgisayar.TabIndex = 8;
            this.lblBilgisayar.Text = "Bilgisayar Bilgisi";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.BackColor = System.Drawing.Color.LightBlue;
            this.label4.Font = new System.Drawing.Font("Century Gothic", 8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(-1, 106);
            this.label4.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(59, 15);
            this.label4.TabIndex = 11;
            this.label4.Text = "İp Adresi: ";
            // 
            // lblIpAdresi
            // 
            this.lblIpAdresi.AutoSize = true;
            this.lblIpAdresi.BackColor = System.Drawing.Color.LightBlue;
            this.lblIpAdresi.Font = new System.Drawing.Font("Century Gothic", 8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblIpAdresi.Location = new System.Drawing.Point(0, 124);
            this.lblIpAdresi.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblIpAdresi.Name = "lblIpAdresi";
            this.lblIpAdresi.Size = new System.Drawing.Size(50, 15);
            this.lblIpAdresi.TabIndex = 10;
            this.lblIpAdresi.Text = "İp Bilgisi";
            // 
            // label5
            // 
            this.label5.BackColor = System.Drawing.Color.LightBlue;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 32F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.ForeColor = System.Drawing.SystemColors.ButtonFace;
            this.label5.Location = new System.Drawing.Point(0, -5);
            this.label5.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(203, 377);
            this.label5.TabIndex = 12;
            this.label5.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(237, 152);
            this.label6.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(37, 13);
            this.label6.TabIndex = 13;
            this.label6.Text = "Parola";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(237, 99);
            this.label7.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(64, 13);
            this.label7.TabIndex = 14;
            this.label7.Text = "Kullanıcı Adı";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.LightBlue;
            this.label1.Font = new System.Drawing.Font("Century Gothic", 8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(-2, 152);
            this.label1.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(145, 15);
            this.label1.TabIndex = 16;
            this.label1.Text = "En Son Yeniden Başlatma:";
            // 
            // lblsonYenidenBaslama
            // 
            this.lblsonYenidenBaslama.AutoSize = true;
            this.lblsonYenidenBaslama.BackColor = System.Drawing.Color.LightBlue;
            this.lblsonYenidenBaslama.Font = new System.Drawing.Font("Century Gothic", 8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblsonYenidenBaslama.Location = new System.Drawing.Point(-1, 171);
            this.lblsonYenidenBaslama.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblsonYenidenBaslama.Name = "lblsonYenidenBaslama";
            this.lblsonYenidenBaslama.Size = new System.Drawing.Size(176, 15);
            this.lblsonYenidenBaslama.TabIndex = 15;
            this.lblsonYenidenBaslama.Text = "En Son Yeniden Başlatma Bilgisi";
            // 
            // pictureBox2
            // 
            this.pictureBox2.BackColor = System.Drawing.Color.LightBlue;
            this.pictureBox2.Image = global::XCubeCrm.UI.Win.Properties.Resources.XCubeLogo;
            this.pictureBox2.Location = new System.Drawing.Point(66, 211);
            this.pictureBox2.Margin = new System.Windows.Forms.Padding(2);
            this.pictureBox2.Name = "pictureBox2";
            this.pictureBox2.Size = new System.Drawing.Size(70, 70);
            this.pictureBox2.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox2.TabIndex = 17;
            this.pictureBox2.TabStop = false;
            this.pictureBox2.Click += new System.EventHandler(this.pictureBox2_Click);
            // 
            // pictureBox1
            // 
            this.pictureBox1.BackColor = System.Drawing.Color.Transparent;
            this.pictureBox1.Location = new System.Drawing.Point(287, 15);
            this.pictureBox1.Margin = new System.Windows.Forms.Padding(2);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(140, 58);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox1.TabIndex = 0;
            this.pictureBox1.TabStop = false;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.BackColor = System.Drawing.Color.LightBlue;
            this.label8.Font = new System.Drawing.Font("Gill Sans MT", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.ForeColor = System.Drawing.Color.DarkGreen;
            this.label8.Location = new System.Drawing.Point(67, 283);
            this.label8.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(69, 23);
            this.label8.TabIndex = 18;
            this.label8.Text = "XCUBE";
            this.label8.DoubleClick += new System.EventHandler(this.label8_DoubleClick);
            // 
            // lblCapsLockStatus
            // 
            this.lblCapsLockStatus.AutoSize = true;
            this.lblCapsLockStatus.Location = new System.Drawing.Point(235, 201);
            this.lblCapsLockStatus.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblCapsLockStatus.Name = "lblCapsLockStatus";
            this.lblCapsLockStatus.Size = new System.Drawing.Size(0, 13);
            this.lblCapsLockStatus.TabIndex = 8;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(423, 316);
            this.label9.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(35, 13);
            this.label9.TabIndex = 19;
            this.label9.Text = "label9";
            // 
            // tglBeniAnimsa
            // 
            this.tglBeniAnimsa.Location = new System.Drawing.Point(388, 236);
            this.tglBeniAnimsa.Margin = new System.Windows.Forms.Padding(2);
            this.tglBeniAnimsa.Name = "tglBeniAnimsa";
            this.tglBeniAnimsa.Properties.OffText = "Unut";
            this.tglBeniAnimsa.Properties.OnText = "Beni Anımsa";
            this.tglBeniAnimsa.Size = new System.Drawing.Size(118, 18);
            this.tglBeniAnimsa.TabIndex = 3;
            this.tglBeniAnimsa.Toggled += new System.EventHandler(this.toggleSwitch1_Toggled);
            this.tglBeniAnimsa.Click += new System.EventHandler(this.toggleSwitch1_Click);
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(239, 195);
            this.label10.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(69, 13);
            this.label10.TabIndex = 22;
            this.label10.Text = "Firma Seçiniz";
            // 
            // cmbFirma
            // 
            this.cmbFirma.Location = new System.Drawing.Point(238, 211);
            this.cmbFirma.Name = "cmbFirma";
            this.cmbFirma.Properties.Appearance.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
            this.cmbFirma.Properties.Appearance.Options.UseFont = true;
            this.cmbFirma.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.cmbFirma.Properties.NullText = "Seçim Yapınız";
            this.cmbFirma.Properties.NullValuePrompt = "Seçim Yapınız";
            this.cmbFirma.Properties.PopupView = this.grdFirma;
            this.cmbFirma.Size = new System.Drawing.Size(268, 20);
            this.cmbFirma.TabIndex = 24;
            this.cmbFirma.CloseUp += new DevExpress.XtraEditors.Controls.CloseUpEventHandler(this.cmbFirma_CloseUp);
            // 
            // grdFirma
            // 
            this.grdFirma.Appearance.EvenRow.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.grdFirma.Appearance.EvenRow.Options.UseBackColor = true;
            this.grdFirma.Appearance.HideSelectionRow.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
            this.grdFirma.Appearance.HideSelectionRow.Options.UseFont = true;
            this.grdFirma.Appearance.SelectedRow.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
            this.grdFirma.Appearance.SelectedRow.Options.UseFont = true;
            this.grdFirma.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.colFirmaNo,
            this.colDonem,
            this.colFirmaAdi,
            this.colLOGICALREF});
            this.grdFirma.FocusRectStyle = DevExpress.XtraGrid.Views.Grid.DrawFocusRectStyle.RowFocus;
            this.grdFirma.Name = "grdFirma";
            this.grdFirma.OptionsBehavior.Editable = false;
            this.grdFirma.OptionsBehavior.HyperlinkClickMode = DevExpress.Utils.Drawing.HyperlinkClickMode.None;
            this.grdFirma.OptionsBehavior.KeepGroupExpandedOnSorting = false;
            this.grdFirma.OptionsEditForm.ShowOnDoubleClick = DevExpress.Utils.DefaultBoolean.False;
            this.grdFirma.OptionsFind.ShowCloseButton = false;
            this.grdFirma.OptionsHint.ShowCellHints = false;
            this.grdFirma.OptionsSelection.EnableAppearanceFocusedCell = false;
            this.grdFirma.OptionsSelection.EnableAppearanceHotTrackedRow = DevExpress.Utils.DefaultBoolean.False;
            this.grdFirma.OptionsSelection.UseIndicatorForSelection = false;
            this.grdFirma.OptionsView.EnableAppearanceEvenRow = true;
            this.grdFirma.OptionsView.ShowAutoFilterRow = true;
            this.grdFirma.OptionsView.ShowGroupPanel = false;
            this.grdFirma.OptionsView.ShowIndicator = false;
            // 
            // colFirmaNo
            // 
            this.colFirmaNo.Caption = "FirmaNo";
            this.colFirmaNo.FieldName = "FIRMANO";
            this.colFirmaNo.Name = "colFirmaNo";
            this.colFirmaNo.Visible = true;
            this.colFirmaNo.VisibleIndex = 0;
            this.colFirmaNo.Width = 63;
            // 
            // colDonem
            // 
            this.colDonem.Caption = "Dönem";
            this.colDonem.FieldName = "DONEM";
            this.colDonem.Name = "colDonem";
            this.colDonem.Visible = true;
            this.colDonem.VisibleIndex = 1;
            this.colDonem.Width = 39;
            // 
            // colFirmaAdi
            // 
            this.colFirmaAdi.Caption = "Firma";
            this.colFirmaAdi.FieldName = "FIRMA";
            this.colFirmaAdi.Name = "colFirmaAdi";
            this.colFirmaAdi.Visible = true;
            this.colFirmaAdi.VisibleIndex = 2;
            this.colFirmaAdi.Width = 742;
            // 
            // contextMenuStrip1
            // 
            this.contextMenuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.varsayılanFirmaYapToolStripMenuItem});
            this.contextMenuStrip1.Name = "contextMenuStrip1";
            this.contextMenuStrip1.Size = new System.Drawing.Size(182, 26);
            // 
            // varsayılanFirmaYapToolStripMenuItem
            // 
            this.varsayılanFirmaYapToolStripMenuItem.Name = "varsayılanFirmaYapToolStripMenuItem";
            this.varsayılanFirmaYapToolStripMenuItem.Size = new System.Drawing.Size(181, 22);
            this.varsayılanFirmaYapToolStripMenuItem.Text = "Varsayılan Firma Yap";
            // 
            // colLOGICALREF
            // 
            this.colLOGICALREF.Caption = "gridColumn1";
            this.colLOGICALREF.FieldName = "LOGICALREF";
            this.colLOGICALREF.Name = "colLOGICALREF";
            // 
            // GirisForms
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Beige;
            this.ClientSize = new System.Drawing.Size(524, 332);
            this.Controls.Add(this.cmbFirma);
            this.Controls.Add(this.label10);
            this.Controls.Add(this.tglBeniAnimsa);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.lblCapsLockStatus);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.pictureBox2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.lblsonYenidenBaslama);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.lblIpAdresi);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.lblBilgisayar);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.lblSonGuncellemeTarihi);
            this.Controls.Add(this.btnVazgec);
            this.Controls.Add(this.btnGiris);
            this.Controls.Add(this.txtParola);
            this.Controls.Add(this.txtKullaniciAdi);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.label5);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Margin = new System.Windows.Forms.Padding(2);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "GirisForms";
            this.Opacity = 0.9D;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Kullanıcı Girişi";
            this.Load += new System.EventHandler(this.frmGiris_Load);
            this.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.frmGiris_KeyPress);
            this.MouseDown += new System.Windows.Forms.MouseEventHandler(this.frmGiris_MouseDown);
            this.MouseMove += new System.Windows.Forms.MouseEventHandler(this.frmGiris_MouseMove);
            this.MouseUp += new System.Windows.Forms.MouseEventHandler(this.frmGiris_MouseUp);
            ((System.ComponentModel.ISupportInitialize)(this.txtKullaniciAdi.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtParola.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tglBeniAnimsa.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cmbFirma.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.grdFirma)).EndInit();
            this.contextMenuStrip1.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private DevExpress.XtraEditors.TextEdit txtKullaniciAdi;
        private DevExpress.XtraEditors.TextEdit txtParola;
        private DevExpress.XtraEditors.SimpleButton btnGiris;
        private DevExpress.XtraEditors.SimpleButton btnVazgec;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Label lblSonGuncellemeTarihi;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label lblBilgisayar;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label lblIpAdresi;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label lblsonYenidenBaslama;
        private System.Windows.Forms.PictureBox pictureBox2;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label lblCapsLockStatus;
        private System.Windows.Forms.Label label9;
        private DevExpress.XtraEditors.ToggleSwitch tglBeniAnimsa;
        private System.Windows.Forms.Label label10;
        private DevExpress.XtraEditors.GridLookUpEdit cmbFirma;
        private DevExpress.XtraGrid.Views.Grid.GridView grdFirma;
        private DevExpress.XtraGrid.Columns.GridColumn colFirmaNo;
        private DevExpress.XtraGrid.Columns.GridColumn colDonem;
        private DevExpress.XtraGrid.Columns.GridColumn colFirmaAdi;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip1;
        private System.Windows.Forms.ToolStripMenuItem varsayılanFirmaYapToolStripMenuItem;
        private DevExpress.XtraGrid.Columns.GridColumn colLOGICALREF;
    }
}