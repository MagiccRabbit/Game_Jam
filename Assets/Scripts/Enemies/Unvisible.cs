using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Unvisible : MonoBehaviour
{
    private bool can_hit = false;
    private float timer;
    public bool Can_take_dmg()
    {
        return can_hit;
    }

    public void Hitable()
    {
        timer = 10.0f;
        can_hit = true;
    }

    void Update() {
        if(timer > 0.0)
        {
            timer -= Time.deltaTime;
        }
        else
        {
            can_hit = false;
        }
    }
}
