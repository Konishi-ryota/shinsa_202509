using System;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public int EnemyHP;
    [SerializeField] int EnemySpeed;

    List<Transform> targetInRange = new();

    private int currentMovePointIndex;

    [NonSerialized] public MovePoint movepoint;
    public Vector3 CurrentPointPosition => movepoint.GetPointPosision(currentMovePointIndex);

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        currentMovePointIndex = 0;
        movepoint = FindAnyObjectByType<MovePoint>();
    }

    // Update is called once per frame
    void Update()
    {
        Move();
        if (NextPointReached())
        {
            UpdatePointIndex();
        }
    }
    private void Move()
    {
        transform.position = Vector3.MoveTowards(transform.position,//動く前の場所
                                                 CurrentPointPosition,//動いてほしい場所
                                                 EnemySpeed * Time.deltaTime);//動く速度
    }
    /// <summary>
    /// 次に移動する地点を決める
    /// </summary>
    private void UpdatePointIndex()
    {
        if (currentMovePointIndex < movepoint.points.Length - 1)
        {
            currentMovePointIndex++;
        }
    }
    /// <summary>
    /// 目標地点についたらtrue
    /// </summary>
    /// <returns></returns>
    private bool NextPointReached()
    {
        float distance = (transform.position - CurrentPointPosition).sqrMagnitude;

        if (distance < 0.01)
        {
            Debug.Log($"目標地点{currentMovePointIndex}に到着");
            return true;
        }
        return false;
    }

    private void OnTriggerStay(Collider other)
    {
        if (other.CompareTag("Ally"))
        {
            targetInRange.Add(other.transform);
        }
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Ally"))
        {
            targetInRange.Remove(other.transform);
        }
    }
}
