using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CloudController : MonoBehaviour {

    private float minimun = 1.0f;          //大きさの最低値
    private float magSpeed = 10.0f;        //大きさの変化の速度
    private float magnification = 0.07f;   //変化倍率
    
    // Use this for initialization
	void Start () {
        magSpeed = Random.Range(3.0f, 10.0f);    //変加速度をランダムに決定
	}
	
	// Update is called once per frame
	void Update () {
        //オブジェクトの x,z のスケールを変化させる
        this.transform.localScale = new Vector3( this.minimun + Mathf.Sin(Time.time * this.magSpeed) * this.magnification, this.transform.localScale.y, this.minimun + Mathf.Sin(Time.time * this.magSpeed) * this.magnification);
	}
}
