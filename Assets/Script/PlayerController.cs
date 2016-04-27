using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using UnityEngine.SceneManagement;
//using UnityEngine.Render;
using System;
/**as of 9/23/2015 currerntly working on adding buttons that make the game reset after completion

step 1: learn more info on buttons.
.
.: #^#$%@$%&#%$>
.
end: do it

as of 9/28/2015, ditched the idea of adding buttons, created a new level beneath the first one and aded a maze, now
trying to make it when the score equals 52, the player is moved to the top left corner.
then will make it when the score is equal to 52, then the whole entire level one,
(the PickUp, PIckUpBads, and PickUpBonuses, and walls)
they will be set active false.

*/
public class PlayerController : MonoBehaviour
{

    public float speed;
    public float jumpheight;
    public Text ScoreText;
    public Text winText;
    public Text restartText;
    public UnityEngine.Renderer rend;
    private bool restart;


    private Rigidbody rb;
    private int score;
    private GameObject LevelOne;
    private GameObject LevelTwo;
    private GameObject LevelThree;
    private GameObject LevelFour;
    private GameObject PlayerLevelOne;
    private GameObject Boss;
    private GameObject Level2End;
    private GameObject Lvl3End;
    private GameObject A;
    private GameObject B;
    private GameObject C;
    private GameObject D;
    private GameObject AE;
    private GameObject BE;
    private GameObject CE;
    private GameObject DE;
    private GameObject ren;
    //private GameObject rend;
    //private GameObject MW;
    //private GameObject AW;
    private int a;
    private int b;
    private int c;
    private int d;
   // private int E;
    private int e;
    private int f;
    private int g;
    private int h;
    //private int i;
   // private bool jumping;
   



    void Start()
    {
        rb = GetComponent<Rigidbody>();
        score = 0;
        SetScoreText ();
        winText.text = "";
        restart = false;
        restartText.text = "";
        LevelOne = GameObject.FindWithTag("Level 1");
        LevelTwo = GameObject.FindWithTag("Level 2");
        PlayerLevelOne = GameObject.FindWithTag("PlayerLevelOne");
        Boss = GameObject.FindWithTag("Boss");
        LevelThree = GameObject.FindWithTag("Level 3");
        LevelFour = GameObject.FindWithTag("Level 4");
        Lvl3End = GameObject.FindWithTag("Level3End");
        A = GameObject.FindWithTag("W5");
        AE = GameObject.FindWithTag("AE");
        B = GameObject.FindWithTag("W4");
        BE = GameObject.FindWithTag("BE");
        C = GameObject.FindWithTag("W3");
        CE = GameObject.FindWithTag("CE");
        D = GameObject.FindWithTag("W2");
        DE = GameObject.FindWithTag("DE");
       //   MW = GameObject.FindWithTag("MW");
       // AW = GameObject.FindWithTag("AW");
        a = 0;
        b = 0;
        c = 0;
        d = 0;
        e = UnityEngine.Random.Range(1, 4);
        f = UnityEngine.Random.Range(1, 4);
        g = UnityEngine.Random.Range(1, 4);
        h = UnityEngine.Random.Range(1, 4);
        //rend = AE.GetComponent<Renderer>();
        //LevelOne.SetActive(true);
        //LevelTwo.SetActive(false);
        //LevelThree.SetActive(false);
        //LevelFour.SetActive(false);

        /**Renderer[] rs = ren.GetComponentInChildren<Renderer[]>();
        foreach (Renderer r in rs)
            r.enabled = true;*/


    }


