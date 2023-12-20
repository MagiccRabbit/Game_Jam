using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy_core : MonoBehaviour
{
    private GameObject game; 
    public int hp = 10;
    public int juice = 5;
    // Start is called before the first frame update
    void Start()
    {
        game = GameObject.Find("Game_settings");
    }

    public void Getting_hit(int dmg)
    {
        Unvisible unvis;
        if(((unvis = GetComponent<Unvisible>()) == null) || unvis.Can_take_dmg())
        {
            hp -= dmg;
            if(hp <= 0)
            {
                game.GetComponent<Game_core>().Add_juice(juice);
                Destroy(gameObject);
            }    
        }
    }



}
