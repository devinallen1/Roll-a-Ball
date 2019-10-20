using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FortyFiveDegreeLaunch : MonoBehaviour
{
    public GameObject playerObj;
    public float power = 100;

    private Rigidbody rb;
    // Start is called before the first frame update
    void Start()
    {
        rb = playerObj.GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {

    }

    //private void OnCollisionStay(Collision collision)
    //{
        
    //}
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            Vector3 spring = new Vector3(0f, power, -power);
            rb.AddForce(spring);
        }
    }
}
