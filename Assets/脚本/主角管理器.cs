using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Animations;
using UnityEngine.SceneManagement;
public class 主角管理器 : MonoBehaviour
{
    
    public GameObject tieTu;//角色贴图
    public GameObject Player_HP_ui;//角色血条UI
    public GameObject Player_MP_ui;//角色蓝条UI
    public GameObject Player_ES_ui;//角色蓝条UI
    public GameObject Player_button_ui;
    public GameObject Player_camera;
    public int Player_HP_num = 100;///角色血量
    public int Player_HP_num_Max = 100;///角色血量_最大值
    public int Player_MP_num = 0;///角色蓝量
    public int Player_MP_num_Max = 100;///角色蓝量_最大值
    public int Player_ES_num = 100;///角色血量
    public int Player_ES_num_Max = 100;///角色蓝量_最大值

    public float speed = 5f;//角色移动速度
    public int gameLevel_num;//切换关卡

    public GameObject attackPoint;//攻击生成点
    public GameObject bullet;//攻击子弹
    public GameObject bullet2;//攻击子弹
    public GameObject bullet_FX;//攻击子弹特效
    public float attackTime;//攻击子弹时间
    public float attackTime_max;//攻击子弹时间最大值


    public GameObject enemyPoint;//敌人跟随点
    public GameObject enemyBorn2_1;//敌人生成点2
    public GameObject enemyBorn2_2;//敌人生成点2

    public GameObject enemyBorn3_1;//敌人生成点2
    public GameObject enemyBorn3_2;//敌人生成点2
    public GameObject enemyBorn3_3;//敌人生成点2

    public GameObject otherPlayer;
    public  GameObject otherPlayer_button_ui;
    public GameObject otherPlayer_HP_ui;
    public GameObject otherPlayer_camera;

    public GameObject failure_ui;
    public Text HP_text;
    public Text MP_text;
    public Text ES_text;

    public GameObject goText;
    public GameObject textShow;

    bool isGo=true;
    public bool isGun;
    public bool isPlay1;
    bool isBigGun_dir=true;
    bool antiRigidity;
    bool isES=false;

    public GameObject hold_ui;
    public GameObject boom1;//爆炸
    public GameObject yun;//爆炸

    public GameObject ult_ui;
    public GameObject hpUp_ui;
    public GameObject mpUp_ui;
    public GameObject shield;
    public GameObject Se;
    public GameObject bigGun;
    

    // Start is called before the first frame update


    void Start()
    {
        

        //判断角色攻击点是左边还是在右边





    }



    // Update is called once per frame

