﻿using FluentCassandra.Types;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.ComponentModel;
using System.Text;
using System.Linq;

namespace FluentCassandra.Test
{
	[TestClass]
	public class LongTypeTest
	{
		public TestContext TestContext { get; set; }

		#region Additional test attributes
		// 
		//You can use the following additional attributes as you write your tests:
		//
		//Use ClassInitialize to run code before running the first test in the class
		//[ClassInitialize()]
		//public static void MyClassInitialize(TestContext testContext)
		//{
		//}
		//
		//Use ClassCleanup to run code after all tests in a class have run
		//[ClassCleanup()]
		//public static void MyClassCleanup()
		//{
		//}
		//
		//Use TestInitialize to run code before running each test
		//[TestInitialize()]
		//public void MyTestInitialize()
		//{
		//}
		//
		//Use TestCleanup to run code after each test has run
		//[TestCleanup()]
		//public void MyTestCleanup()
		//{
		//}
		//
		#endregion

		[TestMethod]
		public void CassandraType_Cast_Int64()
		{
			// arranage
			long expected = 300L;
			LongType type = expected;

			// act
			CassandraType actual = type;

			// assert
			Assert.AreEqual(expected, (long)actual);
		}

		[TestMethod]
		public void Implicit_Cast_From_Int64()
		{
			// arrange
			long expected = 300L;

			// act
			LongType actual = expected;

			// assert
			Assert.AreEqual(expected, (long)actual);
		}

		[TestMethod]
		public void Implicit_Cast_To_Int64()
		{
			// arrange
			long expected = 300L;
			LongType type = expected;

			// act
			long actual = type;

			// assert
			Assert.AreEqual(expected, actual);
		}

		[TestMethod]
		public void Implicit_Cast_From_Int32()
		{
			// arrange
			int value = 300;
			long expected = 300L;

			// act
			LongType actual = value;

			// assert
			Assert.AreEqual(expected, (long)actual);
		}

		[TestMethod]
		public void Implicit_Cast_From_ByteArray()
		{
			// arrange
			long expected = 300L;
			byte[] value = BitConverter.GetBytes(expected);
			Array.Reverse(value); // put them to Java byte format

			// act
			LongType actual = new LongType();
			actual.SetValue(value);

			// assert
			Assert.AreEqual(expected, (long)actual);
		}

		[TestMethod]
		public void Implicity_Cast_To_ByteArray()
		{
			// arrange
			long value = 300L;
			byte[] expected = BitConverter.GetBytes(value);
			Array.Reverse(expected); // put them to Java byte format
			LongType type = value;

			// act
			byte[] actual = type;

			// assert
			Assert.IsTrue(actual.SequenceEqual(expected));
		}

		[TestMethod]
		public void Operator_EqualTo()
		{
			// arrange
			long value = 300L;
			LongType type = value;

			// act
			bool actual = type == value;

			// assert
			Assert.IsTrue(actual);
		}

		[TestMethod]
		public void Operator_NotEqualTo()
		{
			// arrange
			long value = 300L;
			LongType type = value;

			// act
			bool actual = type != value;

			// assert
			Assert.IsFalse(actual);
		}
	}
}