// ****************************************************************************
// (c) 2023 Thingthing LTD
// ****************************************************************************

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class FKKey : MonoBehaviour
{

    public GameObject active_image = null;
    public string key = "";
    private int key_type = 0;

    // Start is called before the first frame update
    void Start()
    {
    
            if(key_type==0){
              TextMeshProUGUI textMeshPro = GetComponentInChildren<TextMeshProUGUI>();
              if(key.Length==1){
                textMeshPro.text = key;
              }
            }
            else{
              HideAll();
            }         
    }


    public void OnPointerDown()
    {
        if (key_type == 0)
        {
            GameObject obj_img = transform.GetChild(0).Find("ImageRounded").gameObject;
            GameObject obj_img_over = transform.GetChild(0).Find("ImageRoundedPress").gameObject;
            obj_img.SetActive(false);
            obj_img_over.SetActive(true);
        }
        else {
            GameObject obj_img = transform.GetChild(0).Find("Image").gameObject;
            GameObject obj_img_over = transform.GetChild(0).Find("ImagePress").gameObject;
            obj_img.SetActive(false);
            obj_img_over.SetActive(true);
        }
    }

    public void OnPointerUp()
    {
        if (key_type == 0)
        {
            GameObject obj_img = transform.GetChild(0).Find("ImageRounded").gameObject;
            GameObject obj_img_over = transform.GetChild(0).Find("ImageRoundedPress").gameObject;
            obj_img.SetActive(true);
            obj_img_over.SetActive(false);
        }
        else
        {
            GameObject obj_img = transform.GetChild(0).Find("Image").gameObject;
            GameObject obj_img_over = transform.GetChild(0).Find("ImagePress").gameObject;
            obj_img.SetActive(true);
            obj_img_over.SetActive(false);
        }
    }



    public void SetLabel(string label) {
        this.key = label;
        TextMeshProUGUI textMeshPro = GetComponentInChildren<TextMeshProUGUI>();
        if (key.Length == 1)
        {
            textMeshPro.text = label;
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }


    void HideAll(){
        
        GameObject obj = transform.GetChild(0).gameObject;

        for(int i = 2; i < obj.transform.childCount; i++)
        {
          GameObject obj_img = obj.transform.GetChild(i).gameObject;
              if(active_image!=obj_img)
                    obj_img.SetActive(false);
          
        }
 
    }


    void ActivateKey(string id_key){

        Vector2 new_size = new Vector2(0,0);
        if (active_image != null) {
            new_size = active_image.GetComponent<RectTransform>().sizeDelta;
            active_image.SetActive(false);
        }

        GameObject obj_img = transform.GetChild(0).Find(id_key).gameObject;

        if (active_image!=null){
            obj_img.GetComponent<RectTransform>().sizeDelta = new_size;
        }

        active_image = obj_img;
        obj_img.SetActive(true);
       
 
    }

    public GameObject GetActiveImage()
    {
        return active_image;
    }

    public void SetGraphicKey(string label)
    {
        key_type = 1;
        key = label;
        if(key=="backspace"){
            ActivateKey("Image_1");
        }
        else if(key=="shift"){
            ActivateKey("Image_2");
        }
        else if (key == "numbers")
        {
            ActivateKey("Image_3");
        }
        else if (key == "magic")
        {
            ActivateKey("Image_4");
        }
        else if (key == "enter")
        {
            ActivateKey("Image_5");
        }
        else if (key == "spacebar")
        {
            ActivateKey("Image_6");
        }
        else if (key == "numbers2")
        {
            ActivateKey("Image_7");
        }

    }



}
