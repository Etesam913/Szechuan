using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Test : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject RendererDone;
    public Material PanMat;
    public Material FridgeMat;
    public Material KnifeMat;
    public Material BoardMat;
    public Material StoveMat;
    public Material TableMat;
    public Material GlowMat;
    GameObject Obj;
    GameObject Obj2;
    GameObject Arrow2;
    GameObject Arrow3;
    GameObject Arrow4;
    float MultiplierDegree = 57.2958f;
    float t,t2,t3,t4;
    float speed = 40f;
    int whichArrow = 5;
    bool needsUpdate = true;
    /*float t_old = 0;
    float z_old = 0;
    float x_old = 0;
    float dx, dz, dt;
    float temp;*/

    Vector3 storeEuler, storeEuler2, storeEuler3, storeEuler4;
    void Start()
    {
        Obj = GameObject.FindWithTag("Pan");
        Obj.GetComponent<MeshRenderer>().material = GlowMat;
        //Obj = GameObject.FindWithTag("Fridge");
        //Obj = GameObject.FindWithTag("Fridge");
        Obj2 = GameObject.FindWithTag("Arrow");
        Arrow2 = GameObject.FindWithTag("Arrow2");
        Arrow3 = GameObject.FindWithTag("Arrow3");
        Arrow4 = GameObject.FindWithTag("Arrow4");
        /*Debug.Log(Obj.transform.position);
        Debug.Log(Obj2.transform.position);
        Debug.Log(Obj2.transform.rotation);
        Debug.Log(Obj.transform.eulerAngles);*/
        t = (float)Math.Atan((Obj2.transform.position.x - Obj.transform.position.x) / (Obj.transform.position.z - Obj2.transform.position.z))* MultiplierDegree;
        if (t < 0)
        {
            t = t + 360;
        }
        storeEuler = Obj2.transform.eulerAngles;
        storeEuler2 = Arrow2.transform.eulerAngles;
        storeEuler3 = Arrow3.transform.eulerAngles;
        storeEuler4 = Arrow4.transform.eulerAngles;
        /*//Obj2.transform.eulerAngles = new Vector3(storeEuler.x, storeEuler.y, t);
        //transform.position = Quaternion.AngleAxis(t, Vector3.up) * cameraOffset;
        Obj2.transform.Rotate(0, 0, 30);*/
        /*Debug.Log(Obj2.transform.eulerAngles);
        Debug.Log("HEreeeeeeeeeee");
        Debug.Log(Obj2.transform.localEulerAngles);*/
        /*t_old = t;
        z_old = Obj2.transform.position.z;
        x_old = Obj2.transform.position.x;*/


        


        if (((float)Math.Abs((360 - storeEuler.y) - t)) < 5)
        {
            Obj2.GetComponent<MeshRenderer>().enabled = true;
            whichArrow = 1;
        }
        else if (((float)Math.Abs((360 - storeEuler2.y) - t)) < 5) {
            Arrow2.GetComponent<MeshRenderer>().enabled = true;
            whichArrow = 2;
        }
        else if (((float)Math.Abs((360 - storeEuler3.y) - t)) < 5)
        {
            Arrow3.GetComponent<MeshRenderer>().enabled = true;
            whichArrow = 3;
        }
        else if (((float)Math.Abs((360 - storeEuler4.y) - t)) < 5)
        {
            Arrow4.GetComponent<MeshRenderer>().enabled = true;
            whichArrow = 4;
        }
        else {
            /*Obj2.GetComponent<MeshRenderer>().enabled = false;
            Arrow2.GetComponent<MeshRenderer>().enabled = false;
            Arrow3.GetComponent<MeshRenderer>().enabled = false;
            Arrow4.GetComponent<MeshRenderer>().enabled = false;*/
            whichArrow = 5;
        }

    }

    // Update is called once per frame
    void Update()
    {
        if (Stove_Tutorial.stoveDone == true) {
            Obj.GetComponent<MeshRenderer>().material = StoveMat;
            RendererDone.GetComponent<MeshRenderer>().enabled = true;
        }
        else if (Board_Tutorial.boardDone == true)
        {
            Obj.GetComponent<MeshRenderer>().material = BoardMat;
            Obj = GameObject.FindWithTag("Stove");
            Obj.GetComponent<MeshRenderer>().material = GlowMat;
        }
        else if (Knife_Tutorial.knifeDone == true)
        {
            Obj.GetComponent<MeshRenderer>().material = KnifeMat;
            Obj = GameObject.FindWithTag("Board");
            Obj.GetComponent<MeshRenderer>().material = GlowMat;
        }
        else if (Fridge_Tutorial.fridgeDone == true)
        {
            Obj.GetComponent<MeshRenderer>().material = FridgeMat;
            Obj = GameObject.FindWithTag("Knife");
            Obj.GetComponent<MeshRenderer>().material = GlowMat;
        }
        else if (Table_Tutorial.tableDone == true)
        {
            Obj.GetComponent<MeshRenderer>().material = TableMat;
            Obj = GameObject.FindWithTag("FridgeDoor");
            Obj.GetComponent<MeshRenderer>().material = GlowMat;
        }
        else if (Pan_Tutorial.panDone == true)
        {
            Obj.GetComponent<MeshRenderer>().material = PanMat;
            Obj = GameObject.FindWithTag("Table");
            Obj.GetComponent<MeshRenderer>().material = GlowMat;
        }
        t = (float)Math.Atan((Obj2.transform.position.x - Obj.transform.position.x) / (Obj.transform.position.z - Obj2.transform.position.z)) * MultiplierDegree;
        if ((t < 0) && (Obj.transform.position.z > Obj2.transform.position.z))
        {
            t = t + 360;
        }
        else if ((t > 0) && (Obj.transform.position.z < Obj2.transform.position.z))
        {
            t = t + 180;
        }
        else if ((t < 0) && (Obj.transform.position.z < Obj2.transform.position.z)) {
            t = t + 180;
        }
      
        //Debug.Log(z);
        /*temp = (float)Math.Cos(t_old / MultiplierDegree);
        dx = Obj2.transform.position.x - x_old;
        dz = Obj2.transform.position.z - z_old;
        dt = ((z_old*dx - x_old*dz)* MultiplierDegree)/ ((z_old*z_old)*(temp*temp)) ;
        storeEuler = Obj2.transform.eulerAngles;
        t = t_old + dt;
        //Obj2.transform.localEulerAngles += new Vector3(storeEuler.x, storeEuler.y, dt);
        if (((float)Math.Abs(t-t_old))>10) {
            //Obj2.transform.rotation = Obj2.transform.rotation * Quaternion.AngleAxis(z, Vector3.forward);
            //Obj2.transform.rotation = Quaternion.Euler(storeEuler.x, storeEuler.y, );
            Obj2.transform.eulerAngles += new Vector3(storeEuler.x, storeEuler.y, dt);
        }
        t_old = t;*/
        storeEuler = Obj2.transform.eulerAngles;
        storeEuler2 = Arrow2.transform.eulerAngles;
        storeEuler3 = Arrow3.transform.eulerAngles;
        storeEuler4 = Arrow4.transform.eulerAngles;
        Debug.Log(Obj.transform.position);
        Debug.Log(storeEuler.z);
        Debug.Log(360-storeEuler.y);
        Debug.Log(storeEuler.x);
        Debug.Log(t);
        if (whichArrow == 1)
        {
            if (((float)Math.Abs((360 - storeEuler.y) - t)) > 5)
            {
                needsUpdate = true;
            }
            else
            {
                needsUpdate = false;
            }
        }
        else if (whichArrow == 2)
        {
            if (((float)Math.Abs((360 - storeEuler2.y) - t)) > 5)
            {
                needsUpdate = true;
            }
            else
            {
                needsUpdate = false;
            }
        }
        else if (whichArrow == 3)
        {
            if (((float)Math.Abs((360 - storeEuler3.y) - t)) > 5)
            {
                needsUpdate = true;
            }
            else
            {
                needsUpdate = false;
            }
        }
        else if (whichArrow == 4)
        {
            if (((float)Math.Abs((360 - storeEuler4.y) - t)) > 5)
            {
                needsUpdate = true;
            }
            else
            {
                needsUpdate = false;
            }
        }
        else {
            needsUpdate = true;
        }

        if ((whichArrow == 5) || (needsUpdate == true))
        {
            Obj2.GetComponent<MeshRenderer>().enabled = false;
            Arrow2.GetComponent<MeshRenderer>().enabled = false;
            Arrow3.GetComponent<MeshRenderer>().enabled = false;
            Arrow4.GetComponent<MeshRenderer>().enabled = false;
            if (((float)Math.Abs((360 - storeEuler.y) - t)) > 5)
            {
                Obj2.transform.Rotate(0, 0, speed * Time.deltaTime);

                if (((float)Math.Abs((360 - storeEuler2.y) - t)) > 5)
                {
                    Arrow2.transform.Rotate(0, 0, speed * Time.deltaTime);
                    if (((float)Math.Abs((360 - storeEuler3.y) - t)) > 5)
                    {
                        Arrow3.transform.Rotate(0, 0, speed * Time.deltaTime);
                        if (((float)Math.Abs((360 - storeEuler4.y) - t)) > 5)
                        {
                            Arrow4.transform.Rotate(0, 0, speed * Time.deltaTime);
                            Obj2.GetComponent<MeshRenderer>().enabled = false;
                            Arrow2.GetComponent<MeshRenderer>().enabled = false;
                            Arrow3.GetComponent<MeshRenderer>().enabled = false;
                            Arrow4.GetComponent<MeshRenderer>().enabled = false;
                            whichArrow = 5;
                        }
                        else
                        {
                            Arrow4.GetComponent<MeshRenderer>().enabled = true;
                            whichArrow = 4;
                        }
                    }
                    else
                    {
                        Arrow3.GetComponent<MeshRenderer>().enabled = true;
                        whichArrow = 3;
                        if (((float)Math.Abs((360 - storeEuler4.y) - t)) > 5)
                        {
                            Arrow4.transform.Rotate(0, 0, speed * Time.deltaTime);
                        }
                    }
                }
                else
                {
                    Arrow2.GetComponent<MeshRenderer>().enabled = true;
                    whichArrow = 2;
                    if (((float)Math.Abs((360 - storeEuler3.y) - t)) > 5)
                    {
                        Arrow3.transform.Rotate(0, 0, speed * Time.deltaTime);
                    }
                    if (((float)Math.Abs((360 - storeEuler4.y) - t)) > 5)
                    {
                        Arrow4.transform.Rotate(0, 0, speed * Time.deltaTime);
                    }
                }
            }
            else
            {
                Obj2.GetComponent<MeshRenderer>().enabled = true;
                whichArrow = 1;
                if (((float)Math.Abs((360 - storeEuler2.y) - t)) > 5)
                {
                    Arrow2.transform.Rotate(0, 0, speed * Time.deltaTime);
                }
                if (((float)Math.Abs((360 - storeEuler3.y) - t)) > 5)
                {
                    Arrow3.transform.Rotate(0, 0, speed * Time.deltaTime);
                }
                if (((float)Math.Abs((360 - storeEuler4.y) - t)) > 5)
                {
                    Arrow4.transform.Rotate(0, 0, speed * Time.deltaTime);
                }
            }
        }




    }

    /*static public void updateObj(GameObject obj) {
        Obj = obj;
    }*/
}
