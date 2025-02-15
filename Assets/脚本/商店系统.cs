using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;



public class 商店系统 : MonoBehaviour
{
    public Text money;
    public Text redBottle;
    public Text blueBottle;

    public float HP_bag_num;
    public float MP_bag_num;
    public float HP_bag_num_Max;
    public float MP_bag_num_Max;

    public int HP_bag_intNum;
    public int MP_bag_intNum;

    public int commodit_num;
    public int moneyNeed_num;
    public bool isShop;
    public int HP_bag_moneyNum ;
    public int MP_bag_moneyNum ;


    public GameObject shopBox;
    public GameObject HP_bag;
    public GameObject MP_bag;

    public GameObject shopBox_buy;
    public Text shopBox_introduce_text;
    public Text shopBox_bagNum_text;
    public Text shop_HP_bag_text;
    public Text shop_MP_bag_text;
    public Slider shopBox_slider;
    public Image shopBox_image;
    public Sprite[] shopBox_imgSprite;
    bool isBuy=false;
    // Start is called before the first frame update

    public void HP_bag_button()
    {
            commodit_num = 1;
            isShop = true;
        

     
        
        

    }

    public void MP_bag_button()
    {

            commodit_num = 2;
            isShop = true;
        
        
    }

    public void shopBox_buy_button()
    {
        if (commodit_num == 1)
        {
            HP_bag_num_Max -= HP_bag_intNum;
            HP_bag_num=HP_bag_num_Max;
            游戏管理器.redBottle_num += HP_bag_intNum;
            游戏管理器.money_num = 游戏管理器.money_num - moneyNeed_num;

        }

        else if (commodit_num == 2)
        {
            MP_bag_num_Max -= MP_bag_intNum;
            MP_bag_num = MP_bag_num_Max;
            游戏管理器.blueBottle_num += MP_bag_intNum;
            游戏管理器.money_num = 游戏管理器.money_num - moneyNeed_num;

        }
        shopBox_exit_button();
    }

    public void shop_exit_button()
    {
        SceneManager.LoadScene(2);
        GameObject.Find("渐入渐出动画").SetActive(true);
        GameObject.Find("渐入渐出动画").GetComponent<Animator>().SetBool("过渡动画", false);
    }

    public void shopBox_exit_button()
    {
        commodit_num = 0;
        shopBox.SetActive(false);
        shopBox_slider.value = 0.1f;
    }

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        money.text= 游戏管理器.money_num.ToString();
        redBottle.text = 游戏管理器.redBottle_num.ToString();
        blueBottle.text = 游戏管理器.blueBottle_num.ToString();

        shop_HP_bag_text.text = "剩余量：" + HP_bag_num_Max.ToString();
        shop_MP_bag_text.text = "剩余量：" + MP_bag_num_Max.ToString();

        if (HP_bag_num_Max <= 0&& HP_bag_moneyNum > 游戏管理器.money_num)
        {
            shop_HP_bag_text.text = "已售完";
        }
        if (MP_bag_num_Max <= 0)
        {
            shop_MP_bag_text.text = "已售完";
        }

        if (shop_HP_bag_text.text != "已售完" && HP_bag_moneyNum > 游戏管理器.money_num)
        {
            shop_HP_bag_text.text = "邮票不足";
        }
        if (shop_MP_bag_text.text != "已售完" && MP_bag_moneyNum > 游戏管理器.money_num)
        {
            shop_MP_bag_text.text = "邮票不足";
        }



        if (HP_bag_num_Max <= 0|| 游戏管理器.money_num < HP_bag_moneyNum)
        {
            HP_bag.GetComponent<Button>().interactable = true;//测试
        }

        if (MP_bag_num_Max <= 0 || 游戏管理器.money_num < MP_bag_moneyNum)
        {
            MP_bag.GetComponent<Button>().interactable = true;//测试
        }



        if (isShop == true&& commodit_num == 1)
        {
            shopBox_image.GetComponent<Image>().sprite = shopBox_imgSprite[0];
            shopBox.SetActive(true);
         
            HP_bag_num=shopBox_slider.value* HP_bag_num_Max;
            HP_bag_intNum = (int)HP_bag_num;
            moneyNeed_num = HP_bag_intNum * HP_bag_moneyNum;
            shopBox_bagNum_text.text = "购买量:" + HP_bag_intNum.ToString();

            if (moneyNeed_num > 游戏管理器.money_num)
            {
                
                shopBox_introduce_text.text = "邮票金额不足" ;
                shopBox_buy.GetComponent<Button>().interactable = false;
            }
            else
            {

                shopBox_introduce_text.text = "血清恢复剂";
                shopBox_buy.GetComponent<Button>().interactable = true;
                
            }

            

        }

        else if (isShop == true && commodit_num == 2)
        {
            shopBox_image.GetComponent<Image>().sprite = shopBox_imgSprite[1];

            shopBox.SetActive(true);
            
            MP_bag_num = shopBox_slider.value* MP_bag_num_Max;
            MP_bag_intNum = (int)MP_bag_num;
            moneyNeed_num = MP_bag_intNum * MP_bag_moneyNum;
            shopBox_bagNum_text.text = "购买量:" + MP_bag_intNum.ToString();



            if (moneyNeed_num > 游戏管理器.money_num)
            {
                
                shopBox_introduce_text.text = "邮票金额不足";
                shopBox_buy.GetComponent<Button>().interactable = false;
            }
            else
            {
                shopBox_introduce_text.text = "能量增强剂";
                shopBox_buy.GetComponent<Button>().interactable = true;
                
            }



        }


    }
}
