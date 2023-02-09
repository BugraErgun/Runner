using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using TMPro;
using UnityEngine;

public enum BonusType
{
    Addition,
    Difference,
    Multiplication,
    Division
}
public class Doors : MonoBehaviour
{
   

    [Header("Elements")]
    [SerializeField] private SpriteRenderer rightDoorRenderer;
    [SerializeField] private SpriteRenderer leftDoorRenderer;
    [SerializeField] private TextMeshPro rightDoorText;
    [SerializeField] private TextMeshPro leftDoorText;
    [SerializeField] private Collider collider_;

    [Header("Settings")]
    [SerializeField] private BonusType rightDoorBonusType;
    [SerializeField] private int rightDoorBonusAmount;

    [SerializeField] private BonusType leftDoorBonusType;
    [SerializeField] private int leftDoorBonusAmount;

    private Color bonusColor = Color.blue;
    private Color penaltyColor = Color.red;

    void Start()
    {
        ConfigureDoors();
    }

    void Update()
    {
        
    }
    private void ConfigureDoors()
    {
        switch (rightDoorBonusType)
        {
            case BonusType.Addition:
                rightDoorRenderer.color = bonusColor;
                rightDoorText.text = "+" + rightDoorBonusAmount;
                break;
            case BonusType.Difference:
                rightDoorRenderer.color = penaltyColor;
                rightDoorText.text = "-" + rightDoorBonusAmount;
                break;
            case BonusType.Multiplication:
                rightDoorRenderer.color = bonusColor;
                rightDoorText.text = "*" + rightDoorBonusAmount;
                break;
            case BonusType.Division:
                rightDoorRenderer.color = penaltyColor;
                rightDoorText.text = "/" + rightDoorBonusAmount;
                break;
           
        }
        switch (leftDoorBonusType)
        {
            case BonusType.Addition:
                leftDoorRenderer.color = bonusColor;
                leftDoorText.text = "+" + leftDoorBonusAmount;
                break;
            case BonusType.Difference:
                leftDoorRenderer.color = penaltyColor;
                leftDoorText.text = "-" + leftDoorBonusAmount;
                break;
            case BonusType.Multiplication:
                leftDoorRenderer.color = bonusColor;
                leftDoorText.text = "x" + leftDoorBonusAmount;
                break;
            case BonusType.Division:
                leftDoorRenderer.color = penaltyColor;
                leftDoorText.text = "/" + leftDoorBonusAmount;
                break;
           
        }

    }
    public int GetBonusAmount(float xPos)
    {
        if (xPos>0)
        {
            return rightDoorBonusAmount;
        }
        else
        {
            return leftDoorBonusAmount;
        }
    }
    public BonusType GetBonusType(float xPos)
    {
        if (xPos>0)
        {
            return rightDoorBonusType;
        }
        else
        {
            return leftDoorBonusType;
        }
    }
    public void Disable()
    {
        collider_.enabled = false;

    }
}
