using System;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using GenericApp;

namespace GenericApp.Test 
{
	

	[TestClass]
	public class UnitTest1 
	{
		[TestMethod]
		public void TestMethod1() 
		{
			Store store = new Store();
			store.CreateObject<List<string>>();
			List<int> ints = store.CreateObject<List<int>>();
			store.CreateObject<double>();

			ints.Add(0);
			ints.Add(101);
			ints.Add(14);

			var theSameListEnum = store.GetAllObjectsOfType<List<int>>().GetEnumerator();
			theSameListEnum.MoveNext();
			

			Assert.AreEqual(theSameListEnum.Current.Value[1], 101);
			Assert.AreEqual(store.GetObjectByGUID<List<int>>(theSameListEnum.Current.Key)[2], ints[2]);
			Assert.AreEqual(store.GetObjectByGUID<Dictionary<long, int>>(Guid.NewGuid()), null);
		}
	}
}
