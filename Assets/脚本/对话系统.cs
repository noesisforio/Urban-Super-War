using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class 对话系统 : MonoBehaviour
{
    public Text textShow;//设定一个名为“text”的字体显示组件
    public Text name_ui;
    public string[] chapter0;//设定一个名为“chapter”的空数组
    public  int counter ;//设定一个名为“counter”的值，值为0
    public TextAsset juBen;//设定一个名为“text”的读取txt组件
    public Image ld_ui;
    public Sprite[] ld_img;
    public GameObject ld_left;
    public GameObject ld_right;
    public GameObject textSystem;
    public GameObject shop;
    bool istest;
    public void textUp()//设定一个方法（点击切换下一行）
    {

        counter +=2;

    }

    // Start is called before the first frame update
    void Start()
    {
        
        chapter0 = juBen.text.Split();
        StartCoroutine(TypeText());

    }



    // Update is called once per frame
    void Update()
    {
        textShow.GetComponent<Text>().text = chapter0[counter];
        //textShow.text = chapter0[counter].Replace(" ", "");

        if (chapter0[counter].StartsWith("nL-"))
        {
            textShow.GetComponent<Animator>().SetTrigger("运动动画_文字");
            ld_left.GetComponent<Animator>().SetBool("isBlack", false);
            ld_right.GetComponent<Animator>().SetBool("isBlack", true);

            name_ui.text = chapter0[counter].Replace("nL-", "");
            
            counter += 2;

        }

        else if (chapter0[counter].StartsWith("nR-"))
        {
            textShow.GetComponent<Animator>().SetTrigger("运动动画_文字");

            ld_left.GetComponent<Animator>().SetBool("isBlack", true);
            ld_right.GetComponent<Animator>().SetBool("isBlack", false);
            name_ui.text = chapter0[counter].Replace("nR-", "");

            counter += 2;

        }

        

        if (chapter0[counter].StartsWith("ld_L-"))
        {
            int ldLeft_num = int.Parse(chapter0[counter].Replace("ld_L-", "")); 
            ld_left.GetComponent<Image>().sprite = ld_img[ldLeft_num];
            counter += 2;
        }

        if (chapter0[counter].StartsWith("ld_R-"))
        {
            int ldRight_num = int.Parse(chapter0[counter].Replace("ld_R-", ""));
            ld_right.GetComponent<Image>().sprite = ld_img[ldRight_num];
            counter += 2;
        }

        if (chapter0[counter].StartsWith("endShop-"))
        {
            textSystem.transform.localPosition = new Vector3(0, -2000, 0);
            counter += 4;
            shop.SetActive(true);

        }

        if (chapter0[counter].StartsWith("end-"))
        {
            textSystem.transform.localPosition = new Vector3(0, -2000, 0);
            counter += 4;
            
        }

    }
    private IEnumerator TypeText()
    {
        foreach (var item in chapter0[counter].ToCharArray())
        {
            textShow.text += item;
            yield return new WaitForSeconds(0.1f);
        }
    }
}
