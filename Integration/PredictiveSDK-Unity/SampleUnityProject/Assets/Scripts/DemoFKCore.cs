// ****************************************************************************
// (c) 2023 Thingthing LTD
// ****************************************************************************

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class DemoFKCore : MonoBehaviour, FKCoreListener
{
    private TextMeshProUGUI textMeshProPredictions;
    private TextMeshProUGUI textMeshProChecks;
    private TextMeshProUGUI textMeshPro;
    private FKCoreXR fKCoreXR;
    // Start is called before the first frame update
    void Start()
    {



    textMeshProChecks = transform.Find("/TextFieldChecks").GetComponentInChildren<TextMeshProUGUI>();
        textMeshProPredictions = transform.Find("/TextFieldPredictions").GetComponentInChildren<TextMeshProUGUI>();
        textMeshPro = transform.Find("/TextField").GetComponentInChildren<TextMeshProUGUI>();
        

    


       

        fKCoreXR = transform.Find("/_FKCoreXR").GetComponentInChildren<FKCoreXR>();



       // string layout_def = "[{\"labels\":[\"q\",\"1\"],\"x\":16,\"y\":36,\"width\":32,\"height\":72},{\"labels\":[\"w\",\"2\"],\"x\":48,\"y\":36,\"width\":32,\"height\":72},{\"labels\":[\"e\",\"3\",\"é\",\"è\",\"ę\",\"ë\",\"ê\",\"ě\",\"ē\",\"ė\",\"ệ\"],\"x\":80,\"y\":36,\"width\":32,\"height\":72},{\"labels\":[\"r\",\"4\",\"ř\"],\"x\":112,\"y\":36,\"width\":32,\"height\":72},{\"labels\":[\"t\",\"5\",\"ț\",\"ţ\",\"þ\"],\"x\":144,\"y\":36,\"width\":32,\"height\":72},{\"labels\":[\"y\",\"6\",\"ý\"],\"x\":176,\"y\":36,\"width\":32,\"height\":72},{\"labels\":[\"u\",\"7\",\"ü\",\"ū\",\"ú\",\"ù\",\"ư\"],\"x\":208,\"y\":36,\"width\":32,\"height\":72},{\"labels\":[\"i\",\"8\",\"í\",\"ī\",\"ı\",\"î\",\"ì\",\"ï\"],\"x\":240,\"y\":36,\"width\":32,\"height\":72},{\"labels\":[\"o\",\"9\",\"ó\",\"ö\",\"ō\",\"ø\",\"ô\",\"ò\",\"õ\",\"ő\"],\"x\":272,\"y\":36,\"width\":32,\"height\":72},{\"labels\":[\"p\",\"0\"],\"x\":304,\"y\":36,\"width\":32,\"height\":72},{\"labels\":[\"a\",\"@\",\"á\",\"ā\",\"ä\",\"ã\",\"â\",\"å\",\"à\",\"ă\",\"ą\",\"ǎ\",\"ạ\",\"æ\"],\"x\":17.777779,\"y\":108,\"width\":35.555557,\"height\":72},{\"labels\":[\"s\",\"#\",\"š\",\"ş\",\"ś\",\"ș\",\"ß\"],\"x\":53.333336,\"y\":108,\"width\":35.555557,\"height\":72},{\"labels\":[\"d\",\"¤\",\"£\",\"¢\",\"$\",\"¥\",\"€\",\"₱\",\"đ\",\"ð\"],\"x\":88.888885,\"y\":108,\"width\":35.555553,\"height\":72},{\"labels\":[\"f\",\"_\"],\"x\":124.444435,\"y\":108,\"width\":35.555553,\"height\":72},{\"labels\":[\"g\",\"&\",\"ğ\"],\"x\":159.99998,\"y\":108,\"width\":35.555553,\"height\":72},{\"labels\":[\"h\",\"ḩ\",\"ḥ\"],\"x\":195.55554,\"y\":108,\"width\":35.555553,\"height\":72},{\"labels\":[\"j\",\"+\"],\"x\":231.11108,\"y\":108,\"width\":35.555553,\"height\":72},{\"labels\":[\"k\",\"(\"],\"x\":266.66663,\"y\":108,\"width\":35.55555,\"height\":72},{\"labels\":[\"l\",\")\",\"ł\"],\"x\":302.2221,\"y\":108,\"width\":35.555542,\"height\":72},{\"labels\":[\"shift\"],\"x\":17.777779,\"y\":180,\"width\":35.555557,\"height\":72},{\"labels\":[\"z\",\"*\",\"ž\",\"ż\",\"ź\"],\"x\":53.333336,\"y\":180,\"width\":35.555557,\"height\":72},{\"labels\":[\"x\",\"_\"],\"x\":88.888885,\"y\":180,\"width\":35.555553,\"height\":72},{\"labels\":[\"c\",\"ç\",\"č\",\"ć\"],\"x\":124.444435,\"y\":180,\"width\":35.555553,\"height\":72},{\"labels\":[\"v\",\":\"],\"x\":159.99998,\"y\":180,\"width\":35.555553,\"height\":72},{\"labels\":[\"b\",\";\"],\"x\":195.55554,\"y\":180,\"width\":35.555553,\"height\":72},{\"labels\":[\"n\",\"!\",\"ñ\",\"ń\",\"ň\"],\"x\":231.11108,\"y\":180,\"width\":35.555553,\"height\":72},{\"labels\":[\"m\",\"?\"],\"x\":266.66663,\"y\":180,\"width\":35.55555,\"height\":72},{\"labels\":[\"backspace\"],\"x\":302.2221,\"y\":180,\"width\":35.555542,\"height\":72},{\"labels\":[\"numbers\"],\"x\":22.4,\"y\":252,\"width\":44.8,\"height\":72},{\"labels\":[\"magic\"],\"x\":62.4,\"y\":252,\"width\":35.2,\"height\":72},{\"labels\":[\"spacebar\"],\"x\":160,\"y\":252,\"width\":160,\"height\":72},{\"labels\":[\".\"],\"x\":257.6,\"y\":252,\"width\":35.2,\"height\":72},{\"labels\":[\"enter\"],\"x\":297.6,\"y\":252,\"width\":44.8,\"height\":72}]";



        fKCoreXR.StartFleksySDK("license_key", "license_secret");
        fKCoreXR.setListener(this);

       

    }


    public string GetLastParagraph(string original)
    {
        string resul = "";

        original = original.Trim();

        int pos = original.LastIndexOf("\r");

        if (pos == -1) pos = 0;

        resul = original.Substring(pos);

        resul = resul.Trim();

        return resul;
    }


    public string GetLastWord(string original)
    {
        string resul = "";


        original = original.Trim();

        int pos = original.LastIndexOf(" ");

        if (pos == -1) pos = 0;

        resul = original.Substring(pos);

        resul = resul.Trim();

        return resul;
    }


    // Update is called once per frame
    void Update()
    {
        
    }

    // ************************************************************
    // FKCoreListener

    public string replaceStringPositions(string originalString, string replacementText, int startIndex, int endIndex) {

        string partBefore = originalString.Substring(0, startIndex);
        string partAfter = originalString.Substring(endIndex + 1);


        string modifiedString = partBefore + replacementText + partAfter;
        return modifiedString;

    }

    public void OnCurrentWordPredictions(ArrayList predictions) {

        Debug.Log("OnCurrentWordPredictions: " + predictions.Count);


        if (predictions.Count != 0) { 

            string predictions_str = "";
            foreach (FKPredictionItem item in predictions)
            {

                if (predictions_str != "")
                {
                    predictions_str += ",";
                }

                predictions_str += item.label;

            }




            textMeshProChecks.text = predictions_str;
            textMeshPro.text = ((FKPredictionItem)(predictions[0])).label;
        }
    }

    public void OnNextWordPredictions(ArrayList predictions) {
        Debug.Log("OnNextWordPredictions: " + predictions.Count);

        if (predictions.Count != 0)
        {

            string predictions_str = "";
            foreach (FKPredictionItem item in predictions)
            {

                if (predictions_str != "")
                {
                    predictions_str += ",";
                }

                predictions_str += item.label;

            }




            textMeshProPredictions.text = predictions_str;
            textMeshPro.text = textMeshPro.text + " " + ((FKPredictionItem)(predictions[0])).label;
        }
    }


    public void OnSwipeWordPredictions(ArrayList predictions)
    {
        if (predictions.Count != 0) { 
            textMeshPro.text = textMeshPro.text + " " + ((FKPredictionItem)(predictions[0])).label;
        };

    }



}
