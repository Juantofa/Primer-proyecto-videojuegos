using System.Collections;
using System.Collections.Generic;
using UnityEngine;



public class Player : MonoBehaviour
{
    [SerializeField] float speed;
    [SerializeField] GameObject bullet;
    [SerializeField] GameObject superBullet;
    float minX, maxX, minY, maxY;
    [SerializeField] float fireRate;
    private float nextFire = 0.0f;
    private bool superShoot = false;
    private float charge = 0f;
    private float totalChargeNeeded = 3f;

    // Start is called before the first frame update
    void Start()
    {
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
        ///Velocidad
        float dirH = Input.GetAxis("Horizontal");
        float dirV = Input.GetAxis("Vertical");
        
        transform.Translate(new Vector2(dirH * speed * Time.deltaTime, 
        dirV * speed * Time.deltaTime));

        //Limite
        transform.position = new Vector2(
            Mathf.Clamp(transform.position.x,minX, maxX),
            Mathf.Clamp(transform.position.y,minY, maxY));
        if (Input.GetKeyDown(KeyCode.C))
        {
            superShoot = !superShoot;
        }

        if (superShoot)
        {
            if (Input.GetKeyDown(KeyCode.Space) && Time.time > nextFire)
            {
                nextFire = Time.time + fireRate;
                Instantiate(bullet, transform.position, transform.rotation);
            }
        }
        else
        {
            if (Input.GetKey(KeyCode.Space))
            {
                charge += Time.deltaTime;
            }
            if (Input.GetKeyUp(KeyCode.Space))
            {
                AttemptShoot();
            }
        }
       

    }
    
    public void AttemptShoot()
    {
        if (charge >= totalChargeNeeded)
        {
          Instantiate(superBullet, transform.position, transform.rotation);
        }
        charge = 0;
    }

}
