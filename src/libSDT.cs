using System.Collections;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using UnityEngine;
using System;

namespace libSDT
{
    public class SampleRate
    {
        double sr;
        public SampleRate(double srate)
        {
            SDT_setSampleRate(srate);
            sr = srate;
        }
        public void setSampleRate(double srate)
        {
            SDT_setSampleRate(srate);
            sr = srate;
        }
        public double getSampleRate()
        {
            return sr;
        }
        [DllImport("libSDT")]
        private static extern void SDT_setSampleRate(double sampleRate);
    }
    public class Bubble
    {
        private const double MIN_RADIUS = 0.00015;
        private const double MAX_RADIUS = 0.150;
        private const double MAX_EXP = 10.0;
        private const double MAX_RISE = 3.0;
        private const double MAX_RATE = 100000.0;

        private unsafe SDTBubble* bubble;
        public double r, d, rf;

        public unsafe Bubble(double radius, double depth, double riseFactor)
        {
            bubble = SDTBubble_new();
            r = radius;
            SDTBubble_setRadius(bubble, radius);
            d = depth;
            SDTBubble_setDepth(bubble, depth);
            rf = riseFactor;
            SDTBubble_setRiseFactor(bubble, riseFactor);


        }
        public unsafe void update()
        {
            SDTBubble_update(this.bubble);
        }
        public unsafe void free()
        {
            SDTBubble_free(this.bubble);
        }
        public unsafe void setRadius(double radius)
        {
            SDTBubble_setRadius(this.bubble, radius);
        }
        public unsafe void setDepth(double depth)
        {
            SDTBubble_setDepth(this.bubble,depth);
        }
        public unsafe void setRiseFactor(double risefactor)
        {
            SDTBubble_setRiseFactor(this.bubble, risefactor);
        }
        public unsafe void normAmp()
        {
            SDTBubble_normAmp(this.bubble);
        }
        public unsafe double dsp()
        {
            return SDTBubble_dsp(this.bubble);
        }

        //Bubble Dll exports

        [StructLayout(LayoutKind.Sequential, CharSet = CharSet.Ansi)]
        private struct SDTBubble
        {
            private double radius, depth, riseFactor,
                   amp, decay, gain, phaseStep, phaseRise,
                   phase, output, lastOut;
        }
        [DllImport("libSDT")]
        private static extern unsafe SDTBubble* SDTBubble_new();
        [DllImport("libSDT")]
        private static extern unsafe void SDTBubble_free(SDTBubble* b);
        [DllImport("libSDT")]
        private static extern unsafe void SDTBubble_setRadius(SDTBubble* b, double f);
        [DllImport("libSDT")]
        private static extern unsafe void SDTBubble_setDepth(SDTBubble* b, double f);
        [DllImport("libSDT")]
        private static extern unsafe void SDTBubble_setRiseFactor(SDTBubble* b, double f);
        [DllImport("libSDT")]
        private static extern unsafe void SDTBubble_update(SDTBubble* b);
        [DllImport("libSDT")]
        private static extern unsafe void SDTBubble_normAmp(SDTBubble* b);
        [DllImport("libSDT")]
        private static extern unsafe double SDTBubble_dsp(SDTBubble* b);

    }
    public class FluidFlow
    {
        private unsafe SDTFluidFlow* liquid;

        public unsafe FluidFlow(double avgRate, double expDepth, double expRadius, double maxDepth, double maxRadius, double minDepth, double minRadius, double riseCutoff, double riseFactor)
        {
            this.liquid = SDTFluidFlow_new();
            SDTFluidFlow_setAvgRate(liquid, avgRate);
            SDTFluidFlow_setExpDepth(liquid, expDepth);
            SDTFluidFlow_setExpRadius(liquid, expRadius);
            SDTFluidFlow_setMaxDepth(liquid, maxDepth);
            SDTFluidFlow_setMaxRadius(liquid, maxRadius);
            SDTFluidFlow_setMinDepth(liquid, minDepth);
            SDTFluidFlow_setMinRadius(liquid, minRadius);
            SDTFluidFlow_setRiseCutoff(liquid, riseCutoff);
            SDTFluidFlow_setRiseFactor(liquid, riseFactor);
        }
        public unsafe void setAvgRate(double avgRate)
        {
            SDTFluidFlow_setAvgRate(this.liquid, avgRate);
        }

        public unsafe void setExpDepth(double expRadius)
        {

            SDTFluidFlow_setExpDepth(this.liquid, expRadius);
        }

        public unsafe void setExpRadius(double expRadius)
        {
            if (expRadius > 0.00015 || expRadius < 0.150)
                SDTFluidFlow_setExpRadius(this.liquid, expRadius);
        }

        public unsafe void setMaxDepth(double maxDepth)
        {
            SDTFluidFlow_setMaxDepth(this.liquid, maxDepth);
        }

        public unsafe void setMaxRadius(double maxRadius)
        {
            SDTFluidFlow_setMaxRadius(this.liquid, maxRadius);
        }

