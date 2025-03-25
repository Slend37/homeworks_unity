using System.Collections;
using TMPro;
using UnityEngine;

public class PlayerCollectController : MonoBehaviour
{
    private int score = 0;
    [SerializeField] private TextMeshProUGUI tm;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
 
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Coins")
        {
            Destroy(collision.gameObject);
        }
    }

}