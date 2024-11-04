using UnityEngine;
using TMPro;
using System.Collections;

public class ClosingDialogueManager : MonoBehaviour
{
    public TextMeshProUGUI dialogueText;
    public GameObject cat;
    public GameObject mom; // Reference to Mom GameObject for the closing scene
    public float typingSpeed = 0.05f;

    // Dialogue lines for the closing scene
    private string[] dialogueLines = {
        "Narrator: Sally and Conrad rushed through the house, picking up every toy washing every dish, and straightening up as fast as they could. By the time they finished, the house looked perfect. They wiped the sweat from their foreheads just as they heard the sound of their mom’s car pulling into the driveway.",
        "Conrad: “We did it! The house is clean!”",
        "Sally: “I can’t believe we finished in time.”",
        "The Cat in the Hat: “Well done, kids! I knew you could do it. Now, the house is spotless, and your mom will never know just how messy it was. My work here is done!”",
        "Narrator: With a wink, The Cat in the Hat tipped his hat and made his exit. Just as he disappeared, their mom walked through the door.",
        "Mom: “Wow! The house looks so clean. You two must have worked very hard while I was gone.”",
        "Narrator: Sally and Conrad smiled at each other, relieved that they had managed to clean everything up in time, thanks to a little help from The Cat in the Hat."
    };

    private int currentLineIndex = 0;

    private void Start()
    {
        cat.SetActive(true); // Show Cat initially
        mom.SetActive(false); // Hide Mom until her line
        ShowDialogue(); // Start with the first line
    }

    public void ShowDialogue()
    {
        if (currentLineIndex < dialogueLines.Length)
        {
            string currentLine = dialogueLines[currentLineIndex];

            // Show Mom at the right line
            if (currentLine.Contains("mom walked through the door"))
                mom.SetActive(true);

            // Hide Cat after he says his last line
            if (currentLine.Contains("The Cat in the Hat tipped his hat"))
                cat.SetActive(false);

            StartCoroutine(TypeDialogue(currentLine));
            currentLineIndex++;
        }
        else
        {
            EndScene(); // Call EndScene when dialogue ends
        }
    }

    IEnumerator TypeDialogue(string line)
    {
        dialogueText.text = ""; // Clear current text
        foreach (char letter in line)
        {
            dialogueText.text += letter;
            yield return new WaitForSeconds(typingSpeed);
        }
    }

    public void DisplayNextLine()
    {
        StopAllCoroutines();
        ShowDialogue();
    }

    private void EndScene()
    {
        dialogueText.text = "The End"; // Display final message
        // Additional code for a fade-out or scene transition can go here
    }
}
