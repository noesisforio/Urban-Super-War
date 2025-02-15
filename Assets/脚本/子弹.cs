using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class 子弹 : MonoBehaviour
{
    GameObject tieTu;///正在运行中的主角

    bool isRight;
    // Start is called before the first frame update
    void Start()
    {
        tieTu = GameObject.FindWithTag("贴图");

        if (tieTu.GetComponent<SpriteRenderer>().flipX == false)
        {
            isRight=true;
        }
        if (tieTu.GetComponent<SpriteRenderer>().flipX == true)
        {
            isRight = false;
        }
        Destroy(this.gameObject,2f);
    }

    // Update is called once per frame
    void Update()
    {

        if (isRight==true)
        {
            this.gameObject.transform.Translate(new Vector3(0.5f, 0, 0));
        }
        if (isRight==false)
        {
            this.gameObject.transform.Translate(new Vector3(-0.5f, 0, 0));
        }



    }
}
