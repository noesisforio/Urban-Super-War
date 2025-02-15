using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class 直升机 : MonoBehaviour
{
    public GameObject attackPoint;//攻击生成点
    public GameObject attackPoint2;//攻击生成点

    public GameObject bullet;//攻击生成点
    public GameObject tieTu;
    public GameObject se;
    public float attackTime;
    public int speed=100;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D trigger)
    {
        if (trigger.gameObject.tag == "远程攻击")
        {
            Destroy(trigger.gameObject);

        }

    }

        // Update is called once per frame
        void Update()
    {
        tieTu.transform.position = transform.position;
        GetComponent<Rigidbody2D>().velocity = new Vector3(0, 0, 0);



        if (attackPoint.active == true)
        {
            attackTime += Time.deltaTime;
            if (attackTime >= 0.06)
            {

                Instantiate(bullet, attackPoint.transform.position, new Quaternion(0, 0, 0, 0));
                Instantiate(bullet, attackPoint2.transform.position, new Quaternion(0, 0, 0, 0));
                attackTime = 0;
            }
        }
        
            
        if (Input.GetKey(KeyCode.A)) {
            GetComponent<Rigidbody2D>().velocity = new Vector3(-speed, 0, 0);

            //transform.Translate(new Vector3(-speed, 0, 0));



        }

        //D键前进
        if (Input.GetKey(KeyCode.D))
        {
            //enemyPoint.transform.Translate(new Vector3(speed, 0, 0 ));
            GetComponent<Rigidbody2D>().velocity = new Vector3(speed, 0, 0);
            //transform.Translate(new Vector3(speed, 0, 0));

        }

        //W键上走
        if (Input.GetKey(KeyCode.W))
        {
            //transform.Translate(new Vector3(0, speed, 0));
            GetComponent<Rigidbody2D>().velocity = new Vector3(0, speed, 0);


        }

        //S键下走
        if (Input.GetKey(KeyCode.S))
        {
            //transform.Translate(new Vector3(0, -speed, 0));

            GetComponent<Rigidbody2D>().velocity = new Vector3(0, -speed, 0);

        }

        if (Input.GetKeyUp(KeyCode.W) || Input.GetKeyUp(KeyCode.S) || Input.GetKeyUp(KeyCode.A) || Input.GetKeyUp(KeyCode.D))
        {
            //enemyPoint.transform.Translate(new Vector3(0, 0, 0 ));
            GetComponent<Rigidbody2D>().velocity = new Vector3(0, 0, 0);

        }
    }
}
