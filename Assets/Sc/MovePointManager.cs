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
            EditorGUI.BeginChangeCheck();//EndCheckChange�Ƃ̊ԂŕύX���s���Ă邩�`�F�b�N


        }
    }
}
#endif 