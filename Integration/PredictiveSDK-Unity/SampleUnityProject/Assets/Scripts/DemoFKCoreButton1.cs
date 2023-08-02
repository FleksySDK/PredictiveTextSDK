using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using TMPro;
using System;
using UnityEngine.XR;
using UnityEngine.XR.Hands;
using UnityEngine.XR.Management;

public class DemoFKCoreButton1 : MonoBehaviour
{

    
    private TextMeshProUGUI textMeshPro;
    private FKCoreXR fKCoreXR;

    private InputDevice targetDevice;

    public bool m_hands_loaded = false;
    public List<XRHandSubsystem> m_subsystemhands;
    public XRHandSubsystem m_subsystemhand;

    float touchDistance = 0.03f;

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




    public  Bounds GetBoundsFromPose(Pose pose)
    {
        Bounds bounds = new Bounds();

        Renderer[] renderers = GetComponentsInChildren<Renderer>();

        foreach (Renderer renderer in renderers)
        {
            bounds.Encapsulate(renderer.bounds);
        }

        Vector3 center = pose.position;
        Quaternion rotation = pose.rotation;

        bounds.center = rotation * bounds.center + center;

        return bounds;
    }


    public Transform GetJointTransform(XRHandJointID jointId, int posHand)
    {

        try
        {

            XRHand? xrHand = GetOpenXRHand(posHand);





            if (xrHand != null)
            {

                XRHandJoint indexTipJoint = ((XRHand)xrHand).GetJoint(jointId);

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


                    return transform;
                }
                else
                {

                    return null;
                }


            }
            else
            {
                return null;
            }

        }
        catch (Exception err)
        {
            Debug.Log("FKTouchVR GetJointTransform ERROR: " + err.Message + " " + err.StackTrace);

        }

        return null;
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

    public GameObject GetJointObject(XRHandJointID jointId, int posHand)
    {

        try
        {

            XRHand? xrHand = GetOpenXRHand(posHand);

            if (xrHand != null)
            {
                XRHandJoint indexTipJoint = ((XRHand)xrHand).GetJoint(jointId);

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
            else {
                return null;
            }

        }
        catch (Exception err)
        {
            Debug.Log("FKTouchVR GetJointObject ERROR: " + err.Message + " " + err.StackTrace);

        }
        return null;
    }



    // Start is called before the first frame update
    void Start()
    {
      

        

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

        if ((fingerTip != null) && (index_distal_phalange != null)) { 

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
        if (GetObjectHit(ref last_hit, "Button1"))
        {
            // Touch interaction detected
            Debug.Log("Touch interaction detected Button1!");

            
            textMeshPro = transform.Find("/TextField").GetComponentInChildren<TextMeshProUGUI>();
            fKCoreXR = transform.Find("/_FKCoreXR").GetComponentInChildren<FKCoreXR>();

            string tmp = GetLastWord(textMeshPro.text);
            fKCoreXR.CurrentWordPrediction(tmp, 1, tmp.Length);

            // Perform your desired action here
        }
    }
}
