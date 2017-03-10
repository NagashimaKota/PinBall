using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;     //Textを使うため

public class BallController : MonoBehaviour {

    GameObject Text;

    private float visiblePosZ = -6.5f;  //ボールが見える可能性があるz座標
    private GameObject gameoverText;    //テキストを使う用
    private int point = 0;


    // Use this for initialization
    void Start () {
        
        
        //GameObjectを探してアタッチ
        this.gameoverText = GameObject.Find("GameOverText");
        this.Text = GameObject.Find("Point");
	}
	
	// Update is called once per frame
	void Update () {

        //アタッチしたオブジェクトのz座標が初めに決めた値を超えたらGameOverを表示
		if(this.transform.position.z < visiblePosZ)
        {
            this.gameoverText.GetComponent<Text>().text = "GameOver";
        }
        this.Text.GetComponent<Text>().text = "Point:" + point;
    }

    void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.tag == "SmallStarTag")
        {
            point += 5;
            Debug.Log("SmallStarTag");
        }
        else if (other.gameObject.tag == "LargeStarTag")
        {
            point += 20;
            Debug.Log("LargeStarTag");
        }
        else if(other.gameObject.tag == "SmallCloudTag")
        {
            point += 10;
            Debug.Log("SmallCloudTag");
        }
        else if(other.gameObject.tag == "LargeStarTag")
        {
            point += 30;
            Debug.Log("LargeCloudTag");
        }



    }
}
