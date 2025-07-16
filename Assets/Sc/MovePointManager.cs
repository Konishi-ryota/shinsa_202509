using UnityEditor;
using UnityEngine;

#if UNITY_EDITOR
[CustomEditor(typeof(MovePoint))]
public class MovePointManager : Editor
{
    MovePoint _movepoint => target as MovePoint;

    private void OnSceneGUI()
    {
        Handles.color = Color.yellow;

        for (int i = 0; i < _movepoint.points.Length; i++)
        {
            EditorGUI.BeginChangeCheck();//EndCheckChangeとの間で変更が行われてるかチェック
            Vector3 currentpoint = _movepoint.points[i];//位置取得
            Vector3 newpoint = Handles.FreeMoveHandle//SceneでこのGUIを動かすために使われてるメソッド
                (currentpoint, 0.7f, new Vector3(0.3f, 0.3f, 0.3f), Handles.SphereHandleCap);

            GUIStyle textStyle = new();
            textStyle.fontSize = 18;
            textStyle.normal.textColor = Color.white;
            Vector3 textpos = Vector3.down * 0.35f + Vector3.right * 0.35f;

            Handles.Label(_movepoint.points[i] + textpos, $"{i + 1}", textStyle);

            EditorGUI.EndChangeCheck();//BeginChangeCheckとの間で変更が行われてたらtrue

            if (EditorGUI.EndChangeCheck())
            {
                Undo.RecordObject(target, "Move");
                _movepoint.points[i] = newpoint;
            }
        }
    }
}
#endif 