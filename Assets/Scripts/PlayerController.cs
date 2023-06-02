using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerController : MonoBehaviour
{
    public Text ScoreText;
    //public Text ClearText;
    public int score;//良くないがpublicにする
    private float horizontalInput;
    [SerializeField] private float speed;
    [SerializeField] private float xRange;
    [SerializeField] private GameObject projectilePrefab;//食べ物プレハブ（あとで複製）
    void Start()
    {
        score = 0;
        SetCountText();
        //ClearText.text ="";
    }

    void Update()
    {
        horizontalInput = Input.GetAxis("Horizontal");
        transform.Translate(Vector3.right * horizontalInput 
                * Time.deltaTime * speed);
        if(transform.position.x < -xRange) {
            transform.position = new Vector3(   -xRange, 
                                                transform.position.y,
                                                transform.position.z);
        }
        if(xRange < transform.position.x ) {
            transform.position = new Vector3(   xRange,
                                                transform.position.y,
                                                transform.position.z);
        }
        //スペースキーが押されたら
        if(Input.GetKeyDown(KeyCode.Space)) {
            //ここで食べ物を複製する（この使い方、というかメソッド名覚えて！）
            Instantiate(    projectilePrefab, 
                            transform.position,
                            projectilePrefab.transform.rotation);
        }
        
    }
    
    public void SetCountText()
    {
        ScoreText.text = "Count: " + score.ToString();
        //if(score >= 10)
        //{
        //ClearText.text = "GAME CLEAR";
        //}
    }

}
