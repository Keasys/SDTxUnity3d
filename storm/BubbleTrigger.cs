using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using libSDT;

public class BubbleTrigger : MonoBehaviour
{
    SampleRate sr;
    Bubble b;
    // Start is called before the first frame update

    private void OnAudioFilterRead(float[] data, int channels)
    {
        int dataLen = data.Length / channels;
        int i = 0;
        while (i < dataLen)
        {
            int n = 0;
            while(n< channels)
            {
                data[i * channels + n] = (float)b.dsp();
                n++;
            }
            i++;
        }

    }
    void Start()
    {
        sr = new SampleRate(AudioSettings.outputSampleRate);
        b = new Bubble(0.012, 1, 0.4);
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.T))
        {
            Debug.Log("Generating bubble");
            Storm.nextRainDrop();
            b.setRadius(Storm.Instance.radius);
            b.setRiseFactor(Storm.Instance.riseFactor);
            b.update();
        }
    }
}
