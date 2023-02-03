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

        //Create a OmniWheel GLB out of a JSON file
        private void btn_omniwheel_Click(object sender, EventArgs e)
        {

            //Here we open a select menu so you can select a .json file.
            OpenFileDialog openDialog = new OpenFileDialog();
            openDialog.Title = "Select A File";
            openDialog.Filter = "GIMBin JSON File (*.json)|*.json" + "|" + "All Files (*.*)|*.*";

            if (openDialog.ShowDialog() == DialogResult.OK)
            {
                JsonSerializerOptions options = new JsonSerializerOptions
                {
                    //Here we say it's WriteIndented
                    //If you want to learn: https://learn.microsoft.com/en-us/dotnet/api/system.text.json.jsonserializeroptions.writeindented?view=net-7.0
                    WriteIndented = true
                };

                //Here we say string text == the file what we have selected
                string text = File.ReadAllText(openDialog.FileName);

                //Here we serialize the json file
                JsonObjectj jsonObj = JsonSerializer.Deserialize<JsonObjectj>(text, options);

                //Those 2 lines below are parsing the glbs from the json file in base64
                ModelRoot hub1Model = ModelRoot.ParseGLB(Convert.FromBase64String(jsonObj.GLBs[0]));
                ModelRoot hub2Model = ModelRoot.ParseGLB(Convert.FromBase64String(jsonObj.GLBs[0]));

                //This 2 lines are adding the animations to the OmniWheels
                hub1Model.LogicalNodes[0].WithRotationAnimation("Track0", (0, Quaternion.Identity), (1, Quaternion.CreateFromYawPitchRoll(0f, 0f, 10f)), (2, Quaternion.Identity));
                hub2Model.LogicalNodes[0].WithRotationAnimation("Track0", (0, Quaternion.Identity), (1, Quaternion.CreateFromYawPitchRoll(0f, 0f, -10f)), (2, Quaternion.Identity));

                //Here we shuff those ModelRoot hubs into a var HubScene
                var hub1Scene = SceneBuilder.CreateFrom(hub1Model.DefaultScene);
                var hub2Scene = SceneBuilder.CreateFrom(hub2Model.DefaultScene);

                //Here we are saving the Hub's to a GLB file
                hub1Model.SaveGLB("C:\\Users\\oliam\\Videos\\Hub1.glb");
                hub2Model.SaveGLB("C:\\Users\\oliam\\Videos\\Hub2.glb");


                //This is the second part
                //Here we load the GLB's again
                var Object1 = SceneBuilder.LoadDefaultScene("C:\\Users\\oliam\\Videos\\Hub1.glb");
                var Object2 = SceneBuilder.LoadDefaultScene("C:\\Users\\oliam\\Videos\\Hub2.glb");

                //Here is the Matrix4x4
                Matrix4x4 matrix = Matrix4x4.Identity;
                //Here we set the offset for the second hub
                System.Numerics.Vector3 x = new Vector3(0, 0, 29750);
                matrix.Translation = x;

                //Here we apply the offset to the second hub
                Object2.ApplyBasisTransform(matrix);

                //Now we want to save it
                //So first we create a new SceneBuilder
                var merged = new SceneBuilder();

                //Here we add the first hub to the scene
                merged.AddScene(Object1, Matrix4x4.Identity);

                //Here we add the second hub to the scene
                merged.AddScene(Object2, Matrix4x4.Identity);

                //Here we save the scene to a GLB file
                merged.ToGltf2().Save("C:\\Users\\oliam\\Videos\\Merged.glb");
                MessageBox.Show("OmniWheel is created");
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
                var Object1 = SceneBuilder.LoadDefaultScene("C:\\Users\\oliam\\Videos\\Hub1.glb");
                var Object2 = SceneBuilder.LoadDefaultScene("C:\\Users\\oliam\\Videos\\Hub2.glb");
                 Matrix4x4 matrix = Matrix4x4.Identity;
                    System.Numerics.Vector3 x = new Vector3(0, 0, 29750);
                    matrix.Translation = x;

                Object2.ApplyBasisTransform(matrix);

            var merged = new SceneBuilder();
                merged.AddScene(Object1, Matrix4x4.Identity);
                merged.AddScene(Object2, Matrix4x4.Identity);
                merged.ToGltf2().Save("C:\\Users\\oliam\\Videos\\Merged.glb");
        }

        private void btn_changeLocation_Click(object sender, EventArgs e)
        {

        }
    }
}