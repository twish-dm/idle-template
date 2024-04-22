using UnityEngine;
using System;

namespace Engine
{
		[System.Serializable]
		public class AudioClipDataSource : DataSource
		{
				[SerializeField] private AudioClip m_AudioClip;
				override public object Data { get => m_AudioClip; }
				override public AudioClip GetSource<AudioClip>()
				{
						if (typeof(AudioClip).Equals(typeof(UnityEngine.AudioClip)))
								return (AudioClip)Data;
						throw new NullReferenceException($"Missing material of '{typeof(AudioClip).ToString()}'");
				}

		}

}