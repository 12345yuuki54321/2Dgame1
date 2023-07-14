using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Object_date: MonoBehaviour
{
    public string name = "";
    public string[] talk = {};
    public int talk_count = 0;
    SpriteRenderer sr;
    public Sprite[] skin;
    // Start is called before the first frame update
    void Start()
    {
        sr = GetComponent<SpriteRenderer>();

    }

    // Update is called once per frame
    void Update()
    {
        sr.sprite = skin[talk_count];
        
    }
}
