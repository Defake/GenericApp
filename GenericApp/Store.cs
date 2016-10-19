using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices.ComTypes;

namespace GenericApp
{

	/// <summary>
	/// В вашем проекте необходимо хранить GUID для объектов различных типов. 
	/// Создайте класс с тремя дженерик-методами
	/// </summary>
	public class Store
	{

		private readonly Dictionary<Type, IDictionary> _objectsContainer;

		public Store()
		{
			_objectsContainer = new Dictionary<Type, IDictionary>();
		}

		/// <summary>
		/// Первый метод создает объект переданного типа (предполагается, что этот тип имеет конструктор по умолчанию), 
		/// создает для этого объекта Guid, сохраняет соответствие между объектом и Guid в базе и возвращает объект.
		/// </summary>
		/// <typeparam name="T"></typeparam>
		/// <returns></returns>
		public T CreateObject<T>() where T : new()
		{
			if (!_objectsContainer.ContainsKey(typeof (T)))
				_objectsContainer[typeof (T)] = new Dictionary<Guid, T>();

			return (T) (_objectsContainer[typeof(T)][Guid.NewGuid()] = new T());
		}

		/// <summary>
		/// Второй метод умеет быстро выводить пары вида (Guid, объект) для каждого типа объектов.
		/// </summary>
		/// <typeparam name="T"></typeparam>
		/// <returns></returns>
		public IEnumerable<KeyValuePair<Guid, T>> GetAllObjectsOfType<T>()
		{
			if (!_objectsContainer.ContainsKey(typeof (T)))
				return new KeyValuePair<Guid, T>[0];

			return ((Dictionary<Guid, T>)_objectsContainer[typeof(T)]).AsEnumerable();
		}

		/// <summary>
		/// Третий метод умеет быстро выводить по переданному Guid объект переданного типа, 
		/// либо null, если такой объект отсутствует.
		/// </summary>
		/// <typeparam name="T"></typeparam>
		/// <param name="guid"></param>
		/// <returns></returns>
		public T GetObjectByGUID<T>(Guid guid)
		{
			return (_objectsContainer.ContainsKey(typeof(T)) && 
					((Dictionary<Guid, T>)_objectsContainer[typeof(T)]).ContainsKey(guid))? 
					(T)_objectsContainer[typeof(T)][guid] :
					default(T);
		}

	}
}