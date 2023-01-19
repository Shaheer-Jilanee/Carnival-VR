/*
 * VR Carnival
 * 
 * CPSC 488 - 01
 * 
 * Shaheer Mahdi Jilanee
 * Patrick McDermott
 * Philip Dukleth
 * Brady Rainey
 * Charles Davis
 * 
 * FloorScript.cs
 *
 */

using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using UnityEngine.SceneManagement;

public class FloorScript : MonoBehaviour {
	private static int numBottlesTouching;
    private static int galleryScore;
   


    private MilkJugScript milkJug;
    private MilkJugScript can;
    private Text winOrLose, infoText, remaining;
    private Text galleryScoreText, galleryShotsRemaining;
    private GameObject instructionText;


    public AudioSource music;

    // Use this for initialization
    void Start () {

        //Ball Toss Stuff
        numBottlesTouching = 0;
        galleryScore = 0;
       
        winOrLose = GameObject.Find("WinOrLose").GetComponent<Text> ();
        //infoText = GameObject.Find("Text").GetComponent<Text>();
        remaining = GameObject.Find("MilkJugBallsRemaining").GetComponent<Text>();
        


        //Gallery Stuff
        galleryShotsRemaining = GameObject.Find("ShootingGalleryBallsRemaining").GetComponent<Text>();
        galleryScoreText = GameObject.Find("ShootingGalleryScore").GetComponent<Text>();


        Invoke("HideCanvas", 10.0f);

        music = GetComponent<AudioSource>();
    }

	// Update is called once per frame
	void OnCollisionEnter (Collision collision) 
	{

		if (collision.collider.tag == "MilkJug")
        {
            milkJug = collision.collider.GetComponent<MilkJugScript>();

            if (milkJug.hasCollided == false)
            {
                numBottlesTouching++;

                milkJug.hasCollided = true;

            }
            
		}

        if (collision.collider.tag == "Can")
        {
            can = collision.collider.GetComponent<MilkJugScript>();

            if (can.hasCollided == false)
            {
                galleryScore++;
                can.hasCollided = true;
            }

            galleryScoreText.text = "Score: " + galleryScore;

        }

  
        if (numBottlesTouching == 6)
		{
            //infoText.text = "";
            remaining.text = "";
            winOrLose.text = "Winner!!!!";
		}

	}

    void HideCanvas()
    {
        instructionText = GameObject.Find("InstructionsCanvas") as GameObject;
        instructionText.SetActive(false);
    }


    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Backspace))
        {
            SceneManager.LoadSceneAsync(0);
        }
    }
		
}
