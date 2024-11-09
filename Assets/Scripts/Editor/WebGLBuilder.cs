using UnityEditor;
using UnityEngine;
using System.IO;
using System.Linq;
using System.IO.Compression;

public class BuildScript
{
    public static void BuildGame()
    {
        string buildPath = "Builds/Linux";
        CreateDirectory(buildPath);

        BuildPlayerOptions buildPlayerOptions = new BuildPlayerOptions
        {
            scenes = GetEnabledScenes(),
            locationPathName = Path.Combine(buildPath, "YourGameName.x86_64"),
            target = BuildTarget.StandaloneLinux64,
            options = BuildOptions.None
        };

        // Start the build process
        BuildPipeline.BuildPlayer(buildPlayerOptions);
        Debug.Log("Build complete!");

        // Optional: Zip the build directory
        ZipBuild(buildPath);
    }

    private static string[] GetEnabledScenes()
    {
        return EditorBuildSettings.scenes
            .Where(scene => scene.enabled)
            .Select(scene => scene.path)
            .ToArray();
    }

    private static void CreateDirectory(string path)
    {
        if (!Directory.Exists(path))
        {
            Directory.CreateDirectory(path);
        }
    }

    private static void ZipBuild(string buildPath)
    {
        string zipPath = buildPath + ".zip";
        if (File.Exists(zipPath))
        {
            File.Delete(zipPath);
        }
        ZipFile.CreateFromDirectory(buildPath, zipPath);
        Debug.Log($"Build zipped at {zipPath}");
    }
}
