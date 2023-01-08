using System;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

namespace ActionCode.Characters
{
	/// <summary>
	/// Particle System dictionary data.
	/// <para>Play <see cref="ParticleSystem"/> using theirs names or a random one.</para>
	/// </summary>
	[Serializable]
    public sealed class ParticleSystemDictionary
    {
	    [SerializeField, Tooltip("The Particle Systems. You can play them using theirs names.")]
	    private ParticleSystem[] particleSystems;
	    
	    private Dictionary<string, ParticleSystem> dictionary;
	    
	    /// <summary>
	    /// Initializes the dictionary.
	    /// </summary>
	    public void Initialize()
	    {
		    dictionary = new Dictionary<string, ParticleSystem>(particleSystems.Length);
		    foreach (ParticleSystem particleSystem in particleSystems)
		    {
			    dictionary.Add(particleSystem.name, particleSystem);
		    }
	    }
	    
	    /// <summary>
	    /// Plays a random particle system.
	    /// </summary>
	    /// <returns>A random <see cref="ParticleSystem"/> instance.</returns>
	    public void PlayRandom()
	    {
		    int randomIndex = Random.Range(0, particleSystems.Length);
		    Play(randomIndex);
	    }
	    
	    /// <summary>
	    /// Plays a particle system using the given index.
	    /// </summary>
	    /// <param name="index">The index of the particle system. No checking is done.</param>
	    public void Play(int index) => particleSystems[index].Play();
	    
	    /// <summary>
	    /// Plays a particle system using the given name.
	    /// </summary>
	    /// <param name="name">The name of the particle system. No checking is done.</param>
	    public void Play(string name) => dictionary[name].Play();

	    /// <summary>
	    /// Tries to play a particle system using the given name.
	    /// </summary>
	    /// <param name="name">The name of particle system.</param>
	    /// <param name="particleSystem">The Particle System instance found.</param>
	    /// <returns>Whether the given particle system was found.</returns>
	    public bool TryPlay (string name, out ParticleSystem particleSystem)
	    {
		    var hasPS = dictionary.TryGetValue(name, out particleSystem);
		    if (hasPS) particleSystem.Play();
		    return hasPS;
	    }
    }
}