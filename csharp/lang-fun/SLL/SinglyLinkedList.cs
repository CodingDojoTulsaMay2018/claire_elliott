using System;
using System.Collections.Generic;
namespace SLL
{
    class SinglyLinkedList
    {
        public SllNode head;
        public SinglyLinkedList() 
        {
            head = null;
        }
        // SLL methods go here. As a starter, we will show you how to add a node to the list.
        public SinglyLinkedList add(int value) 
        {
            SllNode newNode = new SllNode(value);
            if(head == null) 
            {
                head = newNode;
                return this;
            } 
            else
            {
                SllNode runner = head;
                while(runner.next != null) 
                {
                    runner = runner.next;
                }
                runner.next = newNode;
                return this;
            }
        }
        public SinglyLinkedList remove()
        {
            if(head.next == null)
            {
                head = null;
                return this;
            }
            if(head != null)
            {
                SllNode runner = head;
                while(runner.next.next != null)
                {
                    runner = runner.next;
                }
                runner.next = null;
                return this;
            }
            return null;
        }
        public void printValues()
        {
            if(head == null)
            {
                Console.WriteLine("No values");
            }
            else
            {
                List<int> nodeValues = new List<int>();
                SllNode runner = head;
                while(runner != null)
                {
                    nodeValues.Add(runner.value);
                    runner = runner.next;
                }
                Console.WriteLine(string.Join(", ", nodeValues));
            }
        }
        public void removeAt(int nthNode) 
        {
            if(head != null)
            {
                int count = 0;
                SllNode runner = head;
                while(runner != null)
                {
                    if(count == nthNode-1)
                    {
                        runner.next = runner.next.next;
                    }
                    else
                    {
                        runner = runner.next;
                        count++;
                    }
                }
            }
        }
        public SllNode find(int Ivalue)
        {
            if(head != null)
            {
                SllNode runner = head;
                while(runner != null)
                {
                    if(runner.value == Ivalue)
                    {
                        return runner;
                    }
                    else
                    {
                        runner = runner.next;
                    }
                }
            }
            return null;
        }
    }
}