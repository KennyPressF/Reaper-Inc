using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[CreateAssetMenu(fileName = "New Profile", menuName = "Scriptable Objects/Profile")]

public class ProfileSO : ScriptableObject
{
    [Header("General")]
    public Sprite profilePicture;
    public string profileName;
    public enum Gender { Male, Female }
    public Gender gender;

    [Header("D.O.B")]
    public int birthDay;
    public BirthMonth birthMonth;
    public enum BirthMonth { Jan, Feb, Mar, Apr, May, Jun, Jul, Aug, Sep, Oct, Nov, Dec }
    public int birthYear;
    public bool bornBefore2000;
    public bool bornBefore1990;
    public bool bornBefore1980;

    [Header("Hair")]
    public HairColour hairColour;
    public enum HairColour { Blonde, Brown, Red, Black, Gray }

    [Header("Eyes")]
    public EyeColour eyeColour;
    public enum EyeColour { Blue, Brown, Hazel, Green, Amber }

    [Header("Height")]
    public string height;
    public bool isAboveSixFoot;

    [Header("System")]
    public bool hasBeenProcessed;
}
