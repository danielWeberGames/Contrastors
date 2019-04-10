using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ColorSwap : MonoBehaviour {

    float hue, s, v;
    public Color myColor;
    float changingValue;
    SpriteRenderer sr;

    public float incrument;

    public int playerNum;
	// Use this for initialization
	void Start () {
        sr = GetComponent<SpriteRenderer>();
        myColor = sr.color;
        Color.RGBToHSV(myColor, out hue, out s, out v);
	}
	
	// Update is called once per frame
	void Update () {

        if (Input.GetButtonDown("Jump"))
        {
            if(Input.GetAxis("Vertical") > 0)
            {
                ChangeColor(1);
            }else if (Input.GetAxis("Vertical") < 0)
            {
                ChangeColor(-1);
            }
        }

	}

    void ChangeColor(int dir)
    {
        if (dir > 0 && changingValue<1 || dir <0 && changingValue >0)
        {
            if (playerNum > 0)
            {
                s += incrument * dir;
                changingValue = s;
            }else
            {
                v += incrument * dir;
                changingValue = v;
            }
            myColor = Color.HSVToRGB(hue, s, v);
            sr.color = myColor;
        }
    }





}