        public unsafe void setMinDepth(double minDepth)
        {
            SDTFluidFlow_setMinDepth(this.liquid, minDepth);
        }

        public unsafe void setMinRadius(double minRadius)
        {
            SDTFluidFlow_setMinRadius(this.liquid,minRadius);
        }
        public unsafe void setRiseCutoff(double riseCutoff)
        {
            SDTFluidFlow_setRiseCutoff(this.liquid,riseCutoff);
        }
        public unsafe void setRiseFactor(double riseFactor)
        {
            SDTFluidFlow_setRiseFactor(this.liquid, riseFactor);
        }
        public unsafe double dsp()
        {
            return SDTFluidFlow_dsp(this.liquid);
        }

        //FluidFlow Dll exports 

        [StructLayout(LayoutKind.Sequential, CharSet = CharSet.Ansi)]
        private struct SDTBubble
        {
            private double radius, depth, riseFactor,
                   amp, decay, gain, phaseStep, phaseRise,
                   phase, output, lastOut;
        }
        [StructLayout(LayoutKind.Sequential, CharSet = CharSet.Ansi)]
        private unsafe struct SDTFluidFlow
        {
            /*private SDTBubble** bubbles;
            private double minRadius, maxRadius, expRadius,
                   minDepth, maxDepth, expDepth,
                   riseFactor, riseCutoff, avgRate,
                   success, gain;
            private int nBubbles;*/
        };

        [DllImport("libSDT")]
        private unsafe static extern SDTFluidFlow* SDTFluidFlow_new();

        [DllImport("libSDT")]
        private unsafe static extern void SDTFluidFlow_free(SDTFluidFlow* l);

        [DllImport("libSDT")]
        private unsafe static extern void SDTFluidFlow_setMinRadius(SDTFluidFlow* x, double f);

        [DllImport("libSDT")]
        private unsafe static extern void SDTFluidFlow_setMaxRadius(SDTFluidFlow* x, double f);

        [DllImport("libSDT")]
        private unsafe static extern void SDTFluidFlow_setExpRadius(SDTFluidFlow* x, double f);

        [DllImport("libSDT")]
        private unsafe static extern void SDTFluidFlow_setMinDepth(SDTFluidFlow* x, double f);

        [DllImport("libSDT")]
        private unsafe static extern void SDTFluidFlow_setMaxDepth(SDTFluidFlow* x, double f);

        [DllImport("libSDT")]
        private unsafe static extern void SDTFluidFlow_setExpDepth(SDTFluidFlow* x, double f);

        [DllImport("libSDT")]
        private unsafe static extern void SDTFluidFlow_setRiseFactor(SDTFluidFlow* x, double f);

        [DllImport("libSDT")]
        private unsafe static extern void SDTFluidFlow_setRiseCutoff(SDTFluidFlow* x, double f);

        [DllImport("libSDT")]
        private unsafe static extern void SDTFluidFlow_setAvgRate(SDTFluidFlow* x, double f);

        [DllImport("libSDT")]
        private unsafe static extern double SDTFluidFlow_dsp(SDTFluidFlow* x);
    }

    public class WindFlow
    {
        private unsafe SDTWindFlow* windFlow;

        public unsafe WindFlow(double windSpeed)
        {
            windFlow = SDTWindFlow_new();
            SDTWindFlow_setFilters(this.windFlow);
            SDTWindFlow_setWindSpeed(this.windFlow, windSpeed);
        }

        public unsafe void setWindSpeed(double windSpeed)
        {
            SDTWindFlow_setWindSpeed(this.windFlow, windSpeed);
        }

        public unsafe double dsp()
        {
            return SDTWindFlow_dsp(this.windFlow);
        }

        //WindFlow Dll exports

        [StructLayout(LayoutKind.Sequential, CharSet = CharSet.Ansi)]
        private struct SDTWindFlow { };

        [DllImport("libSDT")]
        private unsafe static extern SDTWindFlow* SDTWindFlow_new();

        [DllImport("libSDT")]
        private unsafe static extern void SDTWindFlow_free(SDTWindFlow* x);

        [DllImport("libSDT")]
        private unsafe static extern void SDTWindFlow_setFilters(SDTWindFlow* x);

        [DllImport("libSDT")]
        private unsafe static extern void SDTWindFlow_setWindSpeed(SDTWindFlow* x, double f);

        [DllImport("libSDT")]
        private unsafe static extern double SDTWindFlow_dsp(SDTWindFlow* x);

    }

    public class WindCavity
    {
        private unsafe SDTWindCavity* windCavity;

        public unsafe WindCavity(int maxDelay, double length, double diameter, double windSpeed)
        {
            windCavity = SDTWindCavity_new(maxDelay);
            SDTWindCavity_setLength(this.windCavity, length);
            SDTWindCavity_setDiameter(this.windCavity, diameter);
            SDTWindCavity_setWindSpeed(this.windCavity, windSpeed);
        }

        public unsafe void setLength(double length)
        {
            SDTWindCavity_setLength(this.windCavity, length);
        }

