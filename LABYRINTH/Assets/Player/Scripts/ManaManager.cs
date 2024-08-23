using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using Unity.VisualScripting;

public class ManaManager : MonoBehaviour
{
    public float manamax;
    public float mana;
    public float regen;
    public Image Manabar;
    public TMP_Text Manatext;
    public float initwidth;
    public bool doneyet;
    public KeyCode fireball;
    public KeyCode bigfireballk;
    public KeyCode explodek;
    public KeyCode toggles;
    public KeyCode be;
    public KeyCode beam;
    public KeyCode lightning;
    public KeyCode heal;
    public KeyCode vort;
    public KeyCode ts;
    public KeyCode dagge;
    public GameObject Fireball;
    public GameObject bigfireball;
    public GameObject explosion;
    public GameObject beamp;
    public GameObject bolt;
    public GameObject healthanim;
    public GameObject vortex;
    public Animator anim;
    public string animst;
    public float sfbc;
    public float lfbc;
    public float spc;
    public float expc;
    public float bowc;
    public float beac;
    public float boltc;
    public float healc;
    public float heala;
    public float vortc;
    public float tsc;
    public float daggc;
    public Transform Player;
    public float res;
    public GameObject Ab1;
    public GameObject Ab2;
    public GameObject Ab3;
    public GameObject Pa;
    public GameObject swa;
    public GameObject boa;
    public KeyCode fly;
    public float flyc;
    public KeyCode Damaura;
    public KeyCode Heaura;
    public KeyCode fraura;
    public KeyCode Laura;
    public float dac;
    public float hac;
    public float fac;
    public float lac;
    public bool daura;
    public bool heaura;
    public bool fraur;
    public bool lsaura;
    public float heamt;
    public float damut;
    public float framt;
    public float frite;
    public GameObject lighte;
    public KeyCode frs;
    public bool freeze;
    public float frc;
    public KeyCode lssw;
    public KeyCode manas;
    public bool lss;
    public bool manass;
    public float lsamt;
    public float mansamt;
    public KeyCode Home;
    public bool aim;
    public KeyCode tp;
    public bool tele;
    public KeyCode ghostt;
    public bool ghosta;
    public float aimc;
    public float tpc;
    public float ghoc;
    public TMP_Text abilitystatus;
    public string abistat;
    public bool manablock;
    public KeyCode mbtog;
    public float mbc;
    public bool counterattack;
    public KeyCode catk;
    public float catc;
    public PhysicsMaterial2D shield;
    // Start is called before the first frame update
    void Start()
    {
        manamax = GetComponent<StatManager>().manafree;
        regen = GetComponent<StatManager>().manaR;
        mana = manamax;
        initwidth = Manabar.rectTransform.rect.width;
        anim = GetComponent<Animator>();
        GetComponent<Movement>().swingcost = spc;
        Player = GameObject.FindWithTag("Player").transform;
    }

