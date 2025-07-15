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
        if (NextPointReached())
        {
            UpdatePointIndex();
        }
    }
    private void Move()
    {
        transform.position = Vector3.MoveTowards(transform.position,//“®‚­‘O‚ÌêŠ
                                                 CurrentPointPosition,//“®‚¢‚Ä‚Ù‚µ‚¢êŠ
                                                 EnemySpeed * Time.deltaTime);//“®‚­‘¬“x
    }

    private void UpdatePointIndex()
    {
        if (currentMovePointIndex < movepoint.points.Length - 1)
        {
            currentMovePointIndex++;
        }
    }
    private bool NextPointReached()
    {
        float distance = (transform.position - CurrentPointPosition).sqrMagnitude;

        if (distance < 0.01)
        {
            return true;
        }
        return false;
    }
}
