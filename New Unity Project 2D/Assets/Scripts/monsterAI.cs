using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class monsterAI : MonoBehaviour
{
    // Integers
    // public int curHealth;
    // public int maxHealth;

    //Floats
    public float distance;
    public float wakeRange;
    // public float shootInterval;
    // public float bulletSpeed = 100;
    // public float bulletTimer;

    //Booleans
    public bool awake = false;
    // public bool lookingRight = true;

    //References
    // public GameObject bullet;
    public Transform target;
    public Animator anim;
    // public Transform shootPointLeft;
    // public Transform shootPointRight;

    //New method
    private float timeBtwShots;
    public float startTimeBtwShots;
    // public GameObject shootPointLefty;

    public GameObject projectile;

    void Awake()
    {
        anim = gameObject.GetComponent<Animator>();
    }

    void Start()
    {
        // curHealth = maxHealth;
        timeBtwShots = startTimeBtwShots;
    }

    void Update()
    {

        anim.SetBool("Awake", awake);
        // anim.SetBool("LookingRight", lookingRight);

        RangeCheck();

    }

    void Shoot()
    {
          if(timeBtwShots <= 0){
            Instantiate(projectile, transform.position, Quaternion.identity);
            timeBtwShots = startTimeBtwShots;
        }else{
            timeBtwShots -= Time.deltaTime;
        }
    }

    void RangeCheck()
    {
        distance = Vector3.Distance(transform.position, target.transform.position);

        if(distance < wakeRange)
        {
            awake = true;
            Shoot();
        }

        if (distance > wakeRange)
        {
            awake = false;
        }


    }
    // public void Attack(bool attacking)
    // {
    //     bulletTimer += Time.deltaTime;

    //     if(bulletTimer >= shootInterval)
    //     {
    //         Vector2 direction = target.transform.position - transform.position;
    //         direction.Normalize();

    //         if(attacking)
    //         {
    //             GameObject bulletClone;
    //             bulletClone = Instantiate(bullet, shootPointLeft.transform.position, shootPointLeft.transform.rotation) as GameObject;
    //             bulletClone.GetComponent<Rigidbody2D>().velocity = direction * bulletSpeed;

    //             bulletTimer = 0;

    //         }
    //     }

    // }

}
