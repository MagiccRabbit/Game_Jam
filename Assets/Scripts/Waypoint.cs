using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Waypoint : MonoBehaviour
{
    public GameObject set1;
    public GameObject set2;

    public Transform spawnpoint1;
    public Transform spawnpoint2;

    public static Transform[] way_points1;
    public static Transform[] way_points2;
    // Start is called before the first frame update
    void Awake() {
        way_points1 = new Transform[set1.transform.childCount];
        for (int i = 0; i < way_points1.Length; i++)
        {
            way_points1[i] = set1.transform.GetChild(i);
        }
        way_points2 = new Transform[set2.transform.childCount];
        for (int i = 0; i < way_points2.Length; i++)
        {
            way_points2[i] = set2.transform.GetChild(i);
        }
    }

    public int Check(Transform enemy)
    {
        if (Vector2.Distance(enemy.position,spawnpoint1.position) <= 0.1f)
        {
            return 1;
        }
        else
        {
            return 2;
        }
    }
}
