namespace GLB___SharpGLTF
{
    partial class Form1
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.gltf_glb = new System.Windows.Forms.Button();
            this.MergeBtn = new System.Windows.Forms.Button();
            this.Rotate180 = new System.Windows.Forms.Button();
            this.Animatie = new System.Windows.Forms.Button();
            this.btn_filedialog = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.btn_changeLocation = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // gltf_glb
            // 
            this.gltf_glb.Location = new System.Drawing.Point(12, 12);
            this.gltf_glb.Name = "gltf_glb";
            this.gltf_glb.Size = new System.Drawing.Size(123, 23);
            this.gltf_glb.TabIndex = 0;
            this.gltf_glb.Text = "GLTF --> GLB";
            this.gltf_glb.UseVisualStyleBackColor = true;
            this.gltf_glb.Click += new System.EventHandler(this.btn_gltfTOglb_Click);
            // 
            // MergeBtn
            // 
            this.MergeBtn.Location = new System.Drawing.Point(141, 12);
            this.MergeBtn.Name = "MergeBtn";
            this.MergeBtn.Size = new System.Drawing.Size(122, 23);
            this.MergeBtn.TabIndex = 1;
            this.MergeBtn.Text = "Merge 2 files";
            this.MergeBtn.UseVisualStyleBackColor = true;
            this.MergeBtn.Click += new System.EventHandler(this.button2_Click);
            // 
            // Rotate180
            // 
            this.Rotate180.Location = new System.Drawing.Point(269, 12);
            this.Rotate180.Name = "Rotate180";
            this.Rotate180.Size = new System.Drawing.Size(143, 23);
            this.Rotate180.TabIndex = 2;
            this.Rotate180.Text = "Rotate 180 Transform";
            this.Rotate180.UseVisualStyleBackColor = true;
            this.Rotate180.Click += new System.EventHandler(this.Rotate180_Click);
            // 
            // Animatie
            // 
            this.Animatie.Location = new System.Drawing.Point(418, 12);
            this.Animatie.Name = "Animatie";
            this.Animatie.Size = new System.Drawing.Size(93, 23);
            this.Animatie.TabIndex = 3;
            this.Animatie.Text = "Animatie";
            this.Animatie.UseVisualStyleBackColor = true;
            this.Animatie.Click += new System.EventHandler(this.Animatie_Click);
            // 
            // btn_filedialog
            // 
            this.btn_filedialog.Location = new System.Drawing.Point(517, 12);
            this.btn_filedialog.Name = "btn_filedialog";
            this.btn_filedialog.Size = new System.Drawing.Size(84, 23);
            this.btn_filedialog.TabIndex = 4;
            this.btn_filedialog.Text = "FileDialog";
            this.btn_filedialog.UseVisualStyleBackColor = true;
            this.btn_filedialog.Click += new System.EventHandler(this.btn_filedialog_Click);
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(141, 41);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(122, 23);
            this.button1.TabIndex = 5;
            this.button1.Text = "New Merge 2 Files";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // btn_changeLocation
            // 
            this.btn_changeLocation.Location = new System.Drawing.Point(269, 41);
            this.btn_changeLocation.Name = "btn_changeLocation";
            this.btn_changeLocation.Size = new System.Drawing.Size(143, 23);
            this.btn_changeLocation.TabIndex = 6;
            this.btn_changeLocation.Text = "ChangeLocation";
            this.btn_changeLocation.UseVisualStyleBackColor = true;
            this.btn_changeLocation.Click += new System.EventHandler(this.btn_changeLocation_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.btn_changeLocation);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.btn_filedialog);
            this.Controls.Add(this.Animatie);
            this.Controls.Add(this.Rotate180);
            this.Controls.Add(this.MergeBtn);
            this.Controls.Add(this.gltf_glb);
            this.Name = "Form1";
            this.Text = "Form1";
            this.ResumeLayout(false);

        }

        #endregion

        private Button gltf_glb;
        private Button MergeBtn;
        private Button Rotate180;
        private Button Animatie;
        private Button btn_filedialog;
        private Button button1;
        private Button btn_changeLocation;
    }
}