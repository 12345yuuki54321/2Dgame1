using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class move : MonoBehaviour
{
public float speed = 2.0f;
private Vector2 inputAxis;
Animator anim;
private Rigidbody2D rb;

public bool contact = false;
public GameObject panel;
public Text name;
public Text mesege;
public bool takara1 = false;
Transform tr;
enemy_takara et;

    // Start is called before the first frame update
    void Start()
    {
        anim = GetComponent<Animator>();
        rb = GetComponent<Rigidbody2D>();
        panel.SetActive(false);
        takara1 = false;
    }

    // Update is called once per frame
    void Update()
    {
        inputAxis.x = Input.GetAxisRaw("Horizontal");
        inputAxis.y = Input.GetAxisRaw("Vertical");
        setAnim(inputAxis);
        
        if(Input.GetkeyDown(keyCode.T) && contact){
            name.text = et.name;
            if(takara1 && et.talk_count == 0 && et.name == "enemy1"){
                et.talk_count = 1;
            }
            if(et.name = "goal"){
                
            }
            mesege.text = et.talk[et.talk_count];
            panel.SetActive(true);
            if(et.name == "宝箱"){
                takara1 = true;
                et.talk_count = 1;
            }
        }
        else if(!contact){
            panel.SetActive(false);
            if(et.name == "enemy" && et.talk_count == 1){
                tr.Translate(0, 1, 0);
                et.talk_count = 2;
            }
        }
    }
    
    private void FixedUpdate(){
        rb.velocity = inputAxis * speed;
    }
    
    public void setAnim(Vector2 vec2){
        if(vec2 == Vector2.zero){
            anim.speed = 0.0f;
            return;
        }
        anim.speed = 1.0f;
        anim.SetFloat("x",vec2.x);
        anim.SetFloat("y",vec2.y);
    }
    
    private void OnCollisionEnter2D(Collision2D other){
        contact = true;
        tr = other.gameObject.GetComponent<Transform>();
        et = other.gameObject.GetComponent<enemy_takara>();
    }
    
    private void OnCollisionExit2D(Collision other){
        contact = false;
    }
}
