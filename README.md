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
* radius: bubble's radius
* depth: bubble's distance from the surface
* riseFactor: velocity at which the bubble reach the surface
Class' exposing a method to reset the bubble's sound process
* update    
  
## FluidFlow
Fluidflow objects are continous flows of liquids, implemented as a population of bubble measured in number of bubbles per second.
Parameters for bubble modeling are the same ones exposed for the bubble object. The only difference is that in this case parameters model the population of bubble givining a minimum, a maximum and an expected value ( between 0 and 1 ) for every bubble parameter.
  
## WindFlow
WindFlow models sound produced by wind hitting a large surface, depending on its irreguarities.The resulting sound is modeled through a bandpass-filtered white noise generator. The center frequency and bandwidth of the filter are empirically set to fixed values, while
the resulting output is modulated in amplitude according to the velocity of the air flow.
The only parameter exposed is the wind's speed.
  
## WindCavity
WindCavity synthesises the sound of wind inside a cavity of a certain diameter and length. Wind's speed parameter is exposed as well
  
## WindKarman
WindKarman simulates the howling sound of wind, hitting through thin objects like wires or brench's trees.
Parameters exposed are wind speed and diameter of the object being hit.
  
## Explosion
  
## Resonator
Resonator is a more complex resonating object, modeled as a spring-mass mechanical oscillator.Resonant modes can be blended together and weighted differently depending on the chosen pickup point, simulating different sonic reactions of an object according to the point hit.
*setters
..*Posiotion
..*Velocity
..*Frequency
..*Decay
..*Weight
..*Gain
..*FragmentSize
..*activeModes
*applyForce
*computeEnergy
  
## Interactor ( Impact - Friction )
Interactors is an abstract class which can be built only by his subclasses constructors: Impact and Fraction
The first modeling an impact, the second a friction between two resonators
  
## Control

# Issues
