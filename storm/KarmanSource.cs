using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using libSDT;

public class KarmanSource : MonoBehaviour
{
    SampleRate sr;
    WindKarman wk;
    //public System.Random r;
    float currentsample;
    private void OnAudioFilterRead(float[] data, int channels)
    {
        int dataLen = data.Length / channels;
        int i = 0;
        while (i < dataLen)
        {
            int n = 0;
            while (n < channels)
            {

                currentsample = (float)wk.dsp();
                //Debug.Log(currentsample);
                data[i* channels+n]= currentsample;
                n++;
            }
            //float sample = ((float)r.NextDouble())*0.2f;
            //Debug.Log(sample);
            i++;
        }
    }
    // Start is called before the first frame update
    void Start()
    {

        sr = new SampleRate(AudioSettings.outputSampleRate);
        wk = new WindKarman(Storm.Instance.karmanDiameter,Storm.Instance.windSpeed);
        //r = new System.Random();

        
    }
}
