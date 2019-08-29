using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

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
        SetWinText();
    }

    void FixedUpdate()
    {
        float moveHorizontal = Input.GetAxis("Horizontal");
        float moveVertical = Input.GetAxis("Vertical");

        Vector3 movement = new Vector3(moveHorizontal, 0.0f, moveVertical);

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
            winText.text = "You Win!";
        }
    }
}
