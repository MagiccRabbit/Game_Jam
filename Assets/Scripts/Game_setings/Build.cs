using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Build : MonoBehaviour
{
    public GameObject[] builds;

    public GameObject[] torches;
    public int build_index;
    public int torch_index;

    public bool editing;

    private int money;
    public int torch_cost = 200;
    public int turret_cost = 200;

    public TMPro.TMP_Text cost_turret;
    public TMPro.TMP_Text cost_torch;
    Game_core game_core;
    // Start is called before the first frame update
    void Start()
    {
        build_index = 0;
        torch_index = 0;
        game_core = GetComponent<Game_core>();
        money = game_core.juice;
        cost_torch.text = torch_cost.ToString();
        cost_turret.text = turret_cost.ToString();
    }

    public GameObject Building()
    {
        money = game_core.juice;
        if(money >= turret_cost)
        {
            money -= turret_cost;
            game_core.Use_juice(turret_cost);
            return builds[build_index];
        }
        return null;
    }

    public GameObject Torch()
    {
        money = game_core.juice;
        if(money >= torch_cost)
        {
            money -= torch_cost;
            game_core.Use_juice(torch_cost);
            return torches[torch_index];
        }
        return null;
    }

    public void Start_edit()
    {
        editing = true;
    }

    public void Stop_edit()
    {
        editing = false;
    }

    public bool Edit_status()
    {
        return editing;
    }


}
