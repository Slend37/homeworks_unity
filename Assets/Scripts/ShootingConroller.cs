using System.Collections;
using System.Runtime.CompilerServices;
using UnityEngine;

public class ShootingConroller : MonoBehaviour
{
    
    private bool canShoot = true;
    [SerializeField] private GameObject bullet;
    [SerializeField] private float delayShoot = 1f;
    public bool direction;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (canShoot)
        {
            if (Input.GetKey(KeyCode.Mouse0))
            {
                direction = false;
                StartCoroutine(shoot());
            }
            if (Input.GetKey(KeyCode.Mouse1))
            {
                direction = true;
                StartCoroutine(shoot());
                
            }


        }
    }

    private IEnumerator shoot()
    {
        canShoot = false;
        Instantiate(bullet, transform.position + (direction ? Vector3.right / 5: Vector3.left / 5), Quaternion.identity);
        yield return new WaitForSeconds(delayShoot);
        canShoot = true;
    }
}