        public unsafe void setDiameter(double diameter)
        {
            SDTWindCavity_setDiameter(this.windCavity, diameter);
        }

        public unsafe void setWindSpeed(double speed)
        {
            SDTWindCavity_setWindSpeed(this.windCavity, speed);
        }

        public unsafe double dsp()
        {
            return SDTWindCavity_dsp(this.windCavity);
        }

        //WindCavity Dll exports

        [StructLayout(LayoutKind.Sequential, CharSet = CharSet.Ansi)]
        private struct SDTWindCavity { };

        /*[DllImport("libSDT")]
        private unsafe static extern void SDTWindCavity_updateGeometry(SDTWindCavity* x);

        [DllImport("libSDT")]
        private unsafe static extern void SDTWindCavity_updateResonance(SDTWindCavity* x);*/

        [DllImport("libSDT")]
        private unsafe static extern SDTWindCavity* SDTWindCavity_new(int maxDelay);

        [DllImport("libSDT")]
        private unsafe static extern void SDTWindCavity_free(SDTWindCavity* x);

        [DllImport("libSDT")]
        private unsafe static extern void SDTWindCavity_setLength(SDTWindCavity* x, double f);

        [DllImport("libSDT")]
        private unsafe static extern void SDTWindCavity_setDiameter(SDTWindCavity* x, double f);

        [DllImport("libSDT")]
        private unsafe static extern void SDTWindCavity_setWindSpeed(SDTWindCavity* x, double f);

        [DllImport("libSDT")]
        private unsafe static extern double SDTWindCavity_dsp(SDTWindCavity* x);
    }

    public class WindKarman
    {
        private unsafe SDTWindKarman* karman;

        public unsafe WindKarman(double diameter, double windSpeed)
        {
            karman = SDTWindKarman_new();
            SDTWindKarman_setDiameter(this.karman, diameter);
            SDTWindKarman_setWindSpeed(this.karman, windSpeed);
        }

        public unsafe void setDiameter(double diameter)
        {
            SDTWindKarman_setDiameter(this.karman, diameter);
        }

        public unsafe void setWindSpeed(double windSpeed)
        {
            SDTWindKarman_setWindSpeed(this.karman, windSpeed);
        }

        public unsafe double dsp()
        {
            return SDTWindKarman_dsp(this.karman);
        }

        //WindKarman Dll exports
        [StructLayout(LayoutKind.Sequential, CharSet = CharSet.Ansi)]
        private struct SDTWindKarman { };

        [DllImport("libSDT")]
        private unsafe static extern SDTWindKarman* SDTWindKarman_new();

        [DllImport("libSDT")]
        private unsafe static extern void SDTWindKarman_free(SDTWindKarman* x);

        [DllImport("libSDT")]
        private unsafe static extern void SDTWindKarman_setDiameter(SDTWindKarman* x, double f);

        [DllImport("libSDT")]
        private unsafe static extern void SDTWindKarman_setWindSpeed(SDTWindKarman* x, double f);

        [DllImport("libSDT")]
        private unsafe static extern double SDTWindKarman_dsp(SDTWindKarman* x);
    }
    public class Explosion
    {
        private unsafe SDTExplosion* explosion;

        public unsafe Explosion(long maxScatter, long maxDelay, double blastTime, double scatterTime, double dispersion, double distance, double waveSpeed)
        {
            explosion = SDTExplosion_new(maxScatter, maxDelay);
            SDTExplosion_setBlastTime(this.explosion, blastTime);
            SDTExplosion_setScatterTime(this.explosion, scatterTime);
            SDTExplosion_setDispersion(this.explosion, dispersion);
            SDTExplosion_setDistance(this.explosion, distance);
            SDTExplosion_setWaveSpeed(this.explosion, waveSpeed);

        }

        public unsafe void setBlastTime(double blastTime)
        {
            SDTExplosion_setBlastTime(this.explosion, blastTime);
        }

        public unsafe void setScatterTime(double scatterTime)
        {
            SDTExplosion_setScatterTime(this.explosion, scatterTime);
        }

        public unsafe void setDispersion(double dispersion)
        {
            SDTExplosion_setDispersion(this.explosion, dispersion);
        }

        public unsafe void setDistance(double distance)
        {
            SDTExplosion_setDistance(this.explosion, distance);
        }

        public unsafe void setWaveSpeed(double waveSpeed)
        {
            SDTExplosion_setWaveSpeed(this.explosion, waveSpeed);
        }

        public unsafe void update()
        {
            SDTExplosion_update(this.explosion);
        }

        public unsafe double dsp()
        {
            double* output = stackalloc double[1];
            SDTExplosion_dsp(this.explosion, output);
            return *output;
        }

        [StructLayout(LayoutKind.Sequential, CharSet = CharSet.Ansi)]
        private struct SDTExplosion { };

        [DllImport("libSDT")]
        private unsafe static extern SDTExplosion* SDTExplosion_new(long maxScatter, long maxDelay);

