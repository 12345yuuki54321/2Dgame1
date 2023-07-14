using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

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
public bool takara = false;
Transform tr;
Object_date od;

    // Start is called before the first frame update
    void Start()
    {
        anim = GetComponent<Animator>();
        rb = GetComponent<Rigidbody2D>();
        panel.SetActive(false);
        takara = false;
    }

    // Update is called once per frame
    void Update()
    {
        inputAxis.x = Input.GetAxisRaw("Horizontal");
        inputAxis.y = Input.GetAxisRaw("Vertical");
        setAnim(inputAxis);

        if (Input.GetKeyDown(KeyCode.E) && contact){
            name.text = od.name;
            if(takara && od.talk_count == 0 && od.name == "敵"){
                od.talk_count = 1;
            }
            if(od.name == "goal"){

            }
            mesege.text = od.talk[od.talk_count];
            panel.SetActive(true);
            if(od.name == "宝箱"){
            takara = true;
            od.talk_count = 1;
            }
        }
    else if(!contact){
        panel.SetActive(false);
        if(od != null && od.name == "敵" && od.talk_count == 1){
            tr.Translate(-2, 0, 0);
            od.talk_count = 2;
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
        od = other.gameObject.GetComponent<Object_date>();
    }

    private void OnCollisionExit2D(Collision2D other){
        contact = false;
    }
}
