using System.Collections;
using System.Collections.Generic;
using Unity.IO.LowLevel.Unsafe;
using UnityEngine;

public class Turret_attack : MonoBehaviour
{
    public int damage = 10;
    public LayerMask enemy_layer;
    public float attack_range = 4.0f;

    public float attack_speed = 4;

    private float counter = 0;

    public Animator animator;

    public AudioSource shoot_audio;

    public float bullet_speed = 10.0f;
    public Transform target;
    public GameObject gun;

    public GameObject projectile;
    // Start is called before the first frame update
    void Start()
    {
        animator.SetBool("Shooting",false);
    }

    // Update is called once per frame
    void Update()
    {
        if(target == null)
        {
            Find_new_target();
            animator.SetBool("Shooting",false);
        }
        else
        {
            animator.SetBool("Shooting",true);
            //Shooting
            counter -= Time.deltaTime;
        
            var secondsPerBullet = 1.0f / attack_speed;

            while (counter <= 0.0f)
            { 
                Fire();
                
                counter += secondsPerBullet;
            }
            Rotation_to_target();
            Check_target();
        }
    }

    void Rotation_to_target()
    {
        float angle = Mathf.Atan2(target.position.y - transform.position.y,target.position.x - transform.position.x) * Mathf.Rad2Deg + 90;
        gun.transform.rotation = Quaternion.Euler(new Vector3(0f, 0f, angle));
    }

    void Find_new_target()
    {
        RaycastHit2D[] enem = Physics2D.CircleCastAll(transform.position, attack_range,transform.position, 0.0f,enemy_layer);
        if(enem.Length > 0)
        {
            target = enem[0].transform;
        }
    }

    void Check_target()
    {
        if(Vector2.Distance(transform.position,target.position) >= attack_range)
        {
            target = null;
        }
    }

    void Fire()
    {
        //shoot_audio.Play();
        GameObject shoot = Instantiate(projectile,transform.position,transform.rotation);
        Vector2 direction = target.position - transform.position;

        shoot.GetComponent<Bullet>().Setup(direction,bullet_speed, damage,attack_range);
    }
}