        [DllImport("libSDT")]
        private unsafe static extern void SDTExplosion_free(SDTExplosion* x);

        [DllImport("libSDT")]
        private unsafe static extern void SDTExplosion_setBlastTime(SDTExplosion* x, double f);

        [DllImport("libSDT")]
        private unsafe static extern void SDTExplosion_setScatterTime(SDTExplosion* x, double f);

        [DllImport("libSDT")]
        private unsafe static extern void SDTExplosion_setDispersion(SDTExplosion* x, double f);

        [DllImport("libSDT")]
        private unsafe static extern void SDTExplosion_setDistance(SDTExplosion* x, double f);

        [DllImport("libSDT")]
        private unsafe static extern void SDTExplosion_setWaveSpeed(SDTExplosion* x, double f);

        [DllImport("libSDT")]
        private unsafe static extern void SDTExplosion_update(SDTExplosion* x);

        [DllImport("libSDT")]
        private unsafe static extern void SDTExplosion_dsp(SDTExplosion* x, double* outs);
    }


    public class Resonator
    {
        internal unsafe SDTResonator* resonator;
        private int NModes;


        public unsafe Resonator(int nModes, int nPickups)
        {
            NModes = nModes;
            resonator = SDTResonator_new(nModes,nPickups);
            
        }

        //get
        public int getNModes()
        {
            return NModes;
        }
        public unsafe double getPosition(int pickUp)
        {
            return SDTResonator_getPosition((SDTResonator*)resonator, pickUp);
        }

        public unsafe double getVelocity(int pickUp)
        {
            return SDTResonator_getVelocity((SDTResonator*)resonator, pickUp);
        }

        public unsafe double getNPickUps()
        {
            return SDTResonator_getNPickups((SDTResonator*)resonator);
        }

        //set
        public unsafe void setPosition(int pickUp, double f)
        {
            SDTResonator_setPosition((SDTResonator*)this.resonator, pickUp, f);
        }

        public unsafe void setVelocity(int pickUp, double f)
        {
            SDTResonator_setVelocity((SDTResonator*)resonator, pickUp, f);
        }

        public unsafe void setFrequency(int mode, double f)
        {
            SDTResonator_setFrequency((SDTResonator*)resonator, mode, f);
        }

        public unsafe void setDecay(int mode , double f)
        {
            SDTResonator_setDecay((SDTResonator*)resonator, mode, f);
        }
        public unsafe void setWeight(int mode, double f)
        {
            SDTResonator_setWeight((SDTResonator*)resonator, mode, f);
        }

        public unsafe void setGain( int pickUp, int mode, double f)
        {
            SDTResonator_setGain((SDTResonator*)resonator, pickUp, mode, f);
        }
        public unsafe void setFragmentSize(double f)
        {
            SDTResonator_setFragmentSize((SDTResonator*)resonator, f);        
        }
        public unsafe void setActiveModes(int n)
        {
            SDTResonator_setActiveModes(this.resonator, n);
        }

        //calc
        public unsafe void applyForce(int pickUp, double f)
        {
            SDTResonator_applyForce((SDTResonator*)resonator, pickUp, f);
        }
        public unsafe void computeEnergy(int pickUp, double f)
        {
            SDTResonator_computeEnergy((SDTResonator*)resonator, pickUp, f);
        }
        public unsafe void dsp()
        {
            SDTResonator_dsp((SDTResonator*)resonator);
        }
        [StructLayout(LayoutKind.Sequential, CharSet = CharSet.Ansi)]
        internal unsafe struct SDTResonator {  };

        [DllImport("libSDT")]
        internal unsafe static extern SDTResonator* SDTResonator_new(int nModes, int nPickups);

        [DllImport("libSDT")]
        private unsafe static extern void SDTResonator_free(SDTResonator* x);

        [DllImport("libSDT")]
        private unsafe static extern double SDTResonator_getPosition(SDTResonator* x, int pickup);

        [DllImport("libSDT")]
        private unsafe static extern double SDTResonator_getVelocity(SDTResonator* x,int pickup);

        [DllImport("libSDT")]
        private unsafe static extern int SDTResonator_getNPickups(SDTResonator* x);

        [DllImport("libSDT")]
        private unsafe static extern void SDTResonator_setPosition(SDTResonator* x, int pickup, double f);

        [DllImport("libSDT")]
        private unsafe static extern void SDTResonator_setVelocity(SDTResonator* x, int pickup, double f);

        [DllImport("libSDT")]
        private unsafe static extern void SDTResonator_setFrequency(SDTResonator* x, int mode, double f);

        [DllImport("libSDT")]
        private unsafe static extern void SDTResonator_setDecay(SDTResonator* x, int mode, double f);

        [DllImport("libSDT")]
        private unsafe static extern void SDTResonator_setWeight(SDTResonator* x,int mode, double f);

        [DllImport("libSDT")]
        private unsafe static extern void SDTResonator_setGain(SDTResonator* x, int pickup, int mode, double f);

