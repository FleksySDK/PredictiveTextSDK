// ****************************************************************************
// (c) 2023 Thingthing LTD
// ****************************************************************************

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using SimpleJSON;

public class FKCoreXR : MonoBehaviour
{

    public bool call_sdk = true;


    private AndroidJavaObject jFleksySDK = null;

    private string _api_licenseKey = "";
    private string _api_licenseSecret = "";

    private int _time_to_uptade_comands = 25;
    private int time = 0;

    private FKCoreListener _listener;

  
    // Start is called before the first frame update
    void Start()
    {
        
    }


    public void StartFleksySDK(string licenseKey, string licenseSecret, string layout_def="", string language_path="")
    {

        try
        {
            Debug.Log("BEgin StartFleksySDK: " + call_sdk);
            if (call_sdk) { 
                _api_licenseKey = licenseKey;
                _api_licenseSecret = licenseSecret;

                AndroidJavaClass jc = new AndroidJavaClass("com.unity3d.player.UnityPlayer");
                AndroidJavaObject jo = jc.GetStatic<AndroidJavaObject>("currentActivity");


                jFleksySDK = new AndroidJavaObject("com.fleksy.fleksycoresdkunity.fleksycoresdkunity");
                jFleksySDK.Call("start", jo, _api_licenseKey, _api_licenseSecret, layout_def, language_path);

                Debug.Log("OK StartFleksySDK: " + jFleksySDK);
            }


        }
        catch (Exception err)
        {

            Debug.Log("ERROR StartFleksySDK: " + err.Message + " " + err.StackTrace);
        }



    }


    public void setListener(FKCoreListener listener) {
        _listener = listener;
    }

    public void NextWordPrediction(string context,int cursorStart, int cursorEnd)
    {
        if (jFleksySDK != null) { 
            jFleksySDK.Call("nextWordPrediction", context, cursorStart, cursorEnd);
        }
    }

    public void CurrentWordPrediction(string context, int cursorStart, int cursorEnd)
    {
        if (jFleksySDK != null)
        {
            jFleksySDK.Call("currentWordPrediction", context, cursorStart, cursorEnd);
        }
    }



    public void startSwipe()
    {

        if (call_sdk)
        {
            jFleksySDK.Call("startSwipe");
        }
    }

    public void stopSwipe()
    {

        if (call_sdk)
        {
            jFleksySDK.Call("endSwipe", "", 1,1);
        }
    }

    public void sendSwipeTypePoint(float x, float y)
    {

        if (call_sdk)
        {
            
            jFleksySDK.Call("onSwipeTypePoint", x, y);
        }



    }


    ArrayList LoadPredictions(JSONNode obj_event)
    {
        ArrayList predictions = new ArrayList();

        try
        {
          
            var obj_result = obj_event["result"];
            int i = 0;
            
            while (i < obj_result.Count)
            {
                var obj_result_item = obj_result[i];
             
                predictions.Add(new FKPredictionItem(obj_result_item["label"], obj_result_item["type"], obj_result_item["score"]));


                i++;

            }


        }
        catch (Exception err)
        {
            Debug.Log("flevent: nextWordPrediction: error " + err.Message + " " + err.StackTrace);
        }


        return predictions;
    }

    void UpdateCommands()
    {

        try
        {
            if (time == _time_to_uptade_comands)
            {
                string flevent = "";

                if (call_sdk)
                {
                    
                    flevent = jFleksySDK.Call<string>("getEvent");
                }

                if ((flevent!=null)&&(flevent != ""))
                {

                    Debug.Log("UpdateCommands flevent:  " + flevent);

                    var obj_event = JSON.Parse(flevent);


                    if (obj_event["type"].Value == "currentWordPrediction")
                    {
                       
                        try
                        {

                            ArrayList predictions = LoadPredictions(obj_event);

                         
                       
                            if (_listener != null)
                            {
                                _listener.OnCurrentWordPredictions(predictions);
                            }

                        }
                        catch (Exception err)
                        {
                            Debug.Log("flevent: currentWordPrediction: error " + err.Message);
                        }
                    }

                    else if (obj_event["type"].Value == "nextWordPrediction")
                    {
                      

                        try
                        {

                            ArrayList predictions = LoadPredictions(obj_event);
                           

                            if (_listener != null) { 
                                _listener.OnNextWordPredictions(predictions);
                            }


                        }
                        catch (Exception err)
                        {
                            Debug.Log("flevent: nextWordPrediction: error " + err.Message + " " + err.StackTrace);
                        }
                    }
        
                    else if (obj_event["type"].Value == "onEndSwipeTypeStream")
                    {

                        try { 
                            var obj_result = obj_event["result"];


                            var obj_result_item = obj_result[0];


                            var obj_replacement = obj_result_item["replacements"][0];


                            string set_text = obj_replacement["replacement"].Value;

                            ArrayList predictions = new ArrayList();
                            predictions.Add(new FKPredictionItem(obj_replacement["replacement"].Value));

                            if (_listener != null)
                            {
                                _listener.OnSwipeWordPredictions(predictions);
                            }
                        }
                        catch (Exception err)
                        {
                            Debug.Log("flevent: onEndSwipeTypeStream: error " + err.Message + " " + err.StackTrace);
                        }

                    }



                }
                time = 0;
            }
            else
            {
                time++;
            }
        }
        catch (Exception err)
        {
            time = 0;
            Debug.Log("ERROR FXCoreXR UpdateCommands: " + err + " " + err.StackTrace);
        }

    }





    // Update is called once per frame
    void Update()
    {
        UpdateCommands();
    }
}
