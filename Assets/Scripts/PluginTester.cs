using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Runtime.InteropServices;

//All code unless specified is referenced from Tom's example code in the tutorial.

public struct IntPos
{
    public IntPos(Vector3 vecPos)
    {
        x = (int)vecPos.x;
        y = (int)vecPos.y;
        z = (int)vecPos.z;
    }

    public IntPos (int locX, int locY, int locZ)
    {
        x = locX;
        y = locY;
        z = locZ;
    }

    public int x;
    public int y;
    public int z;

    public Vector3 Vec3()
    {
        return new Vector3(x, y, z);
    }
}

public class PluginTester : MonoBehaviour
{
    const string DLL_NAME = "TestPlugin";

    [DllImport(DLL_NAME)]
    private static extern void LoadObj(string filePath);

    [DllImport(DLL_NAME)]
    private static extern void SaveObj(string filePath);

    [DllImport(DLL_NAME)]
    private static extern void setObj(int locX, int locY, int locZ);

    [DllImport(DLL_NAME)]
    private static extern System.IntPtr getObj();

    [DllImport(DLL_NAME)]
    private static extern int getLocX();

    [DllImport(DLL_NAME)]
    private static extern int getLocY();

    [DllImport(DLL_NAME)]
    private static extern int getLocZ();

    public Vector3 objPos;

    //public IntPos location;

    void Update()
    { 
        if (Input.GetKeyDown(KeyCode.L));
        {
            activateLoadObj();
        }
        
        if (Input.GetKeyDown(KeyCode.K))
        {
            activateSaveObj();
        }
    }

    public void activateSaveObj()
    {
        Debug.Log("Saving Object Location Data...");

        //transformation to int conversion
        //https://gamedev.stackexchange.com/questions/118371/what-do-position-transform-and-input-getaxis-mean-in-unity/118390#118390

        int locX = Mathf.RoundToInt(transform.position.x);
        int locY = Mathf.RoundToInt(transform.position.y);
        int locZ = Mathf.RoundToInt(transform.position.z);

        objPos = new Vector3(locX, locY, locZ);

        int x = locX;
        int y = locY;
        int z = locZ;

        setObj(x, y, z);
        SaveObj("ObjLoc.txt");
    }

    public void activateLoadObj()
    {
        LoadObj("ObjLoc.txt");

        Debug.Log("Loading Obj Location Data...");

        int x = getLocX();
        int y = getLocY();
        int z = getLocZ();

        int location = x * y * z;

        byte[] a_location = new byte[location];

        Marshal.Copy(getObj(), a_location, 0, location);
    }
}