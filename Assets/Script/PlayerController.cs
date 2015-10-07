using UnityEngine;
using UnityEngine.UI;
using System.Collections;
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
    public Text ScoreText;
    public Text winText;
    public Vector4 Level2Start;
 //   public Button yes;
 //   public Button no;

    private Rigidbody rb;
    private int score;
    private GameObject LevelOne;
    private GameObject LevelTwo;
    private GameObject PlayerLevelOne;
    private GameObject PlayerLevelTwo;
    private GameObject LevelTwoCamera;
    private GameObject MainCamera;
    //private GameObject Level2End;
    //private GameObject Items;


    void Start()
    {
        rb = GetComponent<Rigidbody>();
        score = 0;
        SetScoreText ();
        winText.text = "";
        LevelOne = GameObject.FindWithTag("Level 1");
        LevelTwo = GameObject.FindWithTag("Level 2");
        PlayerLevelOne = GameObject.FindWithTag("PlayerLevelOne");
        PlayerLevelTwo = GameObject.FindWithTag("PlayerLevelTwo");
        LevelTwoCamera = GameObject.FindWithTag("Level2Camera");
        MainCamera = GameObject.FindWithTag("MainCamera");
        // Level2End = GameObject.FindWithTag("Level2End");
        //Items = GameObject.FindWithTag("Items");
        Vector4 Level2Start = transform.TransformPoint(-9, -10, 9);
        //NO     // Instantiate(PlayerLevelOne, Level2Start, PlayerLevelOne.transform.rotation);

        //resetText.text = "";
        PlayerLevelTwo.SetActive(false);


    }


    void FixedUpdate()
    {

        float moveHorizontal = Input.GetAxis("Horizontal");
        float moveVertical = Input.GetAxis("Vertical");

        Vector3 movement = new Vector3(moveHorizontal, 0.0f, moveVertical);

        Vector3 Level2Start = new Vector4(-9, -10, 9);
        

        rb.AddForce(movement * speed); //* speed);
                                       // PlayerLevelTwo.SetActive(false);
        //Instantiate(PlayerLevelOne, Level2Start, PlayerLevelOne.transform.rotation);

    }

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("PickUp"))
        {
            other.gameObject.SetActive(false);
      //WORKS!!!!!..yas      //Instantiate(PlayerLevelOne, Level2Start, PlayerLevelOne.transform.rotation);
            score = score + 1; 
            SetScoreText();

        }
        else if (other.gameObject.CompareTag("PickUpBonus"))
        {
            other.gameObject.SetActive(false);
            score = score + 10;
            SetScoreText();
        }
        else if (other.gameObject.CompareTag("PickUpBad"))
        {
            other.gameObject.SetActive(false);
          //  Instantiate(PlayerLevelOne, Level2Start, PlayerLevelOne.transform.rotation);

            score = score - 5;
            SetScoreText();
        }
        /**else if(other.gameObject.CompareTag("Level2End"))
        {
            other.gameObject.SetActive(false);
        }*/
       else if (other.gameObject.CompareTag("Items"))
        {
            other.gameObject.SetActive(false);
            LevelTwo.SetActive(true);
            LevelOne.SetActive(false);
            Instantiate(PlayerLevelOne, Level2Start, PlayerLevelOne.transform.rotation);

        }
        
      
      
   }
    void SetScoreText ()
    {
        ScoreText.text = "Score: " + score.ToString();
        if (score >= 52)
        {
            winText.text = "Next Level!";

      
            }
        
    }
    void toLevel2 ()
    {

    }
    void Update ()
    {
        //LevelTwo.SetActive(false);
       // PlayerLevelTwo.SetActive(false);
        MainCamera.SetActive(true);
        LevelTwoCamera.SetActive(false);
        //PlayerLevelOne.transform(Vector4);

        if(score >= 52)
        {
            LevelTwoCamera.SetActive(true);
            MainCamera.SetActive(false);
            //Instantiate(PlayerLevelOne, Level2Start, PlayerLevelOne.transform.rotation);
           // PlayerLevelOne.SetActive(false);
            //PlayerLevelOne.
           // PlayerLevelTwo.SetActive(true);
            LevelOne.SetActive(false);
            LevelTwo.SetActive(true);
        }
        


    }






}