    void Update()
    {
        GetComponent<Rigidbody2D>().velocity = new Vector3(0, 0, 0);
        tieTu.GetComponent<Animator>().SetBool("待机动画_主角", true);
        HP_text.text=  Player_HP_num+" / "+Player_HP_num_Max;
        ES_text.text = Player_ES_num + " / " + Player_ES_num_Max;
        if (isPlay1 == true)
        {
            MP_text.text = 游戏管理器.Player1_MP_num / 2 + " / 50";
        }
        else
        {
            MP_text.text = 游戏管理器.Player2_MP_num / 2 + " / 50";
        }
       

        if (isGo==true)
        {
            enemyPoint.transform.position = Vector3.Lerp(enemyPoint.transform.position, transform.position, speed);
            //A键后退


            if (Input.GetKey(KeyCode.A))
            {
                //enemyPoint.transform.Translate(new Vector3(-speed , 0, 0));
                GetComponent<Rigidbody2D>().velocity = new Vector3(-speed, 0, 0);

                if (游戏管理器.isMenuPause==false)
                {
                    if (isBigGun_dir == true)
                    {
                        tieTu.GetComponent<SpriteRenderer>().flipX = true;
                        attackPoint.transform.localPosition = new Vector3(-4, -2, 0);
                    }
                }

                yun.GetComponent<Animator>().SetBool("跑步_云特效", true);
                tieTu.GetComponent<Animator>().SetBool("走路动画_主角", true);
                

            }

            //D键前进
            if (Input.GetKey(KeyCode.D))
            {
                //enemyPoint.transform.Translate(new Vector3(speed, 0, 0 ));
                GetComponent<Rigidbody2D>().velocity = new Vector3(speed, 0, 0);

                if (游戏管理器.isMenuPause == false)
                {
                    if (isBigGun_dir == true)
                    {
                        tieTu.GetComponent<SpriteRenderer>().flipX = false;
                        attackPoint.transform.localPosition = new Vector3(4, -2, 0);
                    }
                }


                yun.GetComponent<Animator>().SetBool("跑步_云特效", true);
                tieTu.GetComponent<Animator>().SetBool("走路动画_主角", true);
                


                

            }

            //W键上走
            if (Input.GetKey(KeyCode.W))
            {
                //yun.GetComponent<Animator>().SetBool("跑步_云特效", true);
                tieTu.GetComponent<Animator>().SetBool("走路动画_主角", true);


                //this.enemyPoint.transform.Translate(new Vector3(0, speed, 0));
                GetComponent<Rigidbody2D>().velocity = new Vector3(0, speed, 0);






                if (this.tieTu.GetComponent<SpriteRenderer>().sortingOrder >= 2)
                {
                    this.tieTu.GetComponent<SpriteRenderer>().sortingOrder = this.tieTu.GetComponent<SpriteRenderer>().sortingOrder / 2;
                }



            }

            //S键下走
            if (Input.GetKey(KeyCode.S))
            {
                //yun.GetComponent<Animator>().SetBool("跑步_云特效", true);
                tieTu.GetComponent<Animator>().SetBool("走路动画_主角", true);

                //this.enemyPoint.transform.Translate(new Vector3(0, -speed, 0));
                GetComponent<Rigidbody2D>().velocity = new Vector3(0, -speed, 0);

                this.tieTu.GetComponent<SpriteRenderer>().sortingOrder = this.tieTu.GetComponent<SpriteRenderer>().sortingOrder + 2;


               
            }

            //WD键前进走上坡路
            if (Input.GetKey(KeyCode.W) && Input.GetKey(KeyCode.D))
            {
                yun.GetComponent<Animator>().SetBool("跑步_云特效", true);
                tieTu.GetComponent<Animator>().SetBool("走路动画_主角", true);
                //this.Player_sylloge.transform.Translate(new Vector3(speed, speed, 0));

                GetComponent<Rigidbody2D>().velocity = new Vector3(speed, speed, 0);
                attackPoint.transform.localPosition = new Vector3(4, -2, 0);



            }

            //WA键后退走上坡路
            if (Input.GetKey(KeyCode.W) && Input.GetKey(KeyCode.A))
            {
                yun.GetComponent<Animator>().SetBool("跑步_云特效", true);
                tieTu.GetComponent<Animator>().SetBool("走路动画_主角", true);
                //this.Player_sylloge.transform.Translate(new Vector3(-speed, speed, 0));
                GetComponent<Rigidbody2D>().velocity = new Vector3(-speed, speed, 0);
                attackPoint.transform.localPosition = new Vector3(-4, -2, 0);



            }

            //SD键前进走下坡路
            if (Input.GetKey(KeyCode.S) && Input.GetKey(KeyCode.D))
            {
                yun.GetComponent<Animator>().SetBool("跑步_云特效", true);
                tieTu.GetComponent<Animator>().SetBool("走路动画_主角", true);
                //this.Player_sylloge.transform.Translate(new Vector3(speed, -speed, 0));
                GetComponent<Rigidbody2D>().velocity = new Vector3(speed, -speed, 0);
                attackPoint.transform.localPosition = new Vector3(4, -2, 0);


            }

            //SA键后退走下坡路
            if (Input.GetKey(KeyCode.S) && Input.GetKey(KeyCode.A))
            {
                yun.GetComponent<Animator>().SetBool("跑步_云特效", true);
                tieTu.GetComponent<Animator>().SetBool("走路动画_主角", true);
                //this.Player_sylloge.transform.Translate(new Vector3(-speed, -speed, 0));
                GetComponent<Rigidbody2D>().velocity = new Vector3(-speed, -speed, 0);
                attackPoint.transform.localPosition = new Vector3(-4, -2, 0);




            }

            //如果放开WSAD键，则停止前进
            if (Input.GetKeyUp(KeyCode.W) || Input.GetKeyUp(KeyCode.S) || Input.GetKeyUp(KeyCode.A) || Input.GetKeyUp(KeyCode.D))
            {
                yun.GetComponent<Animator>().SetBool("跑步_云特效", false);
                tieTu.GetComponent<Animator>().SetBool("走路动画_主角", false);
                //enemyPoint.transform.Translate(new Vector3(0, 0, 0 ));
                GetComponent<Rigidbody2D>().velocity = new Vector3(0, 0, 0);

            }

            //J键攻击
            //如果是枪的话
            if (isGun == true)
            {


                attackTime += Time.deltaTime;
                if (attackTime >= attackTime_max)
                {
                    if (Input.GetKeyDown(KeyCode.J))
                    {



                        attackTime = 0;
                        tieTu.GetComponent<Animator>().SetTrigger("攻击动画_主角");
                        if (attackPoint.transform.localPosition.x ==4)
                        {
                            bullet_FX.GetComponent<SpriteRenderer>().flipX = false;
                            
                            Instantiate(bullet_FX, new Vector3(attackPoint.transform.position.x + 2, attackPoint.transform.position.y, 0), Quaternion.identity);
                            
                        }
                        else if(attackPoint.transform.localPosition.x == -4)
                        {
                            bullet_FX.GetComponent<SpriteRenderer>().flipX = true;
                            Instantiate(bullet_FX, new Vector3(attackPoint.transform.position.x - 2, attackPoint.transform.position.y, 0), Quaternion.identity);
                        }
                        Instantiate(bullet, attackPoint.transform.position, Quaternion.identity);
                        Invoke("twoBullet", 0.5f);
                        



                    }
                }
            }

            //如果是激光炮的话
            else if (isGun == false)
            {
                if (Input.GetKey(KeyCode.J))
                {
                    isBigGun_dir = false;
                    speed = 5;
                    hold_ui.SetActive(true);
                    hold_ui.GetComponent<Slider>().value = hold_ui.GetComponent<Slider>().value + 0.005f;

                }

                if (Input.GetKeyUp(KeyCode.J))
                {
                    if (hold_ui.GetComponent<Slider>().value >= 1)
                    {
                        if (tieTu.GetComponent<SpriteRenderer>().flipX == false)
                        {
                            tieTu.GetComponent<SpriteRenderer>().flipX = false;
                        }
                        else
                        {
                            tieTu.GetComponent<SpriteRenderer>().flipX = true;
                        }

                        hold_ui.GetComponent<Slider>().value = 1;
                        tieTu.GetComponent<Animator>().SetTrigger("攻击动画_主角");
                        Instantiate(bullet, attackPoint.transform.position, Quaternion.identity);
                        hold_ui.GetComponent<Slider>().value = 0;
                        hold_ui.SetActive(false);
                        speed = 20;
                        isBigGun_dir = true;

                    }
                    else
                    {
                        hold_ui.GetComponent<Slider>().value = 0;
                        hold_ui.SetActive(false);
                        speed = 20;
                        isBigGun_dir = true;
                    }
                }
            }



            //K键激光炮
            if (Input.GetKey(KeyCode.K))
            {

                antiRigidity = true;
                tieTu.GetComponent<Animator>().SetBool("大炮动画_主角", true);//则停止走路动画
                antiRigidity = true;
                isBigGun_dir = false;
                speed = 5;
                hold_ui.SetActive(true);
                hold_ui.GetComponent<Slider>().value = hold_ui.GetComponent<Slider>().value + 0.02f;

                

            }

            if (Input.GetKeyUp(KeyCode.K))
            {
                
                if (hold_ui.GetComponent<Slider>().value >= 1)
                {
                    if (tieTu.GetComponent<SpriteRenderer>().flipX == false)
                    {
                        tieTu.GetComponent<SpriteRenderer>().flipX = false;
                    }
                    else
                    {
                        tieTu.GetComponent<SpriteRenderer>().flipX = true;
                    }

                    hold_ui.GetComponent<Slider>().value = 1;
                    tieTu.GetComponent<Animator>().SetTrigger("大炮发射_主角");

                    Instantiate(bigGun, attackPoint.transform.position, Quaternion.identity);
                    hold_ui.GetComponent<Slider>().value = 0;
                    hold_ui.SetActive(false);
                    speed = 20;
                    isBigGun_dir = true;
                    isGo = false;
                    Invoke("GoTrue",1f);


                }
                else
                {
                    antiRigidity = false;
                    tieTu.GetComponent<Animator>().SetBool("大炮动画_主角", false);
                    hold_ui.GetComponent<Slider>().value = 0;
                    hold_ui.SetActive(false);
                    speed = 20;
                    isBigGun_dir = true;
                }
            }
          
            
            //U键喝血瓶
            if (游戏管理器.redBottle_num > 0)
            {
                if (Input.GetKeyDown(KeyCode.U))
                {
                    hpUp_ui.GetComponent<Animator>().SetTrigger("血量上升_启动");
                    Player_HP_num = Player_HP_num + 10;
                    游戏管理器.redBottle_num = 游戏管理器.redBottle_num - 1;
                }
            }


            //I键喝蓝瓶
            if (游戏管理器.blueBottle_num > 0)
            {

                if (Input.GetKeyDown(KeyCode.I))
                {
                    if (isPlay1 == true)
                    {
                        mpUp_ui.GetComponent<Animator>().SetTrigger("蓝量上升_启动");
                        游戏管理器.Player1_MP_num = 游戏管理器.Player1_MP_num + 10;
                        游戏管理器.blueBottle_num = 游戏管理器.blueBottle_num - 1;
                    }
                    if (isPlay1 == false)
                    {
                        游戏管理器.Player2_MP_num = 游戏管理器.Player2_MP_num + 10;
                        游戏管理器.blueBottle_num = 游戏管理器.blueBottle_num - 1;
                    }
                }
            }


            if (Input.GetKeyDown(KeyCode.P))
            {
                Player_ES_num = 0;
                ult_ui.GetComponent<Animator>().SetTrigger("大招标志_主角1");
                GetComponent<Animator>().SetTrigger("大招启动");
            }
        }


        //O键护盾
        if (Input.GetKeyDown(KeyCode.O)&&isES==false&& Player_ES_num > 0)
        {
            isES = true;
        
            Player_ES_ui.SetActive(true);
            shield.SetActive(true);

        }





        //血量
        Player_HP_ui.GetComponent<Slider>().value = Player_HP_num / 600f;
        Player_ES_ui.GetComponent<Slider>().value = Player_ES_num / 100f;

        //======如果护盾量小于0的话
        if (Player_ES_num <= 0)
        {
            isES = false;
            Player_ES_num = 100;
            shield.GetComponent<Animator>().SetBool("护盾消失", true);
            
            Player_ES_ui.SetActive(false);
            Invoke("shieldDie", 1.5f);
        }

        //======如果血量小于0的话
        if (Player_HP_num <= 0)
        {
            Player_HP_num = 0;
            isGo = false;
            游戏管理器.isDie = true;
            GetComponent<Rigidbody2D>().velocity = new Vector3(0, 0, 0);
            tieTu.GetComponent<Animator>().SetBool("死亡动画_主角", true);
            failure_ui.SetActive(true);

            //如果全军覆没
            //if (otherPlayer_button_ui.GetComponent<Button>().enabled == false && Player_HP_num == 0)
            //{
            //    Time.timeScale = 0;
            //    Player_button_ui.GetComponent<Button>().enabled = false;
            //    Player_button_ui.GetComponent<Image>().color = new Color(0.33f, 0.33f, 0.33f);
            //    failure_ui.SetActive(true);


            //}
            //else
            //{

            //    Invoke("MethodName", 1.5f);
            //}







        }


        //蓝量
        if (isPlay1 == true)
        {
            Player_MP_ui.GetComponent<Slider>().value = 游戏管理器.Player1_MP_num / 100f;
            //如果蓝量大于0的话
            if (游戏管理器.Player1_MP_num >= Player_MP_num_Max)
            {
                游戏管理器.Player1_MP_num = Player_MP_num_Max;
            }
        }

        if (isPlay1 == false)
        {
            Player_MP_ui.GetComponent<Slider>().value = 游戏管理器.Player2_MP_num / 100f;
            //如果蓝量大于0的话
            if (游戏管理器.Player2_MP_num >= Player_MP_num_Max)
            {
                游戏管理器.Player2_MP_num = Player_MP_num_Max;
            }
        }






        //======如果血量大于0的话
        else if (Player_HP_num > 0)
        {
            if (Player_HP_num >= Player_HP_num_Max)
            {
                Player_HP_num = Player_HP_num_Max;
            }
        }



    }

