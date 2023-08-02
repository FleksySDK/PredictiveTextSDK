# Sample project for the Fleksy Unity Predictive Keyboard SDK

Fleksy's fleksypredictionsdk.unitypackage allows you to add spell checking, prediction, and swipe to your Unity keyboard.

The SampleUnityProject is a really simple Unity project where we followed the main steps to integrate Fleksy Unity Predictive Keyboard SDK:

1. Import the package fleksypredictionsdk.unitypackage.

2. Drag the _FKCoreXR prefab into your scene.

3. In your application's main class (or in an empty Game Object in your main scene), you must perform the following steps.

    3.1 At the start of your main class, you must initialize the FKCoreXR.

    ```
    fKCoreXR = transform.Find("/_FKCoreXR").GetComponentInChildren<FKCoreXR>(); // Indicate the licenseKey and the licenseSecret

    fKCoreXR.StartFleksySDK("xxxxxxxxx-xxxx-xxxx-xxxxxx-xxxx", "xxxxxxxxxxxxxxxxxxxxxxxxxxxxx"); // Indicate the receiver of the FKCoreXR responses.

    fKCoreXR.setListener(this);
    ```

    By default, FKCoreXR works with a standard key layout and on a keyboard defined in a 320 x 288 rectangle.

    Changing the layout of the keys and the size of that rectangle using a JSON string sent as the third parameter in StartFleksySDK is possible. This is an example:

    ```
    string layout_def = "[{\"labels\":[\"q\",\"1\"],\"x\":16,\"y\":36,\"width\":32,\"height\":72},{\"labels\":[\"w\",\"2\"],\"x\":48,\"y\":36,\"width\":32,\"height \":72},{\"labels\":[\"e\",\"3\",\"é\",\"è\",\"ę\",\"ë\",\"ê\",\"ě\",\"ē\",\"ė\",\"ệ\"],\"x\":80,\"y\":36,\"width\":32,\"height\":72},{\"labels\" :[\"r\",\"4\",\"ř\"],\"x\":112,\"y\":36,\"width\":32,\"height\":72},{\"labels\":[\"t\",\"5\",\"ț\",\"ţ\",\"þ\"],\"x\":144,\"y\":36,\"width\":32,\ "height\":72},{\"labels\":[\"y\",\"6\",\"ý\"],\"x\":176,\"y\":36,\"width\":32,\"height\":72},{\"labels\":[\"u\",\"7\",\"ü\",\"ū\",\"ú\",\"ù\", \"ư\"],\"x\":208,\"y\":36,\"width\":32,\"height\":72},{\"labels\":[\"i\",\"8\",\"í\",\"ī\",\"ı\",\"î\",\"ì\",\"ï\"],\"x\":240,\"y\":36,\"width\":3 2,\"height\":72},{\"labels\":[\"o\",\"9\",\"ó\",\"ö\",\"ō\",\"ø\",\"ô\",\"ò\",\"õ\",\"ő\"],\"x\":272,\"y\":36,\"width\":32,\"height\":72},{\"l abels\":[\"p\",\"0\"],\"x\":304,\"y\":36,\"width\":32,\"height\":72},{\"labels\":[\"a\",\"@\",\"á\",\"ā\",\"ä\",\"ã\",\"â\",\"å\",\"à\",\"ă\", \"ą\",\"ǎ\",\"ạ\",\"æ\"],\"x\":17.777779,\"y\":108,\"width\":35.555557,\"height\":72},{\"labels\":[\"s\",\"#\",\"š\",\"ş\",\"ś\",\"ș\",\" ß\"],\"x\":53.333336,\"y\":108,\"width\":35.555557,\"height\":72},{\"labels\":[\"d\",\"¤\",\"£\",\"¢\",\"$\",\"¥\",\"€\",\"₱\",\"đ\",\"ð\ "],\"x\":88.888885,\"y\":108,\"width\":35.555553,\"height\":72},{\"labels\":[\"f\",\"_\"],\"x\":124.444435,\"y\":108,\"width\":35. 555553,\"height\":72},{\"labels\":[\"g\",\"&\",\"ğ\"],\"x\":159.99998,\"y\":108,\"width\":35.555553,\"height\":72},{\"labels\":[\"h \",\"ḩ\",\"ḥ\"],\"x\":195.55554,\"y\":108,\"width\":35.555553,\"height\":72},{\"labels\":[\"j\",\"+\"],\"x\":231.11108,\"y\":108,\"wi dth\":35.555553,\"height\":72},{\"labels\":[\"k\",\"(\"],\"x\":266.66663,\"y\":108,\"width\":35.55555,\"height\":72},{\"labels\":[\" l\",\")\",\"ł\"],\"x\":302.2221,\"y\":108,\"width\":35.555542,\"height\":72},{\"labels\":[\"shift\"],\"x\":17.777779,\"y\":180,\"width\ ":35.555557,\"height\":72},{\"labels\":[\"z\",\"*\",\"ž\",\"ż\",\"ź\"],\"x\":53.333336,\"y\":180,\"width\":35.555557,\"height\":72},{ \"labels\":[\"x\",\"_\"],\"x\":88.888885,\"y\":180,\"width\":35.555553,\"height\":72},{\"labels\":[\"c\",\"ç\",\"č\",\"ć\"],\"x\":124.44 4435,\"y\":180,\"width\":35.555553,\"height\":72},{\"labels\":[\"v\",\":\"],\"x\":159.99998,\"y\":180,\"width\":35.555553,\"heig ht\":72},{\"labels\":[\"b\",\";\"],\"x\":195.55554,\"y\":180,\"width\":35.555553,\"height\":72},{\"labels\":[\"n\",\"!\",\"ñ\",\"ń\",\"ň\" ],\"x\":231.11108,\"y\":180,\"width\":35.555553,\"height\":72},{\"labels\":[\"m\",\"?\"],\"x\":266.66663,\"y\":180,\"width\":35.5 5555,\"height\":72},{\"labels\":[\"backspace\"],\"x\":302.2221,\"y\":180,\"width\":35.555542,\"height\":72},{\"labels\":[\"numb ers\"],\"x\":22.4,\"y\":252,\"width\":44.8,\"height\":72},{\"labels\":[\"magic\"],\"x\":62.4,\"y\":252,\"width\":35.2,\"height\":72},{\ "labels\":[\"spacebar\"],\"x\":160,\"y\":252,\"width\":160,\"height\":72},{\"labels\":[\".\"],\"x\":257.6,\"y\":252,\"width\":35.2,\"height\":72},{\"labels\":[\"enter\"],\"x\":297.6,\"y\":252,\"width\":44.8,\"height\":72}]";

    fKCoreXR.StartFleksySDK("0b53f460-3704-4f83-b037-c90bc77aa68e", "f7a62985e9628f7d6ff95640d6640cdd", layout_def);
    ```

    It is also possible to use a fourth parameter to define a different language file that must be in Unity's folder StreamingAssets/encrypted and that, if passed as a parameter, you must just indicate the encrypted folder and the file name.

    For example, you must use `encrypted/resourceArchive-en-US.jet` as a parameter to use the file `StreamingAssets/encrypted/resourceArchive-en-US.jet`.

    3.2 Inherit from the FKCoreListener interface and rewrite its methods to receive responses to requests:

    ```
    public interface FKCoreListener {
        // Receive word predictions and completions
        public void OnCurrentWordPredictions(ArrayList predictions);

        // Receive next word predictions
        public void OnNextWordPredictions(ArrayList predictions);

        // Receive swipe decoding
        void OnSwipeWordPredictions(ArrayList predictions);
    }
    ```

    In the example attached with the FKCoreXR.package, the main class is DemoFKCore. We inherit from the interface that we have commented on before:

    ```
    public class DemoFKCore : MonoBehaviour, FKCoreListener
    ```

    We implement the methods of the interface:
    We get a list with the corrections ordered from highest to lowest probability.

    ```
    public void OnCurrentWordPredictions(ArrayList predictions) { 

        Debug.Log("OnCurrentWordPredictions: " + predictions.Count);

        if (predictions.Count != 0) {
            string predictions_str = "";
            foreach (FKPredictionItem item in predictions) {
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
    ```

    We get a list with the predictions ordered from highest to lowest probability.

    ```
    public void OnNextWordPredictions(ArrayList predictions) { 
        Debug.Log("OnNextWordPredictions: " + predictions.Count);

        if (predictions.Count != 0)
        {
            string predictions_str = "";

            foreach (FKPredictionItem item in predictions) {
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
    ```

    We get a list of words that fit the Swipe ordered from highest to lowest probability.

    ```
    public void OnSwipeWordPredictions(ArrayList predictions) {
        if (predictions.Count != 0) {
            textMeshPro.text = textMeshPro.text + " " + ((FKPredictionItem)(predictions[0])).label;
        }; 
    }
    ```

    To execute the FKCoreXR methods that cause the previous responses, we must use:

    Spelling correction:

    ```
    // Get the last word of the text
    string tmp = GetLastWord(textMeshPro.text);

    // We call the CurrentWordPrediction method of the instance of our FKCoreXR class, passing it this word as a parameter.
    fKCoreXR.CurrentWordPrediction(tmp, 1, tmp.Length);
    ```

    Predictions:

    ```
    // Get the last word of the text
    string tmp = GetLastWord(textMeshPro.text);

    // We call the NextWordPrediction method of the instance of our FKCoreXR class, passing this word as a parameter. fKCoreXR.NextWordPrediction(tmp, 1, tmp.Length);
    ```

    In the provided example, you can find this code inside the DemoFKCoreButton1 and DemoFKCoreButton2 scripts. We implement these button classes manually. You can use Unity's XR Interaction Toolkit, but this demo does not use it.

    Swipe:

    We have to perform three actions:

    1. Start the Swipe

        ```
        FKCoreXR demo = GameObject.Find("_FKCoreXR").GetComponent<FKCoreXR>(); demo.startSwipe();
        ```

    2. Send each point

        ```
        FKCoreXR demo = GameObject.Find("_FKCoreXR").GetComponent<FKCoreXR>(); demo.sendSwipeTypePoint(r.x, r.y);
        ```

        It is important to note that we must pass the coordinates of the point in the coordinate space of the keyboard definition currently loaded by FKCoreXR. Remember that by default, it has a 320 x 288 keyboard loaded.

        ```
        Vector3 r = ConvertPoint(new Vector3(point_finger_collider_keyboard.x, point_finger_collider_keyboard.y, 0));
        ```

        `point_finger_collider_keyboard` has the position in coordinates local to the keyboard's dimensions being painted in Unity.

        The ConvertPoint method converts it to the coordinate space of FKCoreXR, in this case 320 x 288.

        ```
        public Vector3 ConvertPoint(Vector3 v) {
            float sx = keyboard_width / keyboard_width_sdk; 
            float sy = keyboard_height / keyboard_height_sdk;

            float max_y = 288f;

            Vector3 resul = v;
            resul.x = resul.x / sx;
            resul.y = max_y - (resul.y / sy);

            return resul;
        }
        ```

        where:

        ```
        public float keyboard_width = 0.18f; 
        public float keyboard_height = 0.18f;
        private float keyboard_width_sdk = 320f; 
        private float keyboard_height_sdk = 288f;
        ```

    3. Finish the swipe so that he answers us with the possible words.

        ```
        FKCoreXR demo = GameObject.Find("_FKCoreXR").GetComponent<FKCoreXR>(); demo.stopSwipe();
        ```

    **Clarifications on the example that is attached with the fleksypredictionsdk.unitypackage**

    The keyboard is just an image. We implement a manual keypress detection mechanism using the finger. We do not use Unity's XR Interaction Toolkit; you can use it with FKCoreXR. There is no problem using Unity's XR Interaction Toolkit. 

    Manual detection involves shooting a beam from the last joint of the index finger of the right hand and checking if it intercepts with the keyboard collider. Then, as previously mentioned, we perform the conversion from the local coordinate space of the image to the coordinate space of the keyboard definition that FKCoreXR has loaded.
 