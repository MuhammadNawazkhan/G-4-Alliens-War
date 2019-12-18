using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using System.Text.RegularExpressions;
public class G4_MethodsScript : MonoBehaviour
{
    public G4_MoveBaloon secondClass;
   // public moveText moveText;
    public Text moveString;
    //public GameObject moveAirplan;
    public int zeroCount;
    public int oneCount;
    public GameObject pointLight;
    public Light light;
    //add audio
    public AudioSource MachineSound;
    public AudioSource AcceptSound;
    public AudioSource RejectSound;
    public AudioSource TankSound;
    public AudioSource GunSound;
    public AudioSource AcceptedJetSound;
    public AudioSource RejectedSpaceshipSound;


    public GameObject planCol;
    public GameObject rejectSpaceship;
    public GameObject acceptedAirplan;
    // get inputed string from input field
    public Text inputString;
    private string str;
    private string originalStr;
    private int input;
    private int input2;
    private int inputLen;
    private int stateCounter;
    public int r;
    public int cubeNub;
    public float cubePos;
    public float posCal;
    // ray cast reading txt
    public string txt;
    //print string
    public Text showTabLine;
    public Text showHead;
    public Text StringValidation;
    public Text showString;
    public int Rcounter;
    //create cube
    private GameObject cube;
    private float xPosition;
    //create sphere
    private GameObject sphere;
    //camera move
    public Camera cam;
    private float camPosition;
    public bool Fend;
    public bool Bend;
    private int Fcounter;
    private int Bcounter;
    //disable gameObjects
    public GameObject btnDisable;
    public GameObject inputFieldDisable;
    //text mesh pro text
    public GameObject TMPr;
    public GameObject Cubetxt;
    // Start is called before the first frame update
    void Start()
    {
        enabled = false;
        Fend = false;
        Bend = true;
        xPosition = -48.0f;
        camPosition = -39.45f;
        Fcounter = 1;
        Bcounter = 1;
        //cubeCounter = 0.0f;
        posCal = 1.5f;
        stateCounter = 1;
        Rcounter = 0;
        zeroCount = 0;
        oneCount = 1;

    }

