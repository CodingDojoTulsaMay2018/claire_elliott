using System;

namespace SLL
{
    class Program
    {
        static void Main(string[] args)
        {
            SinglyLinkedList newList = new SinglyLinkedList();
            newList.add(2).add(3).add(5).add(20);
            newList.printValues();
            newList.printValues();
            SllNode node = newList.find(5);
            Console.WriteLine(node.value);
        }
    }
}
