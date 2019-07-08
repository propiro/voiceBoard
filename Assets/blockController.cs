using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class blockController : MonoBehaviour {

    public int blockID = -999;
    public Object audioToPlay;
    public bool isPlaying;
    public TextMesh blockText;
    public AudioSource playAudio;
    public float speed = 0.3f;
    public Material blinkMaterial;
    private Color blinkColor;
    private float blinkAlpha = 0f;
    private float blinkAlphaMax = 0.5f;
    private bool blinkingUo = false;
    private bool blinkingDown = false;
    private bool blinking = false;
    //AudioSource audioToPlay;

    // Use this for initialization
    void Start () {
       playAudio = GetComponent<AudioSource>();
        
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    private void OnMouseDown()
    {
        playAudio.Play(0);
        blink();
    }

    void blink()
    {
        if (!blinking)
        {
            blinkColor = blinkMaterial.color;




            blinking = true;


            /*
             
             void FadeIn()
{
    renderer.material.color = new Color(1, 1, 1, Mathf.Lerp(0, 1, FadeTime));
    if (FadeTime > 1)
    {
        FadingIn = false;
    }
}
    void FadeOut()
{
    renderer.material.color = new Color(1, 1, 1, Mathf.Lerp(1, 0, FadeTime));
    if (FadeTime > 1)
    {
        FadingOut = false;
    }
}
         
         
         
         
         
         */




        }

    }
}
