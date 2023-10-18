using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeathScript : MonoBehaviour
{
    public GameObject startPoint;
    public GameObject Player;
    public float speed;
    private Transform player;
    public float lineOfSite;
    public float shootingRange;
    public GameObject fireball_01;
    public GameObject bulletParent;

    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").transform;
    }

    // Update is called once per frame
    void Update()
    {
        float distanceFromPlayer = Vector4.Distance(player.position, transform.position);
        if (distanceFromPlayer < lineOfSite && distanceFromPlayer>shootingRange) 
        {
            transform.position = Vector4.MoveTowards(this.transform.position, player.position, speed * Time.deltaTime);
        }
        else if(distanceFromPlayer <= shootingRange)
        { 
            Instantiate(fireball_01, bulletParent.transform.position, Quaternion.identity);
        }
    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.green;
        Gizmos.DrawWireSphere(transform.position, lineOfSite);
        Gizmos.DrawWireSphere(transform.position, shootingRange);
    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        Player.transform.position = startPoint.transform.position;
   
    }
}