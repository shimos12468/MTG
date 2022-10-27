using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemy : MonoBehaviour
{
    public GameObject player;
    public float Damage = 5;
    public float speed = 5;
    public float health;
    float faze2;
    float faze3;
    public char T; 
    public float Walkspeed = 5;
    public float WalkDistance = 100;
    public float AttackDistance = 20;
    public float StoppingDistance = 20;
    public bool once = false;
    public float cooldown = 4;
    public float attackspeed = 1;
    public List<Transform> positionPoints;
    public int Attacks = 2;
    public int index = 0;
    public float percentage;
    public float constant = 1;
    public List<GameObject> Attaks = new List<GameObject>();
    public bool transistion = false;
    private void Start()
    {
        faze2 = health / 2;
        faze3 = health / 3;
    }

    private void Update()
    {
        if (health > faze2)
        {
            if (!transistion)
            {
                if (Vector3.Distance(transform.position, player.transform.position) < (WalkDistance* constant) && Vector3.Distance(transform.position, player.transform.position) > (StoppingDistance * constant))
                {

                    Walk(player.transform ,Walkspeed);
                }

                if (Vector3.Distance(transform.position, player.transform.position) < (AttackDistance* constant))
                {
                    if (Attacks > 0)
                    {

                        Attack();

                    }
                    else
                    {
                        transistion = true;
                        once = false;
                    }

                }
                else
                {
                    //rawr
                    //wait 10 seconds 
                    //health = full
                    //he will start over
                }

            }
            if (transistion)
            {
                if (Vector3.Distance(transform.position, positionPoints[index].position) < (WalkDistance * constant))
                {


                    if (Vector3.Distance(transform.position, positionPoints[index].position) == 0 && once == false)
                    {
                        once = true;
                        T = 'R';
                        StartCoroutine(Wait(2, T));

                    }
                    else
                    {
                        Walk(positionPoints[index], Walkspeed);
                    }
                }
            }
        }

        else if (health <= faze2&&health>faze3)
        {

            if (T == 'F')
            {
                health +=health*(float)(percentage / 100);
            }
            constant = 0.7f;
            if (!transistion)
            {
                if (Vector3.Distance(transform.position, player.transform.position) < (WalkDistance * constant) && Vector3.Distance(transform.position, player.transform.position) > (StoppingDistance * constant))
                {

                    Walk(player.transform, Walkspeed*2);
                }

                if (Vector3.Distance(transform.position, player.transform.position) < (AttackDistance*constant))
                {
                    if (Attacks > 0)
                    {

                        Attack();

                    }
                    else
                    {
                        transistion = true;
                        once = false;
                    }

                }

                else
                {
                    //rawr
                    //wait 10 seconds 
                    //health = full
                    //he will start over
                }

            }
            if (transistion)
            {
                if (Vector3.Distance(transform.position, positionPoints[index].position) < (WalkDistance * constant))
                {


                    if (Vector3.Distance(transform.position, positionPoints[index].position) == 0 && once == false)
                    {
                        once = true;
                        T = 'F';
                        StartCoroutine(Wait(10, T));

                    }
                    else
                    {
                        Walk(positionPoints[index], Walkspeed);
                    }
                }
            }

        }
        else if (health <= faze3)
        {
            percentage *= 5;
            if (T == 'E')
            {
                health += health * (float)(percentage / 100);
            }
            constant = 0.7f;
            if (!transistion)
            {
                if (Vector3.Distance(transform.position, player.transform.position) < (WalkDistance * constant) && Vector3.Distance(transform.position, player.transform.position) > (StoppingDistance * 0.5))
                {

                    Walk(player.transform, Walkspeed * 4);
                }

                else if (Vector3.Distance(transform.position, player.transform.position) < (AttackDistance * 0.5))
                {
                    if (Attacks > 0)
                    {

                        Attack();

                    }
                    else
                    {
                        transistion = true;
                        once = false;
                    }

                }

                else
                {
                    //rawr
                    //wait 10 seconds 
                    //health = full
                    //he will start over
                }

            }
            if (transistion)
            {
                if (Vector3.Distance(transform.position, positionPoints[index].position) < (WalkDistance * constant))
                {


                    if (Vector3.Distance(transform.position, positionPoints[index].position) == 0 && once == false)
                    {
                        once = true;
                        T = 'E';
                        StartCoroutine(Wait(2, T));
                        StartCoroutine(Rawr());
                    }
                    else
                    {
                        Walk(positionPoints[index], Walkspeed);
                    }
                }
            }

        }


        
    }

    private void Attack()
    {
        
        if(once == false)
        {
          
          Debug.Log("Attack");
          once = true;
          StartCoroutine(Wait(cooldown ,'A'));
        
        }
    } 

    IEnumerator Wait(float cd ,char T)
    {

        
        yield return new WaitForSeconds(cd);
        if (T == 'A')
        {
        cooldown = 1 / attackspeed;
        Debug.Log("Will attack now");
        once = false;
        Attacks--;
        }


        if (T == 'R')
        {
            if (index + 1 == positionPoints.Count)
            {
                index = -1;
            }
            index++;
            once = false;
            transistion = false;
            Attacks += 2;
            Debug.Log("Will attack again");
        }

        if (T == 'F')
        {
            if (index + 1 == positionPoints.Count)
            {
                index = -1;
            }
            index++;
            once = false;
            transistion = false;
            Attacks += 4;
            Damage *= 2;
            this.T = '0';

            Debug.Log("Will attack again");
        }


        if (T == 'E')
        {
            if (index + 1 == positionPoints.Count)
            {
                index = -1;
            }
            index++;
            once = false;
            transistion = false;
            Attacks += 5;
            Damage *= 4;


            this.T = '0';

            Debug.Log("Will attack again");
        }
    }


    IEnumerator Rawr()
    {
        yield return new WaitForSeconds(2);
       
    }
    private void Walk(Transform target ,float speed)
    {

       
        Vector3 direction = (target.transform.position - transform.position).normalized;
        direction.y = 0;
        Quaternion lookRotation = Quaternion.LookRotation(direction);
        transform.rotation = Quaternion.Slerp(transform.rotation, lookRotation, speed * Time.deltaTime);
        transform.position= Vector3.MoveTowards(transform.position, target.position, speed * Time.deltaTime);
    }

    public void  TakeDamage(float damageTaken)
    {
        health -= damageTaken;

        if (health <= 0)
        {
            Destroy(this.gameObject);
        }
    }



}
