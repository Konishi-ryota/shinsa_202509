using System;
using Unity.VisualScripting;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public int EnemyHP;
    [SerializeField] int EnemySpeed;

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
    }
    private void Move()
    {
        transform.position = Vector3.MoveTowards(transform.position,
                                                 CurrentPointPosition,
                                                 EnemySpeed * Time.deltaTime);
    }
}
