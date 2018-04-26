using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class QuestionController : MonoBehaviour {
    public static bool showQuestion;
    public Text theQuestionText;
    public Dropdown theDropdown;
    
	// Use this for initialization
	void Start () {
      showQuestion = false;
      Rssreader rss = new Rssreader("http://www.barnettech.com/rss.xml");
      
        //theQuestionText = GameObject.Find("QuestionText");
        
      //theQuestionText.gameObject.SetActive(false);
      theDropdown.gameObject.SetActive(false);
        
      //theCanvas.GetComponent<Renderer>().enabled = false;
      theQuestionText.text = "";
        
	}
	
	// Update is called once per frame
	void Update () {
        Debug.Log("show question is " + showQuestion);
        if(showQuestion) {
          theQuestionText.text = "first question";
          //theQuestionText.gameObject.SetActive(true);
          theDropdown.gameObject.SetActive(true);
        }
    
		
	}
}
