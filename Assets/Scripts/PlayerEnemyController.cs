using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;
using Unity.VisualScripting;


public class PlayerEnemyController : MonoBehaviour
{
    public int HP = 5;
    private bool canLose = true;
    private PlayerCollectController checkpoint;
    private GameObject heart0;
    private GameObject heart1;
    private GameObject heart2;
    private GameObject heart3;
    private GameObject heart4;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        checkpoint = GetComponent<PlayerCollectController>();
        heart0 = GameObject.Find("HP_0");
        heart1 = GameObject.Find("HP_1");
        heart2 = GameObject.Find("HP_2");
        heart3 = GameObject.Find("HP_3");
        heart4 = GameObject.Find("HP_4");
    }

    // Update is called once per frame
    void Update()
    {
        if (HP == 0)
        {
            HP = 5;
            heart0.SetActive(true);
            heart1.SetActive(true);
            heart2.SetActive(true);
            heart3.SetActive(true);
            heart4.SetActive(true);
            GameObject.Find("Player").transform.position = checkpoint.checkpoint;
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Enemy" && canLose == true)
        {
            StartCoroutine(damage());
        }
    }
    private IEnumerator damage()
    {
        canLose = false;
        GameObject.Find("HP_" + (HP - 1).ToString()).SetActive(false);
        HP--;
        yield return new WaitForSeconds(1);
        canLose = true;
    }
}
