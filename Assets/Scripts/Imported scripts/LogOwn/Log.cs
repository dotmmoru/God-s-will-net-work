using UnityEngine;
using System.Collections;
using System;

public class Log
{
		public static bool CONSOLE_OUTPUT = true;

		public static string SOCIAL = "social";

		public static string IAP = "aip";

		public static string SYSTEM = "system";

		public static string ANALYTICS = "analytics";

		public static string AD = "ad";

		public static string LANGUAGE = "language";
		public static string FONT = "font";

		public static string USER_DATA = "user data";

		public static string SCENES = "scenes";
		public static string EVENT = "event";

		public static string CREATE_OBJECT = "create object";

		public static string PROGRESS = "progress";

		public static string LEVEL = "level";


		public static string CAMERA = "camera";

		public static string CHAPTER_CONSTRUCTOR = "chapter";

		public static void debug (MonoBehaviour source, string category, string message, params object[] parameters)
		{
		
				if (CONSOLE_OUTPUT) {
						Debug.Log (source + " " + category + " " + string.Format (message, parameters));
				}

		}

		public static void warn (MonoBehaviour source, string category, string message, params object[] parameters)
		{
		
				if (CONSOLE_OUTPUT) {
						Debug.LogWarning (source + " " + category + " " + string.Format (message, parameters));
				}

		}

		public static void error (MonoBehaviour source, string category, string message, params object[] parameters)
		{
		
				if (CONSOLE_OUTPUT) {
						Debug.LogError (source + " " + category + " " + string.Format (message, parameters));
				}

		}

		public static void fatal (MonoBehaviour source, string category, string message, params object[] parameters)
		{
		
				if (CONSOLE_OUTPUT) {
						Debug.LogError (source + " " + category + " " + string.Format (message, parameters));
				}

		}

		public static void info (MonoBehaviour source, string category, string message, params object[] parameters)
		{
		
				if (CONSOLE_OUTPUT) {
						Debug.Log (category + " " + string.Format (message, parameters));
				}

		}

		public static void debug (string category, string message, params object[] parameters)
		{
		
				if (CONSOLE_OUTPUT) {
						Debug.Log (category + " " + string.Format (message, parameters));
				}
		}

		public static void warn (string category, string message, params object[] parameters)
		{
		
				if (CONSOLE_OUTPUT) {
						Debug.LogWarning (category + " " + string.Format (message, parameters));
				}
		}


		public static void warn (string message, params object[] parameters)
		{
		
				warn ("test", message, parameters);
		}

		public static void error (string message, params object[] parameters)
		{
		
				error ("test", message, parameters);
		}

		public static void error (string category, string message, params object[] parameters)
		{
		
				if (CONSOLE_OUTPUT) {
						Debug.LogError (category + " " + string.Format (message, parameters));
				}
		}

		public static void fatal (string category, string message, params object[] parameters)
		{
		
				if (CONSOLE_OUTPUT) {
						Debug.LogError (category + " " + string.Format (message, parameters));
				}
		}

		public static void info (string category, string message, params object[] parameters)
		{
		
				if (CONSOLE_OUTPUT) {
						Debug.Log (category + " " + string.Format (message, parameters));
				}
		}

		//	private static void printInConsole(String type, String message) {
		//		Debug.Log ();
		//	}
}
