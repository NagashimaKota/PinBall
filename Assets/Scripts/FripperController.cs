using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FripperController : MonoBehaviour {

    private HingeJoint myHingeJoint;    //HingeJointをコンポーネントに入れる
    private float defaultAngle = 20;   //初期の傾き
    private float flickAngle = -40;    //はじいたときの傾き

    
    private int screenWidth = Screen.width / 2;
    
    // Use this for initialization
	void Start () {
        this.myHingeJoint = GetComponent<HingeJoint>();

        SetAngle(this.defaultAngle);
	}
	
	// Update is called once per frame
	void Update () {

        
        //矢印キーの入力のtrueとタグの判定
        if (Input.GetKeyDown(KeyCode.LeftArrow) && tag == "LeftFripperTag") 
        {
            SetAngle(this.flickAngle);
        }
        if (Input.GetKeyDown(KeyCode.RightArrow) && tag == "RightFripperTag")
        {
            SetAngle(this.flickAngle);
        }
        if (Input.GetKeyUp(KeyCode.LeftArrow) || Input.GetKeyUp(KeyCode.RightArrow))
        {
            SetAngle(this.defaultAngle);
        }


        if(Input.touchCount > 0)
        {
            Touch myTouch = Input.touches[0];
            if (myTouch.phase == TouchPhase.Began && tag == "LeftFripperTag" && myTouch.position.x <= screenWidth)
            {
                SetAngle(this.flickAngle);
            }
            else if (myTouch.phase == TouchPhase.Began && tag == "RightFripperTag" && myTouch.position.x > screenWidth)
            {
                SetAngle(this.flickAngle);
            }
            else if(myTouch.phase == TouchPhase.Ended)
            {
                SetAngle(this.defaultAngle);
            }
        }
        
	}

    public void SetAngle(float angle)
    {
        
        JointSpring jointSpr = this.myHingeJoint.spring;  //現在のダンパーの状態を記憶
        jointSpr.targetPosition = angle;                  //ダンパーの位置を動かす
        this.myHingeJoint.spring = jointSpr;              //ダンパーの位置を元に戻す
    }
}
