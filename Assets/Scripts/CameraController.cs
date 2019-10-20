using UnityEngine;
using Cinemachine;

public class CameraController : MonoBehaviour
{
    #region --PUBLIC VARIABLES-- 

    public GameObject player;
    public GameObject[] cameras;
    public GameObject[] Zones;

    #endregion

    #region --PRIVATE VARIABLES-- 

    private Vector3 offset;
    private int cameraIndex;

    #endregion

    // Start is called before the first frame update
    void Start()
    {
        offset = transform.position - player.transform.position;
        cameraIndex = 0;

        for (int i = 1; i < cameras.Length; i++)
        {
            cameras[i].gameObject.SetActive(false);
        }
    }

    // Update is called once per frame
    void LateUpdate()
    {
        transform.position = player.transform.position + offset;
    }

    private void OnTriggerEnter(Collider other)
    {
        //ToDo: when the ball goes into a zone change the camera. 
    }
}
