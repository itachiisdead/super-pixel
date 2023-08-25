using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class player_movement : MonoBehaviour
{
    private Rigidbody2D rb;
    private BoxCollider2D coll;
    private SpriteRenderer sprite;
    private Animator anim;

    [SerializeField] private LayerMask jumpableground;

    [SerializeField] private float move_spped=7f;
    [SerializeField] private float jump_force = 14f;

    private enum movement_state {idle, run ,jump ,fall };
    
    private float x_dir =0f ;

    [SerializeField] private AudioSource jumpeffect;
    // Start is called before the first frame update
    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        coll = GetComponent<BoxCollider2D>();
        sprite = GetComponent<SpriteRenderer>();
        anim= GetComponent<Animator>();
    }

    // Update is called once per frame
    private void Update()
    {
        x_dir = Input.GetAxisRaw("Horizontal");
        rb.velocity = new Vector2(x_dir * move_spped,rb.velocity.y);

        if (Input.GetButtonDown("Jump") && isgronded())
        {
            jumpeffect.Play();
            rb.velocity = new Vector2(rb.velocity.x, jump_force);
        }

        update_anim_state();
    }
    private void update_anim_state()
    {
        movement_state state;
        if (x_dir > 0f)
        {
            state= movement_state.run;
            sprite.flipX = false;
        }
        else if (x_dir < 0f)
        {
            state = movement_state.run;
            sprite.flipX = true;

        }
        else
            state = movement_state.idle;

        if(rb.velocity.y >.1f)
            state = movement_state.jump;

        else if (rb.velocity.y < -.1f)
            state = movement_state.fall;

        anim.SetInteger("state", (int)state); 

    }

    private bool isgronded()
    {
       return Physics2D.BoxCast(coll.bounds.center, coll.bounds.size, 0f, Vector2.down, .1f, jumpableground);

    }

}
