namespace XCubeCrm.UI.Win.Forms.UserControls.Controls.Navigators
{
    partial class SmallNavigator
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(SmallNavigator));
            this.imageCollection = new DevExpress.Utils.ImageCollection(this.components);
            this.Navigator = new DevExpress.XtraEditors.ControlNavigator();
            ((System.ComponentModel.ISupportInitialize)(this.imageCollection)).BeginInit();
            this.SuspendLayout();
            // 
            // imageCollection
            // 
            this.imageCollection.ImageStream = ((DevExpress.Utils.ImageCollectionStreamer)(resources.GetObject("imageCollection.ImageStream")));
            this.imageCollection.InsertImage(global::XCubeCrm.UI.Win.Properties.Resources.first_32x32, "first_32x32", typeof(global::XCubeCrm.UI.Win.Properties.Resources), 0);
            this.imageCollection.Images.SetKeyName(0, "first_32x32");
            this.imageCollection.InsertImage(global::XCubeCrm.UI.Win.Properties.Resources.prev_32x32, "prev_32x32", typeof(global::XCubeCrm.UI.Win.Properties.Resources), 1);
            this.imageCollection.Images.SetKeyName(1, "prev_32x32");
            this.imageCollection.InsertImage(global::XCubeCrm.UI.Win.Properties.Resources.next_32x32, "next_32x32", typeof(global::XCubeCrm.UI.Win.Properties.Resources), 2);
            this.imageCollection.Images.SetKeyName(2, "next_32x32");
            this.imageCollection.InsertImage(global::XCubeCrm.UI.Win.Properties.Resources.last_32x32, "last_32x32", typeof(global::XCubeCrm.UI.Win.Properties.Resources), 3);
            this.imageCollection.Images.SetKeyName(3, "last_32x32");
            // 
            // Navigator
            // 
            this.Navigator.Appearance.Font = new System.Drawing.Font("Tahoma", 7.8F, System.Drawing.FontStyle.Bold);
            this.Navigator.Appearance.ForeColor = System.Drawing.SystemColors.HotTrack;
            this.Navigator.Appearance.Options.UseFont = true;
            this.Navigator.Appearance.Options.UseForeColor = true;
            this.Navigator.Buttons.Append.Visible = false;
            this.Navigator.Buttons.CancelEdit.Visible = false;
            this.Navigator.Buttons.Edit.Visible = false;
            this.Navigator.Buttons.EndEdit.Visible = false;
            this.Navigator.Buttons.First.ImageIndex = 0;
            this.Navigator.Buttons.Last.ImageIndex = 5;
            this.Navigator.Buttons.Next.ImageIndex = 3;
            this.Navigator.Buttons.NextPage.ImageIndex = 4;
            this.Navigator.Buttons.NextPage.Visible = false;
            this.Navigator.Buttons.Prev.ImageIndex = 2;
            this.Navigator.Buttons.PrevPage.ImageIndex = 1;
            this.Navigator.Buttons.PrevPage.Visible = false;
            this.Navigator.Buttons.Remove.Visible = false;
            this.Navigator.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.Navigator.Location = new System.Drawing.Point(0, 2);
            this.Navigator.Name = "Navigator";
            this.Navigator.Size = new System.Drawing.Size(300, 24);
            this.Navigator.TabIndex = 1;
            this.Navigator.Text = "controlNavigator1";
            this.Navigator.TextLocation = DevExpress.XtraEditors.NavigatorButtonsTextLocation.Begin;
            this.Navigator.TextStringFormat = "Kayıtlar ({0}/{1})";
            // 
            // SmallNavigator
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.Navigator);
            this.Name = "SmallNavigator";
            this.Size = new System.Drawing.Size(300, 26);
            ((System.ComponentModel.ISupportInitialize)(this.imageCollection)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.Utils.ImageCollection imageCollection;
        protected internal DevExpress.XtraEditors.ControlNavigator Navigator;
    }
}
