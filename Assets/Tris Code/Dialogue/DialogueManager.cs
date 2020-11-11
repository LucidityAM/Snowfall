using System.Collections;
using System.Collections.Generic;
using System.Data;
using UnityEngine;
using UnityEngine.UI;

public class DialogueManager : MonoBehaviour
{
    #region Dialogue Components
    //Text stuff
    public Text dialogueText;
    public Text nameTextLeft;
    public Text nameTextRight;

    //Visual Stuff
    public GameObject textBox;
    public GameObject spriteLeft;
    public GameObject spriteRight;

    //private Animator Variables
    private Animator textBoxAnim;
    private Animator spriteLeftAnim;
    private Animator spriteRightAnim;
    private Image spriteLeftImage;
    private Image spriteRightImage;

    //Queue for names and sentences
    private Queue<string> sentences;
    private Queue<string> names;
    private Queue<Sprite> sprites;
    private Queue<AudioClip> textSound;
    #endregion

    #region Condition Variables
    private bool isActive;
    private bool endText;
    #endregion

    //Awake is called before the first frame update once and never again
    void Awake()
    {
        #region Getting All Private Components
        textBoxAnim = textBox.GetComponent<Animator>();
        spriteLeftAnim = spriteLeft.GetComponent<Animator>();
        spriteRightAnim = spriteRight.GetComponent<Animator>();
        spriteLeftImage = spriteLeft.GetComponent<Image>();
        spriteRightImage = spriteRight.GetComponent<Image>();
        #endregion
    }

    // Start is called before the first frame update
    void Start()
    {
        #region Resetting Bools
        isActive = false;
        endText = false;
        #endregion

        #region Resetting Queues
        sentences = new Queue<string>();
        names = new Queue<string>();
        sprites = new Queue<Sprite>();
        #endregion

        #region Turning Off All Components
        textBox.SetActive(false);
        spriteLeft.SetActive(false);
        spriteRight.SetActive(false);
        #endregion
    }

    public IEnumerator StartDialogue(Dialogue dialogue)
    {
        endText = false;
        isActive = true;
        //Player disabling happpens here

        #region Setting Up Queues. Turning Arrays > Queues
        sentences.Clear();
        foreach (string sentence in dialogue.sentences)
        {
            sentences.Enqueue(sentence);
        }
        names.Clear();
        foreach (string name in dialogue.names)
        {
            names.Enqueue(name);
        }
        sprites.Clear();
        foreach (Sprite sprite in dialogue.sprites)
        {
            sprites.Enqueue(sprite);
        }
        #endregion

        #region Resetting Text
        dialogueText.text = "";
        nameTextLeft.text = "";
        nameTextRight.text = "";
        #endregion

        #region Animation For Opening The Dialogue
        textBox.SetActive(true);
        textBoxAnim.SetTrigger("isOpen");
        yield return new WaitForSeconds(0.4f);
        DisplayNextSentence();
        #endregion
    }

    public void DisplayNextSentence()
    {
        //Condition checks if sentences are less than 0. If it is, it goes to EndDialogue()
        if(sentences.Count <= 0)
        {
            StartCoroutine("EndDialogue");
            return;
        }

        //Making local variables for the current sentence and name
        string sentence = sentences.Dequeue();
        string name = names.Dequeue();

        StopAllCoroutines();
        StartCoroutine(TypeSentence(sentence, name));
    }

    public IEnumerator TypeSentence(string sentence, string name)
    {
        string leftNameSlot = nameTextLeft.text;
        //Resseting dialogue
        dialogueText.text = "";
        nameTextLeft.text = "";
        nameTextRight.text = "";

        //Name detection
        if( sentence != leftNameSlot && leftNameSlot != null)
        {
            nameTextLeft.text = sentence;
        }
        else
        {
            nameTextRight.text = sentence;
        }

        //Types each word letter for letter
        foreach(char letter in sentence.ToCharArray())
        {
            if(endText == true)
            {
                //StartCoroutine("EndDialogue");
            }
            dialogueText.text += letter;
            yield return null;
        }
    }

    public IEnumerator EndDialogue()
    {
        //Bool on so if anywhere else is still active, it will stop and go to endText
        endText = true;

        //Enable player controls

        #region Turning off Animators in an Animation
        spriteLeftAnim.SetTrigger("isOpen");
        spriteRightAnim.SetTrigger("isOpen");
        yield return new WaitForSeconds(0.7f);
        textBoxAnim.SetTrigger("isOpen");
        yield return new WaitForSeconds(0.3f);
        #endregion

        #region Turning off Game Objects
        textBox.SetActive(false);
        spriteLeft.SetActive(false);
        spriteRight.SetActive(false);
        #endregion
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
