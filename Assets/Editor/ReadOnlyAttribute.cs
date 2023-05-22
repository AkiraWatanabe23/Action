using UnityEngine;
using UnityEditor;

[CustomEditor(typeof(DataViewTest))]
public class ReadOnlyAttribute : Editor
{
    public override void OnInspectorGUI()
    {
        DataViewTest test = (DataViewTest)target;

        EditorGUILayout.LabelField("Value", test.Value.ToString());

        DrawDefaultInspector();
    }
}
