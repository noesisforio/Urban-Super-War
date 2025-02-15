using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class 子弹_主角2 : MonoBehaviour
{


    // Start is called before the first frame update
    void Start()
    {
        if (GameObject.Find("玩家_贴图").GetComponent<SpriteRenderer>().flipX == false)
        {
            this.gameObject.transform.position = new Vector3(GameObject.Find("攻击点").transform.position.x+10, GameObject.Find("攻击点").transform.position.y, 0);
            GetComponent<SpriteRenderer>().flipX = false;
        }
        if (GameObject.Find("玩家_贴图").GetComponent<SpriteRenderer>().flipX == true)
        {
            this.gameObject.transform.position = new Vector3(GameObject.Find("攻击点").transform.position.x-10, GameObject.Find("攻击点").transform.position.y, 0);
            GetComponent<SpriteRenderer>().flipX = true;
        }
       
        Destroy(this.gameObject,1f);
    }

    // Update is called once per frame
    void Update()
    {




    }
}
