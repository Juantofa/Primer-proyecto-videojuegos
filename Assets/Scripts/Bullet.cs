using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    private void OnCollisionEnter2D(Collision2D collision)
    {

        if (collision.gameObject.CompareTag("Animal"))
        {
            collision.gameObject.GetComponent<Animal>().health -= 1;
        }
        Destroy(this.gameObject);
    }
}
