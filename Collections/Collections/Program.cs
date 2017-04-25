using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;

namespace Collections
{
	internal class Program
	{

		private const int collectionLength = 10000000;

		private static void Main(string[] args)
		{
			var random = new Random();

			var arrayList = new ArrayList(); 

			var linkedList = new LinkedList<int>();

			var stackList = new Stack<int>();

			var queueList = new Queue<int>();

			var hashList = new Hashtable();

			var dictionaryList = new Dictionary<int, int>();
			
			var sw = new Stopwatch(); //экземпляр секундомера

			sw.Start();

			PopulateArrayList(arrayList, random);

			sw.Stop();

			Console.WriteLine("Populate Time for ArrayList = " + sw.Elapsed);

			sw.Restart();

			PopulateLinkedList(linkedList, random);

			sw.Stop();

			Console.WriteLine("Populate Time for LinkedList = " + sw.Elapsed);

			sw.Restart();

			PopulateStackList(stackList, random);

			sw.Stop();

			Console.WriteLine("Populate Time for StackList = " + sw.Elapsed);

			sw.Restart();

			PopulateQueueList(queueList, random);

			sw.Stop();

			Console.WriteLine("Populate Time for QueueList = " + sw.Elapsed);

			sw.Restart();

			PopulateHashTable(hashList, random);

			sw.Stop();

			Console.WriteLine("Populate Time for HashList = " + sw.Elapsed);

			sw.Restart();

			PopulateDictionary(dictionaryList, random);

			sw.Stop();

			Console.WriteLine("Populate Time for Dictionary = " + sw.Elapsed);

			sw.Restart();

			arrayList.Add(random.Next(collectionLength));

			sw.Stop();

			Console.WriteLine("Add Time for ArrayList = " + sw.Elapsed);

			sw.Restart();

			arrayList.Insert(random.Next(collectionLength), random.Next(collectionLength));

			sw.Stop();

			Console.WriteLine("Add Middle Time ArrayList = " + sw.Elapsed);

			sw.Restart();

			linkedList.AddLast(random.Next(collectionLength));

			sw.Stop();

			Console.WriteLine("Add Time for LinkedList = " + sw.Elapsed);

			sw.Restart();

			stackList.Push(random.Next(collectionLength));

			sw.Stop();

			Console.WriteLine("Add Time for StackList = " + sw.Elapsed);
			
			sw.Restart();

			queueList.Enqueue(random.Next(collectionLength));

			sw.Stop();

			Console.WriteLine("Add Time for QueueList = " + sw.Elapsed);
			
			sw.Restart();

			hashList.Add(collectionLength + 1,random.Next(collectionLength));

			sw.Stop();

			Console.WriteLine("Add Time for HashList = " + sw.Elapsed);

			sw.Restart();

			dictionaryList.Add(collectionLength + 1, random.Next(collectionLength));

			sw.Stop();

			Console.WriteLine("Add Time for DictionaryList = " + sw.Elapsed);

			sw.Restart();
			
			var searchItem = random.Next(collectionLength);

			sw.Restart();

			var searchedIndex = arrayList.IndexOf(searchItem);

			sw.Stop();

			if (searchedIndex >= 0)
			{
				Console.WriteLine("Element Arraylist " + searchItem + " found with index " + searchedIndex);
			}
			else
			{
				Console.WriteLine("Element ArrayList " + searchItem + " not found");
			}

			Console.WriteLine("Search Time for ArrayList = " + sw.Elapsed);


			var searchItemList = random.Next(collectionLength);
			sw.Restart();
			
			var searchItemFound = linkedList.Contains(searchItemList);

			sw.Stop();
			
			if (searchItemFound)
			{
				Console.WriteLine("Element from LinkedList " + searchItemList + " found");
				var node = linkedList.Find(searchItemList);
				sw.Restart();
				linkedList.AddAfter(node, random.Next(collectionLength));
				sw.Stop();
				Console.WriteLine("Add Middle Time LinkedList = " + sw.Elapsed);
				
			}

			else
			{
				Console.WriteLine("Element LinkedList " + searchItemList + " not found");

			}

			Console.WriteLine("Search Time for LinkedList = " + sw.Elapsed);

			var searchItemStack = random.Next(collectionLength);

			sw.Restart();

			var searchStack = stackList.Contains(searchItemStack);

			sw.Stop();

			if (searchStack)
			{
				Console.WriteLine("Element from StackList " + searchItemStack + " found");
				Console.WriteLine("Search Time for StackList = " + sw.Elapsed);
				
			}

			else
			{
				Console.WriteLine("Element StackList " + searchItemStack + " not found");

			}

			var searchItemQueue = random.Next(collectionLength);

			sw.Restart();

			var searchQueue = queueList.Contains(searchItemQueue);

			sw.Stop();

			if (searchQueue)
			{
				Console.WriteLine("Element from QueueList " + searchItemQueue + " found");
				Console.WriteLine("Search Time for QueueList = " + sw.Elapsed);

			}

			else
			{
				Console.WriteLine("Element QueueList " + searchItemQueue + " not found");

			}

			sw.Restart();

			var hashSearchKey = hashList.ContainsKey(random.Next(collectionLength+1));

			sw.Stop();

			if (hashSearchKey)
			{
				Console.WriteLine("Key from HashList found");
				Console.WriteLine("Search Time for HashListKey = " + sw.Elapsed);

			}

			else
			{
				Console.WriteLine("Key from HashList not found");

			}

			sw.Restart();

			var hashSearchValue = hashList.ContainsValue(random.Next(collectionLength));

			sw.Stop();

			if (hashSearchValue)
			{
				Console.WriteLine("Value from HashList found");
				Console.WriteLine("Search Time for HashListValue = " + sw.Elapsed);

			}

			else
			{
				Console.WriteLine("Value from HashList not found");

			}

			sw.Restart();

			var dictionarySearchKey = dictionaryList.ContainsKey(random.Next(collectionLength+1));

			sw.Stop();

			if (dictionarySearchKey)
			{
				Console.WriteLine("Key from DictionaryList found");
				Console.WriteLine("Search Time for DictionaryKey = " + sw.Elapsed);

			}

			else
			{
				Console.WriteLine("Key from DictionaryList not found");

			}

			sw.Restart();

			var dictionarySearchValue = dictionaryList.ContainsValue(random.Next(collectionLength));

			sw.Stop();

			if (dictionarySearchValue)
			{
				Console.WriteLine("Value from DictionaryList found");
				Console.WriteLine("Search Time for DictionaryValue = " + sw.Elapsed);

			}

			else
			{
				Console.WriteLine("Value from DictionaryList not found");

			}

			sw.Restart();

			arrayList.RemoveAt(random.Next(collectionLength));

			sw.Stop();

			Console.WriteLine("Delete Time for ArrayList " + sw.Elapsed);

			sw.Restart();

			linkedList.Remove(random.Next(collectionLength));

			sw.Stop();

			Console.WriteLine("Delete Time for LinkedList " + sw.Elapsed);

			sw.Restart();

			var deleteStackItem = stackList.Pop();

			sw.Stop();

			Console.WriteLine("Delete Time for StackList " + sw.Elapsed);

			sw.Restart();

			var dequeueItem = queueList.Dequeue();
			
			sw.Stop();

			Console.WriteLine("Delete Time for QueueList " + sw.Elapsed);
			
			sw.Restart();

			hashList.Remove(random.Next(collectionLength+1));

			sw.Stop();

			Console.WriteLine("Delete Time for HashList " + sw.Elapsed);

			sw.Restart();

			dictionaryList.Remove(random.Next(collectionLength+1));

			sw.Stop();

			Console.WriteLine("Delete Time for DictionaryList " + sw.Elapsed);


			Console.ReadLine();

		}

