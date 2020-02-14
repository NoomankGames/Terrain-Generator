/*
 * author : Kirakosyan Nikita
 * e-mail : noomank.games@gmail.com
 */
using UnityEngine;
using UnityEditor;

[CustomEditor(typeof(TerrainGenerator))]
public class TerrainGeneratorEditor : Editor
{
    public override void OnInspectorGUI()
    {
        DrawDefaultInspector();

        if (GUILayout.Button("Generate"))
        {
            TerrainGenerator generator = (TerrainGenerator)target;
            generator.Generate();
        }
        else if (GUILayout.Button("Clear"))
        {
            TerrainGenerator generator = (TerrainGenerator)target;
            generator.Clear();
        }
    }
}