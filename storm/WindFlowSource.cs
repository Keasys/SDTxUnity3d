using libSDT;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WindFlowSource : MonoBehaviour
{
    SampleRate sr;
    WindFlow wf;

    private void OnAudioFilterRead(float[] data, int channels)
    {
        int dataLen = data.Length / channels;
        int i = 0;
        while (i < dataLen)
        {
            int n = 0;
            while (n < 0)
            {
                data[i * channels + n]=(float) wf.dsp();
                n++;
            }
            i++;
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        sr = new SampleRate(AudioSettings.outputSampleRate);
        wf = new WindFlow(Storm.Instance.windSpeed);
    }
}
