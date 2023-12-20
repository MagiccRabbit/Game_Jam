using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Torch_spot : MonoBehaviour
{
    private GameObject build;
    public SpriteRenderer body;
    public Color normal = Color.green;
    public Color hover = Color.blue;
    // Start is called before the first frame update
    void Start()
    {
        body = GetComponent<SpriteRenderer>();
        //body.color = normal;
    }

    private void OnMouseEnter() {
        body.color = hover;
    }

    private void OnMouseExit() {
        body.color = normal;
    }

    private void OnMouseDown() {
        if(build == null)
        {
            GameObject game = GameObject.Find("Game_settings");
            build = game.GetComponent<Build>().Torch();
            if(build != null)
            {
                Instantiate(build,transform.position,Quaternion.identity);
            }
        }
        else
        {
            
        }
    }
}
