// ****************************************************************************
// (c) 2023 Thingthing LTD
// ****************************************************************************

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using UnityEngine.UI;
using UnityEngine.EventSystems;
using TMPro;

using System;

using SimpleJSON;
using UnityEngine.XR;
using UnityEngine.XR.Hands;
using UnityEngine.XR.Management;




public class FKKeyboardDemo : MonoBehaviour
{

    public float keyboard_width = 0.18f;
    public float keyboard_height = 0.18f;

    
    public GameObject key_type1 = null;
    public GameObject key_type2 = null;

    private float keyboard_width_sdk = 320f;
    private float keyboard_height_sdk = 288f;

  

    public List<XRHandSubsystem> m_subsystemhands;
    public XRHandSubsystem m_subsystemhand;
    private bool m_hands_loaded = false;

    private GameObject _cursor;

    //  float touchDistance = 0.03f;

    float touchDistance = 0.06f;


    private int m_state = 0;

    

    public void DrawKeyboard()
    {
        
        int i = 1;
        float sx = keyboard_width / keyboard_width_sdk;
        float sy = keyboard_height / keyboard_height_sdk;

        float max_y = 288f;

    

        // ********************************************************************
        float w = keyboard_width;
        float h = keyboard_height;


        var back_canvas_ref = transform.Find("_FKeyboardBack").gameObject.transform.Find("_FKeyboardBackCanvas");


        back_canvas_ref.GetComponent<RectTransform>().sizeDelta = new Vector2(w, h);





        // ************************************
        var back_canvas_ref_border = transform.Find("_FKeyboardBackBorder").gameObject.transform.Find("_FKeyboardBackCanvasBorder");


        float border = 0.04f;


        back_canvas_ref_border.GetComponent<RectTransform>().sizeDelta = new Vector2(w + border,  h + border);
        var border_position = back_canvas_ref_border.localPosition;
        border_position.x -= border / 2;
        border_position.y -= border / 2;
        back_canvas_ref_border.localPosition = border_position;


        Vector3 old_border_size = back_canvas_ref_border.GetComponent<BoxCollider>().size;
        back_canvas_ref_border.GetComponent<BoxCollider>().size = new Vector3(w + border,  h + border, old_border_size.z);

        // ***********************



        BoxCollider boxCollider = transform.Find("_FKeyboardBackBorder").gameObject.transform.Find("_FKeyboardBackCanvasBorder").GetComponent<BoxCollider>();

        var obj_border_parent = transform.Find("_FKeyboardBackBorder").gameObject.transform.Find("_FKeyboardBackCanvasBorder");



        float cw = w + border;
        float ch =  h + border;
        float cz = 0.005f;

        Vector3 pos = Vector3.zero;
        pos.x += cw / 2;
        pos.y += ch / 2;
        pos.z -= 0.010f; // -0.015f
        boxCollider.center = pos;

        boxCollider.size = new Vector3(cw, ch, cz);


        // **********************************
        var image_back = back_canvas_ref_border.Find("Image");

        image_back.GetComponent<RectTransform>().sizeDelta = new Vector2(w + border, h + border);



    }

    // Start is called before the first frame update
    void Start()
    {

        _cursor = transform.Find("_FKCursor").gameObject;


        var cursor_trail = _cursor.GetComponent<TrailRenderer>();


        cursor_trail.startWidth = _cursor.transform.localScale.x;
        cursor_trail.endWidth = 0.001f;


        CursorHide();


        DrawKeyboard();



    }

    // **************************************************************************************************************


    public void StartHandsFX()
    {
        try
        {
            m_subsystemhand = XRGeneralSettings.Instance?.Manager?.activeLoader?.GetLoadedSubsystem<XRHandSubsystem>();


            if (m_subsystemhand != null)
            {
                m_hands_loaded = true;

            };

        }
        catch (Exception err)
        {
            Debug.Log("FKTouchVR StartHandsFX ERROR: " + err.Message + " " + err.StackTrace);

        }
    }

    public XRHand? GetOpenXRHand(int hand)
    {

        try
        {



            StartHandsFX();

            if (hand == 0)
            {
                return m_subsystemhand.leftHand;
            }
            else
            {
                return m_subsystemhand.rightHand;
            }


        }
        catch (Exception err)
        {
            Debug.Log("FKTouchVR GetOpenXRHand ERROR: " + err.Message + " " + err.StackTrace);

        }


        return null;
    }

    public Pose ToWorldPose(XRHandJoint joint)
    {

        Transform origin = GameObject.Find("XR Origin").transform;
        Pose xrOriginPose = new Pose(origin.position, origin.rotation);
        if (joint.TryGetPose(out Pose jointPose))
        {
            return jointPose.GetTransformedBy(xrOriginPose);
        }
        else
            return Pose.identity;
    }


