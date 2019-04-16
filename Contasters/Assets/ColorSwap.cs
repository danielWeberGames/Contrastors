using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ColorSwap : MonoBehaviour {

    float hue, s, v;
    public Color myColor;
    float changingValue;
    SpriteRenderer sr;

    public float incrument;

    public string inputAxis;
    public string inputAction;

	// Use this for initialization
	void Start () {
        sr = GetComponent<SpriteRenderer>();
        myColor = sr.color;
        Color.RGBToHSV(myColor, out hue, out s, out v);
        changingValue = s;
	}
	
	// Update is called once per frame
	void Update () {

        if (Input.GetButtonDown(inputAction))
        {
            if(Input.GetAxis(inputAxis) >0 || Input.GetAxis(inputAxis) < 0)
            {
                int dir = Mathf.RoundToInt(Input.GetAxisRaw(inputAxis));
                Debug.Log(dir);
                ChangeColor(dir);
            }
        }

	}

    void ChangeColor(int dir)
    {
        if (dir > 0 && changingValue<1 || dir <0 && changingValue >0)
        {
            s += incrument * dir;
            changingValue = s;
            
            myColor = Color.HSVToRGB(hue, s, v);
            sr.color = myColor;
        }
    }





}
