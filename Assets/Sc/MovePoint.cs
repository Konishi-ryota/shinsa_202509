using UnityEngine;

public class MovePoint : MonoBehaviour
{
    public GameObject[] points;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    
    public GameObject GetPointPosision(int index)
    {
        return points[index];
    }

    private void OnDrawGizmos()
    {
        //for���Ŕz��̐��l����������
        for (int i = 0; i < points.Length; i++)
        {
            //�F���w��
            Gizmos.color = Color.yellow;

            //�|�W�V�����A���a
            Gizmos.DrawWireSphere(points[i].transform.position, 0.5f);
        }
    }
}
