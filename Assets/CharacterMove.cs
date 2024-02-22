using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterMove : MonoBehaviour
{
    private Rigidbody2D rigid;
    private float horiz;
    // private float vert;
    public float speed;
    public float jump;

    public bool inAir;
    // Start is called before the first frame update
    void Start()
    {
        rigid = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        horiz = Input.GetAxis("Horizontal");
        // vert = Input.GetAxis("Vertical");
        rigid.velocity = new Vector2(speed * horiz, rigid.velocity.y);

        if (inAir == false && Input.GetButtonDown("Vertical")){
            rigid.AddForce(new Vector2(rigid.velocity.x, jump));
        }

    }

    private void OnCollisionEnter2D(Collision2D other) {
        if (other.gameObject.CompareTag("Floor")) {
            inAir = false;
        }
    }

    private void OnCollisionExit2D(Collision2D other) {
        if (other.gameObject.CompareTag("Floor")) {
            inAir = true;
        }
    }
}
