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
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.MergeBtn);
            this.Controls.Add(this.gltf_glb);
            this.Name = "Form1";
            this.Text = "Form1";
            this.ResumeLayout(false);

        }

        #endregion

        private Button gltf_glb;
        private Button MergeBtn;
    }
}