        [DllImport("libSDT")]
        private unsafe static extern void SDTResonator_setFragmentSize(SDTResonator* x, double f);

        [DllImport("libSDT")]
        private unsafe static extern void SDTResonator_setActiveModes(SDTResonator* x, int i);

        [DllImport("libSDT")]
        private unsafe static extern void SDTResonator_applyForce(SDTResonator* x, int pickup, double f);

        [DllImport("libSDT")]
        private unsafe static extern double SDTResonator_computeEnergy(SDTResonator* x, int pickup, double f);

        [DllImport("libSDT")]
        private unsafe static extern void SDTResonator_dsp(SDTResonator* x);
    }
    public class InertialMass : Resonator
    {
        public unsafe InertialMass():base(1,1)
        {
           
        }
    }

    public class Interactor
    {
        protected unsafe SDTInteractor* inter;
        internal bool reso1;
        internal bool reso2;

        public unsafe void setFirstResonator(Resonator r, long point)
        {            
            SDTInteractor_setFirstResonator(this.inter,(SDTResonator*) r.resonator);
            SDTInteractor_setFirstPoint(this.inter, point);
            reso1 = true;
            Debug.Log("from reso 1"+reso1);

        }

        public unsafe void setSecondResonator(Resonator r, long point)
        {
            SDTInteractor_setSecondResonator(this.inter, (SDTResonator*)r.resonator);
            SDTInteractor_setSecondPoint(this.inter, point);
            reso2 = true;
            Debug.Log("from reso 2"+reso2);
        }

        public unsafe void computeForce()
        {
            SDTInteractor_computeForce(this.inter);
        }

        public unsafe bool isAttached()
        {
            Debug.Log(reso1 + " " + reso2);
            return reso1 && reso2;
        }

        public unsafe double* dsp(double f0, double v0, double s0, double f1, double v1, double s1 )
        {
            double* output = stackalloc double[2];
            SDTInteractor_dsp(inter, f0, v0, s0, f1, v1, s1, output);
            return output;
        }
        [StructLayout(LayoutKind.Sequential, CharSet = CharSet.Ansi)]
         struct SDTResonator { };

        [StructLayout(LayoutKind.Sequential, CharSet = CharSet.Ansi)]
        public  unsafe struct SDTInteractor { };
        [DllImport("libSDT")]
        private unsafe static extern SDTInteractor* SDTInteractor_new();
        [DllImport("libSDT")]
        private unsafe static extern void SDTInteractor_free(SDTInteractor* x);
        [DllImport("libSDT")]
        private unsafe static extern void SDTInteractor_setFirstResonator(SDTInteractor* x, SDTResonator* p);
        [DllImport("libSDT")]
        private unsafe static extern void SDTInteractor_setSecondResonator(SDTInteractor* x, SDTResonator* p);
        [DllImport("libSDT")]
        private unsafe static extern void SDTInteractor_setFirstPoint(SDTInteractor* x, long l);
        [DllImport("libSDT")]
        private unsafe static extern void SDTInteractor_setSecondPoint(SDTInteractor* x, long l);
        [DllImport("libSDT")]
        private unsafe static extern double SDTInteractor_computeForce(SDTInteractor* x);
        [DllImport("libSDT")]
        private unsafe static extern void SDTInteractor_dsp(SDTInteractor* x, double f0, double v0, double s0,
                       double f1, double v1, double s1, double* outs);



    }

    public class Impact : Interactor
    {
        public unsafe Impact()
        {
            inter = SDTImpact_new();
            reso1 = false;
            reso2 = false;
        }

        public unsafe void setStiffness(double f)
        {
            SDTImpact_setStiffness(inter, f);
        }
        public unsafe void setDissipation(double f)
        {
            SDTImpact_setDissipation(inter, f);
        }
        public unsafe void setShape(double f)
        {
            SDTImpact_setShape(inter, f);
        }



        [StructLayout(LayoutKind.Sequential, CharSet = CharSet.Ansi)]
        private struct SDTImpact { };
        [DllImport("libSDT")]
        private unsafe static extern SDTInteractor* SDTImpact_new();
        [DllImport("libSDT")]
        private unsafe static extern void SDTImpact_free(SDTInteractor* x);
        [DllImport("libSDT")]
        private unsafe static extern void SDTImpact_setStiffness(SDTInteractor* x, double f);
        [DllImport("libSDT")]
        private unsafe static extern void SDTImpact_setDissipation(SDTInteractor* x, double f);
        [DllImport("libSDT")]
        private unsafe static extern void SDTImpact_setShape(SDTInteractor* x, double f);


    }
    public class Friction : Interactor
    {
        public unsafe Friction()
        {
            inter = SDTFriction_new();
            reso1 = false;
            reso2 = false;
        }

