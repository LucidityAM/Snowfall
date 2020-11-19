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

    //Visual Stuff
    public GameObject textBox;
    public GameObject sprite;

    //private Animator Variables
    private Animator textBoxAnim;
    private Animator spriteAnim;
    private Image spriteImage;

    //Queue for names and sentences
    private Queue<string> sentences;
    private Queue<Sprite> sprites;
    private Queue<AudioClip> voices;
    #endregion

    #region Condition Variables
    private bool isActive;
    private bool endText;
    int count;
    #endregion
    
    //Awake is called before the first frame update once and never again
    void Awake()
    {
        #region Getting All Private Components
        textBoxAnim = textBox.GetComponent<Animator>();
        spriteAnim = sprite.GetComponent<Animator>();
        spriteImage = sprite.GetComponent<Image>();
        #endregion

        #region Turning Off All Components
        dialogueText.gameObject.SetActive(false);
        textBox.SetActive(false);
        sprite.SetActive(false);
        #endregion
    }

    // Start is called before the first frame update
    void Start()
    {
        #region Resetting Variables
        isActive = false;
        endText = false;
        count = 0;
        #endregion

        #region Resetting Queues
        sentences = new Queue<string>();
        sprites = new Queue<Sprite>();
        voices = new Queue<AudioClip>();
        #endregion

        #region Turning Off All Components
        dialogueText.gameObject.SetActive(false);
        textBox.SetActive(false);
        sprite.SetActive(false);
        #endregion
    }

    public IEnumerator StartDialogue(Dialogue dialogue)
    {
        endText = false;
        isActive = true;
        count = 0;
        //Player disabling happpens here

        #region Setting Up Queues. Turning Arrays > Queues
        sentences.Clear();
        foreach (string sentence in dialogue.sentences)
        {
            sentences.Enqueue(sentence);
        }
        sprites.Clear();
        foreach (Sprite sprite in dialogue.sprites)
        {
            sprites.Enqueue(sprite);
        }
        voices.Clear();
        foreach(AudioClip voice in dialogue.voices)
        {
            voices.Enqueue(voice);
        }
        #endregion

        #region Resetting Text
        dialogueText.text = "";
        #endregion

        #region Animation For Opening The Dialogue
        textBox.SetActive(true);
        sprite.SetActive(true);
        textBoxAnim.SetTrigger("isOpen");
        spriteImage.sprite = sprites.Dequeue();
        count++;
        yield return new WaitForSeconds(0.5f);
        dialogueText.gameObject.SetActive(true);
        DisplayNextSentence();
        #endregion
    }

    public void DisplayNextSentence()
    {
        //Condition checks if sentences are less than 0. If it is, it goes to EndDialogue()
        if (sentences.Count <= 0)
        {
            StartCoroutine("EndDialogue");
            return;
        }
        if (count > 1)
        {
            spriteImage.sprite = sprites.Dequeue();
        }
        count++;
        //Making local variables for the current sentence and name
        string sentence = sentences.Dequeue();

        StopAllCoroutines();
        StartCoroutine(TypeSentence(sentence, name));
    }

    public IEnumerator TypeSentence(string sentence, string name)
    {
        //Resseting dialogue
        dialogueText.text = "";

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
        yield return new WaitForSeconds(0.3f);
        textBoxAnim.SetTrigger("isOpen");
        yield return new WaitForSeconds(0.35f);
        #endregion

        #region Turning off Game Objects
        dialogueText.gameObject.SetActive(false);
        textBox.SetActive(false);
        sprite.SetActive(false);
        #endregion
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
