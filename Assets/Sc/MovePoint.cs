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
        //for文で配列の数値分処理する
        for (int i = 0; i < points.Length; i++)
        {
            //色を指定
            Gizmos.color = Color.yellow;

            //ポジション、半径
            Gizmos.DrawWireSphere(points[i].transform.position, 0.5f);
        }
    }
}
