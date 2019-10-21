using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Transporter : MonoBehaviour
{
    public GameObject Player;
    public GameObject TransportToSpot;

    //private Transform tf;
    private SphereCollider sc;
    private Vector3 transportTO;
    // Start is called before the first frame update
    void Start()
    {
        //tf = Player.GetComponent<Transform>();
        sc = Player.GetComponent<SphereCollider>();
        transportTO = TransportToSpot.transform.position;
    }

    // Update is called once per frame
    void Update()
    {

    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            
            sc.enabled = false;
            Vector3 NewPos = new Vector3(19f, 17f, -199f);
            Player.transform.position = transportTO;
            sc.enabled = true;
        }
    }
}
