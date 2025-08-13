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
        transform.position = Vector3.MoveTowards(transform.position,//�����O�̏ꏊ
                                                 CurrentPointPosition,//�����Ăق����ꏊ
                                                 EnemySpeed * Time.deltaTime);//�������x
    }
    /// <summary>
    /// ���Ɉړ�����n�_�����߂�
    /// </summary>
    private void UpdatePointIndex()
    {
        if (currentMovePointIndex < movepoint.points.Length - 1)
        {
            currentMovePointIndex++;
        }
    }
    /// <summary>
    /// �ڕW�n�_�ɂ�����true
    /// </summary>
    /// <returns></returns>
    private bool NextPointReached()
    {
        float distance = (transform.position - CurrentPointPosition).sqrMagnitude;

        if (distance < 0.01)
        {
            Debug.Log($"�ڕW�n�_{currentMovePointIndex}�ɓ���");
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
