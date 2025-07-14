using System;
using UnityEditor;
using UnityEngine;
using static UnityEngine.GraphicsBuffer;

#if UNITY_EDITOR
[CustomEditor(typeof(MovePoint))]
public class MovePointManager : Editor
{
    MovePoint movepoint => target as MovePoint;

    private void OnSceneGUI()
    {
        Handles.color = Color.yellow;

        for (int i = 0; i < movepoint.points.Length; i++)
        {
            EditorGUI.BeginChangeCheck();//EndCheckChangeとの間で変更が行われてるかチェック
            Vector3 currentpoint = movepoint.points[i];//位置取得
            Vector3 newpoint = Handles.FreeMoveHandle
                (currentpoint, 0.7f, new Vector3(0.3f, 0.3f, 0.3f), Handles.SphereHandleCap);

            GUIStyle textStyle = new();
            textStyle.fontSize = 18;
            textStyle.normal.textColor = Color.white;
            Vector3 textpos = Vector3.down * 0.35f + Vector3.right * 0.35f;
        }
    }
}
#endif 