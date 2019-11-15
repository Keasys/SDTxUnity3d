# SDTxUnity3d
C# wrapper for SoundDesignToolkit, physical modelling synthesis engine

# Build Instructions (Visual Studio 2017)

1. open folder build/Windows in a Visual C++ Dynamic Library Project
2. compile settings : x64, Release Mode
3. copy libSDT.dll in your Plugins folder in your Unity3d project (Assets folder)

# Documentation

libSDT is a physical modeling synthesis engine written in C originally to be embedded in a Pure Data/ Max MSP environment.
Here's an attempt to make this library embeddable in a C# environment like Unity3d.

Every class is equipped with a .dsp method, which renders the audio, and several setters to control synthesis parameters in real-time.
The MonoBehaviour script needs to implement *OnAudioFilterRead()*, provided by UnityEngine. This procedure is called any sampling period to fill the Unity's audio buffer. In this function we want to call *.dsp()* on any object we are implementing in the scene we want to produce sound.

In order to do this we must create a SampleRate object, having a sample rate according to Unity's audio settings.



## SampleRate

SampleRate object provides temporal granularity for any other object to produce sound, if not initialized properly, <i>.dsp()</i> methods of any other class won't work. Constructor paramenter is a double and represents the sample rate at which libSDT works.
  
##  Bubble

Bubble object are a mathematical modelization of a bubble's sound it has three parameters
* radius

    bubble's radius
* depth

    bubble's distance from the surface
* riseFactor

    velocity at which the bubble reach the surface
* update
    
    reset the bubble at inititial values, being able to make sound again
    
  
## FluidFlow
Fluidflow 
  
## WindFlow
  
## WindCavity
  
## WindKarman
  
## Explosion
  
## Resonator
  
## Interactor ( Impact - Friction )
  
## Control

# Issues