        public unsafe void setNormalForce(double f)
        {
            SDTFriction_setNormalForce(inter, f);
        }
        public unsafe void setStribeckVelocity(double f)
        {
            SDTFriction_setStribeckVelocity(inter, f);
        }
        public unsafe void setStaticCoefficient(double f)
        {
            SDTFriction_setStaticCoefficient(inter,f);
        }
        public unsafe void setDynamicCoefficient(double f)
        {
            SDTFriction_setDynamicCoefficient(inter, f);
        }
        public unsafe void setBreakAway(double f)
        {
            SDTFriction_setBreakAway(inter, f);
        }

        public unsafe void setStiffness(double f)
        {
            SDTFriction_setStiffness(inter, f);
        }
        
        public unsafe void setDissipation(double f)
        {
            SDTFriction_setDissipation(inter, f);
        }
        public unsafe void setViscosity(double f)
        {
            SDTFriction_setViscosity(inter, f);
        }
        public unsafe void setNoisiness(double f)
        {
            SDTFriction_setNoisiness(inter, f);
        }

        [StructLayout(LayoutKind.Sequential, CharSet = CharSet.Ansi)]
        private struct SDTFriction { };
        [DllImport("libSDT")]
        private unsafe static extern SDTInteractor* SDTFriction_new();
        [DllImport("libSDT")]
        private unsafe static extern void SDTFriction_free(SDTInteractor* x);
        [DllImport("libSDT")]
        private unsafe static extern void SDTFriction_setNormalForce(SDTInteractor* x, double f);
        [DllImport("libSDT")]
        private unsafe static extern void SDTFriction_setStribeckVelocity(SDTInteractor* x, double f);
        [DllImport("libSDT")]
        private unsafe static extern void SDTFriction_setStaticCoefficient(SDTInteractor* x, double f);
        [DllImport("libSDT")]
        private unsafe static extern void SDTFriction_setDynamicCoefficient(SDTInteractor* x, double f);
        [DllImport("libSDT")]
        private unsafe static extern void SDTFriction_setBreakAway(SDTInteractor* x, double f);
        [DllImport("libSDT")]
        private unsafe static extern void SDTFriction_setStiffness(SDTInteractor* x, double f);
        [DllImport("libSDT")]
        private unsafe static extern void SDTFriction_setDissipation(SDTInteractor* x, double f);
        [DllImport("libSDT")]
        private unsafe static extern void SDTFriction_setViscosity(SDTInteractor* x, double f);
        [DllImport("libSDT")]
        private unsafe static extern void SDTFriction_setNoisiness(SDTInteractor* x, double f);
    }

    public class Bouncing
    {
        private Impact inter;
        private unsafe SDTBouncing* bounce;

        public unsafe Bouncing(double restitution, double height, double irregularity, Impact i)
        {
            if (!i.isAttached())
                throw new NoResonatorsAttachedException("Interactor has no Resonator attached");
            else
            {
                inter = i;
                bounce = SDTBouncing_new();
                SDTBouncing_setRestitution(bounce, restitution);
                SDTBouncing_setHeight(bounce, height);
                SDTBouncing_setIrregularity(bounce, irregularity);
                SDTBouncing_reset(bounce);
                Debug.Log(bounce->restitution);
                Debug.Log(bounce->height);
                Debug.Log(bounce->irregularity);
                Debug.Log("current velocity"+bounce->currentVelocity);
                Debug.Log("target velocity"+bounce->targetVelocity);
            }
        }

        public unsafe void setRestitution(double f)
        {
            SDTBouncing_setRestitution(bounce, f);
        }

        public unsafe void setHeight(double f)
        {
            SDTBouncing_setHeight(bounce, f);
        }

        public unsafe void setIrregularity(double f)
        {
            SDTBouncing_setIrregularity(bounce, f);
        }
        public unsafe void reset()
        {
            SDTBouncing_reset(bounce);
        }
        public unsafe int hasFinished()
        {
            return SDTBouncing_hasFinished(bounce);
        }
        public unsafe double* dsp(double f0, double s0, double f1, double s1)
        {
            double controlOut =  SDTBouncing_dsp(bounce);
            Debug.Log("from dsp controlout:" + controlOut);
            Debug.Log("from dsp target velocity"+bounce->targetVelocity);
            Debug.Log("from dsp current velocity"+bounce->currentVelocity);
            return inter.dsp(f0,-controlOut,s0,f1,0,s1);
            
        }

        [StructLayout(LayoutKind.Sequential, CharSet = CharSet.Ansi)]
        public struct SDTBouncing {
            public double restitution, height, irregularity, targetVelocity, currentVelocity;
        };

        [DllImport("libSDT")]
        private unsafe static extern SDTBouncing* SDTBouncing_new();

        [DllImport("libSDT")]
        private unsafe static extern void SDTBouncing_free(SDTBouncing* x);

        [DllImport("libSDT")]
        private unsafe static extern void SDTBouncing_setRestitution(SDTBouncing* x, double f);

        [DllImport("libSDT")]
        private unsafe static extern void SDTBouncing_setHeight(SDTBouncing* x, double f);

        [DllImport("libSDT")]
        private unsafe static extern void SDTBouncing_setIrregularity(SDTBouncing* x, double f);

