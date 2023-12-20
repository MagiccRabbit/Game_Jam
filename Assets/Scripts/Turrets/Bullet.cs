using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    private float bullet_speed;
    private int damage = 0;
    private Vector2 target;
    private float lifetime = 0;
    private Vector2 start;
    public void Setup(Vector2 direction, float speed, int dmg, float distance)
    {
        bullet_speed = speed;
        target = direction;
        damage = dmg;
        lifetime = distance;
        start = transform.position;
    }

    private void OnTriggerEnter2D(Collider2D other) {
        Enemy_core enemy = other.GetComponent<Enemy_core>();
        if(enemy != null)
        {
            enemy.Getting_hit(damage);
            Destroy(gameObject);
        }
    }

    // Update is called once per frame
    void Update()
    {
        transform.position += bullet_speed * Time.deltaTime * (Vector3)target.normalized;
        if(Vector2.Distance(start,transform.position) > lifetime)
        {
            Destroy(gameObject); 
        }
    }
}
