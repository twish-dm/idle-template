using UnityEngine;
using Engine;
using Engine.Model;
using Engine.Views;
using System;

public class Test : MonoBehaviour
{
		public class Test2
		{

		}
		// Start is called before the first frame update
		void Start()
		{
				GameObject test = DataSources.GetSource<GameObject>("CheckGA1");
				Debug.Log(test);

				Debug.Log(DataSources.GetSourceList<Material>().Count);

				Debug.Log(DataSources.GetSourceList<Material>("Check2").Count);

				new Test2().AddData("Proof");

				Debug.Log(DataSources.GetSource<Test2>("Proof"));


			

				WebRequest.LoadURL($"{Application.streamingAssetsPath}/game_model.json", (string data) =>
				{
						ModelBase.Deserialize<GameModel>(data).AddData("game_model");
						Debug.Log($"Loaded ['{data}']");
						Debug.Log(DataSources.GetSource<GameModel>("game_model").Serialize());
						gameModel = DataSources.GetSource<GameModel>("game_model");

						Debug.Log(gameModel.PlayerEntity.SoftMoney.Count);
				});


				DataSources.GetSource<ViewManager>("view_manager").Push("Tesst");

				this.Subscribe(Engine.EventType.OnChange, OnStartTest);
		}

		private void OnStartTest(Test arg0)
		{
				Debug.Log(arg0.name);
		}

		private void Update()
		{
				
				if(Input.GetMouseButtonDown(0))
				{
						DataSources.GetSource<ViewManager>("view_manager").Pop();
				}
				if (Input.GetMouseButtonDown(1))
				{
						DataSources.GetSource<ViewManager>("view_manager").Push("Tesst1", false);
				}
				if (Input.GetMouseButtonDown(2))
				{
						DataSources.GetSource<ViewManager>("view_manager").Push("Tesst", false);
				}
				if(Input.GetKeyDown(KeyCode.Space))
				{
						DataSources.GetSource<ViewManager>("view_manager").CurrentView.IsOverlay = !DataSources.GetSource<ViewManager>("view_manager").CurrentView.IsOverlay;
				}
				if (Input.GetKeyDown(KeyCode.Backspace))
				{
						this.InvokeEvent(Engine.EventType.OnChange);
				}
				if (Input.GetKeyDown(KeyCode.W))
				{
						this.Unsubscribe(Engine.EventType.OnChange, OnStartTest);
				}
		}
		public GameModel gameModel;

		private void OnValidate()
		{
				//Debug.Log(gameModel.Serialize());
		}

}
