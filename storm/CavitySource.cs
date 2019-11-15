using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using libSDT;

public class CavitySource : MonoBehaviour
{
    SampleRate sr;
    WindCavity wc;

    private void OnAudioFilterRead(float[] data, int channels)
    {
        int dataLen = data.Length / channels;
        int i = 0;
        while (i < dataLen)
        {
            int n = 0;
            while (n < channels)
            {
                data[i * channels + n] = (float)wc.dsp();
                n++;
            }
            i++;
        }
    }
    // Start is called before the first frame update
    void Start()
    {
        sr = new SampleRate(AudioSettings.outputSampleRate);
        wc = new WindCavity(Storm.Instance.maxDelay, Storm.Instance.cavityLength, Storm.Instance.cavityDiameter, Storm.Instance.windSpeed);
    }

}
