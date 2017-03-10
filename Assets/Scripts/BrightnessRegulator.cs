using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BrightnessRegulator : MonoBehaviour {

    Material myMaterial;                //Materialを入れる

    private float miniEmission = 0.3f;  //Emissionの最小値
    private float magEmission = 2.0f;   //Emissionの強度
    private int degree = 0;             //角度
    private int speed = 10;             //発光速度
    Color defaultColor = Color.white;   //ターゲットのデフォルトの色
    

    // Use this for initialization
	void Start () {

        //タグごとのデフォルトカラー
        if(tag == "SmallStarTag")
        {
            this.defaultColor = Color.white;
        }
        else if(tag == "LargeStarTag")
        {
            this.defaultColor = Color.yellow;
        }
        else if(tag == "SmallCloudTag" || tag == "LargeCloudTag")
        {
            this.defaultColor = Color.red;
        }
        
        //オブジェクトのマテリアルを変更
        this.myMaterial = GetComponent<Renderer>().material;
        //オブジェクトの初期色をセット！
        myMaterial.SetColor("_EmissionColor", this.defaultColor * miniEmission);


	}
	
	// Update is called once per frame
	void Update () {
        
        //発光しているとき
        if (this.degree >= 0)
        {
            //光の値を設定
            Color emissionColor = this.defaultColor * (this.miniEmission + Mathf.Sin(this.degree * Mathf.Deg2Rad) * this.magEmission);
            myMaterial.SetColor("_EmissionColor", emissionColor);     //光らせる
            this.degree -= this.speed;                                //光を弱める

        }
        
	}

    //衝突時呼ばれる関数
    void OnCollisionEnter(Collision other)
    {
        //角度を180に設定
        this.degree = 180;
    }
}