        [DllImport("libSDT")]
        private unsafe static extern void SDTBouncing_reset(SDTBouncing* x);

        [DllImport("libSDT")]
        private unsafe static extern double SDTBouncing_dsp(SDTBouncing* x);

        [DllImport("libSDT")]
        private unsafe static extern int SDTBouncing_hasFinished(SDTBouncing* x);

    }
    public class Breaking
    {
        private Interactor inter;
        private Resonator reso1, reso2;
        private unsafe SDTBreaking* brk; 
        public unsafe Breaking(double storedEnergy, double crushingEnergy, double granularity, double fragmentation, Interactor i)
        {
            if (!i.isAttached())            
                throw new NoResonatorsAttachedException("Interactor has no Resonator attached");
            else
            {
                brk = SDTBreaking_new();
                SDTBreaking_setStoredEnergy(brk, storedEnergy);
                SDTBreaking_setCrushingEnergy(brk, crushingEnergy);
                SDTBreaking_setGranularity(brk, granularity);
                SDTBreaking_setFragmentation(brk, fragmentation);
                inter = i;

            }


        }

        public unsafe void setStoredEnergy(double f)
        {
            SDTBreaking_setStoredEnergy(brk, f);
        }

        public unsafe void setCrushingEnergy(double f)
        {
            SDTBreaking_setCrushingEnergy(brk, f);
        }

        public unsafe void setGranularity(double f)
        {
            SDTBreaking_setGranularity(brk, f);
        }

        public unsafe void setFragmentation(double f)
        {
            SDTBreaking_setFragmentation(brk, f);
        }

        public unsafe void reset()
        {
            SDTBreaking_reset(brk);
        }

        public unsafe int hasFinished()
        {
            return SDTBreaking_hasFinished(brk);
        }
        public unsafe double* dsp(double v0, double v1)
        {
            double* controlOut = stackalloc double[2];            
            SDTBreaking_dsp(brk, controlOut);
            double * audioOut = inter.dsp(controlOut[0],v0,1,0,v1,controlOut[1]);
            return audioOut;
        }

        [StructLayout(LayoutKind.Sequential, CharSet = CharSet.Ansi)]
        private struct SDTBreaking { };
        [DllImport("libSDT")]
        private unsafe static extern SDTBreaking* SDTBreaking_new();
        [DllImport("libSDT")]
        private unsafe static extern void SDTBreaking_free(SDTBreaking* x);
        [DllImport("libSDT")]
        private unsafe static extern void SDTBreaking_setStoredEnergy(SDTBreaking* x, double f);
        [DllImport("libSDT")]
        private unsafe static extern void SDTBreaking_setCrushingEnergy(SDTBreaking* x, double f);
        [DllImport("libSDT")]
        private unsafe static extern void SDTBreaking_setGranularity(SDTBreaking* x, double f);
        [DllImport("libSDT")]
        private unsafe static extern void SDTBreaking_setFragmentation(SDTBreaking* x, double f);
        [DllImport("libSDT")]
        private unsafe static extern void SDTBreaking_reset(SDTBreaking* x);
        [DllImport("libSDT")]
        private unsafe static extern int SDTBreaking_hasFinished(SDTBreaking* x);
        [DllImport("libSDT")]
        private unsafe static extern void SDTBreaking_dsp(SDTBreaking* x, double* outs);
    }

    public class Crumpling
    {
        private Interactor inter;
        private unsafe SDTCrumpling* crumple;

        public unsafe Crumpling(Interactor i)
        {
            crumple = SDTCrumpling_new();
            if (!i.isAttached())
                throw new NoResonatorsAttachedException("Interactor has no Resonator attached");
            else
                inter = i;
            
        }
        
        public unsafe void setCrushingEnergy(double f)
        {
            SDTCrumpling_setCrushingEnergy(crumple, f);
        }

        public unsafe void setGranularity(double f)
        {
            SDTCrumpling_setGranularity(crumple, f);
        }

        public unsafe void setFragmentation(double f)
        {
            SDTCrumpling_setFragmentation(crumple, f);
        }
        public unsafe double* dsp(double v0, double v1)
        {
            double* controlOut = stackalloc double[2];
            SDTCrumpling_dsp(crumple, controlOut);
            double* audioOut = inter.dsp(controlOut[0],v0, controlOut[1],controlOut[0], v1, controlOut[1]);
            return audioOut;            
        }
            
        [StructLayout(LayoutKind.Sequential, CharSet = CharSet.Ansi)]
        private struct SDTCrumpling { };
        [DllImport("libSDT")]
        private unsafe static extern SDTCrumpling* SDTCrumpling_new();
        [DllImport("libSDT")]
        private unsafe static extern void SDTCrumpling_free(SDTCrumpling* x);
        [DllImport("libSDT")]
        private unsafe static extern void SDTCrumpling_setCrushingEnergy(SDTCrumpling* x, double f);
        [DllImport("libSDT")]
        private unsafe static extern void SDTCrumpling_setGranularity(SDTCrumpling* x, double f);
        [DllImport("libSDT")]
        private unsafe static extern void SDTCrumpling_setFragmentation(SDTCrumpling* x, double f);
        [DllImport("libSDT")]
        private unsafe static extern void SDTCrumpling_dsp(SDTCrumpling* x, double* outs);



    }
    public class Rolling
    {
        private Interactor inter;
        private unsafe SDTRolling* roll;
        private Surface surface;

