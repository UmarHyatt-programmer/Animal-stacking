﻿using UnityEngine.Audio;
using UnityEngine;

public class Sonud
{
 public  string  name ;
 public  AudioClip clip ;
 [Range(0f,1f)]

 public  float volume ;
 [Range(0.1f,3f)]

 public  float  pitch ;
 [Range(0f,1f)]
 public  float  virtual3D;
}