    void FixedUpdate()
    {

        float moveHorizontal = Input.GetAxis("Horizontal");
        float moveVertical = Input.GetAxis("Vertical");

        Vector3 movement = new Vector3(moveHorizontal, 0.0f, moveVertical);        

        rb.AddForce(movement * speed);
        if (Input.GetKeyDown(KeyCode.Space))
        {
            
            rb.AddForce(Vector3.up * jumpheight);
            // winText.text = "Space Pressed";

        }
        else
        {
            rb.AddForce(Vector3.up * 0);
        }
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("PickUp"))
        {
            other.gameObject.SetActive(false);
            score = score + 1; 
            SetScoreText();
            itemings();

        }
        else if (other.gameObject.CompareTag("PickUpBonus"))
        {
            other.gameObject.SetActive(false);
            score = score + 10;
            SetScoreText();
            itemings();
        }
        else if (other.gameObject.CompareTag("PickUpBad"))
        {
            other.gameObject.SetActive(false);
            score = score - 5;
            SetScoreText();
            restartText.text = "Press 'R' for Restart";
            restart = true; 
        }
        else if (other.gameObject.CompareTag("Level2End"))
        {
            other.gameObject.SetActive(false);
            LevelTwo.SetActive(false);
            toLevel3();
        }
        else if (other.gameObject.CompareTag("AE"))
        {
            ren = A;
            ChangeRend();
           
        }
        else if (other.gameObject.CompareTag("BE"))
        {
            ren = B;
            ChangeRend();
        }
        else if (other.gameObject.CompareTag("CE"))
        {
            ren = C;
            ChangeRend();
        }
        else if (other.gameObject.CompareTag("DE"))
        {
            ren = D;
            ChangeRend();
        }
        else if (other.gameObject.CompareTag("Level3End"))
        {
            other.gameObject.SetActive(false);
            LevelThree.SetActive(false);
            LevelFour.SetActive(true);
            toLevel4();
        }


    }

    void ChangeRend ()
    {
      /**  Renderer[] rs = ren.GetComponentInChildren<Renderer>();
        foreach (Renderer r in rs)
            r.enabled = false;
        //rend = GetComponent<MeshRenderer>();
        
        //rend.enabled = false;*/
    }

    private Type className(MeshRenderer meshRenderer)
    {
        throw new NotImplementedException();
    }

    void SetScoreText ()
    {
        ScoreText.text = "Score: " + score.ToString();
        if (score >= 52)
        {
            winText.text = "Next Level!";
            
      
            }
        
    }
    void itemings()
    {
        if(score >=52)
        {
            toLevel2();
            
                    
        }
    }




    void toLevel2 ()
    {
        PlayerLevelOne.transform.position = new Vector3(-9, -10, 9);
        LevelOne.SetActive(false);
        LevelTwo.SetActive(true);
    }
    
   void toLevel3 ()
    {
        PlayerLevelOne.transform.position =  new Vector3(0, -20, 0);
        LevelTwo.SetActive(false);
        LevelThree.SetActive(true);
        
        
        //LevelThree.SetActive(true);
        /*for (n = q;n<=4;n++)
        {
            if (n == 1)
            {
                A.transform.Rotate(new Vector3(0, 0, 0));
                break;
            } 
            else if( n ==2)
            {
                A.transform.Rotate(new Vector3(0, 90, 0));
                break;
            }
            else if(n ==3)
            {
                A.transform.Rotate(new Vector3(0, 180, 0));
                break;
            }
            else if(n==4)
            {
                A.transform.Rotate(new Vector3(0, 270, 0));
                break;
            }
        }         */
        MazeRunner();
    }


    void MazeRunner()
    {
      
            for (a = e; e!= f;)//n <=4;n++)
            {
                if (a == 1)
                {
                    A.transform.Rotate(new Vector3(0, 0, 0));
                    AE.transform.Rotate(new Vector3(0, 0, 0));
                Lvl3End.transform.position=(new Vector3(9, -20, 9));
                break;
                }
                else if (a == 2)
                {
                    A.transform.Rotate(new Vector3(0, 90, 0));
                AE.transform.Rotate(new Vector3(0, 90, 0));
                Lvl3End.transform.position=(new Vector3(-9, -20, 9));
                break;
                }
                else if (a == 3)
                {
                    A.transform.Rotate(new Vector3(0, 180, 0));
                AE.transform.Rotate(new Vector3(0, 180, 0));
                Lvl3End.transform.position= new Vector3(9, -20, -9);
                break;
                }
                else if (a == 4)
                {
                    A.transform.Rotate(new Vector3(0, 270, 0));
                AE.transform.Rotate(new Vector3(0, 270, 0));
                Lvl3End.transform.position = new Vector3(-9, -20, -9);
                break;
                }
            }

            for (b = f; e != f;)//o <= 4; o++)
            { 
                if (b == 1)
                {
                    B.transform.Rotate(new Vector3(0, 0, 0));
                BE.transform.Rotate(new Vector3(0, 0, 0));
                break;
                }
                else if (b == 2)
                {
                    B.transform.Rotate(new Vector3(0, 90, 0));
                BE.transform.Rotate(new Vector3(0, 90, 0));
                break;
                }
                else if (b == 3)
                {
                    B.transform.Rotate(new Vector3(0, 180, 0));
                BE.transform.Rotate(new Vector3(0, 180, 0));

                break;
                }
                else if (b == 4)
                {
                    B.transform.Rotate(new Vector3(0, 270, 0));
                BE.transform.Rotate(new Vector3(0, 270, 0));
                break;
                }
            }
        for (c = g; g != f;)//o <= 4; o++)
        {
            if (c == 1)
            {
                C.transform.Rotate(new Vector3(0, 0, 0));
                CE.transform.Rotate(new Vector3(0, 0, 0));
                break;
            }
            else if (c == 2)
            {
                C.transform.Rotate(new Vector3(0, 90, 0));
                CE.transform.Rotate(new Vector3(0, 90, 0));
                break;
            }
            else if (c == 3)
            {
                C.transform.Rotate(new Vector3(0, 180, 0));
                CE.transform.Rotate(new Vector3(0, 180, 0));
                break;
            }
            else if (c == 4)
            {
               C.transform.Rotate(new Vector3(0, 270, 0));
               CE.transform.Rotate(new Vector3(0, 270, 0));
                break;
            }
        }
        for (d = h; h != g;)//o <= 4; o++)
        {
            if (d == 1)
            {
               D.transform.Rotate(new Vector3(0, 0, 0));
                DE.transform.Rotate(new Vector3(0, 0, 0));

                break;
            }
            else if (d == 2)
            {
                D.transform.Rotate(new Vector3(0, 90, 0));
                DE.transform.Rotate(new Vector3(0, 90, 0));
                break;
            }
            else if (d == 3)
            {
                D.transform.Rotate(new Vector3(0, 180, 0));
                DE.transform.Rotate(new Vector3(0, 180, 0));
                break;
            }
            else if (d == 4)
            {
                D.transform.Rotate(new Vector3(0, 270, 0));
                DE.transform.Rotate(new Vector3(0, 270, 0));
                break;
            }
        }
    }

    void toLevel4()
    {
        PlayerLevelOne.transform.position = new Vector3(0, -29, -5);
        LevelThree.SetActive(false);
        LevelFour.SetActive(true);
        Boss.SetActive(true);
       // PlayerLevelOne.transform.localScale = new Vector3(2, 2, 2);
    }

   //public static void LoadScene(string MiniGame, SceneManagement.LoadSceneMode mode = Single);




        void Update ()
    {
            //LevelTwo.SetActive(false);
            //MainCamera.SetActive(true);


            if (score >= 52)
            {

                LevelOne.SetActive(false);

            }
           else if(restart)
            {
           // restartText.text = "Press 'R' for Restart";
            if (Input.GetKeyDown(KeyCode.R))
                 {
                   SceneManager.LoadScene(0);


                 }

             }




        }
   
    
    /**transform each wall by y= 90;wall set by y=0; y = 90;y=180;y=270;
        only need to shorten one wall;
        the make loop that chooses between 1-4;
        "int" A=0
        ""B=90
        ""C=180
        ""D=270
        1 = A
        2 = B
        3 = C
        4 = D
        
        1 is left wall;
        2 is northern wall;
        3 is western wall;
        4 is the eastern wall;*/






}