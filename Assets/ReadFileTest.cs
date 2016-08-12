using UnityEngine;
using System.Collections;
using System.Text;
using System.IO;
using System;

public class ReadFileTest : MonoBehaviour {

    private bool Load(string filename)
    {
        try
        {
            string line;
            StreamReader theReader = new StreamReader(filename, Encoding.Default);
            using(theReader)
            {
                do
                {
                    line = theReader.ReadLine();
                    if (line != null)
                    {
                        string[] entries = line.Split(';');
                        if (entries.Length > 0)
                        {
                            //DoStuff(entries);
                        }
                    }
                }while (line != null);
                
                theReader.Close();
                return true;
                
            }
        }
        catch (Exception e)
        {
            Debug.Log(e);
            return false;
        }
    }
}