    // Update is called once per frame
    void Update()
    {

        //print("Print from Update");
        if (Input.GetKeyDown(KeyCode.Space))
        {

           
            showTabLine.text = "Head       Action       Move";
            MachineSound.Play();
            //light = pointLight.GetComponent<Light>();
            //light.color = Color.blue;
            Ray ray = cam.ViewportPointToRay(new Vector3(0.5f, 0.5f, 0.0f));
            RaycastHit hit;
            if (Physics.Raycast(ray, out hit, 100))
            {
                TMPr = hit.transform.GetChild(0).gameObject;
                txt = TMPr.GetComponent<TextMeshPro>().text;
                //showString.text = txt;
                //input = int.Parse(txt);
                //print("i'm int of txt"+input);
                print(inputLen);
                print("i'm reading =" + txt);
                print("I'm looking at " + hit.transform.name);
                //TMPr.GetComponent<TextMeshPro>().text = txt+"5" ;
                Debug.DrawLine(ray.origin, hit.point, Color.red);

                 r = inputLen % 2;
                cubeNub = inputLen / 2;
                cubePos = cubeNub * 1.5f;
                //Head();
                //showHead.text = "Head at ="+txt;
                if (!txt.Equals("&") && (txt.Equals("1")||txt.Equals("0")))
                { 
                    //cubeCounter += 1.5f;
                    //print("i'm reading =" + txt);
                    if (Fend == false)
                    {
                        if (Fcounter == 1)
                        {

                            if (txt.Equals("0"))
                            {
                                zeroCount = 2;
                                stateCounter += 1;

                                input = int.Parse(txt);
                                Bcounter = 1;
                                TMPr.GetComponent<TextMeshPro>().text = "&";
                                showHead.text =txt + "         Write &"+"         Right";
                                print("FCounter is 1 so set &");
                            }
                            else
                            {
                                zeroCount = 1;
                                input = int.Parse(txt);
                                Bcounter = 1;
                                TMPr.GetComponent<TextMeshPro>().text = "&";
                                showHead.text = txt + "         Write &" + "         Right";
                                print("FCounter is 1 so set &");
                            }
                        }
                        else {
                            showHead.text = txt + "         Read " + txt + "         Right"; }
                        //input = int.Parse(txt);
                        //print("i'm int of txt="+input);
                        print("Move Forward");
                        print("i'm forward counter ="+Fcounter);
                        posCal += 1.5f;
                        print("cube position=" + posCal);
                        showString.text = "Current State = Q" + zeroCount;
                        //State();
                        
                        MoveForward();
                        Fcounter += 1;
                    }
                    else if (Fend == true)
                    {
                        if (Bcounter == 1)
                        {
                            if (txt.Equals("0"))
                            {
                                zeroCount = 5;
                                stateCounter += 1;
                                input2 = int.Parse(txt);
                                if (input == input2)
                                {
                                    TMPr.GetComponent<TextMeshPro>().text = "&";
                                    showHead.text =txt + "         Write &" + "         Left";
                                    print("BCounter is 1 so set &");
                                }
                                else
                                {
                                    //showString.text = "Current State = Accepted State";
                                    State();
                                    print("Non Palindrom");
                                    //showString.text = "Accepted";
                                    //TMPr.GetComponent<TextMeshPro>().color = Color.red;
                                    RejectSound.Play();
                                    RejectedSpaceshipSound.Play();
                                    TankSound.Stop();
                                    GunSound.Stop();
                                    //CreateSphere();
                                    //moveString.text = originalStr+ "  String is Rejected";
                                    rejectSpaceship.gameObject.GetComponent<Animator>().enabled = true;
                                    planCol.GetComponent<MeshRenderer>().material.color = Color.red;
                                    secondClass.EnableUpdate(true);
                                    enabled = false;
                                }
                                Fcounter = 1;
                            }
                            else
                            {
                                zeroCount = 5;
                                input2 = int.Parse(txt);
                                if (input == input2)
                                {
                                    TMPr.GetComponent<TextMeshPro>().text = "&";
                                    showHead.text = txt + "         Write &" + "         Left";
                                    print("BCounter is 1 so set &");
                                }

                                else
                                {

                                    //showString.text = "Current State = Accepted State";
                                    State();
                                    print("Non Palindrom");
                                    //showString.text = "Accepted";
                                    //TMPr.GetComponent<TextMeshPro>().color = Color.red;
                                    RejectSound.Play();
                                    RejectedSpaceshipSound.Play();
                                    TankSound.Stop();
                                    GunSound.Stop();
                                    //CreateSphere();
                                    // moveString.text = originalStr + "  String is Rejected";
                                    rejectSpaceship.gameObject.GetComponent<Animator>().enabled = true;
                                    planCol.GetComponent<MeshRenderer>().material.color = Color.red;
                                    secondClass.EnableUpdate(true);
                                    enabled = false;
                                }
                                Fcounter = 1;

                            }
                        }
                        else { showHead.text = txt + "         Read " + txt + "         Left"; }
                        print("i'm int of txt=" + input);
                        print("Move Backward");
                        print("i'm backward counter="+Bcounter);
                        posCal -= 1.5f;
                        print("cube position=" + posCal);
                        showString.text = "Current State = Q" + zeroCount;
                        //State();
                        
                        MoveBackward();
                        Bcounter += 1;
                    }
                }
                else
                {
                    if (Fend == false)
                    {
                        if (txt.Equals("&"))
                        {
                            if (zeroCount == 2)
                            {
                                zeroCount = 4;
                                posCal -= 1.5f;
                                stateCounter += 1;
                                showString.text = "Current State = Q" + zeroCount;
                                //State();
                                showHead.text = txt + "         Read " + txt + "         Left";
                                MoveBackward();
                                Fend = true;
                                print("N");
                            }
                            else {
                                zeroCount = 3;
                                
                                posCal -= 1.5f;
                                stateCounter += 1;
                                showString.text = "Current State = Q" + zeroCount;
                                //State();
                                showHead.text = txt + "         Read " + txt + "         Left";
                                MoveBackward();
                                Fend = true;
                                print("N");
                            }

                           
                            if (Fcounter == 1 && txt.Equals("&") && stateCounter == 2)
                            {
                                //stateCounter += 10;
                                showString.text = "Current State = Accepted State";
                                print("Palindrom");
                                //showString.text = "Accepted";
                                //TMPr.GetComponent<TextMeshPro>().color = Color.red;
                                AcceptSound.Play();
                                AcceptedJetSound.Play();
                                TankSound.Stop();
                                GunSound.Stop();
                                acceptedAirplan.gameObject.GetComponent<Animator>().enabled = true;
                               // moveString.text = originalStr + "  String is Accepted";
                                planCol.GetComponent<MeshRenderer>().material.color = new Color32(5, 100, 50, 255);
                                secondClass.EnableUpdate(true);
                                enabled = false;
                            }
                        }
                        else {
                            Rcounter += 1;
                            if (Rcounter == 2)
                            {
                                showString.text = "Current State = Q" + zeroCount;
                                //State();
                                print("Non Palindrom");
                                //showString.text = "Accepted";
                                //TMPr.GetComponent<TextMeshPro>().color = Color.red;
                                RejectSound.Play();
                                RejectedSpaceshipSound.Play();
                                TankSound.Stop();
                                GunSound.Stop();
                                //CreateSphere();
                                //moveString.text = originalStr + "  String is Rejected";
                                rejectSpaceship.gameObject.GetComponent<Animator>().enabled = true;
                                planCol.GetComponent<MeshRenderer>().material.color = Color.red;
                                secondClass.EnableUpdate(true);
                                enabled = false;
                            }
                        }
                    }
                    else
                    {
                        zeroCount = 0;
                        posCal += 1.5f;
                        stateCounter = 1;
                        showString.text = "Current State = Q" + zeroCount;
                        //State();
                        showHead.text = txt + "         Read " + txt + "         Right";
                        MoveForward();
                        Fend = false;
                        print("M");
                        if (Fcounter == 2 && txt.Equals("&") )
                        {
                            //stateCounter += 10;
                            showString.text = "Current State = Accepted State";
                            print("Palindrom");
                            //showString.text = "Accepted";
                            //TMPr.GetComponent<TextMeshPro>().color = Color.red;
                            AcceptSound.Play();
                            AcceptedJetSound.Play();
                            TankSound.Stop();
                            GunSound.Stop();
                            acceptedAirplan.gameObject.GetComponent<Animator>().enabled = true;
                           // moveString.text = originalStr + "  String is Accepted";
                            planCol.GetComponent<MeshRenderer>().material.color = new Color32(5, 100, 50, 255);
                            secondClass.EnableUpdate(true);
                            enabled = false;

                        }
                    }
                }
            }
        }
    }
    public void MoveForward() {
        camPosition += 3.0f;
        cam.transform.position = new Vector3(camPosition, 55.0f, -6.0f);
    }
    public void MoveBackward() {

        camPosition -= 3.0f;
        cam.transform.position = new Vector3(camPosition, 55.0f, -6.0f);
    }
    public void Compare() {
    }

