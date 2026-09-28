using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using Photon.Pun

public class Pickup : MonoBehaviour
{
    public enum PickupType
    {
        Health,
        Ammo 
    }

    public PickupType type;
    public int value;

    [PunRPC]
    public void Heal (int amountToHeal)
    {
        curHp = Mathf.Clamp(curHp + amountToHeal, 0, maxHp);

        //update the health bar UI
    }
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
