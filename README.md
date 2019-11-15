# SDTxUnity3d
C# wrapper for SoundDesignToolkit, physical modelling synthesis engine

# Build Instructions (Visual Studio 2017)

1. open folder build/Windows in a Visual C++ Dynamic Library Project
2. compile settings : x64, Release Mode<br>
3. copy libSDT.dll in your Plugins folder in your Unity3d project (Assets folder)<br>

# Documentation

libSDT is a physical modeling synthesis engine written in C originally to be embedded in a Pure Data/ Max MSP environment.
Here's an attempt to make this library embeddable in a C# environment like Unity3d.<br>



  <b>SampleRate</b>
  SampleRate object provides temporal granularity for any other object to produce sound, if not initialized properly, <i>.dsp()</i> methods             of any other class won't work.
  
  <b>Bubble</b>
  
  <b>FluidFlow</b>
  
  <b>WindFlow</b>
  
  <b>WindCavity</b>
  
  <b>WindKarman</b>
  
  <b>Explosion</b>
  
  <b>Resonator</b>
  
  <b>Interactor ( Impact - Friction )</b>
  
  <b>Control</b> 