    // Update is called once per frame
    private void FixedUpdate()
    {
        if (mana < manamax)
        {
            mana += regen / 25;
        }
        if (mana > manamax)
        {
            mana = manamax;
        }
        if (mana < 0)
        {
            mana = 0;
        }
        if (daura == true && mana >= dac * 0.02f)
        {
            lighte.GetComponent<SpriteRenderer>().color = Color.red;
            mana -= dac * 0.02f;
            GameObject[] enemies = GameObject.FindGameObjectsWithTag("Enemy");
            foreach (GameObject enemy in enemies)
            {
                if (Vector3.Distance(transform.position, enemy.transform.position) < 5)
                {
                    if ((enemy.GetComponent<SlimeDamage>() != null))
                        enemy.GetComponent<SlimeDamage>().damage += damut * ((manamax / 5 + 80)) / 2;
                    if ((enemy.GetComponent<SnakeDamage>() != null))
                        enemy.GetComponent<SnakeDamage>().damage += damut * ((manamax / 5 + 80)) / 2;
                    if ((enemy.GetComponent<LADamage>() != null))
                        enemy.GetComponent<LADamage>().damage += damut * ((manamax / 5 + 80)) / 2;
                    if ((enemy.GetComponent<SpawnerDamage>() != null))
                        enemy.GetComponent<SpawnerDamage>().damage += damut * ((manamax / 5 + 80)) / 2;
                }
            }
        } else if (heaura == true && mana >= hac * 0.02f)
        {
            lighte.GetComponent<SpriteRenderer>().color = new Color(1, 0.5f, 0.5f);
            if (GetComponent<PlayerDamage>().health < GetComponent<PlayerDamage>().maxhealth) {
                mana -= hac * 0.02f;
                GetComponent<PlayerDamage>().health += heamt * 0.0002f * GetComponent<PlayerDamage>().maxhealth;
            }
        } else if (fraur == true && mana >= fac) {
            if (frite > 0)
            {
                frite -= 1;
            }
            if (frite == 0)
            {
                mana -= fac;
                GameObject[] enemies = GameObject.FindGameObjectsWithTag("Enemy");
                foreach (GameObject enemy in enemies)
                {
                    if (Vector3.Distance(transform.position, enemy.transform.position) < 5)
                    {
                        enemy.GetComponent<FreezeManager>().freezeTime += framt;
                    }
                }
                frite = 100;
            }
            lighte.GetComponent<SpriteRenderer>().color = new Color(0.5f, 0.8f, 1f);
        } else if (lsaura == true && mana >= (dac + hac) * 0.02f)
        {
            lighte.GetComponent<SpriteRenderer>().color = Color.red;
            mana -= dac * 0.02f;
            GameObject[] enemies = GameObject.FindGameObjectsWithTag("Enemy");
            foreach (GameObject enemy in enemies)
            {
                if (Vector3.Distance(transform.position, enemy.transform.position) < 5)
                {
                    if ((enemy.GetComponent<SlimeDamage>() != null))
                        enemy.GetComponent<SlimeDamage>().damage += damut * ((manamax / 5 + 80)) / 2;
                    if ((enemy.GetComponent<SnakeDamage>() != null))
                        enemy.GetComponent<SnakeDamage>().damage += damut * ((manamax / 5 + 80)) / 2;
                    if ((enemy.GetComponent<LADamage>() != null))
                        enemy.GetComponent<LADamage>().damage += damut * ((manamax / 5 + 80)) / 2;
                    if ((enemy.GetComponent<SpawnerDamage>() != null))
                        enemy.GetComponent<SpawnerDamage>().damage += damut * ((manamax / 5 + 80)) / 2;
                }
            }
            if (GetComponent<PlayerDamage>().health < GetComponent<PlayerDamage>().maxhealth)
            {
                mana -= hac * 0.02f;
                GetComponent<PlayerDamage>().health += heamt * 0.0002f * GetComponent<PlayerDamage>().maxhealth;
            }

        } else
        {
            lighte.GetComponent<SpriteRenderer>().color = Color.white;
            daura = false;
            heaura = false;
            fraur = false;
            lsaura = false;
        }
    }

