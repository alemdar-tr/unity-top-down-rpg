using System;
using Unity.Netcode;
using UnityEngine;

public class scr : NetworkBehaviour
{
    public static stats playerstats = new stats(20, 5, 23, 5);
    public static int playerhp = playerstats.GetHp();
    public static int playerxp = 0;
    public static int playerlevel = 1;
    static int requiredxp = 26 * (int)Math.Pow(2, playerlevel - 1);
    public GameObject atak;
    private Timers timer1 = new Timers();
    private GameObject clone;
    private Rigidbody2D rb;
    public float Speed;
    bool facingright = true;
    float cooldown = 0.4F;
    float cooldown2 = 0.5F;
    float nextfire = 0;
    bool isdashing = false;
    public static weapon equipedweapon = swords.sword;
    // Start is called before the first frame update
    void Start()
    {

    }

    private void Awake(){
        rb = GetComponent<Rigidbody2D>();
    }

// do all the definingb
    // Update is called once per frame
    void Update()
    {
        if (!IsOwner) return;
        attack();
        movement();
        levelup();
        timer1.countdown();
        Debug.Log(playerxp + ", " + requiredxp + ", " + playerlevel);
        if (Time.time <= nextfire){
            clone.transform.position = transform.position;
        }
    }
    void levelup(){
        if (playerxp >= requiredxp){
            playerxp -= requiredxp;
            playerlevel += 1;
            requiredxp = 26 * (int)Math.Pow(2, playerlevel - 1);
        }
    }

    private void movement() {
        if(Input.GetKey(KeyCode.Space) && timer1.timer == 0){
            Speed *= 5;
            timer1.timer = cooldown2;
            isdashing = true;
        }
        if(timer1.timer < 0.1 && isdashing == true){
            Speed /= 5;
            isdashing = false;
        }
        float y = Input.GetAxis("Vertical");
        float x = Input.GetAxis("Horizontal");
        Vector2 mov = new Vector2(x, y) * Speed;
        if (x > 0 || y > 0 || x < 0 || y <0){
            rb.bodyType = RigidbodyType2D.Dynamic;
            rb.velocity = mov;
        }
        else{
            rb.bodyType = RigidbodyType2D.Kinematic;
        }
        if (x < 0 && facingright){
            flip();
        }
        else if(x > 0 && !facingright) {
            flip();
        }
        
    }

    void attack() {
        if (Time.time > nextfire){
            if (Input.GetKey(KeyCode.Mouse0)) {
                clone = (GameObject)Instantiate(atak, transform.position, Quaternion.identity);
                clone.transform.position= transform.position;
                Destroy(clone, 0.4F);
                nextfire = Time.time + cooldown;
                if(!facingright){
                    flipatak();
                }
            }
        }
    }

    void flip() {
        Vector3 curruntscale = gameObject.transform.localScale;
        curruntscale.x *= -1;
        gameObject.transform.localScale = curruntscale;

        facingright = !facingright;
    }
    void flipatak(){
        Vector3 currentside = clone.gameObject.transform.localScale;
        currentside *= -1;
        clone.gameObject.transform.localScale = currentside;
    }


}
