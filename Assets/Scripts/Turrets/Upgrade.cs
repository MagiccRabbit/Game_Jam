using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Upgrade : MonoBehaviour
{
    public GameObject upgrade;
    public Button dmg;
    public Button at_speed;
    public Button range;

    public int cost = 100;

    private Turret_attack edit;
    // Start is called before the first frame update

    void Start()
    {
        dmg.onClick.AddListener(Damage_up);
        at_speed.onClick.AddListener(Attack_speed_up);
        range.onClick.AddListener(Range_up);
        edit = GetComponent<Turret_attack>();
    }
    public void Upgrade_show(bool set)
    {
        upgrade.SetActive(set);
    }

    private void Damage_up()
    {
        GameObject game = GameObject.Find("Game_settings");
        if(cost <= game.GetComponent<Game_core>().Get_juice())
        {
            game.GetComponent<Game_core>().Use_juice(cost);
            edit.damage += 5;
        }
    }
    private void Range_up()
    {
        GameObject game = GameObject.Find("Game_settings");
        if(cost <= game.GetComponent<Game_core>().Get_juice())
        {
            game.GetComponent<Game_core>().Use_juice(cost);
            edit.attack_range += 1;
        }
    }
    private void Attack_speed_up()
    {
        GameObject game = GameObject.Find("Game_settings");
        if(cost <= game.GetComponent<Game_core>().Get_juice())
        {
            game.GetComponent<Game_core>().Use_juice(cost);
            edit.attack_speed += 1;
        }
    }


}