    void Update()
    {
        abistat = "Passive - ";
        if (daura == true || fraur == true || heaura == true || GetComponent<Movement>().fly == true || lsaura == true)
        {
            abistat = abistat + "Enabled\n";
        } else
        {
            abistat = abistat + "Disabled\n";
        }
        abistat = abistat + "Sword - ";
        if (GetComponent<Movement>().swordproj == true || manass == true || freeze == true || GetComponent<Movement>().daggers == true || lss == true)
        {
            abistat = abistat + "Enabled\n";
        }
        else
        {
            abistat = abistat + "Disabled\n";
        }
        abistat = abistat + "Bow - ";
        if (GetComponent<Movement>().bowexp == true || ghosta == true || tele == true || GetComponent<Movement>().tripleshot == true || aim == true)
        {
            abistat = abistat + "Enabled\n";
        }
        else
        {
            abistat = abistat + "Disabled\n";
        }
        abilitystatus.text = abistat;


        if (Ab1.GetComponent<AbilitySlot>().id_self == 1)
        {
            fireball = KeyCode.F;
        } else if (Ab2.GetComponent<AbilitySlot>().id_self == 1) {
            fireball = KeyCode.R;
        }
        else if (Ab3.GetComponent<AbilitySlot>().id_self == 1)
        {
            fireball = KeyCode.C;
        } else
        {
            fireball = KeyCode.None;
        }
        if (Ab1.GetComponent<AbilitySlot>().id_self == 2)
        {
            bigfireballk = KeyCode.F;
        }
        else if (Ab2.GetComponent<AbilitySlot>().id_self == 2)
        {
            bigfireballk = KeyCode.R;
        }
        else if (Ab3.GetComponent<AbilitySlot>().id_self == 2)
        {
            bigfireballk = KeyCode.C;
        }
        else
        {
            bigfireballk = KeyCode.None;
        }
        if (Ab1.GetComponent<AbilitySlot>().id_self == 3)
        {
            explodek = KeyCode.F;
        }
        else if (Ab2.GetComponent<AbilitySlot>().id_self == 3)
        {
            explodek = KeyCode.R;
        }
        else if (Ab3.GetComponent<AbilitySlot>().id_self == 3)
        {
            explodek = KeyCode.C;
        }
        else
        {
            explodek = KeyCode.None;
        }
        if (Ab1.GetComponent<AbilitySlot>().id_self == 4)
        {
            beam = KeyCode.F;
        }
        else if (Ab2.GetComponent<AbilitySlot>().id_self == 4)
        {
            beam = KeyCode.R;
        }
        else if (Ab3.GetComponent<AbilitySlot>().id_self == 4)
        {
            beam = KeyCode.C;
        }
        else
        {
            beam = KeyCode.None;
        }
        if (Ab1.GetComponent<AbilitySlot>().id_self ==5)
        {
            lightning = KeyCode.F;
        }
        else if (Ab2.GetComponent<AbilitySlot>().id_self == 5)
        {
            lightning = KeyCode.R;
        }
        else if (Ab3.GetComponent<AbilitySlot>().id_self == 5)
        {
            lightning = KeyCode.C;
        }
        else
        {
            lightning = KeyCode.None;
        }
        if (Ab1.GetComponent<AbilitySlot>().id_self == 6)
        {
            heal = KeyCode.F;
        }
        else if (Ab2.GetComponent<AbilitySlot>().id_self == 6)
        {
            heal = KeyCode.R;
        }
        else if (Ab3.GetComponent<AbilitySlot>().id_self == 6)
        {
            heal = KeyCode.C;
        }
        else
        {
            heal = KeyCode.None;
        }
        if (Ab1.GetComponent<AbilitySlot>().id_self == 7)
        {
            vort = KeyCode.F;
        }
        else if (Ab2.GetComponent<AbilitySlot>().id_self == 7)
        {
            vort = KeyCode.R;
        }
        else if (Ab3.GetComponent<AbilitySlot>().id_self == 7)
        {
            vort = KeyCode.C;
        }
        else
        {
            vort = KeyCode.None;
        }
        if(Pa.GetComponent<AbilitySlot>().id_self == 1)
        {
            Damaura = KeyCode.V;
        } else
        {
            Damaura = KeyCode.None;
            daura = false;
        }
        if (Pa.GetComponent<AbilitySlot>().id_self == 2)
        {
            Heaura = KeyCode.V;
        }
        else
        {
            Heaura = KeyCode.None;
            heaura = false;
        }
        if (Pa.GetComponent<AbilitySlot>().id_self == 3)
        {
            fraura = KeyCode.V;
        }
        else
        {
            fraura = KeyCode.None;
            fraur = false;
        }
        if (Pa.GetComponent<AbilitySlot>().id_self == 4)
        {
            Laura = KeyCode.V;
        }
        else
        {
            Laura = KeyCode.None;
            lsaura = false;
        }
        if (Pa.GetComponent<AbilitySlot>().id_self == 5)
        {
            fly = KeyCode.V;
        }
        else
        {
            fly = KeyCode.None;
            GetComponent<Movement>().fly = false;
        }
        if (swa.GetComponent<AbilitySlot>().id_self == 1)
        {
            dagge = KeyCode.G;
        }
        else
        {
            dagge = KeyCode.None;
            GetComponent<Movement>().daggers = false;
        }
        if (swa.GetComponent<AbilitySlot>().id_self == 2)
        {
            toggles = KeyCode.G;
        }
        else
        {
            toggles = KeyCode.None;
            GetComponent<Movement>().swordproj = false;
        }
        if (swa.GetComponent<AbilitySlot>().id_self == 3)
        {
            frs = KeyCode.G;
            
        }
        else
        {
            frs = KeyCode.None;
            freeze = false;
        }
        if (swa.GetComponent<AbilitySlot>().id_self == 4)
        {
            manas = KeyCode.G;
            
        }
        else
        {
            manas = KeyCode.None;
            manass = false;
        }
        if (swa.GetComponent<AbilitySlot>().id_self == 5)
        {
            lssw = KeyCode.G;
            
        }
        else
        {
            lssw = KeyCode.None;
            lss = false;
        }
        if (boa.GetComponent<AbilitySlot>().id_self == 1)
        {
            ghostt = KeyCode.B;
        }
        else
        {
            ghostt = KeyCode.None;
            ghosta = false;
        }
        if (boa.GetComponent<AbilitySlot>().id_self == 2)
        {
            be = KeyCode.B;
        }
        else
        {
            be = KeyCode.None;
            GetComponent<Movement>().bowexp = false;
        }
        if (boa.GetComponent<AbilitySlot>().id_self == 3)
        {
            ts = KeyCode.B;

        }
        else
        {
            ts = KeyCode.None;
            GetComponent<Movement>().tripleshot = false;
        }
        if (boa.GetComponent<AbilitySlot>().id_self == 4)
        {
            tp = KeyCode.B;

        }
        else
        {
            tp = KeyCode.None;
            tele = false;
        }
        if (boa.GetComponent<AbilitySlot>().id_self == 5)
        {
            Home = KeyCode.B;

        }
        else
        {
            Home = KeyCode.None;
            aim = false;
        }
        if (lss == true)
        {
            gameObject.GetComponent<SpriteRenderer>().color = new Color(1, 0.9f, 0.9f, 1);
        } else if (manass == true)
        {
            gameObject.GetComponent<SpriteRenderer>().color = new Color(0.9f, 1f, 1f, 1);
        }
        else
        {
            gameObject.GetComponent<SpriteRenderer>().color = Color.white;
        }
        res = Screen.width;
        if (Time.timeScale != 0)
        {
            if (Input.GetKeyDown(Damaura))
            {
                if (daura == true)
                {
                    daura = false;
                }
                else if (mana > dac)
                {
                    daura = true;
                }
            }
            if (Input.GetKeyDown(mbtog))
            {
                if (manablock == true)
                {
                    manablock = false;
                }
                else if (mana > dac)
                {
                    manablock = true;
                }
            }
            if (Input.GetKeyDown(catk))
            {
                if (counterattack == true)
                {
                    counterattack = false;
                    shield.friction = 0.6f;
                }
                else
                {
                    counterattack = true;
                    shield.friction = 0;
                }
            }
            if(counterattack == true)
            {
                shield.friction = 0.45f;
            }
            else
            {
                shield.friction = 0f;
            }
            if (mana <= mbc * 0.05f)
            {
                manablock = false;
            }
            if (Input.GetKeyDown(Home))
            {
                if (aim == true)
                {
                    aim = false;
                }
                else if (mana > aimc)
                {
                    aim = true;
                }
            }
            if (Input.GetKeyDown(tp))
            {
                if (tele == true)
                {
                    tele = false;
                }
                else if (mana > tpc)
                {
                    tele = true;
                }
            }
            if (Input.GetKeyDown(ghostt))
            {
                if (ghosta == true)
                {
                    ghosta = false;
                }
                else if (mana > ghoc)
                {
                    ghosta = true;
                }
            }
            if (Input.GetKeyDown(lssw))
            {
                if (lss == true)
                {
                    lss = false;
                }
                else
                {
                    lss = true;
                }
            }
            if (Input.GetKeyDown(manas))
            {
                if (manass == true)
                {
                    manass = false;
                }
                else
                {
                    manass = true;
                }
            }
            if (Input.GetKeyDown(frs))
            {
                if (freeze == true)
                {
                    freeze = false;
                }
                else if (mana > frc)
                {
                    freeze = true;
                }
            }
            if (Input.GetKeyDown(Laura))
            {
                if (lsaura == true)
                {
                    lsaura = false;
                }
                else if (mana > lac)
                {
                    lsaura = true;
                }
            }
            if (Input.GetKeyDown(Heaura))
            {
                if (heaura == true)
                {
                    heaura = false;
                }
                else if (mana > hac)
                {
                    heaura = true;
                }
            }
            if (Input.GetKeyDown(fraura))
            {
                if (fraur == true)
                {
                    fraur = false;
                }
                else if (mana > fac)
                {
                    fraur = true;
                }
            }
            if (Input.GetKeyDown(fly))
            {
                if (GetComponent<Movement>().fly == true)
                {
                    GetComponent<Movement>().fly = false;
                }
                else if(mana > flyc)
                {
                    GetComponent<Movement>().fly = true;
                }
            }
            if (Input.GetKeyDown(be))
            {
                if (GetComponent<Movement>().bowexp == true)
                {
                    GetComponent<Movement>().bowexp = false;
                }
                else
                {
                    GetComponent<Movement>().bowexp = true;
                }
            }
            if (Input.GetKeyDown(ts))
            {
                if (GetComponent<Movement>().tripleshot == true)
                {
                    GetComponent<Movement>().tripleshot = false;
                }
                else
                {
                    GetComponent<Movement>().tripleshot = true;
                }
            }
            if (Input.GetKeyDown(dagge))
            {
                if (GetComponent<Movement>().daggers == true)
                {
                    GetComponent<Movement>().daggers = false;
                }
                else
                {
                    GetComponent<Movement>().daggers = true;
                }
            }
            if (Input.GetKeyDown(heal) && mana >= healc * manamax && animst != "FwdSwing" && animst != "Jab" && animst != "UpJab" && animst != "DownSlash" && animst != "DownAir" && animst != "Nair" && animst != "Fair" && animst != "UpAir" && animst != "BowDraw" && animst != "BowFull" && animst != "NBow" && animst != "NBowFull" && anim.GetBool("Nbow") == false && anim.GetBool("BowF") == false && animst != "MagicCast")
            {
                if (manamax >= 100)
                {
                    anim.SetBool("Magic", true);
                    heala = healc * GetComponent<PlayerDamage>().maxhealth;
                    if (GetComponent<PlayerDamage>().maxhealth - GetComponent<PlayerDamage>().health >= heala)
                    {
                        GetComponent<PlayerDamage>().health += heala;
                    }
                    else
                    {
                        heala -= (GetComponent<PlayerDamage>().maxhealth - GetComponent<PlayerDamage>().health);
                        GetComponent<PlayerDamage>().health = GetComponent<PlayerDamage>().maxhealth;
                        GetComponent<PlayerDamage>().shield += heala;
                    }
                    mana -= healc * manamax;
                    Instantiate(healthanim, transform.position, Quaternion.identity);
                }
                else if (mana >= healc * 100)
                {
                    anim.SetBool("Magic", true);
                    heala = healc * GetComponent<PlayerDamage>().maxhealth;
                    if (GetComponent<PlayerDamage>().maxhealth - GetComponent<PlayerDamage>().health >= heala)
                    {
                        GetComponent<PlayerDamage>().health += heala;
                    }
                    else
                    {
                        heala -= (GetComponent<PlayerDamage>().maxhealth - GetComponent<PlayerDamage>().health);
                        GetComponent<PlayerDamage>().health = GetComponent<PlayerDamage>().maxhealth;
                        GetComponent<PlayerDamage>().shield += heala;
                    }
                    mana -= healc * 100;
                    Instantiate(healthanim, transform.position, Quaternion.identity);
                }
            }
            animst = anim.GetCurrentAnimatorClipInfo(0)[0].clip.name;
            if (manamax != 0 && doneyet == false)
            {
                mana = manamax;
                doneyet = true;
            }
            if (Input.GetKeyDown(toggles))
            {
                if (GetComponent<Movement>().swordproj == true)
                {
                    GetComponent<Movement>().swordproj = false;
                }
                else
                {
                    GetComponent<Movement>().swordproj = true;
                }
            }
            anim.SetBool("Magic", false);
            manamax = GetComponent<StatManager>().manafree;
            regen = GetComponent<StatManager>().manaR;
            
            Manatext.text = (Mathf.Round(mana * 10) / 10) + " / " + Mathf.Round(manamax * 10) / 10;
            if (Input.GetKeyDown(vort) && mana >= vortc && animst != "FwdSwing" && animst != "Jab" && animst != "UpJab" && animst != "DownSlash" && animst != "DownAir" && animst != "Nair" && animst != "Fair" && animst != "UpAir" && animst != "BowDraw" && animst != "BowFull" && animst != "NBow" && animst != "NBowFull" && anim.GetBool("Nbow") == false && anim.GetBool("BowF") == false && animst != "MagicCast")
            {
                mana -= vortc;
                anim.SetBool("Magic", true);
                if (GetComponent<Movement>().left == false)
                {
                    Instantiate(vortex, new Vector3(transform.position.x + 2, transform.position.y, 0), Quaternion.identity);
                }
                else
                {
                    Instantiate(vortex, new Vector3(transform.position.x - 2, transform.position.y, 0), Quaternion.identity);
                }
            }
            if (Input.GetKeyDown(fireball) && mana >= sfbc && animst != "FwdSwing" && animst != "Jab" && animst != "UpJab" && animst != "DownSlash" && animst != "DownAir" && animst != "Nair" && animst != "Fair" && animst != "UpAir" && animst != "BowDraw" && animst != "BowFull" && animst != "NBow" && animst != "NBowFull" && anim.GetBool("Nbow") == false && anim.GetBool("BowF") == false && animst != "MagicCast")
            {
                anim.SetBool("Magic", true);
                mana -= sfbc;
                Debug.Log("BALL");
                if (GetComponent<Movement>().left == false)
                {
                    GameObject ball = Instantiate(Fireball, transform.position, Quaternion.identity);

                }
                else
                {
                    GameObject ball = Instantiate(Fireball, transform.position, Quaternion.identity);
                    ball.transform.Rotate(0, 0, 180);
                }
            }
            if (Input.GetKeyDown(lightning) && mana >= boltc && animst != "FwdSwing" && animst != "Jab" && animst != "UpJab" && animst != "DownSlash" && animst != "DownAir" && animst != "Nair" && animst != "Fair" && animst != "UpAir" && animst != "BowDraw" && animst != "BowFull" && animst != "NBow" && animst != "NBowFull" && anim.GetBool("Nbow") == false && anim.GetBool("BowF") == false && animst != "MagicCast")
            {
                anim.SetBool("Magic", true);
                mana -= boltc;
                Debug.Log("BALL");
                if (GetComponent<Movement>().left == false)
                {
                    GameObject ball = Instantiate(bolt, transform.position, Quaternion.identity, Player);
                    ball.transform.position += new Vector3(2.09375f, -0.1875f, 0);
                }
                else
                {
                    GameObject ball = Instantiate(bolt, transform.position, Quaternion.identity, Player);
                    ball.transform.position -= new Vector3(2.09375f, 0.1875f, 0);
                    ball.GetComponent<SpriteRenderer>().flipY = true;
                    ball.transform.Rotate(0, 0, 180);
                }
            }
            if (Input.GetKeyDown(bigfireballk) && mana >= lfbc && animst != "FwdSwing" && animst != "Jab" && animst != "UpJab" && animst != "DownSlash" && animst != "DownAir" && animst != "Nair" && animst != "Fair" && animst != "UpAir" && animst != "BowDraw" && animst != "BowFull" && animst != "NBow" && animst != "NBowFull" && anim.GetBool("Nbow") == false && anim.GetBool("BowF") == false && animst != "MagicCast")
            {
                anim.SetBool("Magic", true);
                mana -= lfbc;
                if (GetComponent<Movement>().left == false)
                {
                    GameObject ball = Instantiate(bigfireball, transform.position, Quaternion.identity);
                    ball.transform.position += new Vector3(0.5f, 0, 0);
                }
                else
                {
                    GameObject ball = Instantiate(bigfireball, transform.position, Quaternion.identity);
                    ball.transform.Rotate(0, 0, 180);
                    ball.transform.position -= new Vector3(0.5f, 0, 0);
                }
                Debug.Log("BIG BALL");
            }
            if (Input.GetKeyDown(beam) && mana >= beac && animst != "FwdSwing" && animst != "Jab" && animst != "UpJab" && animst != "DownSlash" && animst != "DownAir" && animst != "Nair" && animst != "Fair" && animst != "UpAir" && animst != "BowDraw" && animst != "BowFull" && animst != "NBow" && animst != "NBowFull" && anim.GetBool("Nbow") == false && anim.GetBool("BowF") == false && animst != "MagicCast")
            {
                anim.SetBool("Magic", true);
                mana -= beac;
                if (GetComponent<Movement>().left == false)
                {
                    GameObject ball = Instantiate(beamp, transform.position, Quaternion.identity);
                    ball.transform.position += new Vector3(32.5f, -0.25f, 0);
                }
                else
                {
                    GameObject ball = Instantiate(beamp, transform.position, Quaternion.identity);
                    ball.transform.Rotate(0, 0, 180);
                    ball.transform.position -= new Vector3(32.5f, 0.25f, 0);
                }
                Debug.Log("BIG BALL");
            }
            if (Input.GetKeyDown(explodek) && mana >= expc && animst != "FwdSwing" && animst != "Jab" && animst != "UpJab" && animst != "DownSlash" && animst != "DownAir" && animst != "Nair" && animst != "Fair" && animst != "UpAir" && animst != "BowDraw" && animst != "BowFull" && animst != "NBow" && animst != "NBowFull" && anim.GetBool("Nbow") == false && anim.GetBool("BowF") == false && animst != "MagicCast")
            {
                anim.SetBool("Magic", true);
                mana -= expc;
                Instantiate(explosion, transform.position, Quaternion.identity);
                Debug.Log("BIG BALL");
            }
        }
        Manabar.rectTransform.localScale = new Vector2(mana / manamax * res / 1920, res / 1920);
        Manabar.rectTransform.position = new Vector2(res - (212 * res / 1920), 44 * res / 1920);
        Manatext.rectTransform.localScale = new Vector2(res / 1920, res / 1920);
        Manatext.rectTransform.position = new Vector2(res - (212 * res / 1920), 44 * res / 1920);

    }
}
