using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Game_core : MonoBehaviour
{
    public int juice = 100;

    public Slider slider;

    public int HP = 100;

    public GameObject end_screen;

    public TMPro.TMP_Text juice_counter;
    // Start is called before the first frame update
    void Start()
    {
        slider.maxValue = HP;
        slider.minValue = 0;
        slider.value = HP;
        juice_counter.text = juice.ToString();
    }

    public void Add_juice(int count)
    {
        juice += count;
        juice_counter.text = juice.ToString();
    }
    public void Use_juice(int count)
    {
        juice -= count;
        juice_counter.text = juice.ToString();
    }

    public int Get_juice()
    {
        return juice;
    }

    public void Hit(int dmg)
    {
        HP -= dmg;
        slider.value = HP;
        if(HP <= 0)
        {
            Game_over();
        }
    }


    private void Game_over()
    {
        Instantiate(end_screen);
        SceneManager.LoadScene(0);
    }

    // Update is called once per frame
}
