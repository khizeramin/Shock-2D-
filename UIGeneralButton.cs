using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.EventSystems;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

// F8FF00 .........///////////
[RequireComponent(typeof(Image))]
[RequireComponent(typeof(Button))]
public class UIGeneralButton : UIGeneral
{
    public AudioClip sound;
    private AudioSource audioButtonSource { get { return GetComponent<AudioSource>(); } }

    public bool controlSwitch;
    public int retCounter = 0;
    public void Start()
    {
        //controlSwitch = false;
        gameObject.AddComponent<AudioSource>();
        audioButtonSource.clip = sound;
        audioButtonSource.playOnAwake = false;
    }

    public enum ButtonSprite
    {
        FirstSwitch,
        SecondSwitch,
        ThirdSwitch,
        FourthSwitch,
        FifthSwitch,
        SixthSwitch
           
    };

     
    public ButtonSprite buttonSprite;
    //public ButtonSpriiteAfterClick buttonSpriiteAfterClick;

    Image image;
    Image icon;
    Image iconAfter;
    Button button;
    //Image beeBackImage;
    
    

    
    protected override void OnUIOperation()
    {
        base.OnUIOperation();
        
        // Object decelaration for the images and the Button.
         
        image = GetComponent<Image>();
        icon = transform.Find("Icon").GetComponent<Image>();
        iconAfter = transform.Find("IconAfter").GetComponent<Image>();
        button = GetComponent<Button>();

        
                     
        // Button State is set in the SpriteSwap state "Allows different sprites
        // to display depending on what state the button is currently in, the sprites can be customised.

        button.transition = Selectable.Transition.SpriteSwap;
        button.targetGraphic = image;

        image.sprite = UIData.buttonSprite;
        image.type = Image.Type.Sliced;
        button.spriteState = UIData.buttonSpriteState;

        switch (buttonSprite)
        {   
            case ButtonSprite.FirstSwitch:
                icon.sprite = UIData.ONE;
                //iconAfter.sprite = UIData.img1;
                break;
            case ButtonSprite.SecondSwitch:
                icon.sprite = UIData.TWO;
                break;
            case ButtonSprite.ThirdSwitch:
                icon.sprite = UIData.THREE;
                break;

        }

        
    }
    
    public void FixedUpdate()
    {
               
        
        //beeBackImage = GameObject.Find("Button").GetComponent<Button>();
        controlSwitch = false;

        //image.GetComponent<Image>().color = new Color32(255, 255, 0, 89);


        if (Input.GetMouseButtonDown(0))
        {
            //image.GetComponent<Image>().color = new Color32(255, 255, 0, 255);
            buttonEventSystem(button);

            retCounter++;

        }
        
        Debug.Log(retCounter);

        if (retCounter < 3)
        {
            Debug.Log("Wait for:" + retCounter);
        }
        else
        {
            //Here a method to load scene 2.
            StartCoroutine(ExecuteAfterThisTime());
            
    
        }
         
    }

    public void buttonEventSystem(Button button)
    {
        //iconAfter = transform.Find("IconAfter").GetComponent<Image>();
        button.onClick.AddListener(() => ImageSwitch());
        audioButtonSource.PlayOneShot(sound);
    }

    public void ImageSwitch()
    {
         
        //yellowSprite = GameObject.Find("Button").GetComponent<Sprite>();
        
        switch (buttonSprite)
        {
            case ButtonSprite.FourthSwitch:
                //Destroy(icon);
                icon.sprite = UIData.img1;
                image.GetComponent<Image>().color = new Color32(255, 255, 0, 0);
                //Destroy(icon);
                break;
            case ButtonSprite.FifthSwitch:
                //Destroy(icon);
                icon.sprite = UIData.img2;
                image.GetComponent<Image>().color = new Color32(255, 255, 0, 0);
                break;
            case ButtonSprite.SixthSwitch:
                //Destroy(icon);
                icon.sprite = UIData.img3;
                image.GetComponent<Image>().color = new Color32(255, 255, 0, 0);
                break;

        }
         
         
    }

    public void SceneController()
    {
       SceneManager.LoadScene("KaffeeScene");
        
    }

    IEnumerator ExecuteAfterThisTime()
    {   
        yield return new WaitForSeconds(2);
        Handheld.Vibrate();
        Handheld.Vibrate();
        Debug.Log("Scene 2 is Loaded... BOOM!!!");
        SceneController();
        
        Handheld.Vibrate();




    }
}
