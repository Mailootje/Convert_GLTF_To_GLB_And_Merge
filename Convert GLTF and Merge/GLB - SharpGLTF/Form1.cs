using System;
using SharpGLTF;
using SharpGLTF.Scenes;
using System.Numerics;
using System.Linq.Expressions;
using System.Globalization;

using System.Collections.Generic;
using System.Text;
using System.Linq;

using SharpGLTF.Collections;
using SharpGLTF.Transforms;
using SharpGLTF.Animations;
using SharpGLTF.Validation;

namespace GLB___SharpGLTF
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        //Convert GLTF to GLB
        private void btn_gltfTOglb_Click(object sender, EventArgs e)
        {
            var model = SharpGLTF.Schema2.ModelRoot.Load("model.gltf");
            model.SaveGLB("SavedGLB.glb");
        }

        //Merge 2 GLB files into one
        private void button2_Click(object sender, EventArgs e)
        {
            ///////////////////////////////////////////////////////// Merge 1 ////////////////////////////////////////////////////////////////
            ///
            var Object1 = SceneBuilder.LoadDefaultScene("Soldier.glb");
            var Object2 = SceneBuilder.LoadDefaultScene("Xbot.glb");
            // filter out the parts you don't want
            /*            foreach (var instance in boat.Instances.ToArray())
                        {
                            if (instance.Name.StartsWith("Test")) instance.Remove();  // remove this instance from the boat scene.
                        }*/
            var merged = new SceneBuilder();
            merged.AddScene(Object1, Matrix4x4.Identity);
            merged.AddScene(Object2, Matrix4x4.CreateTranslation(2, 0, 0));
            merged.ToGltf2().Save("Merged.glb");

            ///////////////////////////////////////////////////////// Merge 2 ////////////////////////////////////////////////////////////////

            var Object3 = SceneBuilder.LoadDefaultScene("Merged.glb");
            var Object4 = SceneBuilder.LoadDefaultScene("Xbot.glb");
            // filter out the parts you don't want
            /*            foreach (var instance in boat.Instances.ToArray())
                        {
                            if (instance.Name.StartsWith("Test")) instance.Remove();  // remove this instance from the boat scene.
                        }*/
            var merged2 = new SceneBuilder();
            merged2.AddScene(Object3, Matrix4x4.Identity);
            merged2.AddScene(Object4, Matrix4x4.CreateTranslation(4, 0, 0));
            merged2.ToGltf2().Save("Merged2.glb");

            ///////////////////////////////////////////////////////// Merge 3 ////////////////////////////////////////////////////////////////

            var Object5 = SceneBuilder.LoadDefaultScene("Merged2.glb");
            var Object6 = SceneBuilder.LoadDefaultScene("Xbot.glb");
            // filter out the parts you don't want
            /*            foreach (var instance in boat.Instances.ToArray())
                        {
                            if (instance.Name.StartsWith("Test")) instance.Remove();  // remove this instance from the boat scene.
                        }*/
            var merged3 = new SceneBuilder();
            merged3.AddScene(Object5, Matrix4x4.Identity);
            merged3.AddScene(Object6, Matrix4x4.CreateTranslation(-2, 0, 0));
            merged3.ToGltf2().Save("Merged3.glb");
        }

        private void Rotate180_Click(object sender, EventArgs e)
        {
            var ObjectRotate = SceneBuilder.LoadDefaultScene("Merged3.glb");
            ObjectRotate.ApplyBasisTransform(Matrix4x4.CreateRotationZ((float)Math.PI)); // for a 180° Rotation
            ObjectRotate.ToGltf2().Save("Rotated.glb");
        }

        private void Animatie_Click(object sender, EventArgs e)
        {
            var ObjectAnimatie = SceneBuilder.LoadDefaultScene("Xbot.glb");
        }

        private void btn_filedialog_Click(object sender, EventArgs e)
        {
            OpenFileDialog openDialog = new OpenFileDialog();
            openDialog.Title = "Select A File";
            openDialog.Filter = "3D Object (*.gltf;*.glb)|*.gltf;*.glb" + "|" +
                                "All Files (*.*)|*.*";
            if (openDialog.ShowDialog() == DialogResult.OK)
            {
                string file = openDialog.FileName;
                var FileDialog = SceneBuilder.LoadDefaultScene(file);
                FileDialog.ApplyBasisTransform(Matrix4x4.CreateRotationZ((float)Math.PI)); // for a 180° Rotation
                FileDialog.ToGltf2().Save("OpenDialog.glb");
            }
        }
    }
}