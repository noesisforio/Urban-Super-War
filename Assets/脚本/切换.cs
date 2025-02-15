using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class 切换 : MonoBehaviour
{
    public GameObject Player1;
    public GameObject Player2;
    public GameObject Player1_TieTu;
    public GameObject Player2_TieTu;




    public void changePlayer()
    {
        this.Player1.transform.localPosition = new Vector3(this.Player2.transform.localPosition.x, this.Player2.transform.localPosition.y, 0);
        this.Player1.transform.localScale = (new Vector3(this.Player2.transform.localScale.x, this.Player2.transform.localScale.y));
        if (Player1_TieTu.GetComponent<SpriteRenderer>().flipX == false)
        {
            Player2_TieTu.GetComponent<SpriteRenderer>().flipX = false;
        }
        if (Player1_TieTu.GetComponent<SpriteRenderer>().flipX == true)
        {
            Player2_TieTu.GetComponent<SpriteRenderer>().flipX = true;
        }
    }




        // Start is called before the first frame update
        void Start()
    {
        
    }

    // Update is called once per frame

    private void Update()
    {

    }
}
