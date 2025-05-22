using System.Runtime.CompilerServices;
using UnityEditor.Experimental.GraphView;
using UnityEngine;
using Mono.Cecil.Cil;

public class BulletController : MonoBehaviour
{
    [SerializeField] private float bulletSpeed = 2f;
    private bool direction;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        GameObject player = GameObject.Find("Player");
        GetComponent<ShootingConroller>();
        direction = player.GetComponent<ShootingConroller>().direction;
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(new Vector3(bulletSpeed * (direction ? 1 : -1), 0, 0) * Time.deltaTime);

        
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Enemy")
        {
            Destroy(collision.gameObject);
        }
    }

}
