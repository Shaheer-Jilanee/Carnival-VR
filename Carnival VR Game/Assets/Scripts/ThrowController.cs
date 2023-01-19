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
 * ThrowController.cs
 *
 */

using UnityEngine;
using UnityEngine.UI;
using System.Collections;


public class ThrowController : MonoBehaviour {
	
	private BallController ballScript;
	public GameObject prefab;
	private GameObject parentBone;
	private GameObject ball;
	public int numBalls;
    //public Animator animator;
    private Text milkJugBallsRemaining, shootingGalleryBallsRemaining;
    public AudioSource audio;
    public AudioClip [] throwBall;

    private static Text targetGameBallsRemaining;

    private int NUM_THROW_CLIPS = 3;
    private int NUM_BALLS = 100;


    // Use this for initialization
    void Start () {

       
        parentBone = GameObject.Find("parentBone");
		milkJugBallsRemaining = GameObject.Find("MilkJugBallsRemaining").GetComponent<Text> ();
        shootingGalleryBallsRemaining = GameObject.Find("ShootingGalleryBallsRemaining").GetComponent<Text>();
        targetGameBallsRemaining = GameObject.Find("TargetGameBallsRemaining").GetComponent<Text>();

    }


    void Awake()
    {
        audio = GetComponent<AudioSource>();
        //backGroundMusic.Play();

        throwBall = new AudioClip[NUM_THROW_CLIPS];
        throwBall[0] = Resources.Load<AudioClip>("PotsAndPans0.ogg");
        throwBall[1] = Resources.Load<AudioClip>("PotsAndPans1.ogg");
        throwBall[2] = Resources.Load<AudioClip>("PotsAndPans2.ogg");
    }

	// Update is called once per frame
	void Update () {

        

		if (Input.GetMouseButtonDown (0)) {

            //Debug.Log(throwBall[0]);
            audio.clip = throwBall[0];
            audio.Play();
            Invoke("ThrowBall", 0.4f);
		}

        milkJugBallsRemaining.text = "Remaining: " + NUM_BALLS;
        shootingGalleryBallsRemaining.text = "Remaining: " + NUM_BALLS;
        targetGameBallsRemaining.text = "Remaining: " + NUM_BALLS;

    }

	void ThrowBall(){
       
        if (NUM_BALLS > 0) {
            makeNewBall();
            ballScript = ball.GetComponent<BallController>();
            ballScript.Release();
            NUM_BALLS--;
		}
    }

    public void makeNewBall() {
        ball = Instantiate(prefab, parentBone.transform.position, parentBone.transform.rotation) as GameObject;
    }


	
		

	public int getNumBalls(){

		return this.NUM_BALLS;

	}



}
