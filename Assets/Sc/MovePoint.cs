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
    /// Gizmos�̊g���@�\
    /// </summary>
    private void OnDrawGizmos()
    {
        for (int i = 0; i < points.Length; i++)//for���Ŕz��̐��l����������
        {
            Gizmos.color = Color.yellow;//�F���w��

            Gizmos.DrawWireSphere(points[i], 0.5f);//�|�W�V�����A���a
        }
    }
}
