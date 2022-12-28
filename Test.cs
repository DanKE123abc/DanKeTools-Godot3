using Godot;
using System;
using DanKeTools;

namespace Test
{

	public class Test : Singleton<Test>
	{ 
		public void Hello()
		{
			GD.Print("Hello");
		}

	}


}
