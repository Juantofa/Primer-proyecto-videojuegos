using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Animal : MonoBehaviour
{

    [SerializeField] int hearths;
    Rigidbody2D myBody;
    [SerializeField] float speed;
    bool direction = true;
    float minX, maxX, minY, maxY;
    // Start is called before the first frame update
    void Start()
    {
        myBody = GetComponent<Rigidbody2D>();

        Vector2 esqInfIzq = (Camera.main).ViewportToWorldPoint(new Vector2(0, 0));
        Vector2 esqSupDer = (Camera.main).ViewportToWorldPoint(new Vector2(1, 1));

        minX = esqInfIzq.x;
        maxX = esqSupDer.x;
        minY = esqInfIzq.y;
        maxY = esqSupDer.y;
    }

    // Update is called once per frame
    void Update()
    {
        // Cambia la dirección de los animales
        if (transform.position.x >= maxX)
            direction = false;
        else if (transform.position.x <= minX)
            direction = true;
    }


    private void FixedUpdate()
    {
        if (direction)
        {
            myBody.velocity = new Vector2(speed, myBody.velocity.y);
        }
        else
        {
            myBody.velocity = new Vector2(-speed, myBody.velocity.y);
        }

    }
}
