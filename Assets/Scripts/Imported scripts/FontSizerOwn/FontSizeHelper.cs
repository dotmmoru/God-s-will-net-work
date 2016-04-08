using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using System;

public class FontSizeHelper : MonoBehaviour
{

		public static float square;
		public bool needRecalculate;
		EventManager.EventWrapper listenerScreenSize;

		void OnEnable ()
		{
		
				UpdateSize ();

				listenerScreenSize = new EventManager.EventWrapper (delegate {
						needRecalculate = true;
						UpdateSize ();
				});

				EventManager.instance.Listen (EventManager.SYSTEM_ON_WINDOW_RESIZED, listenerScreenSize);
		}

		public void OnDisable ()
		{

				EventManager.instance.DestroyListener (EventManager.SYSTEM_ON_WINDOW_RESIZED, listenerScreenSize);
		}

		public FontSize size;

		public void UpdateSize ()
		{
//				if (needRecalculate) {
				Text text = GetComponent<Text> ();
				text.fontSize = calculateSize ();

				needRecalculate = false;
//				}
			/*	GameController gameController = GameController.GetInstance ();
				if (gameController != null) {
						Font font = gameController.GetTextFont ();
						if (font != null) {
								text.font = font;
						}
			
				}
		*/

		}

		public void SetFontSize (FontSize newFontSize)
		{
				size = newFontSize;
				needRecalculate = true;
				UpdateSize ();
		}
	
		// Use this for initialization
		void Start ()
		{
				UpdateSize ();
	
		}
	
		// Update is called once per frame
		void Update ()
		{
	
		}

		int calculateSize ()
		{
//				if (square <= 0) {
						Camera mainCamera = Camera.main;

						int width = (int)mainCamera.pixelWidth;
						int height = (int)mainCamera.pixelHeight;

						square = width * height;
//					Log.warn (Log.FONT, " {0}x{1} = {2}",width, height, square);
//				}

				float ratio = calculatetRatio ();
				int fontSize = (int)Math.Sqrt (square * ratio);
		//				Log.debug (Log.FONT, "calculate font size {0} for {1} ratio = {2}, {3}x{4} = {5}", fontSize, size, ratio, width, height, square);
				
				return fontSize;
		}

		float calculatetRatio ()
		{
				float ratio = 1f;
				switch (size) {
				case FontSize.TEXT:
						ratio = 0.0009f;
						break;
				case FontSize.TEXT_SMALL:
						ratio = 0.00045f;
						break;
				case FontSize.TEXT_SMALL_MIDDLE:
						ratio = 0.0007f;
						break;
				case FontSize.BUTTON:
						ratio = 0.0009f;
						break;
				case FontSize.TITLE:
						ratio = 0.0012f;
						break;
				case FontSize.TEXT_DIALOG:
						ratio = 0.0012f;
						break;
				case FontSize.RECORD:
						ratio = 0.0016f;
						break;
		
				default:
						break;
				}

				return ratio;
		}

}
