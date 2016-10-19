using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GenericApp 
{
	class Program 
	{
		static void Main(string[] args) 
		{
			Processor.CreateEngine<int>().For<string>().With<Double>();
		}
	}
}