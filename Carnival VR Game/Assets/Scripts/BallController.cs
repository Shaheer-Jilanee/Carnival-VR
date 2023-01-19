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
 * BallController.cs
 *
 */

using UnityEngine;

using UnityEngine.UI;

using System.Collections;

public class BallController : MonoBehaviour {

	private Rigidbody rb;
	private GameObject mainCamera;

    public GameObject reticle;
    private static Text targetGameScoreText, targetGameBallsRemaining;
    private static int targetScore = 0;

    private GameObject parentBone;
   
    //private float rotation;
    //private bool right = true;

    //public float speed;


    void Awake()
    {
        //Target Game Stuff
        targetGameScoreText = GameObject.Find("TargetGameScore").GetComponent<Text>();
        targetGameBallsRemaining = GameObject.Find("TargetGameBallsRemaining").GetComponent<Text>();

    }

	public void Release()
	{
		rb = GetComponent<Rigidbody> ();

		parentBone = GameObject.Find ("parentBone");
		mainCamera = GameObject.Find ("MainCamera");
		transform.parent = parentBone.transform;

        //parentBone = GameObject.Find("parentBone");
        reticle = GameObject.Find("Reticle");
        mainCamera = GameObject.Find("CenterEyeAnchor");
        transform.parent = reticle.transform;

		rb.useGravity = false;

		transform.parent = null;
		rb.useGravity = true;

        transform.rotation = mainCamera.transform.rotation;

		transform.rotation = mainCamera.transform.rotation;
		rb.AddForce(transform.forward * 16000);
		rb.AddForce (new Vector3 (-1.0f, 1.0f, 0.0f) * 1000);

		transform.rotation = mainCamera.transform.rotation;


        Vector3 direction = (reticle.transform.position - transform.position).normalized;


        rb.AddForce(direction * 20000);
  

    }



    void OnCollisionEnter(Collision collision)
    {
        if (collision.collider.name == "OuterRing")
        {
            targetScore += 1;
            

        }
        else if (collision.collider.name == "MiddleRing")
        {
            targetScore += 2;
        }
        else if (collision.collider.name == "InnerRing")
        {
            targetScore += 2;
        }
        else { /*targetGameScoreText.text = "Score: " + targetScore;*/ }

    }

    void Update() { targetGameScoreText.text = "Score: " + targetScore; }

    

}


