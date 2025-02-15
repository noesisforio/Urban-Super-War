using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class 怪物生成点 : MonoBehaviour
{
    public GameObject enemy1;
    public GameObject enemy2;
    public GameObject camera;
    public GameObject airWall;

    public int enemyBorn_num = 0;
    public int enemyBorn_num_Max;
    public int enemyBorn_X_Min;
    public int enemyBorn_X_Max;

    public float enemyBorn_time = 0;
    public float enemyBorn_time_Max;
    public int enemyDie_num_Max;

    public float camera_num_Max;
    public int radom_num;

    public GameObject goText;
    // Start is called before the first frame update
    void Start()
    {


    }

    // Update is called once per frame
    void Update()
    {
        if (enemyBorn_num < enemyBorn_num_Max)
        {
            enemyBorn_time += Time.deltaTime;


            if (enemyBorn_time > enemyBorn_time_Max)
            {
                transform.position = new Vector3(Random.Range(enemyBorn_X_Min, enemyBorn_X_Max), Random.Range(0, -5));

                radom_num = Random.Range(0, 100);

                if (radom_num <= 50)
                {
                    Instantiate(enemy1, transform.position, Quaternion.identity);
                }


                if (radom_num > 50)
                {
                    Instantiate(enemy2, transform.position, Quaternion.identity);
                }

                enemyBorn_time = 0;
                enemyBorn_num += 1;

            }
        };
        if (游戏管理器.enemyDie_num >= enemyDie_num_Max)
        {
            

            camera.transform.localScale = Vector3.Lerp(camera.transform.localScale, new Vector3(camera_num_Max, camera.transform.localScale.y), 0.005f);
            airWall.GetComponent<BoxCollider2D>().isTrigger = true;
        };

        if (游戏管理器.enemyDie_num == enemyDie_num_Max)
        {
            goText.SetActive(true);
        }
         
    }

}
