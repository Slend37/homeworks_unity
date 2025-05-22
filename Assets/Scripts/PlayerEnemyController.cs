using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;


public class PlayerEnemyController : MonoBehaviour
{
    private int HP = 5;
    private bool canLose = true;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (HP == 0)
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
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
        Destroy(GameObject.Find("HP_" + (HP - 1).ToString()));
        HP--;
        yield return new WaitForSeconds(1);
        canLose = true;
    }
}
