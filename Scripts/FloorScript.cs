using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FloorScript : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D other)
    {
        if(other.transform.tag=="Arrow")
        {
            Destroy(other.gameObject);
        }
        if(other.transform.tag=="Meteor")
        {
            Destroy(other.gameObject);
        }
        if(other.transform.tag=="ArrowAbility")
        {
            Destroy(other.gameObject);
        }
        if(other.transform.tag=="EnemyArrow")
        {
            Destroy(other.gameObject);
        }
        if(other.transform.tag=="CastleMageMagic")
        {
            Destroy(other.gameObject);
        }
        if(other.transform.tag=="EnemyMeteor")
        {
            Destroy(other.gameObject);
        }
        if(other.transform.tag=="Stun")
        {
            Destroy(other.gameObject);
        }
    }
}
