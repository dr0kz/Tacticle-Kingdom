using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShipsInstantiating : MonoBehaviour
{
    public Ship shipPrefab;
    void Start()
    {
        InvokeRepeating("ShipInstantiate", 5f, 17f);
    }
    private void ShipInstantiate()
    {
        Ship ship = Instantiate(shipPrefab);
        ship.transform.position = transform.position;
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