    //碰撞
    private void OnCollisionStay2D(Collision2D collision)
    {
        
        
 



        
    }
    //触发
    private void OnTriggerEnter2D(Collider2D trigger)
    {
        if (isES == false)
        {
            //如果受到怪物的远程攻击
            if (trigger.gameObject.tag == "远程攻击")
            {

                GameObject.Find("玩家_贴图").GetComponent<Animator>().SetTrigger("受伤动画_主角");
                Player_HP_num -= 5;
                if (attackPoint.transform.localPosition.x == 4)
                {
                    Instantiate(boom1, new Vector3(trigger.gameObject.transform.position.x, trigger.gameObject.transform.position.y, 0), Quaternion.identity);
                }
                else if (attackPoint.transform.localPosition.x == -4)
                {
                    Instantiate(boom1, new Vector3(trigger.gameObject.transform.position.x, trigger.gameObject.transform.position.y, 0), Quaternion.identity);
                }


                Destroy(trigger.gameObject);

                tieTu.GetComponent<Animator>().SetBool("走路动画_主角", false);
                GetComponent<Rigidbody2D>().velocity = new Vector3(0, 0, 0);
                if (antiRigidity == false)
                {
                    isGo = false;
                    Invoke("GoTrue", 0.5f);
                }

            }

            if (trigger.gameObject.tag == "激光攻击")
            {

                GameObject.Find("玩家_贴图").GetComponent<Animator>().SetTrigger("受伤动画_主角");
                Player_HP_num -= 5;
                Instantiate(boom1, this.gameObject.transform.position, Quaternion.identity);



                tieTu.GetComponent<Animator>().SetBool("走路动画_主角", false);
                GetComponent<Rigidbody2D>().velocity = new Vector3(0, 0, 0);
                if (antiRigidity == false)
                {
                    isGo = false;
                    Invoke("GoTrue", 0.5f);
                }
            }


            //如果受到近程怪的攻击
            if (trigger.gameObject.tag == "近程攻击")
            {

                GameObject.Find("玩家_贴图").GetComponent<Animator>().SetTrigger("受伤动画_主角");
                Destroy(trigger.gameObject);
                Player_HP_num -= 10;

            }

        }

        if (isES == true)
        {

                if (trigger.gameObject.tag == "远程攻击")
                {

                shield.GetComponent<Animator>().SetTrigger("护盾被攻击");
                Player_ES_num -= 6;
                    Destroy(trigger.gameObject);
                    if (attackPoint.transform.localPosition.x == 4)
                    {
                        Instantiate(boom1, new Vector3(trigger.gameObject.transform.position.x, trigger.gameObject.transform.position.y, 0), Quaternion.identity);
                    }
                    else if (attackPoint.transform.localPosition.x == -4)
                    {
                        Instantiate(boom1, new Vector3(trigger.gameObject.transform.position.x, trigger.gameObject.transform.position.y, 0), Quaternion.identity);
                    }
                }

                if (trigger.gameObject.tag == "激光攻击")
                {
                    shield.GetComponent<Animator>().SetTrigger("护盾被攻击");
                    Player_ES_num -= 6;
                    Instantiate(boom1, this.gameObject.transform.position, Quaternion.identity);
                }

        }


        


            //如果进入下一个小关卡
            if (trigger.gameObject.tag == "小关卡1")
        {

            


            trigger.gameObject.SetActive(false);
            游戏管理器.enemyDie_num = 游戏管理器.enemyDie_num+1;
            Debug.Log("触发第二个小关卡");
            goText.SetActive(false);
            enemyBorn2_1.SetActive(true);
            enemyBorn2_2.SetActive(true);
        }

        //如果进入下一个小关卡
        if (trigger.gameObject.tag == "小关卡2")
        {
            trigger.gameObject.SetActive(false);
            游戏管理器.enemyDie_num = 游戏管理器.enemyDie_num + 1;
            Debug.Log("触发第三个小关卡");
            goText.SetActive(false);
            enemyBorn3_1.SetActive(true);
            enemyBorn3_2.SetActive(true);
            enemyBorn3_3.SetActive(true);
        }

        //如果进入下一个小关卡
        if (trigger.gameObject.tag == "小关卡3")
        {
            textShow.transform.localPosition = new Vector3(0, 0, 0);//显示对话框
            游戏管理器.enemyDie_num = 0;
            trigger.gameObject.GetComponent<BoxCollider2D>().isTrigger=false;
            goText.SetActive(false);
            //SceneManager.LoadScene(gameLevel_num);
        }

        //如果捡到红瓶的话
        if (trigger.gameObject.tag == "血瓶")
        {
            Debug.Log("捡到血瓶");
            游戏管理器.redBottle_num = 游戏管理器.redBottle_num + 1;
            Destroy(trigger.gameObject);
        }

        //如果捡到蓝瓶的话
        if (trigger.gameObject.tag == "蓝瓶")
        {
            Debug.Log("捡到蓝瓶");
            游戏管理器.blueBottle_num = 游戏管理器.blueBottle_num + 1;
            Destroy(trigger.gameObject);
        }

        //如果捡到金币的话
        if (trigger.gameObject.tag == "金币")
        {
           
            游戏管理器.money_num = 游戏管理器.money_num + Random.Range(30, 70);
            Debug.Log("捡到金币"+游戏管理器.money_num);
            Destroy(trigger.gameObject);
        }

        if (trigger.gameObject.tag == "血瓶"||trigger.gameObject.tag == "蓝瓶"||trigger.gameObject.tag == "金币")
        {
            Instantiate(Se, attackPoint.transform.position, Quaternion.identity);
        }
            
    }

