using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Networking;
using UnityEngine.Analytics;

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
            StartCoroutine(TrackJump());
            inAir = true;

        }
    }

    private IEnumerator TrackJump() {
            string URL = "https://docs.google.com/forms/u/0/d/e/1FAIpQLSfdji8CdwfD0zEitXGcs9aKSgTElXx9be91O2GoFA4cC7MS1Q/formResponse";
            WWWForm form = new WWWForm();
            form.AddField("entry.304903029", AnalyticsSessionInfo.sessionId.ToString());
            form.AddField("entry.672846850", "Jump - " + SceneManager.GetActiveScene().name);
            UnityWebRequest www = UnityWebRequest.Post(URL, form);
            yield return www.SendWebRequest();
    }
}
