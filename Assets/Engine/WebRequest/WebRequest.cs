using System.Collections;
using System.Collections.Generic;

using UnityEngine;
using UnityEngine.Events;
using UnityEngine.Networking;

public class WebRequest:MonoBehaviour
{
		static private WebRequest m_GameObject;
		
		protected static void  Initializie()
		{
				if (m_GameObject) return;
				m_GameObject = new GameObject("WebRequest").AddComponent<WebRequest>();
				GameObject.DontDestroyOnLoad(m_GameObject);
		}
		static public void LoadURL(string uri, UnityAction<string> onComplete)
		{
				if (m_GameObject == null) Initializie();
				m_GameObject.Load(uri, onComplete);
		}
		public void Load(string uri, UnityAction<string> onComplete)
		{
				

				StartCoroutine(GetRequest(uri));
				IEnumerator GetRequest(string uri)
				{
						using (UnityWebRequest webRequest = UnityWebRequest.Get(uri))
						{
								// Request and wait for the desired page.
								yield return webRequest.SendWebRequest();

								string[] pages = uri.Split('/');
								int page = pages.Length - 1;

								switch (webRequest.result)
								{
										case UnityWebRequest.Result.ConnectionError:
										case UnityWebRequest.Result.DataProcessingError:
												Debug.LogError(pages[page] + ": Error: " + webRequest.error);
												break;
										case UnityWebRequest.Result.ProtocolError:
												Debug.LogError(pages[page] + ": HTTP Error: " + webRequest.error);
												break;
										case UnityWebRequest.Result.Success:
												Debug.Log(pages[page] + ":\nReceived: " + webRequest.downloadHandler.text);
												onComplete?.Invoke(webRequest.downloadHandler.text);
												break;
								}
						}
				}
		}
}
