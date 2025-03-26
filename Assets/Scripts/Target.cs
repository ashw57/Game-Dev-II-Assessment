using System.Collections;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UIElements;

public class Target : GameBehaviour
{
    [SerializeField]
    TargetClass myTargetClass;
    public PatrolType myPatrolType;
    public float stoppingDistance = 0.3f;
    float moveDistance = 500;

    private int myHealth;
    private int mySpeed;
    private int myScore;

    public int MyScore => myScore;

    private Transform moveToPos;
    
    public void Initialize(Transform _startPos)
    {
       switch (myTargetClass) 
       {
            case TargetClass.Beanz:
                myHealth = 2;
                mySpeed = 10;
                myPatrolType = PatrolType.Random;
                myScore = 100;
                break;

            case TargetClass.Nyeh:
                myHealth = 4;
                mySpeed = 5;
                myPatrolType = PatrolType.Random;
                myScore = 200;
                break;

            case TargetClass.Pickle:
                myHealth = 1;
                mySpeed = 10;
                myPatrolType = PatrolType.Random;
                myScore = 150;
                break;
       }
        StartCoroutine(Move());
    }

    private IEnumerator Move()
    {
        switch (myPatrolType)
        {
            case PatrolType.Random:

                moveToPos = _TM.GetRandomSpawnPoint;
                break;
        }
        transform.LookAt(moveToPos);

        while (Vector3.Distance(transform.position, moveToPos.position) > stoppingDistance)
        {
            transform.position = Vector3.MoveTowards(transform.position, moveToPos.position, mySpeed * Time.deltaTime);
            yield return null;
        }

        yield return new WaitForSeconds(1);
        StartCoroutine(Move());
    }

    public void Hit(int _damage)
    {
        myHealth -= _damage;
        _GM.AddScore(myScore);

        if (myHealth <= 0)
            myHealth = 0;
        Die();
    }

    public void Die()
    {
        StopAllCoroutines();
        _TM.KillTarget(this);
    }

}
