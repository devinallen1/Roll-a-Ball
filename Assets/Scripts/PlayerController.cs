using UnityEngine;
using TMPro;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class PlayerController : MonoBehaviour
{
    #region --PUBLIC VARIABLES-- 
    public float Speed;
    public TextMeshProUGUI countText;
    public TextMeshProUGUI winText;
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

        Vector3 movement = new Vector3(moveHorizontal, 0.0f, moveVertical);
        //movement = fpsCam.transform.TransformDirection(movement);
        rb.AddForce(movement * Speed);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Pick Up"))
        {
            other.gameObject.SetActive(false);
            count++;
            SetCountText();
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
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
            winText.text = "You Win!";
        }
    }
}
