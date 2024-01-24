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
    private bool isColliding;

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
        if (isColliding) return;
        isColliding = true;
        Debug.Log("Hit wall");
        
        if (other.gameObject.tag.Equals("Ball"))
        {
            Debug.Log("Hit wall 2");
            if (!targetAchieved)
            {
                ChangeColour();
            }
        }   
        StartCoroutine(ResetIsColliding()); 
    }

    private void ChangeColour()
    {
        Debug.Log("Colour");

        int index = GetNewColourCheck();

        meshRenderer.material.color = colourList[index];
        CheckForTargetColour();
    }

    private int GetNewColourCheck()
    {
        System.Random rand = new System.Random();
        int index = rand.Next(colourList.Count);
        if (meshRenderer.material.color == colourList[index]) return GetNewColourCheck();
        return index;
    }
    
    private void CheckForTargetColour()
    {
        if (meshRenderer.material.color == targetColour)
        {
            targetAchieved = true;
            EventOverseer.InvokeCombinationUnlocked();
        }
    }

    private IEnumerator ResetIsColliding()
    {
        yield return new WaitForEndOfFrame();
        isColliding = false;
    }
}
