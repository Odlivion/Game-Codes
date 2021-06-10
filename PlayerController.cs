using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    // Tehdään pelihahmosta Singelton
    public static PlayerController instance;

    // Liikemuuttujat
    public float moveSpeed;         // pelihahmon nopeus x-akselin suunnassa
    public float jumpForce;         // pelihahmon hyppynopeus

    // Näppäinmuttujat
    public KeyCode left;    // näppäin, joka liikuttaa pelihahmoa vasemmalle
    public KeyCode right;   // näppäin, joka liikuttaa pelihahmoa oikealle
    public KeyCode jump;    // näppäin, joka hypyyttää pelihahmoa

    // Parempi hyppy
    // private float fallMultiplier = 4f;  // Mitä suurempi arvo sen nopeammin tullaan alas (1=normitila)
    // private float lowJumpMultiplier = 2f;  // Mitä suurempi arvo sitä pienempi hyppy (1=normitila)

    // Referenssi fysiikkamoottoriin
    public Rigidbody2D rb2d;

    // Referenssi piirtokomponentiin
    private SpriteRenderer spriteRenderer;

    public Animator MyAnim { get; set; }

    // Voiko pelihahmo liikkua
    public bool MyCanMove { get; set; }

    // Hyppyyn liittyvät muuttujat
    public Transform groundCheckpoint;
    public float groundCheckRadius;
    public LayerMask whatIsGround;
    private bool isGround;              // Jos IsGround=true, niin että ollaan maassa

    // Start is called before the first frame update
    void Start()
    {

        // Otetaan Singelton käyttöön
        instance = this;

        // Luodaan yhteys pelihahmon fysiikkamoottoriin
        rb2d = GetComponent<Rigidbody2D>();

        // Luodaan yhteys pelihahmon piirtokomponenttiin
        spriteRenderer = GetComponent<SpriteRenderer>();

        // Luodaan yhteys animaattoriin
        MyAnim = GetComponent<Animator>();

        // Pelihahmo voi liikkua oletuksena
        MyCanMove = true;

    }

    // Update is called once per frame
    void Update()
    {
        // Voiko pelihahmo liikkua? false = ei voi, tämä tieto saadaan PuzzleControllerilta
       // if (MyCanMove == false)
        //{
            // Ei voi, joten estetään pelihahmon liike ja hypätään Update-metodista pois
          //  rb2d.velocity = Vector2.zero;
           // return;
        //}

        // Tutkitaan onko kurpitsapoika maassa vai ilmassa.
        // Ilmassa silloin kun isGround = false ja maassa kun isGround = true;
        isGround = Physics2D.OverlapCircle(groundCheckpoint.position, groundCheckRadius, whatIsGround);

        // Liikutetaan pelihahmoa
        MovePlayer();

        // Käsittele animaatiot
        HandleAnimation();

    }

    private void HandleAnimation()
    {
        MyAnim.SetFloat("Speed", Mathf.Abs(rb2d.velocity.x));

        MyAnim.SetBool("Grounded", isGround);
    }

    private void MovePlayer()
    {
        // Liikkuuko pelihahmo vasemmalle?
        if (Input.GetKey(left))
        {
            // Kyllä, joten suoritetaan liike
            rb2d.velocity = new Vector2(-moveSpeed, rb2d.velocity.y);
            // Varmistetaan että pelihahmo katsoo menosuuntaan            
            spriteRenderer.flipX = true;


        }
        // Liikutaanko oikealle?
        else if (Input.GetKey(right))
        {
            // Kyllä, joten suoritetaan liike
            rb2d.velocity = new Vector2(moveSpeed, rb2d.velocity.y);
            // Varmistetaan että pelihahmo katsoo menosuuntaan
            spriteRenderer.flipX = false;


        }
        else
        {

            // Onko vielä ilmassa?
            if (rb2d.velocity.y != 0)
            {
                // Kyllä, joten liike jatkuu
                rb2d.velocity = new Vector2(rb2d.velocity.x, rb2d.velocity.y);
                isGround = false;
            }
            else
            {
                // Ei, joten liike päättyy
                rb2d.velocity = new Vector2(0, rb2d.velocity.y);
                isGround = true;
            }
        }
        // Painettiinko hyppypainiketta?
        if (Input.GetKeyDown(KeyCode.Space) && isGround)
        {
            // Kyllä, joten pelihahmo hyppää
            rb2d.velocity = new Vector2(rb2d.velocity.x, jumpForce);
            //isGround = true;
        }
    }

    private void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.tag == "Ground")
            isGround = true;
    }

}
