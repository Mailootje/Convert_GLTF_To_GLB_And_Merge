using SharpGLTF.Scenes;
using System.Numerics;
using SharpGLTF.Schema2;
using SharpGLTF.Animations;
using System.Text.Json;
using System.Text.Json.Serialization;
using System.Text.Json.Nodes;

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
            OpenFileDialog openDialog = new OpenFileDialog();
            openDialog.Title = "Select A File";
            openDialog.Filter = "3D Object (*.gltf;*.glb)|*.gltf;*.glb" + "|" +
                                "All Files (*.*)|*.*";
            if (openDialog.ShowDialog() == DialogResult.OK)
            {
                JsonSerializerOptions options = new JsonSerializerOptions
                {
                    WriteIndented = true

                };

                string text = File.ReadAllText(openDialog.FileName); //4

                var merged = new SceneBuilder();

                JsonObjectj jsonObj = JsonSerializer.Deserialize<JsonObjectj>(text, options); //4

                Matrix4x4 matrix = Matrix4x4.Identity;
                System.Numerics.Vector3 offset = new Vector3(100, 100, 100);
                matrix.Translation = offset;



                //for omniwheel
                ModelRoot hub1Model = ModelRoot.ParseGLB(Convert.FromBase64String(jsonObj.GLBs[0]));

                ModelRoot hub2Model = ModelRoot.ParseGLB(Convert.FromBase64String(jsonObj.GLBs[0]));

                hub2Model.ApplyBasisTransform(matrix, "myfirstnode");

                hub1Model.LogicalNodes[0].WithRotationAnimation("Track0", (0, Quaternion.Identity), (1, Quaternion.CreateFromYawPitchRoll(0f, 0f, 4f)), (2, Quaternion.Identity));
                hub2Model.LogicalNodes[0].WithRotationAnimation("Track0", (0, Quaternion.Identity), (1, Quaternion.CreateFromYawPitchRoll(0f, 0f, -4f)), (2, Quaternion.Identity));

                var hub1Scene = SceneBuilder.CreateFrom(hub1Model.DefaultScene);
                var hub2Scene = SceneBuilder.CreateFrom(hub2Model.DefaultScene);

                merged.AddScene(hub2Scene, Matrix4x4.CreateTranslation(1112, 130, 120));

                merged.AddScene(hub1Scene, Matrix4x4.Identity);
                //merged.AddScene(hub2Scene, matrix);

                merged.ToGltf2().Save(openDialog.FileName);

                //// Load the glTF file
                //var model = ModelRoot.Load("path/to/gltf/file.glb");

                //// Get the animation you want to change
                //var animation = model.Animations[0];

                //// Modify the animation as desired
                //animation.Name = "My New Animation";
                //animation.Channels[0].Sampler.Input.Accessor.AsVector3Array()[0] = new SharpGLTF.Math.Vector3(1, 2, 3);

                //// Save the modified glTF file
                //model.Save("modified/gltf/file.glb", true);
            }

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
                DialogResult dialogResult = MessageBox.Show("Do you want that file that you selected to be rotated 180° ?", "", MessageBoxButtons.YesNo);
                if (dialogResult == DialogResult.Yes)
                {
                    var FileDialog = SceneBuilder.LoadDefaultScene(file);
                    FileDialog.ApplyBasisTransform(Matrix4x4.CreateRotationZ((float)Math.PI)); // for a 180° Rotation
                    FileDialog.ToGltf2().Save("OpenDialog.glb");
                }
                else if (dialogResult == DialogResult.No)
                {
                    //do something else
                }

            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            OpenFileDialog openDialog = new OpenFileDialog();
            openDialog.Multiselect = true;
            openDialog.Title = "Select A File";
            openDialog.Filter = "3D Object (*.gltf;*.glb)|*.gltf;*.glb" + "|" +
                                "All Files (*.*)|*.*";
            if (openDialog.ShowDialog() == DialogResult.OK)
            {
                string filename = openDialog.FileName;
                //string file2 = openDialog.FileName;

                var Object1 = SceneBuilder.LoadDefaultScene(filename);
                //var Object2 = SceneBuilder.LoadDefaultScene(file2);
                // filter out the parts you don't want
                /*            foreach (var instance in boat.Instances.ToArray())
                            {
                                if (instance.Name.StartsWith("Test")) instance.Remove();  // remove this instance from the boat scene.
                            }*/
                var merged = new SceneBuilder();
                merged.AddScene(Object1, Matrix4x4.Identity);
                //merged.AddScene(Object2, Matrix4x4.CreateTranslation(2, 0, 0));
                merged.ToGltf2().Save("Merged2FilesTogether.glb");
            }
        }

        private void btn_changeLocation_Click(object sender, EventArgs e)
        {

            OpenFileDialog openDialog = new OpenFileDialog();
            openDialog.Title = "Select A File";
            openDialog.Filter = "3D Object (*.gltf;*.glb)|*.gltf;*.glb" + "|" +
                                "All Files (*.*)|*.*";
            
           
        }
    }
}


//SharpGLTF.Animations.AnimatableProperty(1);