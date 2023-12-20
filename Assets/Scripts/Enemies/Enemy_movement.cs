using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy_movement : MonoBehaviour
{
    // Start is called before the first frame update

    private int way_point_count = 0;
    public int dmg = 5;
    public float move_speed = 2.0f;
    private Transform target;
    private int route;
    void Start()
    {
        GameObject route_g = GameObject.Find("Waypoints");
        route = route_g.GetComponent<Waypoint>().Check(transform);
        if(route == 2)
        {
            target = Waypoint.way_points2[way_point_count];
        }
        else
        {
            target = Waypoint.way_points1[way_point_count];
        }
    }

    // Update is called once per frame
    void Update()
    {
        Vector2 direction = target.position - transform.position;
        float angle = Mathf.Atan2(target.position.y - transform.position.y,target.position.x - transform.position.x) * Mathf.Rad2Deg + 90;
        transform.rotation = Quaternion.Euler(new Vector3(0f, 0f, angle));
        transform.position += move_speed * Time.deltaTime * (Vector3)direction.normalized;

        if(Vector2.Distance(target.position,transform.position) <= 0.1f)
        {
            way_point_count++;
            if(route == 2)
            {
                if(way_point_count >= Waypoint.way_points2.Length)
                {
                    GameObject game = GameObject.Find("Game_settings");
                    game.GetComponent<Game_core>().Hit(dmg);
                    Destroy(gameObject);
                }
                else
                {
                    target = Waypoint.way_points2[way_point_count];
                }
                }
            else
            {
                if(way_point_count >= Waypoint.way_points1.Length)
                {
                    GameObject game = GameObject.Find("Game_settings");
                    game.GetComponent<Game_core>().Hit(dmg);
                    Destroy(gameObject);
                }
                else
                {
                    target = Waypoint.way_points1[way_point_count];
                }
            }

        }
    }
}