        public unsafe Rolling(Interactor i, Surface s)
        {
            if (!i.isAttached())
                throw new NoResonatorsAttachedException("Interactor has no Resonator attached");
            else
            {
                roll = SDTRolling_new();
                surface = s;
                inter = i;
            }
        }

        public unsafe void setGrain(double f)
        {
            SDTRolling_setGrain(roll, f);
        }

        public unsafe void setDepth(double f)
        {
            SDTRolling_setDepth(roll, f);
        }
        public unsafe void setMass(double f)
        {
            SDTRolling_setMass(roll, f);
        }
        public unsafe void setVelocity(double f)
        {
            SDTRolling_setVelocity(roll, f);
        }
        public unsafe double* dsp(double v0, double s0, double v1, double s1)
        {
            double nextsample = surface.nextSample();
            double controlOut  = SDTRolling_dsp(roll, nextsample);
            double *audioOut = inter.dsp(controlOut, v0, s0, controlOut, v1, s1);
            return audioOut;
        }


        [StructLayout(LayoutKind.Sequential, CharSet = CharSet.Ansi)]
        private struct SDTRolling { };
        [DllImport("libSDT")]
        private unsafe static extern SDTRolling* SDTRolling_new();
        [DllImport("libSDT")]
        private unsafe static extern void SDTRolling_free(SDTRolling* x);
        [DllImport("libSDT")]
        private unsafe static extern void SDTRolling_setGrain(SDTRolling* x, double f);
        [DllImport("libSDT")]
        private unsafe static extern void SDTRolling_setDepth(SDTRolling* x, double f);
        [DllImport("libSDT")]
        private unsafe static extern void SDTRolling_setMass(SDTRolling* x, double f);
        [DllImport("libSDT")]
        private unsafe static extern void SDTRolling_setVelocity(SDTRolling* x, double f);
        [DllImport("libSDT")]
        private unsafe static extern double SDTRolling_dsp(SDTRolling* x, double input);
    }
    public class Scraping
    {
        private unsafe SDTScraping* scrape;
        private Resonator resonator;

        public unsafe Scraping(Resonator r)
        {
            scrape = SDTScraping_new();
            resonator = r;
        }

        public unsafe void setGrain(double f)
        {
            SDTScraping_setGrain(scrape, f);
        }

        public unsafe void setForce(double f)
        {
            SDTScraping_setForce(scrape, f);
        }

        public unsafe void setVelocity(double f)
        {
            SDTScraping_setVelocity(scrape, f);
        }

        public unsafe double dsp()
        {
            double nextsample = 0;
            double controlOut = SDTScraping_dsp(scrape, nextsample);
            for (int i=0;i< resonator.getNPickUps();i++)
                resonator.applyForce(i,controlOut);
            //resonator.computeEnergy();
            resonator.dsp();
            return nextsample;

        }

        [StructLayout(LayoutKind.Sequential, CharSet = CharSet.Ansi)]
        private struct SDTScraping { };
        [DllImport("libSDT")]
        private unsafe static extern SDTScraping* SDTScraping_new();
        [DllImport("libSDT")]
        private unsafe static extern void SDTScraping_free(SDTScraping* x);
        [DllImport("libSDT")]
        private unsafe static extern void SDTScraping_setGrain(SDTScraping* x, double f);
        [DllImport("libSDT")]
        private unsafe static extern void SDTScraping_setForce(SDTScraping* x, double f);
        [DllImport("libSDT")]
        private unsafe static extern void SDTScraping_setVelocity(SDTScraping* x, double f);
        [DllImport("libSDT")]
        private unsafe static extern double SDTScraping_dsp(SDTScraping* x, double input);

    }
    public abstract class Surface
    {
        //TODO: altre funzioni di riempimento per la tabella
        //      funzioni periodiche...
        internal double[] table = new double[1024];
        //internal double sampleRate;
        internal int index;

        public abstract double nextSample();
    }
    public class WhiteNoise : Surface
    {
        System.Random r = new System.Random();

        public WhiteNoise(double scale)
        {
            if (scale > 0.2 || scale <= 0)
                throw new Exception("Invalid value for scale");
            else
            {
                for(int i = 0; i < 1024; i++)
                {
                    table[i]= r.NextDouble()*scale;
                    index = 0;

                }
            }
        }
        public override double nextSample()
        {
            double currentsample = table[index];
            index = (index+1)%1024;
            return currentsample;
        }
    }
    public class NoResonatorsAttachedException : Exception
    {
        public NoResonatorsAttachedException(string message) : base(message) { }
    }
}





