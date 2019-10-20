using UnityEngine;
using TMPro;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using Cinemachine;

public class PlayerController : MonoBehaviour
{
    #region --PUBLIC VARIABLES-- 
    public float Speed;
    public string Win_Message;
    public TextMeshProUGUI countText;
    public TextMeshProUGUI winText;
    //public Camera camera;
    //public CinemachineFreeLook Camera;
    public Camera Camera;
    #endregion

    #region  --PRIVATE VARIABLES--
    private Rigidbody rb;
    private int count;
    
    #endregion

    private void Start()
    {
        rb = GetComponent<Rigidbody>();
        count = 0;
        SetCountText();
        winText.text = "";
        //camera = Camera.main;
    }
    void Update()
    {
        if (Input.GetKey("escape")) { Application.Quit(); }
        SetWinText();
    }

    void FixedUpdate()
    {
        float moveHorizontal = Input.GetAxis("Horizontal");
        float moveVertical = Input.GetAxis("Vertical");

        var forward = Camera.transform.forward;
        var right = Camera.transform.right;

        forward.y = 0f;
        right.y = 0f;

        forward.Normalize();
        right.Normalize();

        Vector3 moveDirection = forward * moveVertical + right * moveHorizontal;

        Vector3 movement = new Vector3(moveHorizontal, 0.0f, moveVertical);
        //movement = fpsCam.transform.TransformDirection(movement);
        rb.AddForce(moveDirection * Speed);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Pick Up"))
        {
            //other.gameObject.SetActive(false);
            Renderer renderer = other.GetComponent<Renderer>();
            renderer.enabled = false;
            count++;
            SetCountText();
            AudioSource temp = other.GetComponent<AudioSource>();
            temp.Play();
            Destroy(other.gameObject, temp.clip.length);

        }
        
    }

    void SetCountText()
    {
        countText.text = "Count: " + count.ToString();
    }

    void SetWinText()
    {
        if (count == 12)
        {
            //SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
            winText.text = Win_Message;
        }
    }


}
