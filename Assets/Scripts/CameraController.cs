using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    #region --PUBLIC VARIABLES-- 

    public GameObject player;

    #endregion

    #region --PRIVATE VARIABLES-- 

    private Vector3 offset; 

    #endregion

    // Start is called before the first frame update
    void Start()
    {
        offset = transform.position - player.transform.position; 
    }

    // Update is called once per frame
    void LateUpdate()
    {
        transform.position = player.transform.position + offset;
    }
}
