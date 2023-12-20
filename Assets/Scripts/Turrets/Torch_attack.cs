using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Torch_attack : MonoBehaviour
{

    public LayerMask enemy_layer;
    public float attack_range = 4.0f;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    void Find_new_target()
    {
        RaycastHit2D[] enem = Physics2D.CircleCastAll(transform.position, attack_range,transform.position, 0.0f,enemy_layer);
        foreach (var enemy in enem)
        {
            Transform hit = enemy.transform;
            Unvisible unvis;
            if((unvis = hit.GetComponent<Unvisible>()) != null)
            {
                unvis.Hitable();
            }
        }
    }

    // Update is called once per frame
    void Update()
    {
        Find_new_target();
    }
}
