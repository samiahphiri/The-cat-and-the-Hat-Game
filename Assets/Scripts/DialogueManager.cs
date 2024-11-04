using UnityEngine;
using TMPro; // Make sure to import TMP for TextMeshPro
using System.Collections;

public class DialogueManager : MonoBehaviour
{
    public TextMeshProUGUI dialogueText; // Link to the Text for dialogue
    private string[] dialogueLines = {
        "Narrator: It was a rainy afternoon, and Sally and Conrad were stuck inside. Their house was a mess dirty dishes on the table, toys scattered everywhere, and books piled up on the floor. Their mom had told them to behave and keep the house clean, but now she was on her way home, and there wasn’t much time left.",
        "Sally: “Mom’s going to be home any minute! We have to clean this up before she gets here!”",
        "Conrad: “There’s so much to do! How are we going to get this done in time?”",
        "Narrator: Suddenly, The Cat in the Hat appeared, with a mischievous grin and his tall striped hat.",
        "The Cat in the Hat: “Well, well, well! It looks like you two could use some help Don’t worry, cleaning can be fun! But you’ll have to be quick if you want to finish before your mom walks through that door.”",
        "Narrator: Sally and Conrad looked at each other, realizing they had no choice but to start cleaning right away. With The Cat in the Hat’s help or maybe his mischief they set off to clean the house as fast as they could.",
        "The Cat in the Hat: “Let’s see how fast you can pick up those toys, wash the dishes, and make this place spotless. But be careful you don’t want to make an even bigger mess!”",
    };

    private int currentLineIndex = 0; // Tracks the current line in the dialogue
    public float typingSpeed = 0.05f; // Speed of typing effect (in seconds)

    private void Start()
    {
        ShowDialogue(); // Display the first line
    }

    public void ShowDialogue()
    {
        if (currentLineIndex < dialogueLines.Length)
        {
            StartCoroutine(TypeDialogue(dialogueLines[currentLineIndex])); // Type out the dialogue
            currentLineIndex++;
        }
        else
        {
            dialogueText.text = ""; // Clear text if finished
        }
    }

    IEnumerator TypeDialogue(string line)
    {
        dialogueText.text = ""; // Clear current text
        foreach (char letter in line)
        {
            dialogueText.text += letter; // Add one letter at a time
            yield return new WaitForSeconds(typingSpeed); // Wait between each letter
        }
    }

    public void DisplayNextLine()
    {
        StopAllCoroutines(); // Stop any ongoing typing effect
        ShowDialogue(); // Display the next line
    }
}
