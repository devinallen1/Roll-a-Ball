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
    public GameObject m_winPanel;
    public TextMeshProUGUI endScore;
    public TextMeshProUGUI SecretScore;
    //public Camera camera;
    //public CinemachineFreeLook Camera;
    public Camera Camera;
    #endregion

    #region  --PRIVATE VARIABLES--
    private Rigidbody rb;
    private PlayerController playerCon;
    private int count;
    private int countSecret;
    private bool isGameEnded;
    
    #endregion

    private void Start()
    {
        rb = GetComponent<Rigidbody>();
        playerCon = GetComponent<PlayerController>();
        count = 0;
        SetCountText();
        winText.text = "";
        //camera = Camera.main;
    }
    void Update()
    {
        if (Input.GetKey("escape")) { Application.Quit(); }
        SetWinText();
        if (isGameEnded)
        {
            EndLevel();
        }
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
            SphereCollider sc = other.GetComponent<SphereCollider>();
            sc.enabled = false;
            count++;
            SetCountText();
            AudioSource temp = other.GetComponent<AudioSource>();
            temp.Play();
            Destroy(other.gameObject, temp.clip.length);

        }
        if (other.gameObject.CompareTag("EndLevel"))
        {
            MeshCollider mc = other.GetComponent<MeshCollider>();
            mc.enabled = false;
            Renderer renderer = other.GetComponent<Renderer>();
            AudioSource temp = other.GetComponent<AudioSource>();
            temp.Play();
            renderer.enabled = false;
            count++;
            SetCountText();
            isGameEnded = true;
            //playerCon.enabled = false;
            
        }
        if (other.gameObject.CompareTag("SecretRing"))
        {
            SphereCollider sc = other.GetComponent<SphereCollider>();
            sc.enabled = false;
            Renderer renderer = other.GetComponent<Renderer>();
            renderer.enabled = false;
            countSecret++;
            AudioSource temp = other.GetComponent<AudioSource>();
            temp.Play();
            Destroy(other.gameObject, temp.clip.length);
        }

    }

    void EndLevel()
    {
        endScore.text ="Rings Collected: " + count.ToString() + "/ 80";
        SecretScore.text = "Secret Rings Collected: " + countSecret.ToString() + "/ 5";
        m_winPanel.SetActive(true);

    }

    void SetCountText()
    {
        countText.text = "Count: " + count.ToString();
    }

    void SetWinText()
    {
        //if (count == 12)
        //{
        //    //SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
        //    winText.text = Win_Message;
        //}
    }


}
