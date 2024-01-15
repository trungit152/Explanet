using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MonsterWaypoint : MonoBehaviour
{
    [SerializeField] private GameObject[] monsterWaypoints;
    private int currentMonsterWaypointIndex = 0;
    [SerializeField] private float speed = 2f;
    private SpriteRenderer sprite;
    private void Start()
    {
        sprite = GetComponent<SpriteRenderer>();
    }
    void Update()
    {
        if (Vector2.Distance(monsterWaypoints[currentMonsterWaypointIndex].transform.position, transform.position) < 0.5f)
        {
            currentMonsterWaypointIndex++;
            sprite.flipX = !sprite.flipX;
            if (currentMonsterWaypointIndex >= monsterWaypoints.Length)
            {
                currentMonsterWaypointIndex = 0;
            }
        }
        transform.position = Vector2.MoveTowards(transform.position, 
            monsterWaypoints[currentMonsterWaypointIndex].gameObject.transform.position, Time.deltaTime * speed);
    }
}
