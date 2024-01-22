using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CombinationUnit : MonoBehaviour
{

    private MeshRenderer meshRenderer;
    private Color colourRed;
    private Color colourBlue;
    private Color colourGreen;
    private Color targetColour;
    private bool targetAchieved;
    private bool delayRunning;

    private List<Color> colourList;
    
    public enum EnumColourList
    {
        red, blue, green
    }

    [SerializeField] EnumColourList enumColourList;

    private void Start() 
    {
        meshRenderer = GetComponent<MeshRenderer>(); 
        colourList = new List<Color>();
        AssignColours();   
        GetTargetColour();
    }

    private void GetTargetColour()
    {
        switch (enumColourList)
        {
            case EnumColourList.red:
                targetColour = colourRed;
                Debug.Log("Red");
                break;
            case EnumColourList.blue:
                targetColour = colourBlue;
                Debug.Log("Blue");
                break;
            case EnumColourList.green:
                targetColour = colourGreen;
                Debug.Log("Green");
                break;    
        }
    }

    private void AssignColours()
    {
        colourRed = Color.red;
        colourBlue = Color.blue;
        colourGreen = Color.green;
        colourList.Add(colourRed);
        colourList.Add(colourBlue);
        colourList.Add(colourGreen);
    }


    private void OnCollisionEnter(Collision other) 
    {
        if (other.gameObject.tag.Equals("Ball"))
        {
            if (!targetAchieved)
            {
                ChangeColour();
            }
        }    
    }

    private IEnumerator ChangeColour()
    {
        delayRunning = true;
        yield return new WaitForSeconds(0.2f);
        delayRunning = false;

        System.Random rand = new System.Random();
        int index = rand.Next(colourList.Count);

        meshRenderer.material.color = colourList[index];
    }
    
    private void CheckForTargetColour()
    {
        if (meshRenderer.material.color == targetColour)
        {
            targetAchieved = true;
            EventOverseer.InvokeCombinationUnlocked();
        }
    }
}
