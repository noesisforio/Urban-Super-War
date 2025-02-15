using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class 子弹向下落 : MonoBehaviour
{
    public GameObject boom;
    GameObject tieTu;///正在运行中的主角

    bool isRight;
    // Start is called before the first frame update
    void Start()
    {
        Destroy(this.gameObject, 2f);
    }
    // Update is called once per frame
    void Update()
    {
        this.gameObject.transform.Translate(new Vector3(0, -0.5f, 0));




    }

    private void OnTriggerEnter2D(Collider2D trigger)//触发器
    {
        if (trigger.gameObject.tag == "空气墙")
        {
            Instantiate(boom, transform.position, Quaternion.identity);
            Destroy(this.gameObject);
        }
        if(trigger.gameObject.tag == "Player")
        {
            Instantiate(boom, new Vector3(transform.position.x, transform.position.y-3, 0), Quaternion.identity);
            Destroy(this.gameObject);
        }
    }
}
