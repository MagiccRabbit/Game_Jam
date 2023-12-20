using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tile : MonoBehaviour
{

    private GameObject build;

    private Upgrade upg;
    public SpriteRenderer body;
    public Color normal = Color.green;
    public Color hover = Color.blue;

    private bool active_edit;
    // Start is called before the first frame update
    void Start()
    {
        body = GetComponent<SpriteRenderer>();
        active_edit = false;
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
            if(!(game.GetComponent<Build>().Edit_status()))
            {
                build = game.GetComponent<Build>().Building();
                if(build != null)
                {
                    build = Instantiate(build,transform.position,Quaternion.identity);
                    upg = build.GetComponent<Upgrade>();
                }
            }
        }
        else
        {
            active_edit = !active_edit;
            GameObject game = GameObject.Find("Game_settings");
            if(active_edit == true)
            {
                game.GetComponent<Build>().Start_edit();
            }
            else
            {
                game.GetComponent<Build>().Stop_edit();
            }
            upg.Upgrade_show(active_edit);
        }
    }

}
