using UnityEditor;
namespace MyBuilder
{
    public class WebGLBuilder
    {
        [MenuItem("Build/Build MyWebGL")]
        public static void build()
        {
            string[] scenes = { "Assets/Scenes/SampleScene.unity" };
            BuildPipeline.BuildPlayer(scenes, "Build", BuildTarget.WebGL, BuildOptions.None);
        }
    }
}
