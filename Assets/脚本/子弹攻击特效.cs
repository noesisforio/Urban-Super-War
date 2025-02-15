using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class 子弹攻击特效 : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        Destroy(this.gameObject, 0.3f);
    }

    // Update is called once per frame
    void Update()
    {
        
        if (GameObject.Find("攻击点").transform.localPosition.x == 4)
        {
            transform.position = Vector3.Lerp(transform.position, new Vector3(GameObject.Find("攻击点").transform.position.x + 2, GameObject.Find("攻击点").transform.position.y, 0), 1);

        }
        else if (GameObject.Find("攻击点").transform.localPosition.x == -4)
        {
            transform.position = Vector3.Lerp(transform.position, new Vector3(GameObject.Find("攻击点").transform.position.x - 2, GameObject.Find("攻击点").transform.position.y, 0), 1);
        }
    }
}
