using UnityEngine;

public class MovePoint : MonoBehaviour
{
    public Vector3[] points;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    
    public Vector3 GetPointPosision(int index)
    {
        return points[index];
    }

    /// <summary>
    /// Gizmosの拡張機能
    /// </summary>
    private void OnDrawGizmos()
    {
        for (int i = 0; i < points.Length; i++)//for文で配列の数値分処理する
        {
            Gizmos.color = Color.yellow;//色を指定

            Gizmos.DrawWireSphere(points[i], 0.5f);//ポジション、半径
        }
    }
}