    public void ESbtn()
    {

        TankSound.Play();
        GunSound.Play();
        //secondClass.EnableUpdate(true);
           enabled = true;
        //str gets input field value
        //MoveBaloon ob = new MoveBaloon();
        
        originalStr = inputString.GetComponent<Text>().text;
        
        originalStr = originalStr.Replace(" ", string.Empty);

        string re = @"([0-1]+)$";
        Match match = Regex.Match(originalStr, re);
        if (match.Success || originalStr == "")
        {
            StringValidation.text ="";
            //StringValidation.Equals("");
            btnDisable.SetActive(false);
            inputFieldDisable.SetActive(false);
            str = "&&" +originalStr+ "&&";
            //print(str);
            inputLen = str.Length;
            //showString.text = str;      
            char[] CHarray = str.ToCharArray();
            for (int i = 0; i < CHarray.Length; i++)
            {
                xPosition += 3.0f;
                //print(CHarray[i]);
                cube = GameObject.CreatePrimitive(PrimitiveType.Cube);
                cube.transform.position = new Vector3(xPosition, 55.0f, -2.0f);
                //cube.transform.rotation= new Vector3(17.5f, 28.0f, 8.3f);
                
                cube.transform.localScale = new Vector3(1.0f, 1.0f, 0.1f);
                //cube.transform.localRotation = new Vector3(17.5f, 28.0f, 8.3f);
                //cube.GetComponent<MeshRenderer>().material.color=new 
                cube.GetComponent<MeshRenderer>().material.color = new Color32(127, 130, 127, 255);
                GameObject go = new GameObject();
                go.transform.parent = cube.transform;
                //go.AddComponent<TextMeshPro>();
                Cubetxt = cube.transform.GetChild(0).gameObject;
                Cubetxt.AddComponent<TextMeshPro>();
                Cubetxt.GetComponent<TextMeshPro>().fontSize = 10;
                Cubetxt.GetComponent<TextMeshPro>().alignment = TextAlignmentOptions.Center;
                Cubetxt.GetComponent<TextMeshPro>().text = CHarray[i].ToString();
                Cubetxt.GetComponent<TextMeshPro>().color = Color.white;
                Cubetxt.transform.Rotate(0, 0, 0);
                Vector3 pos = Cubetxt.transform.localPosition;
                pos.x = 0;
                pos.y = 0;
                pos.z = -0.51f;
                Cubetxt.transform.localPosition = pos;
                //camera.transform.position = new Vector3(x, 0.68f, -2.37f);
            }
            State();
            //Head();
        }
        else {
            StringValidation.text = "*Enter Valid String*";

                }
    }
    public void Head() {
        Ray ray = cam.ViewportPointToRay(new Vector3(0.5f, 0.5f, 0.0f));
        RaycastHit hit;
        if (Physics.Raycast(ray, out hit, 100))
        {
            TMPr = hit.transform.GetChild(0).gameObject;
            txt = TMPr.GetComponent<TextMeshPro>().text;
            //showString.text = txt;
            //input = int.Parse(txt);
            //print("i'm int of txt"+input);
            print(inputLen);
            print("i'm reading =" + txt);
            print("I'm looking at " + hit.transform.name);
            //TMPr.GetComponent<TextMeshPro>().text = txt+"5" ;
            Debug.DrawLine(ray.origin, hit.point, Color.red);
        }
        showHead.text = "Head at =" + txt;
        }
    public void State() {
        showString.text = "Current State = Q"+zeroCount;
        print("Current State=" + stateCounter);
        //showHead.text = "Head at =" + txt;
        //Head();
    }
    public void CreateSphere() {
        sphere = GameObject.CreatePrimitive(PrimitiveType.Sphere);
        sphere.transform.position = new Vector3(cubePos, 0.5f, 0.2f);
        sphere.transform.localScale = new Vector3(1.0f, 1.0f, 0.1f);
        //cube.GetComponent<MeshRenderer>().material.color=new 
        sphere.GetComponent<MeshRenderer>().material.color = new Color32(127, 130, 127, 255);
    }
}
