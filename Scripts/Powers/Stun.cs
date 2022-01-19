using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Stun : MonoBehaviour
{
    private int StunDamage = 20;
    private void Start()
    {
        SoundManager.PlaySound("stun");
    }
    public int GetStunDamage()
    {
        return StunDamage;
    }

}
