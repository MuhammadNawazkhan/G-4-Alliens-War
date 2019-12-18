using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using System.Text.RegularExpressions;

public class G4_abc_MethodScript : MonoBehaviour
{
    public G4_abc_MoveBaloon secondClass;
    public Text moveString;
    public int zeroCount;
    public int oneCount;
    public GameObject pointLight;
    public Light light;
    //add audio
    public AudioSource MachineSound;
    public AudioSource AcceptSound;
    public AudioSource RejectSound;
    public AudioSource JetSound;
    public AudioSource TankSound;
    public AudioSource GunSound;

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

    private int Acount;
    private int Bcount;
    private int Ccount;
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
        Acount = 1;
        Bcount = 1;
        Ccount = 1;

    }

    // Update is called once per frame
    void Update()
    {

        //print("Print from Update");
        if (Input.GetKeyDown(KeyCode.Space))
        {


            showTabLine.text = "  Head     Action       Move";
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
                if (!txt.Equals("&") && (txt.Equals("a") || txt.Equals("b") || txt.Equals("c") || txt.Equals("0") || txt.Equals("1") || txt.Equals("2")))
                {
                   
                        if (Fend == false)
                        {

                        if (txt.Equals("a") && Acount == 1)
                        {
                            Acount = 2;
                            zeroCount = 1;
                            TMPr.GetComponent<TextMeshPro>().text = "0";
                            Bcounter = 1;
                            print("FCounter is 1 so set 0 at a");
                            showHead.text = txt + "         Write 0" + "         Right";
                            MoveForward();
                            Fcounter += 1;
                        }
                        else if ((txt.Equals("a") && Acount == 2) || (txt.Equals("1") && zeroCount == 1))
                        {
                            zeroCount = 1;
                            showHead.text = txt + "         Write " + txt + "         Right";
                            MoveForward();
                            Fcounter += 1;
                        } else if (txt.Equals("c") && zeroCount == 0) {
                            zeroCount = 8;
                            showHead.text = txt + "         Write " + txt + "         Stay";

                            RejectSound.Play();
                            RejectedSpaceshipSound.Play();
                            TankSound.Stop();
                            GunSound.Stop();
                            rejectSpaceship.gameObject.GetComponent<Animator>().enabled = true;
                            //MoveForward();
                            Fcounter += 1;
                            enabled = true;
                        }
                        else if (txt.Equals("b") && Bcount == 1 && (zeroCount == 1 || zeroCount == 0))
                        {
                            Bcount = 2;
                            zeroCount = 2;
                            TMPr.GetComponent<TextMeshPro>().text = "1";
                            Bcounter = 1;
                            print("FCounter is 1 so set 0 at a");
                            showHead.text = txt + "         Write 1" + "         Right";
                            MoveForward();
                            Fcounter += 1;
                        }
                        else if ((txt.Equals("b") && Bcount == 2) || (txt.Equals("2") && zeroCount == 2))
                        {
                            zeroCount = 2;
                            showHead.text = txt + "         Write " + txt + "         Right";
                            MoveForward();
                            Fcounter += 1;
                        } else if ((txt.Equals("a") && zeroCount == 2)) {
                            zeroCount = 8;
                            showHead.text = txt + "         Write " + txt + "         Stay";

                            RejectSound.Play();

                            RejectedSpaceshipSound.Play();
                            TankSound.Stop();
                            GunSound.Stop();
                            rejectSpaceship.gameObject.GetComponent<Animator>().enabled = true;
                            //MoveForward();
                            Fcounter += 1;
                            enabled = true;
                        }
                        else if (txt.Equals("c") && Ccount == 1 && zeroCount == 2)
                        {
                            Ccount = 2;
                            zeroCount = 3;
                            TMPr.GetComponent<TextMeshPro>().text = "2";
                            Bcounter = 1;
                            print("FCounter is 1 so set 0 at a");
                            //MoveForward();
                            showHead.text = txt + "         Write 2" + "         Left";
                            MoveBackward();
                            Fend = true;
                            Fcounter += 1;
                        } else if (txt.Equals("1") && (zeroCount == 0 || zeroCount == 4)) {
                            zeroCount = 4;
                            showHead.text = txt + "         Write " + txt + "         Right";
                            MoveForward();
                            Fcounter += 1;
                        } else if (txt.Equals("2") && zeroCount == 4)
                        {
                            zeroCount = 4;
                            showHead.text = txt + "         Write " + txt + "         Right";
                            MoveForward();
                            Fcounter += 1;
                        }
                        else if (txt.Equals("b") && zeroCount == 4) {
                            zeroCount = 5;
                            showHead.text = txt + "         Write " + txt + "         Right";
                            MoveForward();
                            Fcounter += 1;

                        } else if ((txt.Equals("b") || txt.Equals("2")) && zeroCount == 5) {
                            zeroCount = 5;
                            showHead.text = txt + "         Write " + txt + "         Right";
                            MoveForward();
                            Fcounter += 1;
                        } else if (txt.Equals("c") && zeroCount == 5) {

                            zeroCount = 6;
                            showHead.text = txt + "         Write " + txt + "         Right";
                            MoveForward();
                            Fcounter += 1;
                        } else if (txt.Equals("c") && zeroCount == 6) {
                            zeroCount = 6;
                            showHead.text = txt + "         Write " + txt + "         Right";
                            MoveForward();
                            Fcounter += 1;
                        }

                            print("Move Forward");
                            print("i'm forward counter =" + Fcounter);
                            posCal += 1.5f;
                            print("cube position=" + posCal);
                            showString.text = "Current State = Q" + zeroCount;
                            //State();

                            //MoveForward();
                            //Fcounter += 1;
                        }
                        else
                        {

                        if ((txt.Equals("2") || txt.Equals("b") || txt.Equals("1") || txt.Equals("a")) && zeroCount == 3)
                        {
                            zeroCount = 3;
                            showHead.text = txt + "         Write " + txt + "         Left";
                            MoveBackward();
                            //Fcounter = 1;
                        } 
                        else if (txt.Equals("0") && zeroCount == 3)
                        {

                            Fend = false;
                            Acount = 1;
                            Bcount = 1;
                            Ccount = 1;
                            Fcounter = 1;
                            zeroCount = 0;
                            showHead.text = txt + "         Write " + txt + "         Right";
                            MoveForward();
                        }
                            print("Move Forward");
                            print("i'm forward counter =" + Fcounter);
                            posCal += 1.5f;
                            print("cube position=" + posCal);
                            showString.text = "Current State = Q" + zeroCount;
                        }
                    
                   
                }
                else
                {
                    if (zeroCount == 6)
                    {
                        AcceptSound.Play();
                        JetSound.Play();
                        TankSound.Stop();
                        GunSound.Stop();
                        acceptedAirplan.gameObject.GetComponent<Animator>().enabled = true;
                        zeroCount = 7;
                        showString.text = "Current State = Q" + zeroCount;
                        showHead.text = txt + "         Write " + txt + "         Stay";
                        //moveString.text = originalStr + "  String is Accepted";
                        planCol.GetComponent<MeshRenderer>().material.color = new Color32(5, 100, 50, 255);
                        secondClass.EnableUpdate(true);
                        enabled = false;
                    }else if (zeroCount==3) {
                        AcceptSound.Play();
                        JetSound.Play();
                        TankSound.Stop();
                        GunSound.Stop();
                        acceptedAirplan.gameObject.GetComponent<Animator>().enabled = true;
                        zeroCount = 7;
                        showString.text = "Current State = Q" + zeroCount;
                        showHead.text = txt + "         Write " + txt + "         Stay";
                        //moveString.text = originalStr + "  String is Accepted";
                        planCol.GetComponent<MeshRenderer>().material.color = new Color32(5, 100, 50, 255);
                        secondClass.EnableUpdate(true);
                        enabled = false;
                    }
                    else {
                        RejectSound.Play();
                        RejectedSpaceshipSound.Play();
                        TankSound.Stop();
                        GunSound.Stop();
                        rejectSpaceship.gameObject.GetComponent<Animator>().enabled = true;
                        showString.text = "Current State = Q" + zeroCount;
                        showHead.text = txt + "         Write " + txt + "         Stay";
                        //moveString.text = originalStr + "  String is Rejected";
                        planCol.GetComponent<MeshRenderer>().material.color = Color.red;
                        secondClass.EnableUpdate(true);
                        enabled = false;
                    }

       
                }
            }
        }
    }
    public void MoveForward()
    {
        camPosition += 3.0f;
        cam.transform.position = new Vector3(camPosition, 55.0f, -6.0f);
    }
    public void MoveBackward()
    {

        camPosition -= 3.0f;
        cam.transform.position = new Vector3(camPosition, 55.0f, -6.0f);
    }
    public void Compare()
    {
    }

    public void ESbtn()
    {
        //secondClass.EnableUpdate(true);
        enabled = true;
        //str gets input field value
        //MoveBaloon ob = new MoveBaloon();

        originalStr = inputString.GetComponent<Text>().text;

        originalStr = originalStr.Replace(" ", string.Empty);

        string re = @"([a-b-c]+)$";
        Match match = Regex.Match(originalStr, re);
        if (match.Success || originalStr == "")
        {
            StringValidation.text = "";
            //StringValidation.Equals("");
            btnDisable.SetActive(false);
            inputFieldDisable.SetActive(false);
            str = "&&" + originalStr + "&&";
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
                cube.transform.localScale = new Vector3(1.0f, 1.0f, 0.1f);
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
                Cubetxt.GetComponent<TextMeshPro>().color = Color.blue;
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
        else
        {
            StringValidation.text = "*Enter Valid String*";

        }
    }
    public void Head()
    {
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
    public void State()
    {
        showString.text = "Current State = Q" + zeroCount;
        print("Current State=" + stateCounter);
        //showHead.text = "Head at =" + txt;
        //Head();
    }
    public void CreateSphere()
    {
        sphere = GameObject.CreatePrimitive(PrimitiveType.Sphere);
        sphere.transform.position = new Vector3(cubePos, 0.5f, 0.2f);
        sphere.transform.localScale = new Vector3(1.0f, 1.0f, 0.1f);
        //cube.GetComponent<MeshRenderer>().material.color=new 
        sphere.GetComponent<MeshRenderer>().material.color = new Color32(127, 130, 127, 255);
    }
}