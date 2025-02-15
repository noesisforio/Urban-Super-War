using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class 子弹_主角 : MonoBehaviour
{


    public bool isRight;
    // Start is called before the first frame update
    void Start()
    {

        if (GameObject.Find("玩家_贴图").GetComponent<SpriteRenderer>().flipX == false)
        {
            isRight=true;
        }
        if (GameObject.Find("玩家_贴图").GetComponent<SpriteRenderer>().flipX == true)
        {
            isRight = false;
        }
        Destroy(this.gameObject,2f);
    }

    // Update is called once per frame
    void Update()
    {

        if (isRight)
        {
            this.gameObject.transform.Translate(new Vector3(1f, 0, 0));
        }
        if (!isRight)
        {
            this.gameObject.transform.Translate(new Vector3(-1f, 0, 0));
        }
        


    }
}
