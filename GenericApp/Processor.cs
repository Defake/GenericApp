using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

// Processor.CreateEngine<MyEngine>().For<MyEntity>().With<MyLogger>();

namespace GenericApp 
{
	public class Processor<TEngine, TEntity, TLogger>
	{
	}

	public class Processor
	{
		public static ProcessorWithEngine<TEngine> CreateEngine<TEngine>()
		{
			return new ProcessorWithEngine<TEngine>();
		}
		
	}

	public class ProcessorWithEngine<TEngine>
	{
		public ProcessorWithEngineAndEntity<TEngine, TEntity> For<TEntity>()
		{
			return new ProcessorWithEngineAndEntity<TEngine, TEntity>();
		} 
	}

	public class ProcessorWithEngineAndEntity<TEngine, TEntity>
	{
		public Processor<TEngine, TEntity, TLogger> With<TLogger>()
		{
			return new Processor<TEngine, TEntity, TLogger>();
		} 
	}
}
