using System;
using System.Globalization;
using Unity.Netcode;
using UnityEngine;

public class scr : NetworkBehaviour
{
    public static stats playerstats = new stats(20, 5, 23, 5);
    public static int playerhp;
    public int playerxp;
    public int playerlevel;
    public static int requiredxp;
    public GameObject atak;
    private Timers timer1 = new Timers(0.5F);
    private GameObject clone;
    private Rigidbody2D rb;
    MainCam mainCam;
    Camera cam;
    Canvas canvas;
    public float Speed;
    public static bool facingright = true;
    float cooldown = 1;
    float cooldown2 = 0.5F;
    float nextfire = 0;
    bool isdashing = false;
    public static weapon equipedweapon = swords.sword;
    void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        canvas = GetComponentInChildren<Canvas>();
        cam = GetComponentInChildren<Camera>();
        mainCam = GetComponentInChildren<MainCam>();
    }
    // Start is called before the first frame update
    void Start()
    {
        SetStats();
        if (IsLocalPlayer) return;
        cam.enabled = false;
        canvas.enabled = false;
    }

// do all the definingb
    // Update is called once per frame
    void Update()
    {
        if (!IsLocalPlayer) return;
        levelup();
        attack();
        movement();
        timer1.countdown();
        if (Time.time <= nextfire){
            clone.transform.position = transform.position;
        }
    }
    public void SetStats()
    {
        if (!IsLocalPlayer) return;
        playerhp = playerstats.GetHp();
        playerxp = 0;
        playerlevel = 1;
        requiredxp = 26;
        SetStatsServerRpc(playerstats.GetHp(), 0, 1, 26);
    }
    [ServerRpc]
    public void SetStatsServerRpc(int hp, int xp, int level, int Rxp)
    {
        if (!IsLocalPlayer) {
            playerhp = hp;
            playerxp = xp;
            playerlevel = level;
            requiredxp = Rxp;
        }
        SetStatsClientRpc(playerstats.GetHp(), 0, 1, 26);
    }
    [ClientRpc] public void SetStatsClientRpc(int hp, int xp, int level, int Rxp)
    {
        if (!IsLocalPlayer && !IsServer) {
        playerhp = hp;
        playerxp = xp;
        playerlevel = level;
        requiredxp = Rxp;
        }
    }
    void OnCollisionEnter2D(Collision2D col){
        if(!IsLocalPlayer) return;
        if (col.collider.tag == "Enemy")
        {
            playerhp -= goop.goopstats.GetPow();
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
        if(Input.GetKeyDown(KeyCode.Space) && timer1.timer == 0){
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
            rb.bodyType = RigidbodyType2D.Static;
        }
        if (x < 0 && facingright){
            flip();
            mainCam.FlipCam();
        }
        else if(x > 0 && !facingright) {
            flip();
            mainCam.FlipCam();
        }
        
    }



    void attack()
    {
        if (Time.time > nextfire)
        {
            if (Input.GetKey(KeyCode.Mouse0))
            {
                clone = (GameObject)Instantiate(atak, transform.position, Quaternion.identity);
                clone.transform.SetParent(transform);
                Destroy(clone, 0.4F);
                nextfire = Time.time + cooldown;
                if (!facingright)
                {
                    flipatak();
                }
            }
        }
    }
    [ClientRpc]
    void attackClientRpc()
    {
        if (!IsLocalPlayer) return;
        clone = (GameObject)Instantiate(atak, transform.position, Quaternion.identity);
        clone.GetComponent<NetworkObject>().Spawn();
        clone.transform.SetParent(transform);
        Destroy(clone, 0.4F);
        clone.GetComponent <NetworkObject>().Despawn();
        nextfire = Time.time + cooldown;
        if (!facingright)
        {
            flipatak();
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
