using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.Xml;

public class QuestionController : MonoBehaviour {
    public static bool showQuestion;
    public Text theQuestionText;
    public Dropdown theDropdown;
    XmlNode localNodeRss;
    XmlNode localNodeItem;
    
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
        //localNodeRss = Rssreader.nodeRss;
        if(showQuestion) {
          Debug.Log("value from the RSS is " + Rssreader.rowNews.item[0].title);
          theQuestionText.text = Rssreader.rowNews.item[0].title;
          //theQuestionText.gameObject.SetActive(true);
          theDropdown.gameObject.SetActive(true);
        }
    
		
	}
}