    private void MethodName()
    {
        isGo = true;
        otherPlayer.transform.localPosition = new Vector3(transform.localPosition.x,transform.localPosition.y, 0);
        this.gameObject.SetActive(false);
        Player_HP_ui.SetActive(false);
        Player_button_ui.GetComponent<Button>().enabled = false;
        Player_button_ui.GetComponent<Image>().color = new Color(0.33f, 0.33f, 0.33f);
        Player_camera.SetActive(false);
        otherPlayer_button_ui.GetComponent<Button>().interactable = false;
        otherPlayer_HP_ui.SetActive(true);
        otherPlayer.SetActive(true);
        otherPlayer_camera.SetActive(true);


    }
    private void twoBullet()
    {
        Instantiate(bullet2, attackPoint.transform.position, Quaternion.identity);
        if (attackPoint.transform.localPosition.x == 4)
        {
            bullet_FX.GetComponent<SpriteRenderer>().flipX = false;
            Instantiate(bullet_FX, new Vector3(attackPoint.transform.position.x + 2, attackPoint.transform.position.y, 0), Quaternion.identity);
        }
        else if (attackPoint.transform.localPosition.x == -4)
        {
            bullet_FX.GetComponent<SpriteRenderer>().flipX = true;
            Instantiate(bullet_FX, new Vector3(attackPoint.transform.position.x - 2, attackPoint.transform.position.y, 0), Quaternion.identity);
        }
    }

    private void GoTrue()
    {
        isGo = true;
        antiRigidity = false;
        tieTu.GetComponent<Animator>().SetBool("大炮动画_主角", false);
        tieTu.GetComponent<Animator>().SetBool("走路动画_主角", false);

    }

    private void shieldDie()
    {
        shield.SetActive(false);
    }
}