		private static void PopulateArrayList(ArrayList collection, Random random)
		{
			var count = collectionLength;

			while (count > 0)
			{
				collection.Add(random.Next(collectionLength));
				count--;
			}

		}

		private static void PopulateLinkedList(LinkedList<int> collection, Random random)
		{
			var count = collectionLength;

			while (count > 0)
			{
				collection.AddLast(random.Next(collectionLength));
				count--;
			}
		}

		private static void PopulateStackList(Stack<int> stack, Random random)
		{
			var count = collectionLength;
			while (count > 0)
			{
				stack.Push(random.Next(collectionLength));
				count--;
			}

		}

		private static void PopulateQueueList(Queue<int> queque, Random random)
		{
			var count = collectionLength;
			while (count > 0)
			{
				queque.Enqueue(random.Next(collectionLength));
				count--;
			}

		}

		private static void PopulateHashTable(Hashtable table, Random random)
		{

			for (int i = 0; i <= collectionLength; i++)
			{
				table.Add(i++, random.Next(collectionLength));//создаем ключи и присваиваем рандомное значение
			}
			
			
		}

		private static void PopulateDictionary(Dictionary<int, int> dictionary, Random random)
		{
			for (int i = 0; i <= collectionLength; i++)
			{
				dictionary.Add(i++, random.Next(collectionLength));//создае ключи и рандом значение
			}
		}


	}
}