namespace ScrapMeNow
{
    partial class Export_Form
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
            MaterialSkin.Controls.MaterialRaisedButton btnExportCSV;
            MaterialSkin.Controls.MaterialRaisedButton btnExportJSON;
            MaterialSkin.Controls.MaterialRaisedButton btnExportExcel;
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Export_Form));
            this.cbProduction = new MaterialSkin.Controls.MaterialCheckBox();
            this.materialRaisedButton2 = new MaterialSkin.Controls.MaterialRaisedButton();
            this.cbEvents = new MaterialSkin.Controls.MaterialCheckBox();
            this.cbContributions = new MaterialSkin.Controls.MaterialCheckBox();
            this.cbVenue = new MaterialSkin.Controls.MaterialCheckBox();
            this.cbPersons = new MaterialSkin.Controls.MaterialCheckBox();
            this.saveFileDialog = new System.Windows.Forms.SaveFileDialog();
            this.cbOrganizer = new MaterialSkin.Controls.MaterialCheckBox();
            this.txtId = new MaterialSkin.Controls.MaterialSingleLineTextField();
            this.materialLabel1 = new MaterialSkin.Controls.MaterialLabel();
            this.groupBoxTables = new System.Windows.Forms.GroupBox();
            btnExportCSV = new MaterialSkin.Controls.MaterialRaisedButton();
            btnExportJSON = new MaterialSkin.Controls.MaterialRaisedButton();
            btnExportExcel = new MaterialSkin.Controls.MaterialRaisedButton();
            this.groupBoxTables.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnExportCSV
            // 
            btnExportCSV.AllowDrop = true;
            btnExportCSV.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            btnExportCSV.AutoSize = true;
            btnExportCSV.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            btnExportCSV.Depth = 0;
            btnExportCSV.Font = new System.Drawing.Font("Century Gothic", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(161)));
            btnExportCSV.Icon = null;
            btnExportCSV.Location = new System.Drawing.Point(302, 137);
            btnExportCSV.MouseState = MaterialSkin.MouseState.HOVER;
            btnExportCSV.Name = "btnExportCSV";
            btnExportCSV.Primary = true;
            btnExportCSV.Size = new System.Drawing.Size(123, 36);
            btnExportCSV.TabIndex = 3;
            btnExportCSV.Text = "Export to CSV";
            btnExportCSV.UseVisualStyleBackColor = true;
            btnExportCSV.Click += new System.EventHandler(this.materialRaisedButton1_Click);
            // 
            // btnExportJSON
            // 
            btnExportJSON.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            btnExportJSON.AutoSize = true;
            btnExportJSON.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            btnExportJSON.Depth = 0;
            btnExportJSON.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            btnExportJSON.Font = new System.Drawing.Font("Century Gothic", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(161)));
            btnExportJSON.Icon = null;
            btnExportJSON.Location = new System.Drawing.Point(302, 188);
            btnExportJSON.MouseState = MaterialSkin.MouseState.HOVER;
            btnExportJSON.Name = "btnExportJSON";
            btnExportJSON.Primary = true;
            btnExportJSON.Size = new System.Drawing.Size(128, 36);
            btnExportJSON.TabIndex = 7;
            btnExportJSON.Text = "Export in JSON";
            btnExportJSON.UseVisualStyleBackColor = true;
            btnExportJSON.Click += new System.EventHandler(this.btnExportJSON_Click);
            // 
            // btnExportExcel
            // 
            btnExportExcel.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            btnExportExcel.AutoSize = true;
            btnExportExcel.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            btnExportExcel.Depth = 0;
            btnExportExcel.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            btnExportExcel.Font = new System.Drawing.Font("Century Gothic", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(161)));
            btnExportExcel.Icon = null;
            btnExportExcel.Location = new System.Drawing.Point(302, 239);
            btnExportExcel.MouseState = MaterialSkin.MouseState.HOVER;
            btnExportExcel.Name = "btnExportExcel";
            btnExportExcel.Primary = true;
            btnExportExcel.Size = new System.Drawing.Size(134, 36);
            btnExportExcel.TabIndex = 8;
            btnExportExcel.Text = "Export in Excel";
            btnExportExcel.UseVisualStyleBackColor = true;
            btnExportExcel.Click += new System.EventHandler(this.btnExportExcel_Click);
            // 
            // cbProduction
            // 
            this.cbProduction.AutoSize = true;
            this.cbProduction.BackColor = System.Drawing.Color.Transparent;
            this.cbProduction.Depth = 0;
            this.cbProduction.Font = new System.Drawing.Font("Roboto", 10F);
            this.cbProduction.Location = new System.Drawing.Point(13, 16);
            this.cbProduction.Margin = new System.Windows.Forms.Padding(0);
            this.cbProduction.MouseLocation = new System.Drawing.Point(-1, -1);
            this.cbProduction.MouseState = MaterialSkin.MouseState.HOVER;
            this.cbProduction.Name = "cbProduction";
            this.cbProduction.Ripple = true;
            this.cbProduction.Size = new System.Drawing.Size(96, 30);
            this.cbProduction.TabIndex = 0;
            this.cbProduction.Text = "production";
            this.cbProduction.UseVisualStyleBackColor = false;
            this.cbProduction.CheckedChanged += new System.EventHandler(this.cbProduction_CheckedChanged);
            // 
            // materialRaisedButton2
            // 
            this.materialRaisedButton2.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.materialRaisedButton2.AutoSize = true;
            this.materialRaisedButton2.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.materialRaisedButton2.Depth = 0;
            this.materialRaisedButton2.Icon = null;
            this.materialRaisedButton2.Location = new System.Drawing.Point(189, 375);
            this.materialRaisedButton2.MouseState = MaterialSkin.MouseState.HOVER;
            this.materialRaisedButton2.Name = "materialRaisedButton2";
            this.materialRaisedButton2.Primary = true;
            this.materialRaisedButton2.Size = new System.Drawing.Size(73, 36);
            this.materialRaisedButton2.TabIndex = 2;
            this.materialRaisedButton2.Text = "Cancel";
            this.materialRaisedButton2.UseVisualStyleBackColor = true;
            this.materialRaisedButton2.Click += new System.EventHandler(this.materialRaisedButton2_Click);
            // 
            // cbEvents
            // 
            this.cbEvents.AutoSize = true;
            this.cbEvents.BackColor = System.Drawing.Color.Transparent;
            this.cbEvents.Depth = 0;
            this.cbEvents.Font = new System.Drawing.Font("Roboto", 10F);
            this.cbEvents.Location = new System.Drawing.Point(13, 251);
            this.cbEvents.Margin = new System.Windows.Forms.Padding(0);
            this.cbEvents.MouseLocation = new System.Drawing.Point(-1, -1);
            this.cbEvents.MouseState = MaterialSkin.MouseState.HOVER;
            this.cbEvents.Name = "cbEvents";
            this.cbEvents.Ripple = true;
            this.cbEvents.Size = new System.Drawing.Size(71, 30);
            this.cbEvents.TabIndex = 4;
            this.cbEvents.Text = "events";
            this.cbEvents.UseVisualStyleBackColor = false;
            this.cbEvents.CheckedChanged += new System.EventHandler(this.cbEvents_CheckedChanged);
            // 
            // cbContributions
            // 
            this.cbContributions.AutoSize = true;
            this.cbContributions.BackColor = System.Drawing.Color.Transparent;
            this.cbContributions.Depth = 0;
            this.cbContributions.Font = new System.Drawing.Font("Roboto", 10F);
            this.cbContributions.Location = new System.Drawing.Point(13, 61);
            this.cbContributions.Margin = new System.Windows.Forms.Padding(0);
            this.cbContributions.MouseLocation = new System.Drawing.Point(-1, -1);
            this.cbContributions.MouseState = MaterialSkin.MouseState.HOVER;
            this.cbContributions.Name = "cbContributions";
            this.cbContributions.Ripple = true;
            this.cbContributions.Size = new System.Drawing.Size(111, 30);
            this.cbContributions.TabIndex = 5;
            this.cbContributions.Text = "contributions";
            this.cbContributions.UseVisualStyleBackColor = false;
            this.cbContributions.CheckedChanged += new System.EventHandler(this.cbContributions_CheckedChanged);
            // 
            // cbVenue
            // 
            this.cbVenue.AutoSize = true;
            this.cbVenue.BackColor = System.Drawing.Color.Transparent;
            this.cbVenue.Depth = 0;
            this.cbVenue.Font = new System.Drawing.Font("Roboto", 10F);
            this.cbVenue.Location = new System.Drawing.Point(12, 109);
            this.cbVenue.Margin = new System.Windows.Forms.Padding(0);
            this.cbVenue.MouseLocation = new System.Drawing.Point(-1, -1);
            this.cbVenue.MouseState = MaterialSkin.MouseState.HOVER;
            this.cbVenue.Name = "cbVenue";
            this.cbVenue.Ripple = true;
            this.cbVenue.Size = new System.Drawing.Size(67, 30);
            this.cbVenue.TabIndex = 6;
            this.cbVenue.Text = "venue";
            this.cbVenue.UseVisualStyleBackColor = false;
            this.cbVenue.CheckedChanged += new System.EventHandler(this.cbVenue_CheckedChanged);
            // 
            // cbPersons
            // 
            this.cbPersons.AutoSize = true;
            this.cbPersons.BackColor = System.Drawing.Color.Transparent;
            this.cbPersons.Depth = 0;
            this.cbPersons.Font = new System.Drawing.Font("Roboto", 10F);
            this.cbPersons.Location = new System.Drawing.Point(13, 159);
            this.cbPersons.Margin = new System.Windows.Forms.Padding(0);
            this.cbPersons.MouseLocation = new System.Drawing.Point(-1, -1);
            this.cbPersons.MouseState = MaterialSkin.MouseState.HOVER;
            this.cbPersons.Name = "cbPersons";
            this.cbPersons.Ripple = true;
            this.cbPersons.Size = new System.Drawing.Size(80, 30);
            this.cbPersons.TabIndex = 6;
            this.cbPersons.Text = "persons";
            this.cbPersons.UseVisualStyleBackColor = false;
            this.cbPersons.CheckedChanged += new System.EventHandler(this.cbPersons_CheckedChanged);
            // 
            // cbOrganizer
            // 
            this.cbOrganizer.AutoSize = true;
            this.cbOrganizer.BackColor = System.Drawing.Color.Transparent;
            this.cbOrganizer.Depth = 0;
            this.cbOrganizer.Font = new System.Drawing.Font("Roboto", 10F);
            this.cbOrganizer.Location = new System.Drawing.Point(13, 204);
            this.cbOrganizer.Margin = new System.Windows.Forms.Padding(0);
            this.cbOrganizer.MouseLocation = new System.Drawing.Point(-1, -1);
            this.cbOrganizer.MouseState = MaterialSkin.MouseState.HOVER;
            this.cbOrganizer.Name = "cbOrganizer";
            this.cbOrganizer.Ripple = true;
            this.cbOrganizer.Size = new System.Drawing.Size(88, 30);
            this.cbOrganizer.TabIndex = 10;
            this.cbOrganizer.Text = "organizer";
            this.cbOrganizer.UseVisualStyleBackColor = false;
            this.cbOrganizer.CheckedChanged += new System.EventHandler(this.cbOrganizer_CheckedChanged);
            // 
            // txtId
            // 
            this.txtId.BackColor = System.Drawing.SystemColors.Control;
            this.txtId.Depth = 0;
            this.txtId.Hint = "";
            this.txtId.Location = new System.Drawing.Point(163, 108);
            this.txtId.MaxLength = 32767;
            this.txtId.MouseState = MaterialSkin.MouseState.HOVER;
            this.txtId.Name = "txtId";
            this.txtId.PasswordChar = '\0';
            this.txtId.SelectedText = "";
            this.txtId.SelectionLength = 0;
            this.txtId.SelectionStart = 0;
            this.txtId.Size = new System.Drawing.Size(111, 23);
            this.txtId.TabIndex = 11;
            this.txtId.TabStop = false;
            this.txtId.UseSystemPasswordChar = false;
            // 
            // materialLabel1
            // 
            this.materialLabel1.AutoSize = true;
            this.materialLabel1.Depth = 0;
            this.materialLabel1.Font = new System.Drawing.Font("Roboto", 11F);
            this.materialLabel1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(222)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.materialLabel1.Location = new System.Drawing.Point(185, 80);
            this.materialLabel1.MouseState = MaterialSkin.MouseState.HOVER;
            this.materialLabel1.Name = "materialLabel1";
            this.materialLabel1.Size = new System.Drawing.Size(69, 19);
            this.materialLabel1.TabIndex = 12;
            this.materialLabel1.Text = "Select ID";
            // 
            // groupBoxTables
            // 
            this.groupBoxTables.Controls.Add(this.cbOrganizer);
            this.groupBoxTables.Controls.Add(this.cbPersons);
            this.groupBoxTables.Controls.Add(this.cbVenue);
            this.groupBoxTables.Controls.Add(this.cbEvents);
            this.groupBoxTables.Controls.Add(this.cbProduction);
            this.groupBoxTables.Controls.Add(this.cbContributions);
            this.groupBoxTables.ForeColor = System.Drawing.SystemColors.ButtonFace;
            this.groupBoxTables.Location = new System.Drawing.Point(12, 95);
            this.groupBoxTables.Name = "groupBoxTables";
            this.groupBoxTables.Size = new System.Drawing.Size(134, 300);
            this.groupBoxTables.TabIndex = 13;
            this.groupBoxTables.TabStop = false;
            this.groupBoxTables.Text = "Choose";
            // 
            // Export_Form
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(448, 438);
            this.Controls.Add(this.groupBoxTables);
            this.Controls.Add(this.materialLabel1);
            this.Controls.Add(this.txtId);
            this.Controls.Add(btnExportExcel);
            this.Controls.Add(btnExportJSON);
            this.Controls.Add(btnExportCSV);
            this.Controls.Add(this.materialRaisedButton2);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "Export_Form";
            this.Sizable = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.groupBoxTables.ResumeLayout(false);
            this.groupBoxTables.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private MaterialSkin.Controls.MaterialCheckBox cbProduction;
        private MaterialSkin.Controls.MaterialRaisedButton materialRaisedButton2;
        private MaterialSkin.Controls.MaterialCheckBox cbEvents;
        private MaterialSkin.Controls.MaterialCheckBox cbContributions;
        private MaterialSkin.Controls.MaterialCheckBox cbVenue;
        private MaterialSkin.Controls.MaterialCheckBox cbPersons;
        private System.Windows.Forms.SaveFileDialog saveFileDialog;
        private MaterialSkin.Controls.MaterialCheckBox cbOrganizer;
        private MaterialSkin.Controls.MaterialSingleLineTextField txtId;
        private MaterialSkin.Controls.MaterialLabel materialLabel1;
        private System.Windows.Forms.GroupBox groupBoxTables;
    }
}