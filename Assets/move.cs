using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class move : MonoBehaviour
{
public float speed = 2.0f;
private Vector2 inputAxis;
Animator anim;
private Rigidbody2D rb;

    // Start is called before the first frame update
    void Start()
    {
        anim = GetComponent<Animator>();
        rb = GetComponent<Rigidbody2D>();
        
    }

    // Update is called once per frame
    void Update()
    {
        inputAxis.x = Input.GetAxisRaw("Horizontal");
        inputAxis.y = Input.GetAxisRaw("Vertical");
        setAnim(inputAxis);
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
}
