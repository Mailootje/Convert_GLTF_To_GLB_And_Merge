using System;
using SharpGLTF;
using SharpGLTF.Scenes;
using System.Numerics;

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
            var terrain = SceneBuilder.LoadDefaultScene("Soldier.glb");
            var boat = SceneBuilder.LoadDefaultScene("Xbot.glb");
            // filter out the parts you don't want
            /*            foreach (var instance in boat.Instances.ToArray())
                        {
                            if (instance.Name.StartsWith("Test")) instance.Remove();  // remove this instance from the boat scene.
                        }*/
            var merged = new SceneBuilder();
            merged.AddScene(terrain, Matrix4x4.Identity);
            merged.AddScene(boat, Matrix4x4.CreateTranslation(1, 0, 0));
            merged.ToGltf2().Save("merged.glb");
        }
    }
}