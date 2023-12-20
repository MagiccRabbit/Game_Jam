using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Enemy_spawner : MonoBehaviour
{
    public int wave;
    public TMPro.TMP_Text wave_counter;
    public GameObject[] enemies;
    public Transform spawn_point1;
    public Transform spawn_point2;

    public Button next_wave;

    public bool playing;
    // Start is called before the first frame update
    void Start()
    {
        wave = 0;
        playing = false;
        next_wave.onClick.AddListener(Next_wave);
    }

    public void Next_wave()
    {   
        if(!playing)
        {
            wave++;
            wave_counter.text = "Wave: " + wave.ToString();
            StartCoroutine(Wave_start(wave));
        }
    }

    IEnumerator Wave_start(int wave)
    {
        switch (wave)
        {
            case 1:
                StartCoroutine(Worms(20,spawn_point1));
                break;
            case 2:
                StartCoroutine(Worms(20,spawn_point1));
                yield return new WaitForFixedUpdate();
                StartCoroutine(Worms(20,spawn_point1));
                break;
            case 3:
                StartCoroutine(Worms(20,spawn_point1));
                StartCoroutine(Fly(20,spawn_point1));
                break;
            case 4:
                StartCoroutine(Worms(20,spawn_point1));
                StartCoroutine(Worms(20,spawn_point2));
                break;
            case 5:
                StartCoroutine(Worms(20,spawn_point1));
                StartCoroutine(Fly(20,spawn_point1));
                yield return new WaitForSeconds(4);
                StartCoroutine(Worms(20,spawn_point2));
                StartCoroutine(Fly(20,spawn_point2));
                break;
            case 6:
                StartCoroutine(Worms(20,spawn_point1));
                yield return new WaitForSeconds(4);
                StartCoroutine(Boss(1,spawn_point1));
                yield return new WaitForSeconds(7);
                StartCoroutine(Worms(20,spawn_point1));
                StartCoroutine(Worms(20,spawn_point2));
                yield return new WaitForSeconds(4);
                StartCoroutine(Fly(20,spawn_point1));
                break;
            case 7:
                StartCoroutine(Worms(20,spawn_point1));
                StartCoroutine(Fly(20,spawn_point1));
                StartCoroutine(Worms(20,spawn_point2));
                StartCoroutine(Fly(20,spawn_point2));
                yield return new WaitForSeconds(4);
                StartCoroutine(Worms(20,spawn_point1));
                StartCoroutine(Fly(20,spawn_point1));
                StartCoroutine(Worms(20,spawn_point2));
                StartCoroutine(Fly(20,spawn_point2));
                break;
            case 8:
                StartCoroutine(Worms(20,spawn_point1));
                StartCoroutine(Fly(20,spawn_point1));
                StartCoroutine(Worms(20,spawn_point2));
                StartCoroutine(Fly(20,spawn_point2));
                yield return new WaitForSeconds(4);
                StartCoroutine(Boss(4,spawn_point1));
                StartCoroutine(Worms(20,spawn_point1));
                StartCoroutine(Fly(20,spawn_point1));
                StartCoroutine(Worms(20,spawn_point2));
                StartCoroutine(Fly(20,spawn_point2));
                yield return new WaitForSeconds(4);
                StartCoroutine(Boss(4,spawn_point1));
                StartCoroutine(Boss(4,spawn_point2));
                StartCoroutine(Fly(20,spawn_point1));
                StartCoroutine(Fly(20,spawn_point2));
                break;
            case 9:
                break;
            case 10:
                break;
            default:
                break;
        }
        yield break;
    }

    IEnumerator Worms(int number, Transform spawnpoint)
    {
        for (int i = 0; i < number; i++)
        {
            Instantiate(enemies[0],spawnpoint.position,spawnpoint.rotation);
            yield return new WaitForSeconds(1);
            //yield return new WaitForFixedUpdate();
        }
        yield break;
    }

    IEnumerator Fly(int number, Transform spawnpoint)
    {
        for (int i = 0; i < number; i++)
        {
            Instantiate(enemies[1],spawnpoint.position,spawnpoint.rotation);
            yield return new WaitForSeconds(1);
            //yield return new WaitForFixedUpdate();
        }
        yield break;
    }
    IEnumerator Boss(int number, Transform spawnpoint)
    {
        for (int i = 0; i < number; i++)
        {
            Instantiate(enemies[2],spawnpoint.position,spawnpoint.rotation);
            yield return new WaitForSeconds(4);
            //yield return new WaitForFixedUpdate();
        }
        yield break;
    }

}