    public GameObject GetJointObject(XRHandJointID jointId, int posHand)
    {

        try
        {

            XRHand? xrHand = GetOpenXRHand(posHand);

            if (xrHand != null)
            {

                XRHandJoint indexTipJoint = ((XRHand) xrHand).GetJoint(jointId);

                Pose indexTipPose;


                indexTipPose = ToWorldPose(indexTipJoint);


                bool resul = (indexTipPose != Pose.identity);

                GameObject obj = null;
                if (resul)
                {

                    obj = new GameObject();
                    Transform transform = obj.transform;

                    transform.position = indexTipPose.position;
                    transform.rotation = indexTipPose.rotation;
                }
                return obj;
            }
        }
        catch (Exception err)
        {
            Debug.Log("FKTouchVR GetJointObject ERROR: " + err.Message + " " + err.StackTrace);

        }
        return null;
    }


    public bool GetObjectHit(ref RaycastHit hitout, string object_name)
    {

        Boolean bResul = false;

        Vector3 fingerTipForward;
        Vector3 fingerTipBackward;

        GameObject fingerTip;
        GameObject index_distal_phalange = null;


        fingerTip = GetJointObject(XRHandJointID.IndexTip, 1);


        index_distal_phalange = GetJointObject(XRHandJointID.IndexDistal, 1);


        if((fingerTip!=null) && (index_distal_phalange!=null)) { 


            fingerTipForward = fingerTip.transform.position - index_distal_phalange.transform.position;
            fingerTipForward.Normalize();



            var point_finger_world = fingerTip.transform.position;

            RaycastHit[] hits;


            hits = Physics.RaycastAll(fingerTip.transform.position, fingerTipForward, touchDistance);





            foreach (RaycastHit hit in hits)
            {
                if (hit.collider.gameObject.name == object_name)
                {
                    hitout = hit;
                    bResul = true;
                    break;
                }

            }

        }

        return bResul;
    }



    // Update is called once per frame
    void Update()
    {
        RaycastHit last_hit = new RaycastHit();
        if (GetObjectHit(ref last_hit, "_FKeyboardKeys"))
        {

            var fkinput = transform.Find("_FKeyboardKeys");
            var point_finger_collider_keyboard = fkinput.transform.InverseTransformPoint(last_hit.point);

         
            if (m_state == 0)
            {

                m_state = 1;

                CursorShow(point_finger_collider_keyboard);

                Vector3 r = ConvertPoint(new Vector3(point_finger_collider_keyboard.x, point_finger_collider_keyboard.y, 0));

                FKCoreXR demo = GameObject.Find("_FKCoreXR").GetComponent<FKCoreXR>();

                if (demo != null)
                {
                    Debug.Log("startSwipeR ");
                    demo.startSwipe();
                    demo.sendSwipeTypePoint(r.x, r.y);
                }
                else {
                    Debug.Log("Not access allowed to FKCoreXR ");

                }

            }
            else {
                CursorMove(point_finger_collider_keyboard);

                Vector3 r = ConvertPoint(new Vector3(point_finger_collider_keyboard.x, point_finger_collider_keyboard.y, 0));

               
                FKCoreXR demo = GameObject.Find("_FKCoreXR").GetComponent<FKCoreXR>();
                if (demo != null)
                {
                    demo.sendSwipeTypePoint(r.x, r.y);
                }

            };
        }
        else
        {

            if (m_state == 1) { 
                m_state = 0;
                CursorHide();

                FKCoreXR demo = GameObject.Find("_FKCoreXR").GetComponent<FKCoreXR>();
                demo.stopSwipe();
            }
        }
    }

    public Vector3 ConvertPoint(Vector3 v)
    {
        float sx = keyboard_width / keyboard_width_sdk;
        float sy = keyboard_height / keyboard_height_sdk;
        float max_y = 288f;

        Vector3 resul = v;

        resul.x = resul.x / sx;
        resul.y = max_y - (resul.y / sy);

        return resul;
    }


    // ************* Cursor ***************************
    public void CursorMove(Vector3 pto)
    {


        try
        {

            _cursor.transform.localPosition = new Vector3(pto.x, pto.y, pto.z - 0.015f);
        }
        catch (Exception err)
        {
            Debug.Log("CursorShow Error0:" + err.Message + " " + err.StackTrace);
        }



    }

    public void CursorShow(Vector3 pto)
    {



        try
        {
            _cursor.transform.localPosition = new Vector3(pto.x, pto.y, pto.z - 0.015f);
        }
        catch (Exception err)
        {
            Debug.Log("CursorShow Error1:" + err.Message + " " + err.StackTrace);
        }



        try
        {

            _cursor.SetActive(true);
        }
        catch (Exception err)
        {
            Debug.Log("CursorShow Error2:" + err.Message + " " + err.StackTrace);
        }
    }

    public void CursorHide()
    {
        try
        {

            _cursor.SetActive(false);
        }
        catch (Exception err)
        {
            Debug.Log("CursorShow Error3:" + err.Message + " " + err.StackTrace);
        }
    }


    // ***********************************************


}
