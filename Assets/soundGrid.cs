using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class soundGrid : MonoBehaviour

{   // declare variables
    public GameObject prefabBlock;

    public int gridY = 10;
    public int gridX = 10;
    public int blockID = 0;
    public int maxLineChars = 11;
    public float offsetZ = 0.0f;
    public float offserX = 0.2f;
    public float offsetY = 0.05f;
    public Object[] audioFiles;

    void Start()
    {

        // load all audio files from resources/audio folder as array
        audioFiles = Resources.LoadAll("Audio", typeof(AudioClip));

        
        createGrid();
    }

    void createGrid()
    {
        for (int x = 0; x < gridY; x++)
        {
            

            for (int y = 0; y < gridX; y++)
            {
                
                // instantite blocks here
                GameObject soundBlock = Instantiate(prefabBlock, Vector3.zero, prefabBlock.transform.rotation) as GameObject;
                soundBlock.transform.parent = transform;
                soundBlock.transform.localPosition = new Vector3(x + (offserX * x), y + (offsetY * y), offsetZ);
                soundBlock.name = ("sB_x"+ x as string + "_y" + y as string + "_ID" + blockID as string +"_clip_" + audioFiles[blockID].name  );

                // work on each block parameters through component cast
                blockController tempBlockController = soundBlock.GetComponent<blockController>();
                AudioSource tempAS = soundBlock.GetComponent<AudioSource>();
                tempBlockController.blockText.text = splitString( audioFiles[blockID].name, maxLineChars );
                tempBlockController.blockID = blockID;
                tempBlockController.audioToPlay = audioFiles[blockID];
                tempAS.clip = (AudioClip)audioFiles[blockID];


                // remember to increment blockID 
                blockID++;
            }
        }
    }

    private string splitString(string input, int lineLength)
    {

        // Split string by char " "         
        string[] words = input.Split("_"[0]);

        // Prepare result
        string result = "";

        // Temp line string
        string line = "";

        // for each all words        
        foreach (string s in words)
        {
            // Append current word into line
            string temp = line + " " + s;

            // If line length is bigger than lineLength
            if (temp.Length > lineLength)
            {

                // Append current line into result
                result += line + "\n";
                // Remain word append into new line
                line = s;
            }
            // Append current word into current line
            else
            {
                line = temp;
            }
        }

        // Append last line into result        
        result += line;

        // Remove first " " char
        return result.Substring(1, result.Length - 1);
    }

}
