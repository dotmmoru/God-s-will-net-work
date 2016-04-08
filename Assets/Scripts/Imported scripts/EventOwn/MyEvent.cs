using UnityEngine;
using System.Collections;

public class MyEvent
{
	public string type;
	public object parameter;

	public MyEvent (string type, object parameter)
	{
		this.type = type;
		this.parameter = parameter;
	}

	public MyEvent (string type)
	{
		this.type = type;
	}
	



}
