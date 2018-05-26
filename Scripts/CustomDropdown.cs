using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class CustomDropdown : MonoBehaviour {

	[Header("ANIMATORS")]
	public Animator dropdownAnimator;

	[Header("OBJECTS")]
	public GameObject fieldTrigger;
	public Text selectedText;
	public Image selectedImage;

	[Header("PLACEHOLDER")]
	public string customText;
	public Sprite customIcon;

	[Header("SETTINGS")]
	[Tooltip("IMPORTANT! EVERY DORPDOWN MUST HAVE A DIFFERENT ID")]
	public int DropdownID = 0;
    public HeightSize heightSize;
	public bool customPlaceholder;
	public bool rememberSelection = true;
    public bool enableIcon = true;

    //public bool darkTrigger = true;

    private bool isOn;

	private string sText;
	private string sImage;

    public enum HeightSize
    {
        SMALL,
        MEDIUM,
        BIG
    }


    void Start ()
	{
		if (rememberSelection == true)
		{
			sText = PlayerPrefs.GetString (DropdownID + "SelectedText");
			sImage = PlayerPrefs.GetString (DropdownID + "SelectedImage");
		}

		if (customPlaceholder == true)
		{
			selectedText.text = customText;
			selectedImage.sprite = customIcon;
		}

		else 
		{
			selectedText.text = sText;
			//	selectedImage.sprite = 
		}

        if (enableIcon == false)
        {
            selectedImage.enabled = false;
        }
    }

	public void Animate ()
	{
		if (isOn == true) 
		{
            if (heightSize == HeightSize.SMALL)
            {
                dropdownAnimator.Play("Out Small");
            }

            else if (heightSize == HeightSize.MEDIUM)
            {
                dropdownAnimator.Play("Out Medium");
            }

            else if (heightSize == HeightSize.BIG)
            {
                dropdownAnimator.Play("Out Big");
            }

            isOn = false;
			fieldTrigger.SetActive (false);
		}

		else
		{
            if (heightSize == HeightSize.SMALL)
            {
                dropdownAnimator.Play("In Small");
            }

            else if (heightSize == HeightSize.MEDIUM)
            {
                dropdownAnimator.Play("In Medium");
            }

            else if (heightSize == HeightSize.BIG)
            {
                dropdownAnimator.Play("In Big");
            }

            isOn = true;
			fieldTrigger.SetActive (true);
		}
	}
}
